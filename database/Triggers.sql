--criar tabela
CREATE TABLE AuditoriaGeral (
	IdLog INT PRIMARY KEY IDENTITY,
	NomeTabela VARCHAR(100),
	TipoAcao VARCHAR(100),
	Usuario VARCHAR(100),
	DataAcao DATETIME,
	DadosAntigos NVARCHAR(MAX),
	DadosNovos NVARCHAR(MAX),
);
GO
-- criar triggers
CREATE OR ALTER TRIGGER trg_audit_tag ON TAG
AFTER INSERT, UPDATE, DELETE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @old NVARCHAR(MAX), @new NVARCHAR(MAX);

	IF EXISTS (SELECT 1 FROM deleted)
		SELECT @old = (SELECT * FROM deleted FOR JSON AUTO);

	IF EXISTS (SELECT 1 FROM inserted)
		SELECT @new = (SELECT * FROM inserted FOR JSON AUTO);

	INSERT INTO AuditoriaGeral (NomeTabela, TipoAcao, Usuario, DataAcao, DadosAntigos, DadosNovos)
	VALUES (
		'TAG', 
		CASE 
			WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
			WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
			WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
		END,
		SUSER_SNAME(),
		SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time',
		@old,
		@new
	)
END;
GO

CREATE OR ALTER TRIGGER trg_audit_notetag ON NOTETAG
AFTER INSERT, UPDATE, DELETE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @old NVARCHAR(MAX), @new NVARCHAR(MAX);

	IF EXISTS (SELECT 1 FROM deleted)
		SELECT @old = (SELECT * FROM deleted FOR JSON AUTO);

	IF EXISTS (SELECT 1 FROM inserted)
		SELECT @new = (SELECT * FROM inserted FOR JSON AUTO);

	INSERT INTO AuditoriaGeral (NomeTabela, TipoAcao, Usuario, DataAcao, DadosAntigos, DadosNovos)
	VALUES (
		'NOTETAG', 
		CASE 
			WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
			WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
			WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
		END,
		SUSER_SNAME(),
		SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time',
		@old,
		@new
	)
END;
GO

CREATE OR ALTER TRIGGER trg_audit_user ON NOTES_USER
AFTER INSERT, UPDATE, DELETE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @old NVARCHAR(MAX), @new NVARCHAR(MAX);

	IF EXISTS (SELECT 1 FROM deleted)
		SELECT @old = (SELECT * FROM deleted FOR JSON AUTO);

	IF EXISTS (SELECT 1 FROM inserted)
		SELECT @new = (SELECT * FROM inserted FOR JSON AUTO);

	INSERT INTO AuditoriaGeral (NomeTabela, TipoAcao, Usuario, DataAcao, DadosAntigos, DadosNovos)
	VALUES (
		'NOTES_USER', 
		CASE 
			WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
			WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
			WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
		END,
		SUSER_SNAME(),
		SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time',
		@old,
		@new
	)
END;
GO

CREATE OR ALTER TRIGGER trg_audit_note ON NOTE
AFTER INSERT, UPDATE, DELETE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @old NVARCHAR(MAX), @new NVARCHAR(MAX);

	IF EXISTS (SELECT 1 FROM deleted)
		SELECT @old = (SELECT * FROM deleted FOR JSON AUTO);

	IF EXISTS (SELECT 1 FROM inserted)
		SELECT @new = (SELECT * FROM inserted FOR JSON AUTO);

	INSERT INTO AuditoriaGeral (NomeTabela, TipoAcao, Usuario, DataAcao, DadosAntigos, DadosNovos)
	VALUES (
		'NOTE', 
		CASE 
			WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
			WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
			WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
		END,
		SUSER_SNAME(),
		SYSDATETIMEOFFSET() AT TIME ZONE 'E. South America Standard Time',
		@old,
		@new
	)
END;
GO