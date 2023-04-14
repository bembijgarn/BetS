# BS


* Database
    
<pre>
CREATE DATABASE BSAPI
GO

USE BSAPI
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Name NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
    Email NVARCHAR(MAX),
    IdentityId FLOAT
);

CREATE TABLE Accounts (
    Id INT PRIMARY KEY,
    UserName NVARCHAR(MAX),
    Password NVARCHAR(MAX),
    Balance DECIMAL(18,2),
    BankCard FLOAT,
    userId INT FOREIGN KEY REFERENCES Users(Id)
);

CREATE TABLE Transactions (
    Id INT PRIMARY KEY,
    Type NVARCHAR(MAX),
    Amount DECIMAL(18,2),
    CurrentBalance DECIMAL(18,2),
    Datetime DATETIME,
    userId INT FOREIGN KEY REFERENCES Users(Id),
    Status NVARCHAR(MAX)
);

CREATE TABLE Tokens (
    Id INT PRIMARY KEY,
    TokenId UNIQUEIDENTIFIER,
    userId INT FOREIGN KEY REFERENCES Users(Id)
);

</pre>

    

 





 
