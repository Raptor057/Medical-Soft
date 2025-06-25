CREATE TABLE [dbo].[PathologicalBackground]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IDPatient] BIGINT NOT NULL,
    PreviousHospitalization BIT NULL,
    PreviousSurgeries BIT NULL,
    Diabetes BIT NULL,
    ThyroidDiseases BIT NULL,
    Hypertension BIT NULL,
    Cardiopathies BIT NULL,
    Trauma BIT NULL,
    Cancer BIT NULL,
    Tuberculosis BIT NULL,
    Transfusions BIT NULL,
    RespiratoryDiseases BIT NULL,
    GastrointestinalDiseases BIT NULL,
    STDs BIT NULL, -- Enfermedades de Transmisión Sexual
    STDsData VARCHAR(50) NULL, 
    ChronicKidneyDisease BIT NULL, -- Enfermedad Renal Crónica
    Others VARCHAR(MAX) NULL,
    [DateTimeSnap] DATETIME NULL DEFAULT GetDate(), 
    CONSTRAINT [FK_PathologicalBackground_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
)
