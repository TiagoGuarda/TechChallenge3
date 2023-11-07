CREATE DATABASE [db_noticias]

GO

CREATE TABLE [db_noticias].[dbo].[Noticia] (
    Id INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(255) NOT NULL,
	Descricao NVARCHAR(500) NOT NULL,
    Conteudo NVARCHAR(MAX) NOT NULL,
    DataPublicacao DATETIME NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
	DataAtualizacao DATETIME NOT NULL
);