USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateArtistX]    Script Date: 21/02/2019 8:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[usp_UpdateArtistX]
(
	@Name NVARCHAR(120),
	@ID int 
)
as
BEGIN
	UPDATE Artist SET
	Name=@Name 
	WHERE ArtistId=@ID
END
