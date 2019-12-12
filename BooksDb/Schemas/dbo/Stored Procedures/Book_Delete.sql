CREATE PROCEDURE [dbo].[Book_Delete]
	@BookId		UNIQUEIDENTIFIER,
	@Token	UNIQUEIDENTIFIER
AS
BEGIN

	DELETE FROM [dbo].[Book]
	WHERE [Id] = @BookId
		AND [Token] = @Token

END
