CREATE TABLE [dbo].[PatientsFiles]
(
    [Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IDPatient] BIGINT NOT NULL, -- Referencia al ID del paciente
    [IDAppointment] BIGINT NULL,
    [FileName] NVARCHAR(MAX) NOT NULL, -- Nombre del archivo completo
    [FileType] NVARCHAR(50) NOT NULL, -- Tipo de archivo (e.g., Imagen, Documento)
    [FileExtension] NVARCHAR(10) NOT NULL, -- Extensión del archivo (e.g., jpg, pdf)
    [Description] NVARCHAR(MAX) NULL, -- Descripción opcional del archivo
    [FileData] VARBINARY(MAX) NOT NULL, -- Datos binarios completos del archivo
    [DateTimeUploaded] DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha y hora de la carga
    CONSTRAINT [FK_PatientsFiles_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID])
);
