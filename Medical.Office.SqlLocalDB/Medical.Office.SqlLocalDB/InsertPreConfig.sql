/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- Query para insertar datos despues del despliegue de la DB


-- Para la tabla Genders
INSERT INTO Genders (Gender)
SELECT 'Masculino' WHERE NOT EXISTS (SELECT 1 FROM Genders WHERE Gender = 'Masculino');
GO
INSERT INTO Genders (Gender)
SELECT 'Femenino' WHERE NOT EXISTS (SELECT 1 FROM Genders WHERE Gender = 'Femenino');
GO
INSERT INTO UserStatuses (TypeUserStatuses)
SELECT 'Activo' WHERE NOT EXISTS (SELECT 1 FROM UserStatuses WHERE TypeUserStatuses = 'Activo');
GO
INSERT INTO UserStatuses (TypeUserStatuses)
SELECT 'Inactivo' WHERE NOT EXISTS (SELECT 1 FROM UserStatuses WHERE TypeUserStatuses = 'Inactivo');
GO
INSERT INTO Roles (RolesName)
SELECT 'Programador' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RolesName = 'Programador');
GO
INSERT INTO Roles (RolesName)
SELECT 'Doctor' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RolesName = 'Doctor');
GO
INSERT INTO Roles (RolesName)
SELECT 'Enfermera' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RolesName = 'Enfermera');
GO
INSERT INTO Roles (RolesName)
SELECT 'Secretaria' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RolesName = 'Secretaria');
GO
INSERT INTO Roles (RolesName)
SELECT 'Asistente' WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RolesName = 'Asistente');
GO
INSERT INTO Positions (PositionName)
SELECT 'Programador' WHERE NOT EXISTS (SELECT 1 FROM Positions WHERE PositionName = 'Programador');
GO
INSERT INTO Positions (PositionName)
SELECT 'Doctor' WHERE NOT EXISTS (SELECT 1 FROM Positions WHERE PositionName = 'Doctor');
GO
INSERT INTO Specialties (Specialty)
SELECT 'Desarollador' WHERE NOT EXISTS (SELECT 1 FROM Specialties WHERE Specialty = 'Desarollador');
GO
INSERT INTO Specialties (Specialty)
SELECT 'Cirujano' WHERE NOT EXISTS (SELECT 1 FROM Specialties WHERE Specialty = 'Cirujano');
GO
INSERT INTO Users (Usr, Psswd, [Name], Lastname, [Role], Position, Specialtie)
SELECT 'rarriaga', '1A09DF34D876AC0562CDE4723F105436C2D02616ADD65EA50EF83707DFE59BB5', 'Rogelio', 'Arriaga', 'Programador', 'Programador', 'Desarollador'
WHERE NOT EXISTS (
    SELECT 1 FROM Users 
    WHERE Usr = 'rarriaga' 
    AND Psswd = '1A09DF34D876AC0562CDE4723F105436C2D02616ADD65EA50EF83707DFE59BB5' 
    AND [Name] = 'Rogelio' 
    AND Lastname = 'Arriaga' 
    AND [Role] = 'Programador' 
    AND Position = 'Programador' 
    AND Specialtie = 'Desarollador'
);
GO
-- Usr: Admin
-- Psswd: Admin123*
INSERT INTO Users (Usr, Psswd, [Name], Lastname, [Role], Position, Specialtie)
SELECT 'Admin', '0A5BC3E342432F1BAD92FFD51B785343EC72906CDBA6A26131060B008E786656', 'Admin', 'System', 'Doctor', 'Doctor', 'Cirujano'
WHERE NOT EXISTS (
    SELECT 1 FROM Users 
    WHERE Usr = 'Admin' 
    AND Psswd = '0A5BC3E342432F1BAD92FFD51B785343EC72906CDBA6A26131060B008E786656' 
    AND [Name] = 'Admin' 
    AND Lastname = 'System' 
    AND [Role] = 'Doctor' 
    AND Position = 'Doctor' 
    AND Specialtie = 'Cirujano'
);
GO
-- Para la tabla LaboralDays
INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'lunes', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Lunes');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'martes', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Martes');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'miércoles', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Miércoles');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'jueves', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Jueves');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'viernes', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Viernes');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'sábado', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Sábado');
GO

INSERT INTO LaboralDays (Days, Laboral, OpeningTime, ClosingTime)
SELECT 'domingo', 1, '07:00:00', '19:00:00'
WHERE NOT EXISTS (SELECT 1 FROM LaboralDays WHERE Days = 'Domingo');
GO
INSERT INTO OfficeSetup (NameOfOffice, [Address])
SELECT 'N/A', 'N/A'
WHERE NOT EXISTS (
    SELECT 1 
    FROM OfficeSetup 
    WHERE NameOfOffice = 'N/A' 
    AND [Address]= 'N/A' 
);
GO
INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'monday', 'lunes'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'monday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'tuesday', 'martes'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'tuesday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'wednesday', 'miércoles'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'wednesday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'thursday', 'jueves'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'thursday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'friday', 'viernes'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'friday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'saturday', 'sábado'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'saturday');
GO

INSERT INTO DaysTranslation (DayInEnglish, DayInSpanish)
SELECT 'sunday', 'domingo'
WHERE NOT EXISTS (SELECT 1 FROM DaysTranslation WHERE DayInEnglish = 'sunday');
GO
INSERT INTO TypeOfAppointment (NameTypeOfAppointment)
SELECT 'Consulta' WHERE NOT EXISTS (
    SELECT 1 FROM TypeOfAppointment WHERE NameTypeOfAppointment = 'Consulta'
);
GO

INSERT INTO TypeOfAppointment (NameTypeOfAppointment)
SELECT 'Pre Operatorio' WHERE NOT EXISTS (
    SELECT 1 FROM TypeOfAppointment WHERE NameTypeOfAppointment = 'Pre Operatorio'
);
GO

INSERT INTO TypeOfAppointment (NameTypeOfAppointment)
SELECT 'Post Operatorio' WHERE NOT EXISTS (
    SELECT 1 FROM TypeOfAppointment WHERE NameTypeOfAppointment = 'Post Operatorio'
);
GO

INSERT INTO TypeOfAppointment (NameTypeOfAppointment)
SELECT 'Otros' WHERE NOT EXISTS (
    SELECT 1 FROM TypeOfAppointment WHERE NameTypeOfAppointment = 'Otros'
);
GO


INSERT INTO ConsultingTime(MedicalConsultationMinutesForPatients)
SELECT 30 WHERE NOT EXISTS (SELECT 1 FROM ConsultingTime WHERE MedicalConsultationMinutesForPatients = 30);
GO



