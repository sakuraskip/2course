CREATE DATABASE YachtRental;


drop database YachtRental
CREATE TABLE ShipModel (
    Id INT PRIMARY KEY Identity(1,1),
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price int,
    Availability VARCHAR(100),
	ImagePath varchar(500), -- заменить на varbinary
    ShipType varchar(100),
    UnavailableDates TEXT --json?
);
CREATE TABLE UserModel (
    Id INT PRIMARY KEY  Identity(1,1),
    Role VARCHAR(50),
    Login VARCHAR(100) NOT NULL UNIQUE,
	Username VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    ProfilePicture varbinary(max)
);

CREATE TABLE Rental (
    Id INT PRIMARY KEY  Identity(1,1),
    ShipId INT,
    UserId INT,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Status VARCHAR(50),
    Cost int,
    FOREIGN KEY (ShipId) REFERENCES ShipModel(Id) ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES UserModel(Id) ON DELETE CASCADE
);
CREATE TABLE Reviews (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ShipId INT foreign key references ShipModel(Id) NOT NULL,
    UserId INT foreign key references UserModel(Id) NOT NULL,
    Username NVARCHAR(100),
    Comment NVARCHAR(MAX),
    Rating INT NOT NULL CHECK (Rating >= 1 AND Rating <= 5)  
);
select * from Rental
select * from ShipModel
select * from UserModel