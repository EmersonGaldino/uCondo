
USE uCondo
GO

create table [User]
(
    Id      INT IDENTITY(1,1) PRIMARY KEY,
    Email    Varchar(100) not null,
    Password varchar(100)
)
GO

INSERT INTO uCondo.dbo.[User] (Email, Password) 
VALUES ('emersongaldino@hotmail.com', '123456');
GO