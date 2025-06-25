CREATE TABLE [dbo].[PatientAllergies]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IDPatient] BIGINT NOT NULL, 
    [Allergies] VARCHAR(MAX) NULL, 
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_PatientAllergies_ToPatientData] FOREIGN KEY (IDPatient) REFERENCES [PatientData]([ID])
)
