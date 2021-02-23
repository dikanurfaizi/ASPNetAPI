CREATE OR ALTER PROCEDURE SP_InsertAccount
@Name nvarchar(50),
@Email nvarchar(30),
@Phone nvarchar(50),
@Address nvarchar(50),
@Birth date,
@Password nvarchar(30)
AS
BEGIN
INSERT INTO Tb_M_Trainee (Name,Email,Address,Phone,Birth)
VALUES (@Name,@Email,@Address,@Phone,@Birth)
INSERT INTO Tb_M_Account (Id,Password) VALUES 
((SELECT t.Id FROM Tb_M_Trainee t WHERE t.Email = @Email),@Password)
END
GO

CREATE OR ALTER PROCEDURE SP_RetrieveAccount
@Email nvarchar(30),
@Password nvarchar(30)
AS
BEGIN
SELECT t.Id,t.Email,a.Password FROM Tb_M_Trainee t JOIN Tb_M_Account a
ON t.Id=a.Id WHERE (t.Email = @Email OR t.Phone = @Email) AND a.Password = @Password
END
GO

CREATE OR ALTER PROCEDURE SP_UpdateTrainee
@Id int,
@Name nvarchar(50),
@Email nvarchar(30),
@Phone nvarchar(50),
@Address nvarchar(50),
@Birth date
AS
BEGIN
UPDATE Tb_M_Trainee SET Name = @Name, Email = @Email, Phone = @Phone,
Address = @Address, Birth = @Birth WHERE Id = @Id
END
GO

CREATE OR ALTER PROCEDURE SP_RetrieveTrainee
@Id int
AS
BEGIN
SELECT t.Id,t.Name,t.Email,t.Address,t.Phone,t.Birth FROM Tb_M_Trainee t 
WHERE t.Id = @Id
END
GO

CREATE OR ALTER PROCEDURE SP_UpdatePassword
@Email nvarchar(30),
@Password nvarchar(30)
AS
BEGIN
UPDATE Tb_M_Account SET Password = @Password WHERE Id = 
(SELECT Id FROM Tb_M_Trainee WHERE Email = @Email)
END
GO

CREATE OR ALTER PROCEDURE SP_RetrieveAllTrainee
AS
BEGIN
SELECT * FROM Tb_M_Trainee
END
GO