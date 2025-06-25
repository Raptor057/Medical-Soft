CREATE TABLE [dbo].[PatientPrescriptionOfMedications]
(
  -- Permite varios registros en una cita 
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [Medications] VARCHAR(MAX) NULL,
  [Dose] VARCHAR(MAX) NULL,
  [Frequency] VARCHAR(MAX) NULL,
  [Duration] VARCHAR(MAX) NULL,
  [Comments] VARCHAR(MAX) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)
