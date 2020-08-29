CREATE TABLE [dbo].[Authors] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BooksCount] INT            NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

