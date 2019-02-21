USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertArtistXWithOutput]    Script Date: 21/02/2019 8:36:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[usp_InsertArtistXWithOutput]
(
	@Name NVARCHAR(120),
	@ID int OUTPUT
)
as
BEGIN
	INSERT INTO Artist(Name)
	VALUES(@Name)
	
	--PARA CAPTURAR EL ID INGRESADO
	SET @ID= SCOPE_IDENTITY()
	--SELECT @@IDENTITY()--TOMA EL ULTIMO VALOR DE CUALQUIER SETENCIA
END
