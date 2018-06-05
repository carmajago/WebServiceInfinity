CREATE TRIGGER NombresNebulosa
	ON Nebulosas
	AFTER  INSERT
	AS
	
	BEGIN
		UPDATE Nebulosas SET nombre =(select nombre from Nombres where id=(select 1+ROUND(RAND()*(70-1),0))) where id = (select id from inserted)
	
	END