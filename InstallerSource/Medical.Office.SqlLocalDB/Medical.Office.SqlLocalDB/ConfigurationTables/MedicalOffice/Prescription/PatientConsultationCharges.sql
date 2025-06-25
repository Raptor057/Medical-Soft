CREATE TABLE [dbo].[PatientConsultationCharges]
(
  -- No permite varios en 1 cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [Description] VARCHAR(MAX) NULL,
  [Total] DECIMAL(18,2) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)
