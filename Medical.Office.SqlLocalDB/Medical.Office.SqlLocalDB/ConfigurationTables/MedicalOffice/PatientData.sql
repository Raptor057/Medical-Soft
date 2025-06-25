CREATE TABLE [dbo].[PatientData]
(
	[ID] BIGINT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(255) NOT NULL, 
    [FathersSurname] VARCHAR(255) NOT NULL, 
    [MothersSurname] VARCHAR(255) NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Gender] NCHAR(10) NULL, 
    [Address] VARCHAR(MAX) NULL,
    [Country] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [State] VARCHAR(50) NULL, 
    [ZipCode] VARCHAR(50) NULL, 
    [OutsideNumber] NCHAR(10) NULL, 
    [InsideNumber] NCHAR(10) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [EmergencyContactName] VARCHAR(50) NULL, 
    [EmergencyContactPhone] VARCHAR(50) NULL, 
    [InsuranceProvider] VARCHAR(50) NULL, 
    [PolicyNumber] VARCHAR(50) NULL, 
    [BloodType] VARCHAR(50) NULL, 
    [DateCreated] DATETIME NULL DEFAULT GetDate(), 
    [LastUpdated] DATETIME NULL DEFAULT GetDate(), 
    [Photo] VARBINARY(MAX) NULL, 

    [InternalNotes] VARCHAR(MAX) NULL, 
    CONSTRAINT [PK_PatientData] PRIMARY KEY ([ID]) 
)
