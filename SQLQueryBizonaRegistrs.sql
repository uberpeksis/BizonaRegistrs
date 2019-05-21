CREATE TABLE Participants (
	Id INT IDENTITY (1,1),
	parName VARCHAR	(50),
	parSurname VARCHAR (50),
	parNumber INT,
	parAgeGroup VARCHAR (4),
	parRaceTime INT,
	parPoints INT
);

INSERT INTO Participants(parName, parSurname, parNumber, parAgeGroup, parRaceTime, parPoints)
VALUES('Jānis', 'Bērzs', 1, 'V 10', 150, 200)

DELETE FROM Participants
WHERE Id = 8

SELECT *
FROM Participants


