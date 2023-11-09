-- Create a new database
CREATE DATABASE OrganizationDB;
GO

-- Switch to the newly created database
USE OrganizationDB;
GO

-- Create the Organizations table
CREATE TABLE Organizations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CreatedAt DATETIME2 NOT NULL,
    Name NVARCHAR(255) NOT NULL
);
GO

-- Create the Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrganizationId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Avatar NVARCHAR(255),
    CONSTRAINT FK_Users_Organizations FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id)
);
GO

-- Create the Phones table
CREATE TABLE Phones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Blacklisted BIT NOT NULL,
    CONSTRAINT FK_Phones_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Indexes for foreign keys could be created for better performance during JOIN operations
CREATE INDEX IDX_Users_OrganizationId ON Users(OrganizationId);
GO

CREATE INDEX IDX_Phones_UserId ON Phones(UserId);
GO

-- Optionally, create an index on the Blacklisted column if you'll frequently filter on this
CREATE INDEX IDX_Phones_Blacklisted ON Phones(Blacklisted);
GO
