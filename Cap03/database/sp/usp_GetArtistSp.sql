USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetArtistSp]    Script Date: 21/02/2019 8:35:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[usp_GetArtistSp]
(
	@name NVARCHAR(100)
)

as

begin
SELECT ArtistId,Name FROM Artist WHERE Name like @name
end
