CREATE TRIGGER NombresSistemaPlanetarios
	ON SistemaPlanetarios
	AFTER  INSERT
	AS
	
	BEGIN
		UPDATE SistemaPlanetarios SET nombre =(select nombre from Nombres where id=(select 1+ROUND(RAND()*(70-1),0))) where id = (select id from inserted)
	
	END
