USE SW
GO


IF (OBJECT_ID('p_Usuarios', 'P') IS NOT NULL)
BEGIN
	DROP PROC dbo.p_Usuarios --@EstoqueOK=0
END
GO



/*
select * from tb_ClasseProduto
select top 10 * from tb_pedidosaida
p_Usuarios @sigla='7891276849540BY'
p_Usuarios @idclasse=2
select * from tb_produto where sigla='7891276849540BY'
*/
CREATE PROC dbo.p_Usuarios
(
	 @nome				varchar(50)	= NULL
	,@logon				varchar(50)	= NULL
	,@email				varchar(128)= NULL
	,@codigoSituacao	int			= NULL
	,@perfil			varchar(50)	= NULL
)
AS 
BEGIN

	SELECT
		top 1000
		usuario.id,
		usuario.nome,
		usuario.email,
		usuario.logon,
		usuario.qtdeErros,
		usuario.ultimoErro,
		usuario.criadoEm,
		usuario.criadoPor,
		usuario.alteradoEm,
		usuario.alteradoPor,
		situacao.codigo as situacao_codigo,
		situacao.descricao as situacao_descricao,
		situacao.sigla as situacao_sigla,
		situacao.escopo as situacao_escopo,
		dbo.fn_Perfis(usuario.id) as Perfis
	FROM
		tb_Usuario usuario (nolock) 
		inner join tb_Situacao situacao (nolock)
			on situacao.codigo = usuario.codigoSituacao

	WHERE
		(@nome IS NULL OR usuario.nome like '%' + @nome + '%')
	AND (@email IS NULL OR usuario.email like '%' + @email + '%')
	AND (@logon IS NULL OR usuario.logon LIKE '%' + @logon + '%')
	AND (@codigoSituacao IS NULL OR situacao.codigo = @codigoSituacao)
	AND (@perfil IS NULL OR exists( SELECT 1 FROM tb_UsuarioPerfil up (nolock) INNER JOIN tb_Perfil p (nolock) on p.id = up.idPerfil WHERE up.idUsuario = usuario.id and p.sigla = @perfil))

	ORDER BY
		usuario.nome
END
