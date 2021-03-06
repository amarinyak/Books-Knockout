﻿CREATE TABLE [dbo].[Book]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [PK_Book] PRIMARY KEY,
    [Title] NVARCHAR(200) NOT NULL,
    [PageCount] SMALLINT NOT NULL,
    [Publisher] NVARCHAR(200) NULL,
    [Year] SMALLINT NOT NULL,
    [Isbn] VARCHAR(14) NULL,
    [Image] VARCHAR(MAX) NULL,
    [Token] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME2 NOT NULL,
    [EditDate] DATETIME2 NOT NULL
)
