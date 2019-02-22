USE [Chinook]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenreX]    Script Date: 21/02/2019 8:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[usp_InsertGenreX]
(
	@Name NVARCHAR(120)

)
as
BEGIN
	INSERT INTO Genre(Name)
	VALUES(@Name)
	
	--PARA CAPTURAR EL ID INGRESADO
	SELECT SCOPE_IDENTITY()
	--SELECT @@IDENTITY()--TOMA EL ULTIMO VALOR DE CUALQUIER SETENCIA
END

