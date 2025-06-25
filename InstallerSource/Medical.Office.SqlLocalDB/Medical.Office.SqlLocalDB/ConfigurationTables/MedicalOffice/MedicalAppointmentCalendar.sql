CREATE TABLE [dbo].[MedicalAppointmentCalendar]
(
	Id bigint PRIMARY KEY IDENTITY(1,1),
    IDPatient bigint NOT NULL, -- ID del paciente
    [IDDoctor] bigint NOT NULL, -- ID del doctor
    AppointmentDateTime DATETIME NOT NULL,
    ReasonForVisit VARCHAR(MAX), -- Motivo de la visita
    AppointmentStatus VARCHAR(50) NOT NULL DEFAULT ('Activa'), -- Estado de la cita (ej. "Scheduled", "Completed", "Cancelled")
    Notes VARCHAR(MAX), -- Notas adicionales
    EndOfAppointmentDateTime DATETIME, --Fin de la cita
    CreatedAt DATETIME DEFAULT GETDATE(), -- Fecha de creación de la cita
    UpdatedAt DATETIME DEFAULT GETDATE(), -- -- Fecha de actualizacion de la cita
    [TypeOfAppointment] VARCHAR(50) NOT NULL, 
    -- Fecha de la última actualización
    CONSTRAINT [FK_MedicalAppointmentCalendar_ToPatientData] FOREIGN KEY ([IDPatient]) REFERENCES [PatientData]([ID]), 
    CONSTRAINT [FK_MedicalAppointmentCalendar_ToDoctors] FOREIGN KEY ([IDDoctor]) REFERENCES [Doctors]([ID]), 
    CONSTRAINT [FK_MedicalAppointmentCalendar_ToTypeOfAppointment] FOREIGN KEY ([TypeOfAppointment]) REFERENCES [TypeOfAppointment]([NameTypeOfAppointment]), 
)
