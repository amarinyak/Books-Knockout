CREATE PROCEDURE [dbo].[Author_Merge]
	@AuthorCollection [dbo].[AuthorCollection] READONLY
AS
BEGIN

	WITH FilteredAuthors AS (
		SELECT *
		FROM [dbo].[Author] a
		WHERE a.[BookId] IN (SELECT DISTINCT BookId FROM @AuthorCollection)
	)

	MERGE FilteredAuthors t USING @AuthorCollection s
	ON (s.[Id] = t.[Id])
	WHEN MATCHED THEN
        UPDATE SET
			t.[BookId] = s.[BookId],
			t.[FirstName] = s.[FirstName],
			t.[LastName] = s.[LastName]
	WHEN NOT MATCHED THEN  
        INSERT (
			[Id],
			[BookId],
			[FirstName],
			[LastName]
		)
		VALUES (
			s.[Id],
			s.[BookId],
			s.[FirstName],
			s.[LastName]
		)
	WHEN NOT MATCHED BY SOURCE
		THEN DELETE;

END
