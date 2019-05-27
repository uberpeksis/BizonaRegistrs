CREATE TABLE Participants (
	Id INT IDENTITY (1,1),
	parName VARCHAR	(50),
	parSurname VARCHAR (50),
	parNumber INT,
	parAgeGroup VARCHAR (4),
	parRaceTime1 INT,
	parRaceTime2 INT,
	parRaceTime3 INT,
	parRaceTime4 INT,
	parRaceTime5 INT,
	parRaceTime6 INT,
	parRaceTime7 INT,
	parRaceTime8 INT,
	parPoints1 INT,
	parPoints2 INT,
	parPoints3 INT,
	parPoints4 INT,
	parPoints5 INT,
	parPoints6 INT,
	parPoints7 INT,
	parPoints8 INT,
	parPointsSum INT
);

UPDATE Participants SET parPointsSum = @p1 WHERE id = @p2



SELECT * FROM Participants WHERE parAgeGroup = 'V 21'

SELECT TOP 1 "parRaceTime1" FROM Participants WHERE parAgeGroup = 'V 21'

SELECT * FROM Participants WHERE parAgeGroup = 'V 21'

SELECT TOP 1 parRaceTime1 FROM Participants WHERE parAgeGroup = 'V 21' Order BY parRaceTime1

SELECT *
FROM Participants

SELECT Id, parName, parSurname, parNumber, parAgeGroup, parRaceTime1, parPoints1
FROM Participants Order by parPoints1 DESC

SELECT parRaceTime1 
FROM Participants 
WHERE Id = 1 

INSERT INTO Participants(parName, parSurname, parNumber, parAgeGroup, )
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



