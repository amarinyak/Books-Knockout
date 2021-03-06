﻿CREATE TYPE [dbo].[AuthorCollection] AS TABLE
(
    [Id]            UNIQUEIDENTIFIER    NOT NULL,
    [BookId]        UNIQUEIDENTIFIER    NOT NULL,
    [FirstName]     NVARCHAR(50)        NOT NULL,
    [LastName]      NVARCHAR(50)        NOT NULL
)
