-- Inserir usuários
INSERT INTO NOTES_USER(Name, Email, Password, UserThemePreferences, UserFontPreferences, CreatedAt)
VALUES 
('Alice Silva', 'alice@example.com', 'pass123', 1, 1, GETDATE()),
('Bruno Costa', 'bruno@example.com', 'secret456', 2, 1, GETDATE()),
('Carla Dias', 'carla@example.com', 'carla789', 1, 2, GETDATE()),
('Daniel Souza', 'daniel@example.com', 'd4n13l', 2, 2, GETDATE()),
('Elisa Martins', 'elisa@example.com', 'elisa!@#', 1, 3, GETDATE());

-- Inserir notas
INSERT INTO NOTE (Title, Content, ImageUrl, IsFavorite, IsArchived, CreatedAt, UpdatedAt, IdUser)
VALUES
('Nota 1 de Alice', 'Conteúdo da nota da Alice', NULL, 1, 0, GETDATE(), GETDATE(), 1),
('Nota 1 de Bruno', 'Conteúdo da nota de Bruno', 'http://image.com/img2.jpg', 0, 0, GETDATE(), GETDATE(), 2),
('Nota 1 de Carla', 'Conteúdo da nota de Carla', NULL, 1, 1, GETDATE(), GETDATE(), 3),
('Nota 1 de Daniel', 'Conteúdo da nota de Daniel', 'http://image.com/img4.jpg', 0, 0, GETDATE(), GETDATE(), 4),
('Nota 1 de Elisa', 'Conteúdo da nota de Elisa', NULL, 1, 0, GETDATE(), GETDATE(), 5);

-- Inserir tags
INSERT INTO TAG (Name)
VALUES 
('Trabalho'),
('Pessoal'),
('Urgente'),
('Ideias'),
('Estudo');

-- Inserir relações entre notas e tags
-- Supondo que os Ids das notas e tags são incrementais de 1 a 5
INSERT INTO NOTETAG (IdNote, IdTag)
VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1),
(5, 3);
