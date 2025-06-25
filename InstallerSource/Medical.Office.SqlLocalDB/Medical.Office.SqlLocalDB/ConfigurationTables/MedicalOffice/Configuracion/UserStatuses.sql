CREATE TABLE [dbo].[UserStatuses]
(
	[Id] INT NOT NULL  IDENTITY, 
    [TypeUserStatuses] VARCHAR(50) NOT NULL, 
    PRIMARY KEY ([TypeUserStatuses])
)
