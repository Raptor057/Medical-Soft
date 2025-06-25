CREATE TABLE [dbo].[UsersMovements]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Usr] VARCHAR(20) NULL, 
    [UsrName] VARCHAR(50) NULL,
    [UsrRole] VARCHAR(50) NULL, 
    [UsrMovement] VARCHAR(MAX) NULL,
    [UsrToken] VARCHAR(MAX) NULL, 
    [DateTimeSnap] DATETIME NULL DEFAULT GETDATE()
)
