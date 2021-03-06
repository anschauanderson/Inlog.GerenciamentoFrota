BEGIN TRANSACTION
GO
CREATE TABLE dbo.TipoVeiculo
	(
	Id bigint NOT NULL,
	Nome nvarchar(250) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TipoVeiculo ADD CONSTRAINT
	PK_TipoVeiculo PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TipoVeiculo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Veiculo
	(
	Id bigint NOT NULL IDENTITY (1, 1),
	Chassi nvarchar(17) NOT NULL,
	Cor nvarchar(150) NOT NULL,
	QtPassageiros int NOT NULL,
	TipoVeiculoId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Veiculo ADD CONSTRAINT
	PK_Veiculo PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Veiculo ADD CONSTRAINT
	FK_Veiculo_TipoVeiculo FOREIGN KEY
	(
	TipoVeiculoId
	) REFERENCES dbo.TipoVeiculo
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Veiculo SET (LOCK_ESCALATION = TABLE)
GO

INSERT INTO [dbo].[TipoVeiculo]
           ([Id],
		   [Nome])
     VALUES
           (1, 'Caminhao')
GO

INSERT INTO [dbo].[TipoVeiculo]
           ([Id],
		   [Nome])
     VALUES
           (2, 'Onibus')
GO

COMMIT