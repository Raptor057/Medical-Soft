CREATE TABLE [dbo].[FamilyHistory]
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
    IDPatient bigint NOT NULL,
    Diabetes BIT,
    Cardiopathies BIT,
    Hypertension BIT, -- Hipertensión Arterial
    ThyroidDiseases BIT, -- Enfermedades Tiroideas
    ChronicKidneyDisease BIT, -- Enfermedad Renal Crónica
    Others BIT, 
    [OthersData] VARCHAR(50) NULL, 
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_FamilyHistory_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
