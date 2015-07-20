USE SW
GO


IF (OBJECT_ID('p_LogOff', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_LogOff --@EstoqueOK=0
END
GO
/*
BEGIN TRAN

	declare  @codigoRetorno		int
			,@descricaoretorno	varchar(max)
			,@expiracao			datetime

	exec dbo.p_CheckToken
		 @token				= '82702517-CECE-4E28-87C8-D745FABC3662'
		,@deviceUID			= '192.168.2.122'
		,@plataforma		= 'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36'
		,@expiracao			= @expiracao	output
		,@abrirTransacao	= 'N'
		,@codigoRetorno		= @codigoRetorno	output
		,@descricaoRetorno	= @descricaoRetorno	output

	select @codigoRetorno, @descricaoRetorno, @expiracao

ROLLBACK TRAN
*/
CREATE PROC dbo.p_LogOff
(
	 @token				varchar(50)
--	,@usuario			varchar(128)
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
			,@codigoSituacaoTMP		int
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

			UPDATE tb_DeviceToken SET expiracao = '1900-01-01', alteradoEm = GETDATE(), alteradoPor = 'SISTEMA' WHERE token = @token

	END TRY
	BEGIN CATCH

			SELECT	 @CodigoRetorno		= -9
					,@DescricaoRetorno	= 'Erro de Processamento - p_LogOff [' + cast(@token as varchar) + ']'
		
			IF @TransacaoAberta = 'S'
			BEGIN
				ROLLBACK TRAN
				SET @TransacaoAberta = 'N'
			END
		
			SET @LOG = ERROR_MESSAGE() + '\nLinha:' + cast(ERROR_LINE() as varchar)
			exec p_AddLog @Origem='p_LogOff', @Log = @Log, @Usuario = @token
			print @LOG
			GOTO FIM

	END CATCH


FIM:
	SET @LOG = cast(@CodigoRetorno as varchar) + '-' + @DescricaoRetorno
	exec p_AddLog @Origem='p_LogOff', @Log = @Log, @Usuario = @token

	IF @TransacaoAberta = 'S'
	BEGIN
		COMMIT TRAN
		SET @TransacaoAberta = 'N'
	END

END
GO


