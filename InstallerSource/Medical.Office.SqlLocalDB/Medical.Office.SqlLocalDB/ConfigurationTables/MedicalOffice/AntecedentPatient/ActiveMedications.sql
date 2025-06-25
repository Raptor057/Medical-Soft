CREATE TABLE [dbo].[ActiveMedications]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IDPatient] BIGINT NOT NULL, 
    [ActiveMedicationsData] VARCHAR(MAX) NULL, 
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_ActiveMedications_PatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
