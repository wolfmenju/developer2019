USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetGenre]    Script Date: 21/02/2019 8:35:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetGenre]
(
	@pNombre NVARCHAR(100)
)
as

BEGIN
	SELECT GenreId,Name FROM Genre
	WHERE NAME LIKE @pNombre
END
