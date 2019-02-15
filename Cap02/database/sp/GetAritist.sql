use Chinook
go


CREATE PROCEDURE usp_GetGenre
(
	@pNombre NVARCHAR(100)
)
as

BEGIN
	SELECT GenreId,Name FROM Genre
	WHERE NAME LIKE @pNombre
END


create procedure usp_InsertGenreX
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



create procedure usp_InsertArtistXWithOutput
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

--usp_UpdateArtistX

create procedure usp_UpdateArtistX
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

CREATE PROCEDURE usp_InsertArtist  
select top 10 * from Artist with(nolock) order by Artistid desc

sp_helptext usp_InsertArtist

select top 10* from Artist with (nolock) order by ArtistId desc