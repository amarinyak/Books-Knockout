CREATE PROCEDURE [dbo].[Book_GetById]
    @BookId     UNIQUEIDENTIFIER,
    @Token      UNIQUEIDENTIFIER
AS
BEGIN

    SELECT
        b.[Id],
        b.[Title],
        b.[PageCount],
        b.[Publisher],
        b.[Year],
        b.[Isbn],
        b.[Image],
        b.[Token],
        b.[CreateDate],
        b.[EditDate],
        a.[BookId],
        a.[Id],
        a.[FirstName],
        a.[LastName]
    FROM [dbo].[Book] b
        LEFT JOIN [dbo].[Author] a
            ON a.[BookId] = b.[Id]
    WHERE b.[Id] = @BookId
        AND b.[Token] = @Token
    ORDER BY a.FirstName, a.LastName

END
