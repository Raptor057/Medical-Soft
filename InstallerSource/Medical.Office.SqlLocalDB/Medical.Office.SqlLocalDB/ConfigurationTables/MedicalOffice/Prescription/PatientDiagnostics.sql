CREATE TABLE [dbo].[PatientDiagnostics]
(
  -- Permite varios en 1 cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [DiagnosticsType] VARCHAR(MAX) NULL,
  [Comments] VARCHAR(MAX) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)
