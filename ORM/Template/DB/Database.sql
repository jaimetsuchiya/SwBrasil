USE SW
GO


--AF = Aggregate function (CLR)
--C = CHECK constraint
--D = DEFAULT (constraint or stand-alone)
--F = FOREIGN KEY constraint

--FN = SQL scalar function
--FS = Assembly (CLR) scalar-function
--FT = Assembly (CLR) table-valued function
--IF = SQL inline table-valued function

--IT = Internal table
--P = SQL Stored Procedure
--PC = Assembly (CLR) stored-procedure
--PG = Plan guide
--PK = PRIMARY KEY constraint
--R = Rule (old-style, stand-alone)
--RF = Replication-filter-procedure
--S = System base table
--SN = Synonym
--SO = Sequence object
--> 2012
--SQ = Service queue
--TA = Assembly (CLR) DML trigger
--TF = SQL table-valued-function
--TR = SQL DML trigger
--TT = Table type
--U = Table (user-defined)
--UQ = UNIQUE constraint
--V = View
--X = Extended stored procedure
/*************************************************************************************************************************************************
* Constraint
**************************************************************************************************************************************************/
	
	IF (OBJECT_ID('FK_tb_ParametrosSistema_tb_Parametros', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_ParametrosSistema DROP CONSTRAINT FK_tb_ParametrosSistema_tb_Parametros
	END
	
	IF (OBJECT_ID('FK_tb_ParametrosSistema_tb_empresa', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_ParametrosSistema DROP CONSTRAINT FK_tb_ParametrosSistema_tb_empresa
	END

	IF (OBJECT_ID('FK_tb_Usuario_tb_Situacao', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_usuario DROP CONSTRAINT FK_tb_Usuario_tb_Situacao
	END
		
	IF (OBJECT_ID('FK_tb_DeviceToken_tb_Device', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_DeviceToken DROP CONSTRAINT FK_tb_DeviceToken_tb_Device
	END
	
	IF (OBJECT_ID('FK_tb_Device_tb_Situacao', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_Device DROP CONSTRAINT FK_tb_Device_tb_Situacao
	END

	IF (OBJECT_ID('FK_tb_Device_tb_Usuario', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_Device DROP CONSTRAINT FK_tb_Device_tb_Usuario
	END

	IF (OBJECT_ID('FK_tb_UsuarioPerfil_tb_Perfil', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_UsuarioPerfil DROP CONSTRAINT FK_tb_UsuarioPerfil_tb_Perfil
	END

	IF (OBJECT_ID('FK_tb_UsuarioPerfil_tb_Usuario', 'F') IS NOT NULL)
	BEGIN
		ALTER TABLE dbo.tb_UsuarioPerfil DROP CONSTRAINT FK_tb_UsuarioPerfil_tb_Usuario
	END

/*************************************************************************************************************************************************
* DROP´S
**************************************************************************************************************************************************/
	
	IF OBJECT_ID('dbo.tb_ParametrosSistema', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_ParametrosSistema
			DROP CONSTRAINT PK_tb_ParametrosSistema

		DROP TABLE dbo.tb_ParametrosSistema

	END
	
	IF OBJECT_ID('dbo.tb_Parametros', 'U') IS NOT NULL
	BEGIN

		ALTER TABLE dbo.tb_Parametros
			DROP CONSTRAINT PK_tb_Parametros

		DROP TABLE dbo.tb_Parametros

	END


	IF OBJECT_ID('dbo.tb_Perfil', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_Perfil
			DROP CONSTRAINT [PK_tb_Perfil]

		DROP TABLE dbo.tb_Perfil

	END

	
	IF OBJECT_ID('dbo.tb_DeviceToken', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_DeviceToken
			DROP CONSTRAINT [PK_tb_DeviceToken]

		DROP TABLE dbo.tb_DeviceToken

	END

	IF OBJECT_ID('dbo.tb_UsuarioPerfil', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_UsuarioPerfil
			DROP CONSTRAINT [PK_tb_UsuarioPerfil]

		DROP TABLE dbo.tb_UsuarioPerfil

	END

	IF OBJECT_ID('dbo.tb_Usuario', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_Usuario
			DROP CONSTRAINT [PK_tb_Usuario]

		DROP TABLE dbo.tb_Usuario

	END
	
	IF OBJECT_ID('dbo.tb_Device', 'U') IS NOT NULL
	BEGIN
		
		ALTER TABLE dbo.tb_Device
			DROP CONSTRAINT [PK_tb_Device]

		DROP TABLE dbo.tb_Device

	END

	
	IF OBJECT_ID('dbo.tb_Situacao', 'U') IS NOT NULL
	BEGIN
		ALTER TABLE dbo.tb_Situacao
			DROP CONSTRAINT [PK_tb_Situacao]

		DROP TABLE dbo.tb_Situacao
	END
	GO

	IF OBJECT_ID('dbo.tb_Logger', 'U') IS NOT NULL
	BEGIN
		ALTER TABLE tb_Logger
			DROP CONSTRAINT [PK_tb_Logger]
	
		DROP TABLE tb_Logger
	
	END
	GO

/*************************************************************************************************************************************************
* TABLES
**************************************************************************************************************************************************/
	CREATE TABLE dbo.tb_Logger
	(
		id						int			not null identity(1,1),
		origem					varchar(255)	null,
		mensagem				varchar(MAX)	null,
		tipo					varchar(40)		null,
		exibirTrack				bit			not null default(0),
		identificador			varchar(20)		null,
		criadoEm				datetime	not null default(getdate()),
		criadoPor				varchar(128)not null,
		CONSTRAINT [PK_tb_Logger] PRIMARY KEY CLUSTERED 
		(
			[id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO


	CREATE TABLE dbo.tb_Situacao
	(
		codigo					int			not null,
		descricao				varchar(50)	not null,
		sigla					varchar(25)	not null,
		escopo					varchar(25)		null,
		criadoEm				datetime	not null default(getdate()),
		criadoPor				varchar(128)not null,
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
		CONSTRAINT [PK_tb_Situacao] PRIMARY KEY CLUSTERED 
		(
			[codigo] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO


	CREATE TABLE dbo.tb_Usuario
	(
		id						int				not null identity(1,1),
		nome					varchar(50)		not null,
		email					varchar(128)	null,
		logon					varchar(50)		not null,
		senha					varchar(255)	not null,
		codigoSituacao			int				not null,
		--idContrato				int				not null,
		qtdeErros				int				null,
		ultimoErro				datetime		null,
		criadoEm				datetime		not null default(getdate()),
		criadoPor				varchar(128)	not null,
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
	CONSTRAINT [PK_tb_Usuario] PRIMARY KEY CLUSTERED 
	(
		id ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	ALTER TABLE dbo.tb_Usuario
	ADD CONSTRAINT FK_tb_Usuario_tb_Situacao FOREIGN KEY (codigoSituacao)
	REFERENCES tb_Situacao (codigo)
	GO
	
	--ALTER TABLE dbo.tb_Usuario
	--ADD CONSTRAINT FK_tb_Usuario_tb_Contrato FOREIGN KEY (idContrato)
	--REFERENCES tb_Contrato (id)
	--GO

	CREATE TABLE dbo.tb_Perfil
	(
		id						int				not null identity(1,1),
		sigla					varchar(50)		not null,
		criadoEm				datetime		not null default(getdate()),
		criadoPor				varchar(128)	not null,
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
	CONSTRAINT [PK_tb_Perfil] PRIMARY KEY CLUSTERED 
	(
		id ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO



	CREATE TABLE dbo.tb_UsuarioPerfil
	(
		idUsuario				int				not null,
		idPerfil				int				not null,
		criadoEm				datetime		not null default(getdate()),
		criadoPor				varchar(128)	not null,
	CONSTRAINT [PK_tb_UsuarioPerfil] PRIMARY KEY CLUSTERED 
	(
		idUsuario ASC,
		idPerfil ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	ALTER TABLE dbo.tb_UsuarioPerfil
	ADD CONSTRAINT FK_tb_UsuarioPerfil_tb_Usuario FOREIGN KEY (idUsuario)
	REFERENCES tb_Usuario (id)
	GO

	ALTER TABLE dbo.tb_UsuarioPerfil
	ADD CONSTRAINT FK_tb_UsuarioPerfil_tb_Perfil FOREIGN KEY (idPerfil)
	REFERENCES tb_Perfil (id)
	GO


	CREATE TABLE dbo.tb_Device
	(
		id						int				not null identity(1,1),
		deviceUID				varchar(255)	not null,
		--codigoSituacao			int				not null,
		idUsuario				int				not null,
		plataforma				varchar(255)	not null,

		criadoEm				datetime		not null default(getdate()),
		criadoPor				varchar(128)	not null,
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
	CONSTRAINT [PK_tb_Device] PRIMARY KEY CLUSTERED 
	(
		id ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	--ALTER TABLE dbo.tb_Device
	--ADD CONSTRAINT FK_tb_Device_tb_Situacao FOREIGN KEY (codigoSituacao)
	--REFERENCES tb_Situacao (codigo)
	--GO

	ALTER TABLE dbo.tb_Device
	ADD CONSTRAINT FK_tb_Device_tb_Usuario FOREIGN KEY (idUsuario)
	REFERENCES tb_Usuario (id)
	GO
	
	CREATE UNIQUE INDEX UIDX_DEVICE
	ON tb_Device (deviceUID)
	GO

	CREATE TABLE dbo.tb_DeviceToken
	(
		token					uniqueidentifier not null,
		idDevice				int				not null,
		tipoLogon				varchar(20)		not null,
		expiracao				datetime		not null,
		criadoEm				datetime		not null default(getdate()),
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
	CONSTRAINT [PK_tb_DeviceToken] PRIMARY KEY CLUSTERED 
	(
		token ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	ALTER TABLE dbo.tb_DeviceToken
	ADD CONSTRAINT FK_tb_DeviceToken_tb_Device FOREIGN KEY (idDevice)
	REFERENCES tb_Device (id)
	GO


	CREATE TABLE dbo.tb_Parametros
	(
		id						int			not null identity(1,1),
		sigla					varchar(128)not null,
		descricao				varchar(MAX)	null,
		criadoEm				datetime	not null,
		criadoPor				varchar(128)not null,

		CONSTRAINT [PK_tb_Parametros] PRIMARY KEY CLUSTERED
		(
			id ASC
		) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	CREATE TABLE dbo.tb_ParametrosSistema
	(
		idParametro				int			not null,
		codigoEmpresa			int			not null,
		valor					varchar(MAX)not null,
		criadoEm				datetime	not null,
		criadoPor				varchar(128)not null,
		alteradoEm				datetime		null,
		alteradoPor				varchar(128)	null,
		CONSTRAINT [PK_tb_ParametrosSistema] PRIMARY KEY CLUSTERED
		(
			idParametro ASC,
			codigoEmpresa ASC
		) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	
	ALTER TABLE dbo.tb_ParametrosSistema
	ADD CONSTRAINT FK_tb_ParametrosSistema_tb_Parametros FOREIGN KEY (idParametro)
	REFERENCES tb_Parametros (id)
	GO

	ALTER TABLE dbo.tb_ParametrosSistema
	ADD CONSTRAINT FK_tb_ParametrosSistema_tb_empresa FOREIGN KEY (codigoEmpresa)
	REFERENCES tb_Empresa (codigo)
	GO

	