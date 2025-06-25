CREATE TABLE [dbo].[PatientTreatmentPlan]
(
  -- Permite varios registros en una cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [TreatmentPlan] VARCHAR(MAX) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)
