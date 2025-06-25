CREATE TABLE [dbo].[TypeOfAppointment]
(
	[Id] INT NOT NULL  IDENTITY, 
    [NameTypeOfAppointment] VARCHAR(50) NOT NULL, 
    PRIMARY KEY ([NameTypeOfAppointment])
)
