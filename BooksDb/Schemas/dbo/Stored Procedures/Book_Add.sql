CREATE PROCEDURE [dbo].[Book_Add]
    @Id             UNIQUEIDENTIFIER,
    @Title          NVARCHAR(200),
    @PageCount      SMALLINT,
    @Publisher      NVARCHAR(200),
    @Year           SMALLINT,
    @Isbn           VARCHAR(14),
    @Image          VARCHAR(MAX),
    @Token          UNIQUEIDENTIFIER
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
        [Token],
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
        @Token,
        @CurrentUtcDate,
        @CurrentUtcDate
    )

END
