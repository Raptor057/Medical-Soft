using Medical.Office.Domain.Entities.MedicalOffice;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class MedicalAppointmentCalendarSqlDb
{
    private readonly ConfigurationSqlDbConnection<MedicalAppointmentCalendarSqlDb> _con;
    private readonly ILogger<MedicalAppointmentCalendarSqlDb> _logger;

    public MedicalAppointmentCalendarSqlDb(ILogger<MedicalAppointmentCalendarSqlDb> logger, ConfigurationSqlDbConnection<MedicalAppointmentCalendarSqlDb> con)
    {
        _con = con;
        _logger = logger;
    }
    
    
        public async Task<int> MedicalAppointmentCalendarIsOverlapping(long IDDoctor, DateTime AppointmentDateTime)
            => await _con.QueryFirstAsync<int>(@"SELECT CASE
    WHEN EXISTS (
        SELECT 1
        FROM MedicalAppointmentCalendar
        WHERE IDDoctor = @IDDoctor
          AND (
              (dbo.UfnToUniversalTime(@AppointmentDateTime) >= AppointmentDateTime AND dbo.UfnToUniversalTime(@AppointmentDateTime) < EndOfAppointmentDateTime)
              OR (DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  > AppointmentDateTime 
                  AND DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  <= EndOfAppointmentDateTime)
              OR (dbo.UfnToUniversalTime(@AppointmentDateTime) <= AppointmentDateTime AND DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  >= EndOfAppointmentDateTime)
          )
    )
    THEN 1
    ELSE 0
    END AS IsOverlapping", new {IDDoctor,AppointmentDateTime }).ConfigureAwait(false);
        
        public async Task<long> InsertMedicalAppointmentCalendar(MedicalAppointmentCalendar medicalAppointmentCalendar)
        {
            var query = @"
        INSERT INTO MedicalAppointmentCalendar 
        (IDPatient, IDDoctor, AppointmentDateTime, ReasonForVisit, Notes, EndOfAppointmentDateTime, TypeOfAppointment) 
        OUTPUT INSERTED.Id
        VALUES(@IDPatient, @IDDoctor, dbo.UfnToUniversalTime(@AppointmentDateTime), 
               @ReasonForVisit, @Notes, 
               (SELECT DATEADD(MINUTE, (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), 
               dbo.UfnToUniversalTime(@AppointmentDateTime))), 
               @TypeOfAppointment)";

            return await _con.ExecuteScalarAsync<long>(query, new
            {
                medicalAppointmentCalendar.IDPatient,
                medicalAppointmentCalendar.IDDoctor,
                medicalAppointmentCalendar.AppointmentDateTime,
                medicalAppointmentCalendar.ReasonForVisit,
                medicalAppointmentCalendar.Notes,
                medicalAppointmentCalendar.TypeOfAppointment
            }).ConfigureAwait(false);
        }

        
        public async Task<MedicalAppointmentCalendar> GetAppointmentById(long appointmentId)
        {
            var query = @"
        SELECT Id, IDPatient, IDDoctor, AppointmentDateTime, ReasonForVisit, Notes, EndOfAppointmentDateTime, TypeOfAppointment
        FROM MedicalAppointmentCalendar 
        WHERE Id = @Id";

            return await _con.QuerySingleAsync<MedicalAppointmentCalendar>(query, new { Id = appointmentId });
        }


        public async Task UpdateMedicalAppointmentCalendar(MedicalAppointmentCalendar medicalAppointmentCalendar)
            => await _con.ExecuteAsync(@"UPDATE MedicalAppointmentCalendar 
                SET 
                IDDoctor = @IDDoctor, 
                AppointmentDateTime = dbo.UfnToUniversalTime(@AppointmentDateTime), 
                ReasonForVisit = @ReasonForVisit, 
                AppointmentStatus = 'Activa', 
                EndOfAppointmentDateTime = (SELECT DATEADD(MINUTE, (SELECT TOP 1 MedicalConsultationMinutesForPatients  FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime))), 
                UpdatedAt = GETUTCDATE(), 
                TypeOfAppointment = @TypeOfAppointment 
            WHERE Id = @Id;", new
            {
                medicalAppointmentCalendar.IDDoctor,
                medicalAppointmentCalendar.AppointmentDateTime,
                medicalAppointmentCalendar.ReasonForVisit,
                medicalAppointmentCalendar.TypeOfAppointment,
                medicalAppointmentCalendar.Id
            }).ConfigureAwait(false);
        
        public async Task <IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatient(long IdPatient)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT 
            Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime](Mac.[EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            WHERE Mac.IDPatient = @IdPatient 
            ORDER BY Mac.AppointmentDateTime DESC",
            new { IdPatient }).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctor(long IdDoctor)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT 
            Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime](Mac.[EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            WHERE Mac.IDDoctor = @IdDoctor AND Mac.AppointmentStatus = 'Activa' 
            ORDER BY Mac.AppointmentDateTime DESC",
            new { IdDoctor }).ConfigureAwait(false);
        
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendar()
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime]([EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            ORDER BY Mac.AppointmentDateTime DESC",
            new { }).ConfigureAwait(false);
    
}