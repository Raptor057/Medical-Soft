CREATE TABLE [dbo].[PatientLaboratoryAndImagingRequests]
(
  -- Permite varios en 1 cita
  [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [IDPatient] BIGINT NOT NULL,
  [IDAppointment] BIGINT NOT NULL,
  [MedicalStudiesOrImagesTypes] VARCHAR(MAX) NULL,
  [Comments] VARCHAR(MAX) NULL,
  [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
)
