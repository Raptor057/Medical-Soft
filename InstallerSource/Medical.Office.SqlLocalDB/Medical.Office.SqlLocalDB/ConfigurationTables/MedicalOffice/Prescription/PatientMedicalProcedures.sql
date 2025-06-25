CREATE TABLE [dbo].[PatientMedicalProcedures]
(
  -- Permite varios en una cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [MedicalProceduresTypes] VARCHAR(MAX) NULL,
  [Comments] VARCHAR(MAX) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)