 DECLARE @PatientID INT;
DECLARE @DateStart DATE = '2024-12-01';
DECLARE @DateEnd DATE = '2025-01-31';
DECLARE @TimeStart TIME = '07:00:00';
DECLARE @TimeEnd TIME = '19:00:00';

-- Loop through 1000 patients
SET @PatientID = 1;
WHILE @PatientID <= 1000
BEGIN
    -- Generate 1000 appointments for each patient
    DECLARE @Counter INT = 1;
    WHILE @Counter <= 1000
    BEGIN
        -- Generate random date between @DateStart and @DateEnd
        DECLARE @RandomDate DATE = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @DateStart, @DateEnd) + 1), @DateStart);

        -- Generate random time between @TimeStart and @TimeEnd
        DECLARE @RandomTime TIME = DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % DATEDIFF(SECOND, @TimeStart, @TimeEnd), @TimeStart);

        -- Insert the appointment into the table
        INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar]
        ([IDPatient], [IDDoctor], [AppointmentDate], [AppointmentTime], [ReasonForVisit], [AppointmentStatus], [Notes], [TypeOfAppointment])
        VALUES
        (@PatientID, 1, @RandomDate, @RandomTime, 'Routine check-up', 'Scheduled', 'Patient requested a morning appointment','Consulta');

        SET @Counter = @Counter + 1;
    END

    SET @PatientID = @PatientID + 1;
END
