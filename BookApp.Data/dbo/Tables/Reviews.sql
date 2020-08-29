CREATE TABLE [dbo].[Reviews] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Body]     NVARCHAR (MAX) NULL,
    [BookId]   INT            NOT NULL,
    [Rating]   INT            NOT NULL,
    [UserName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Reviews_BookId]
    ON [dbo].[Reviews]([BookId] ASC);

