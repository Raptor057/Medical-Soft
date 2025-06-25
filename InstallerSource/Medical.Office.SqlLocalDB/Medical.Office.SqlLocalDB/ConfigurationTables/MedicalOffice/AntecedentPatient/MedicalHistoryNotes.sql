CREATE TABLE [dbo].[MedicalHistoryNotes]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IDPatient] BIGINT NULL, 
    [MedicalHistoryNotesData] VARCHAR(MAX) NULL, 
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_MedicalHistoryNotes_PatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
