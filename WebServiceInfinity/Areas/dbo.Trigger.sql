CREATE TRIGGER nombreVialactea
	ON ViaLacteas
	after INSERT
	AS
	BEGIN
		INSERT INTO ViaLacteas VALUES(8,'SARIRA');
	END
