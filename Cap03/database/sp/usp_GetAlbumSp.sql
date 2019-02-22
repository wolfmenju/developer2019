USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAlbumSp]    Script Date: 21/02/2019 8:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetAlbumSp]
(
	@pTitle NVARCHAR(100)
)
as

BEGIN
	SELECT AlbumId,Title FROM Album
	WHERE Title LIKE @pTitle
END
