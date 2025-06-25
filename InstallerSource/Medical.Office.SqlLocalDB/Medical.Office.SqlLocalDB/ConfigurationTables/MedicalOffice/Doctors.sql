CREATE TABLE [dbo].[Doctors]
(
	ID BIGINT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(100) NOT NULL, -- Nombre del doctor
    LastName VARCHAR(100) NOT NULL, -- Apellido del doctor
    Specialty VARCHAR(100) NOT NULL, -- Especialidad del doctor
    PhoneNumber VARCHAR(20), -- Número de teléfono del doctor
    Email VARCHAR(100), -- Correo electrónico del doctor
    CreatedAt DATETIME DEFAULT GETDATE(), -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT GETDATE() -- Fecha de la última actualización
, 
    CONSTRAINT [FK_Doctors_ToSpecialities] FOREIGN KEY ([Specialty]) REFERENCES [Specialties]([Specialty]))
