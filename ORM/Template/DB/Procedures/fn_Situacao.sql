USE SW
GO

IF EXISTS ( SELECT 1 FROM sys.objects WHERE type='FN' AND name='fn_Situacao')
	DROP FUNCTION dbo.fn_Situacao
GO

CREATE FUNCTION dbo.fn_Situacao(@Sigla varchar(20), @Escopo varchar(20) = null)
RETURNS INT 
AS
BEGIN
	
	DECLARE @RET INT
	SELECT @RET = Codigo FROM tb_Situacao (nolock) WHERE Sigla = @Sigla AND escopo = @Escopo
	RETURN @RET
		
END
GO