USE SW
GO

/*******************************************************************************************************
* SITUACAO
*******************************************************************************************************/
--BEGIN

		Insert 
			into tb_Situacao
			(
				 codigo
				,sigla
				,descricao
				,escopo
				,criadoEm
				,criadoPor
			)
			values
			(
				 2
				,'ATIVO'
				,'Ativo'
				,'GERAL'
				,GETDATE()
				,'SISTEMA'
			)		

		Insert 
			into tb_Situacao
			(
				 codigo
				,sigla
				,escopo
				,descricao
				,criadoEm
				,criadoPor
			)
			values
			(
				 63
				,'INATIVO'
				,'GERAL'
				,'Inativo'
				,GETDATE()
				,'SISTEMA'
			)		
						
--END							
--END


DECLARE  @ID_USUARIO INT
		,@ID_PERFIL INT

INSERT INTO tb_usuario (nome, email, logon, senha, codigoSituacao, criadoEm, criadoPor) Values('Jaime R. Tsuchiya', 'jaime.tsuchiya@bebestore.com.br', 'u3364', '1234', 2, getdate(), 'SISTEMA')
SELECT @ID_USUARIO = SCOPE_IDENTITY()

INSERT INTO tb_perfil (sigla, criadoEm, criadoPor) values('ADMINISTRADOR', GETDATE(), 'SISTEMA')
SELECT @ID_PERFIL = SCOPE_IDENTITY()
INSERT INTO tb_UsuarioPerfil (idPerfil, idUsuario, criadoPor, criadoEm) values( @ID_PERFIL, @ID_USUARIO, 'SISTEMA', GETDATE())

