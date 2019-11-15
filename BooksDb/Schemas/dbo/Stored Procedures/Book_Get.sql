CREATE PROCEDURE [dbo].[Book_Get]
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
		b.[CreateDate],
		b.[EditDate],
		a.[BookId],
		a.[Id],
		a.[FirstName],
		a.[LastName]
	FROM [dbo].[Book] b
		LEFT JOIN [dbo].[Author] a
			ON a.[BookId] = b.[Id]
	ORDER BY b.Title, a.FirstName, a.LastName

END
