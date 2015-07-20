USE SW
GO


IF (OBJECT_ID('p_CheckToken', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_CheckToken --@EstoqueOK=0
END
GO
/*
BEGIN TRAN

	declare  @codigoRetorno		int
			,@descricaoretorno	varchar(max)
			,@expiracao			datetime
			,@logon				varchar(50)
	exec dbo.p_CheckToken
		 @token				= '96F794D1-025E-4634-8C01-BC5CA9222E62'
		,@deviceUID			= '::1'
		,@plataforma		= 'Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.99 Safari/537.36'
		,@expiracao			= @expiracao	output
		,@logon				= @logon		output
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno, @expiracao, @logon

ROLLBACK TRAN
*/
CREATE PROC dbo.p_CheckToken
(
	 @token				varchar(50)
	,@deviceUID			varchar(255)
	,@plataforma		varchar(255)= null
	,@nome				varchar(50)	= null	output
	,@email				varchar(128)= null	output
	,@logon				varchar(50)	= null	output
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
			,@ID_Usuario			int
			,@codigoSituacaoBloq	int
			,@codigoSituacaoOK		int
			,@expiracaoTMP			datetime
	DECLARE	 @tblPerfis				TABLE (Sigla varchar(50), ID int null )

	SELECT	 @CodigoRetorno		= 0
			,@DescricaoRetorno	= ''

	BEGIN TRY

			IF @abrirTransacao = 'S'
			BEGIN
				BEGIN TRANSACTION
				SET @TransacaoAberta = 'S'
			END

			SELECT @codigoSituacaoBloq	= dbo.fn_Situacao('CANCELADO', 'USUARIO')
			SELECT @codigoSituacaoOK	= dbo.fn_Situacao('ATIVO', 'USUARIO')

			SELECT 
				 @ID_Usuario	= IdUsuario
				,@expiracaoTMP	= expiracao 
				,@nome			= usuario.nome
				,@logon			= usuario.logon
				,@email			= usuario.email
			FROM
				tb_Device device (nolock)
				inner join tb_DeviceToken tokens(nolock)
					on device.id = tokens.idDevice
				inner join tb_Usuario usuario(nolock)
					on usuario.id = device.idUsuario
			WHERE
				tokens.token = @token
			AND device.deviceUID = @deviceUID
			AND(device.plataforma = @plataforma or @plataforma IS NULL)
			--AND device.codigoSituacao = @codigoSituacaoOK

			IF @ID_Usuario IS NULL
			BEGIN
				SELECT	 @CodigoRetorno		= -1
						,@DescricaoRetorno	= 'Token inválido ou não cadastrado'

				GOTO FIM
			END

			IF @expiracaoTMP < GETDATE()
			BEGIN
				SELECT	 @CodigoRetorno		= -2
						,@DescricaoRetorno	= 'Sessão expirada!'

				GOTO FIM
			END
			ELSE
			BEGIN
				IF ABS(DATEDIFF(MI, @expiracaoTMP, GETDATE())) < 5
				BEGIN

					SELECT @expiracao = DATEADD(MI, 20, GETDATE())
					UPDATE tb_DeviceToken SET expiracao = @expiracao WHERE token = @token

				END
			END

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
					,@DescricaoRetorno	= 'Erro de Processamento - p_CheckToken [' + cast(@token as varchar) + ']'
		
			IF @TransacaoAberta = 'S'
			BEGIN
				ROLLBACK TRAN
				SET @TransacaoAberta = 'N'
			END
		
			SET @LOG = ERROR_MESSAGE() + '\nLinha:' + cast(ERROR_LINE() as varchar)
			exec p_AddLog @Origem='p_CheckToken', @Log = @Log, @Usuario = @token
			print @LOG
			GOTO FIM

	END CATCH


FIM:
	SET @LOG = cast(@CodigoRetorno as varchar) + '-' + @DescricaoRetorno
	exec p_AddLog @Origem='p_CheckToken', @Log = @Log, @Usuario = @token

	IF @TransacaoAberta = 'S'
	BEGIN
		COMMIT TRAN
		SET @TransacaoAberta = 'N'
	END

END
GO

EXEC sys.sp_refreshsqlmodule @name = 'p_CheckToken'
GO