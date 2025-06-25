CREATE TABLE [dbo].[LaboralDays]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Days] VARCHAR(50) NOT NULL,
    [Laboral] BIT NOT NULL DEFAULT 1,
    [OpeningTime] TIME(0) NOT NULL, 
    [ClosingTime] TIME(0) NOT NULL 
)
