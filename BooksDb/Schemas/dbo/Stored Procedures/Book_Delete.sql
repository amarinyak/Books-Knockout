﻿CREATE PROCEDURE [dbo].[Book_Delete]
	@Id UNIQUEIDENTIFIER
AS
BEGIN

	DELETE FROM [dbo].[Book]
	WHERE [Id] = @Id

END