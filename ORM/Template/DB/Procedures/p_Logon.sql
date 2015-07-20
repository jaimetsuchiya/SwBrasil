USE SW
GO


IF (OBJECT_ID('p_Logon', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_Logon --@EstoqueOK=0
END
GO

/*
BEGIN TRAN

	DECLARE  @codigoRetorno		int
			,@descricaoRetorno	varchar(MAX)
			,@nome				varchar(50)
			,@token				varchar(50)
			,@expiracao			datetime

	exec dbo.p_Logon
		 @logon				= 'u3364'
		,@senha				= '7110EDA4D09E062AA5E4A390B0A572AC0D2C0220'
		,@deviceUID			= '192.168.2.122'
		,@plataforma		= 'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36'
		,@nome				= @nome				output
		,@token				= @token			output
		,@expiracao			= @expiracao		output
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output


	--exec dbo.p_Logon
	--	 @logon				= 'u3364'
	--	,@tipoLogon			= 'OPENK'
	--	,@deviceUID			= '192.168.2.122'
	--	,@plataforma		= 'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36'
	--	,@nome				= @nome				output
	--	,@token				= @token			output
	--	,@expiracao			= @expiracao		output
	--	,@abrirTransacao	= 'N'
	--	,@codigoRetorno		= @codigoRetorno	output
	--	,@descricaoRetorno	= @descricaoRetorno	output

	SELECT @codigoRetorno, @descricaoRetorno, @nome, @token, @expiracao
	
ROLLBACK TRAN
*/
CREATE PROC dbo.p_Logon
(
	 @logon				varchar(50)
	,@senha				varchar(255)= null
	,@deviceUID			varchar(255)
	,@plataforma		varchar(255)
	,@tipoLogon			varchar(20)	= 'INHOUSE'
	,@nome				varchar(50)	= null	output
	,@email				varchar(128)= null	output
	,@token				varchar(50) = null	output
	,@expiracao			datetime	= null	output
	,@abrirTransacao	char(1)		= 'S'
	,@debug				char(1)		= 'N'
	,@codigoRetorno		int			= null	output
	,@descricaoRetorno	varchar(MAX)= null	output
) AS
BEGIN

	DECLARE  @TransacaoAberta		char(1)
			,@LOG					varchar(MAX)
			,@DeviceID				int
			,@UID					uniqueidentifier
			,@ID_Usuario			int
			,@qtdeErros				int
			,@ultimoErro			datetime
			,@senhaCadastrada		varchar(255)
			,@codigoSituacaoBloq	int
			,@codigoSituacaoOK		int
			,@codigoSituacaoUsuario	int
	DECLARE	 @tblPerfis				TABLE (Sigla varchar(50), ID int null )

	SELECT	 @CodigoRetorno		= 0
			,@DescricaoRetorno	= ''

	BEGIN TRY

			IF @abrirTransacao = 'S'
			BEGIN
				BEGIN TRANSACTION
				SET @TransacaoAberta = 'S'
			END

			SELECT @codigoSituacaoBloq	= dbo.fn_Situacao('BLOQUEADO', 'USUARIO')
			SELECT @codigoSituacaoOK	= dbo.fn_Situacao('ATIVO', 'USUARIO')

			SELECT @ID_Usuario = ID, @qtdeErros = qtdeErros, @ultimoErro = ultimoErro, @senhaCadastrada = senha, @nome = nome, @codigoSituacaoUsuario = codigoSituacao, @email=email  FROM tb_Usuario (nolock) WHERE logon = @logon
			IF @ID_Usuario IS NULL
			BEGIN
				SELECT	 @CodigoRetorno		= -1
						,@DescricaoRetorno	= 'Usuário não cadastrado'

				GOTO FIM
			END

			IF UPPER(@tipoLogon) = 'INHOUSE'
			BEGIN

					IF @codigoSituacaoUsuario != @codigoSituacaoOK
					BEGIN
						SELECT	 @CodigoRetorno		= -3
								,@DescricaoRetorno	= 'Usuário bloqueado ou inativo, favor contactar o administrador!'

						GOTO FIM
					END

					IF @senha != @senhaCadastrada 
					BEGIN
						SELECT	 @CodigoRetorno		= -2
								,@DescricaoRetorno	= 'Senha Inválida!'

						IF @qtdeErros IS NULL OR ABS(DATEDIFF(D, GETDATE(), @ultimoErro)) > 1
							SELECT @qtdeErros = 0

						SELECT @qtdeErros = @qtdeErros + 1
						IF @qtdeErros  > 3
						BEGIN
							--exec p_InserirNotificacao @siglaTipoNotificacao = 'BLOQUEIO_SENHA', @identificador = @logon, @parametros = @logon, @responsavel = @logon
							UPDATE tb_Usuario set codigoSituacao = @codigoSituacaoBloq, qtdeErros = @qtdeErros, ultimoErro = GETDATE() WHERE id= @ID_Usuario
						END
						ELSE
						BEGIN
							UPDATE tb_Usuario set qtdeErros = @qtdeErros, ultimoErro = GETDATE() WHERE id= @ID_Usuario
						END

						GOTO FIM
					END
			END

			SELECT @DeviceID = ID FROM tb_Device (nolock) WHERE deviceUID = @DeviceUID
			IF @DeviceID IS NULL
			BEGIN

				Insert
					INTO tb_Device
					(
						deviceUID,
						idUsuario,
						plataforma,
						criadoEm,
						criadoPor
					)
				VALUES
					(
						 @deviceUID,
						 @ID_Usuario,
						 @plataforma,
						 GETDATE(),
						 @logon
					)

				SELECT @DeviceID = SCOPE_IDENTITY()

			END
			ELSE
			BEGIN

				Update 
					tb_Device
				SET
					 idUsuario = @ID_Usuario
					,alteradoEm = GETDATE()
					,alteradoPor = @logon
				WHERE
					id = @deviceID

			END
			
			SELECT @UID = NEWID()
			SELECT @token = cast(@UID as varchar(50))
			SELECT @expiracao = DATEADD(MI, 60, GETDATE())

			INSERT	
				INTO tb_DeviceToken
				(
					token,
					idDevice,
					tipoLogon,
					expiracao,
					criadoEm
				)
			VALUES
				(
					@UID,
					@DeviceID,
					@tipoLogon,
					@expiracao,
					GETDATE()
				)

			SELECT 
				perfil.id,
				perfil.sigla
			FROM
				tb_Perfil perfil(nolock)
				inner join tb_UsuarioPerfil usuarioPerfil (nolock)
					on perfil.id = usuarioPerfil.idPerfil
			WHERE
				usuarioPerfil.idUsuario = @ID_Usuario
	END TRY
	BEGIN CATCH

			SELECT	 @CodigoRetorno		= -9
					,@DescricaoRetorno	= 'Erro de Processamento - Logon Usuario [' + @Logon + ']'
		
			IF @TransacaoAberta = 'S'
			BEGIN
				ROLLBACK TRAN
				SET @TransacaoAberta = 'N'
			END
		
			SET @LOG = ERROR_MESSAGE() + '\nLinha:' + cast(ERROR_LINE() as varchar)
			exec p_AddLog @Origem='p_Logon', @Log = @Log, @Usuario = @logon
			print @LOG
			GOTO FIM

	END CATCH


FIM:
	SET @LOG = cast(@CodigoRetorno as varchar) + '-' + @DescricaoRetorno
	exec p_AddLog @Origem='p_Logon', @Log = @Log, @Usuario = @logon

	IF @TransacaoAberta = 'S'
	BEGIN
		COMMIT TRAN
		SET @TransacaoAberta = 'N'
	END

END
GO


