CREATE PROCEDURE [dbo].[Book_Add]
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

	INSERT INTO [dbo].[Book] (
		[Id],
		[Title],
		[PageCount],
		[Publisher],
		[Year],
		[Isbn],
		[Image],
		[CreateDate],
		[EditDate]
	)
	VALUES (
		@Id,
		@Title,
		@PageCount,
		@Publisher,
		@Year,
		@Isbn,
		@Image,
		@CurrentUtcDate,
		@CurrentUtcDate
	)

END
