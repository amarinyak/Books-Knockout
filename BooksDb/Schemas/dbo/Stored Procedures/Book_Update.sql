CREATE PROCEDURE [dbo].[Book_Update]
	@Id			UNIQUEIDENTIFIER,
    @Title		NVARCHAR(200),
    @PageCount	SMALLINT,
    @Publisher	NVARCHAR(200),
    @Year		SMALLINT,
    @Isbn		BIGINT,
    @Image		NVARCHAR(MAX)
AS
BEGIN

	DECLARE @CurrentUtcDate DATETIME2(7) = SYSUTCDATETIME();

	UPDATE [dbo].[Book]
	SET
		[Title] = @Title,
		[PageCount] = @PageCount,
		[Publisher] = @Publisher,
		[Year] = @Year,
		[Isbn] = @Isbn,
		[Image] = @Image,
		[EditDate] = @CurrentUtcDate
	WHERE [Id] = @Id

END
