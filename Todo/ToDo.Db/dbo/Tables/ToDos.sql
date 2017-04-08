CREATE TABLE [dbo].[ToDos] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (50)   NOT NULL,
    [Description]  NVARCHAR (4000) NOT NULL,
    [CreatedOnUtc] DATETIME        CONSTRAINT [DF_ToDos_CreatedOnUtc] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedOnUtc] DATETIME        NULL,
    [DeletedOnUtc] DATETIME        NULL,
    CONSTRAINT [PK_ToDos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

