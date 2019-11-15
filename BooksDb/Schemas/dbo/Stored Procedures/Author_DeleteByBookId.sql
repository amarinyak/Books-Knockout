CREATE PROCEDURE [dbo].[Author_DeleteByBookId]
	@BookId UNIQUEIDENTIFIER
AS
BEGIN

	DELETE FROM [dbo].[Author]
	WHERE [BookId] = @BookId

END
