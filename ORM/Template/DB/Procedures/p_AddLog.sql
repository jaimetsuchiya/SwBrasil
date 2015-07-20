USE SW
GO


IF (OBJECT_ID('p_AddLog', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_AddLog
END
GO

CREATE PROC dbo.p_AddLog(@Origem varchar(128), @Log varchar(MAX), @Usuario varchar(128), @tipoLog varchar(40) = null, @showTrack bit = 0, @identificador varchar(20) = null)
AS
BEGIN
	
	INSERT	
		INTO tb_Logger
		(
			 origem
			,mensagem
			,tipo
			,exibirTrack
			,identificador
			,criadoEm
			,criadoPor
		)
		VALUES
		(
			 @Origem
			,@Log
			,@tipoLog
			,@showTrack
			,@identificador
			,GETDATE()
			,@Usuario
		)
END
GO

