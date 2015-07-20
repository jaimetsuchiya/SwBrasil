USE SW
GO


IF (OBJECT_ID('p_ChangePwd', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_ChangePwd --@EstoqueOK=0
END
GO
/*
BEGIN TRAN

	declare  @codigoRetorno		int
			,@descricaoretorno	varchar(max)

	exec dbo.p_ChangePwd
		 @idUsuario			= '1'
		,@senhaAtual		= '1111'
		,@novaSenha			= '1112'
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno
	select * from tb_usuario

	exec dbo.p_ChangePwd
		 @idUsuario			= '1'
		,@senhaAtual		= '1111'
		,@novaSenha			= '1112'
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno
	select * from tb_usuario

	exec dbo.p_ChangePwd
		 @idUsuario			= '1'
		,@senhaAtual		= '1111'
		,@novaSenha			= '1112'
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno
	select * from tb_usuario

	exec dbo.p_ChangePwd
		 @idUsuario			= '1'
		,@senhaAtual		= '1111'
		,@novaSenha			= '1112'
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno
	select * from tb_usuario

ROLLBACK TRAN
*/
CREATE PROC dbo.p_ChangePwd
(
	 @logon				varchar(50)
	,@senhaAtual		varchar(255)
	,@novaSenha			varchar(255)
	,@abrirTransacao	char(1)		= 'S'
	,@debug				char(1)		= 'N'
	,@usuario			varchar(50)	= null
	,@codigoRetorno		int			= null	output
	,@descricaoRetorno	varchar(MAX)= null	output
) AS
BEGIN

	DECLARE  @TransacaoAberta		char(1)
			,@LOG					varchar(MAX)
			,@SenhaAtualTmp			varchar(255)
			,@qtdeErros				int
			,@ultimoErro			datetime
			,@IdUsuarioTmp			varchar(50)
			,@strIdUsuario			varchar(20)

	SELECT	 @CodigoRetorno		= 0
			,@DescricaoRetorno	= ''
			,@usuario			= case when @usuario is null then @logon else @usuario end

	BEGIN TRY

		IF @abrirTransacao = 'S'
		BEGIN
			BEGIN TRANSACTION
			SET @TransacaoAberta = 'S'
		END

			SELECT @IdUsuarioTmp = logon, @qtdeErros = qtdeErros, @ultimoErro = ultimoErro, @SenhaAtualTmp = senha FROM tb_Usuario (nolock) WHERE logon = @logon
			IF @IdUsuarioTmp IS NULL
			BEGIN
				SELECT	 @CodigoRetorno		= -1
						,@DescricaoRetorno	= 'Usuário não cadastrado'

				GOTO FIM
			END

			IF @IdUsuarioTmp != @logon
			BEGIN
				SELECT	 @CodigoRetorno		= -2
						,@DescricaoRetorno	= 'Usuário Inválido'

				GOTO FIM
			END

			IF @senhaAtual != @SenhaAtualTmp 
			BEGIN
				SELECT	 @CodigoRetorno		= -2
						,@DescricaoRetorno	= 'Senha Inválida!'

				IF @qtdeErros IS NULL OR ABS(DATEDIFF(D, GETDATE(), @ultimoErro)) > 1
					SELECT @qtdeErros = 0

				SELECT @qtdeErros = @qtdeErros + 1
				IF @qtdeErros  > 3
				BEGIN
					UPDATE tb_Usuario set codigoSituacao = dbo.fn_Situacao('BLOQUEADO', 'USUARIO'), qtdeErros = @qtdeErros, ultimoErro = GETDATE() WHERE logon = @logon
				END
				ELSE
				BEGIN
					UPDATE tb_Usuario set qtdeErros = @qtdeErros, ultimoErro = GETDATE() WHERE logon= @logon
				END

				GOTO FIM
			END
			
			UPDATE tb_Usuario set Senha = @novaSenha, alteradoEm=GETDATE(), alteradoPor=@usuario where logon = @logon

	END TRY
	BEGIN CATCH

			SELECT	 @CodigoRetorno		= -9
					,@DescricaoRetorno	= 'Erro de Processamento - p_ChangePwd [' +@logon + ']'
		
			IF @TransacaoAberta = 'S'
			BEGIN
				ROLLBACK TRAN
				SET @TransacaoAberta = 'N'
			END
		
			SET @LOG = ERROR_MESSAGE() + '\nLinha:' + cast(ERROR_LINE() as varchar)
			exec p_AddLog @Origem='p_ChangePwd', @Log = @Log, @Usuario = @logon
			print @LOG
			GOTO FIM

	END CATCH


FIM:
	SET @LOG = cast(@CodigoRetorno as varchar) + '-' + @DescricaoRetorno
	exec p_AddLog @Origem='p_ChangePwd', @Log = @Log, @Usuario = @logon

	IF @TransacaoAberta = 'S'
	BEGIN
		COMMIT TRAN
		SET @TransacaoAberta = 'N'
	END

END
GO


