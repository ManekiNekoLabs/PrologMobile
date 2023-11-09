USE OrganizationDB;
GO

-- Allow explicit values to be inserted into the identity column 'Id'
SET IDENTITY_INSERT Organizations ON;
GO
INSERT INTO Organizations (Id, CreatedAt, Name)
VALUES
(1, '2021-04-19T13:45:37.621Z', 'Mrs. Sasha Jakubowski'),
(2, '2021-04-19T09:19:17.052Z', 'Bud Heller'),
-- ... add all other organizations here ...
(50, '2021-04-19T04:21:52.035Z', 'Destini Koch');
GO
-- Disallow explicit values and revert to the identity auto-generation
SET IDENTITY_INSERT Organizations OFF;
GO



-- Allow explicit values to be inserted into the identity column 'Id'
SET IDENTITY_INSERT Users ON;
GO
INSERT INTO Users (Id, OrganizationId, CreatedAt, Name, Avatar)
VALUES
(1, 1, '2021-04-18T22:27:37.490Z', 'Bertha Turner', 'https://s3.amazonaws.com/uifaces/faces/twitter/sunlandictwin/128.jpg');
GO
-- Disallow explicit values and revert to the identity auto-generation
SET IDENTITY_INSERT Users OFF;
GO



-- Allow explicit values to be inserted into the identity column 'Id'
SET IDENTITY_INSERT Phones ON;
GO
INSERT INTO Phones (Id, UserId, CreatedAt, Name, Blacklisted)
VALUES
(1, 1, '2021-04-19T16:27:55.026Z', 'Dejuan Upton MD', 0);
GO
-- Disallow explicit values and revert to the identity auto-generation
SET IDENTITY_INSERT Phones OFF;
GO
