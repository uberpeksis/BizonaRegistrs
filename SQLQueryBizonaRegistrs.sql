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

WHERE parAgeGroup = 'S 21'

SELECT TOP 1 parRaceTime
FROM Participants
WHERE parAgeGroup = 'V 21'
Order BY parRaceTime ASC

UPDATE Participants
SET parPoints = 200
WHERE id = 17

SELECT * 
FROM Participants
Order by Id ASC

SELECT TOP 1 parRaceTime FROM Participants WHERE parAgeGroup = 'V 21' Order BY parRaceTime DESC

SELECT * FROM Participants Order by parPoints DESC

DELETE FROM Participants
WHERE parAgeGroup = '2001'

SELECT Count(*) AS parAgeGroups
FROM (SELECT DISTINCT parAgeGroup FROM Participants)

SELECT DISTINCT parAgeGroup
FROM Participants;

SELECT Count(*) AS DistinctCountries
FROM (SELECT DISTINCT Country FROM Customers);



