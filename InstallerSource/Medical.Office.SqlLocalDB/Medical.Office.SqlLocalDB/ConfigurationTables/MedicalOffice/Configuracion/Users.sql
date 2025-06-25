CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Usr] VARCHAR(20) NOT NULL, 
    [Psswd] VARCHAR(MAX) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Role] VARCHAR(50) NOT NULL, 
    [Position] VARCHAR(255) NOT NULL, 
    [Status] VARCHAR(50) NULL DEFAULT 'Activo', 
    [Specialtie] VARCHAR(100) NOT NULL, 
    [TimeSnap] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Users_ToRoles] FOREIGN KEY ([Role]) REFERENCES [Roles]([RolesName]),
    CONSTRAINT [FK_Users_ToPositions] FOREIGN KEY ([Position]) REFERENCES [Positions]([PositionName]), 
    CONSTRAINT [FK_Users_ToUserStatuses] FOREIGN KEY ([Status]) REFERENCES [UserStatuses]([TypeUserStatuses]), 
    CONSTRAINT [FK_Users_ToSpecialties] FOREIGN KEY ([Specialtie]) REFERENCES [Specialties]([Specialty])
)
