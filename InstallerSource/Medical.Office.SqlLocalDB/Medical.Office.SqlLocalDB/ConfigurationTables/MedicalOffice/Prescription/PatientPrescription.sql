CREATE TABLE [dbo].[PatientPrescription]
(
  -- No permite varios registros en una misma cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [ConsultationNotes] VARCHAR(MAX) NULL,
    -- Signos vitales
    Height DECIMAL(5,2) NULL, -- en metros
    [Weight] DECIMAL(5,2) NULL, -- en kg
    BodyMassIndex DECIMAL(5,2) NULL, -- kg/m2
    Temperature DECIMAL(4,2) NULL, -- en °C
    RespiratoryRate DECIMAL(4,2) NULL, -- respiraciones por minuto
    SystolicPressure DECIMAL(5,2) NULL, -- mmHg
    DiastolicPressure DECIMAL(5,2) NULL, -- mmHg
    HeartRate DECIMAL(5,2) NULL, -- bpm
    BodyFatPercentage DECIMAL(5,2) NULL, -- %
    MuscleMassPercentage DECIMAL(5,2) NULL, -- %
    HeadCircumference DECIMAL(5,2) NULL, -- en cm
    OxygenSaturation DECIMAL(5,2) NULL, -- %
    -- Metadata
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME DEFAULT GETUTCDATE()
)