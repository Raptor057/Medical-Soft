using Medical.Office.Domain.Entities.MedicalOffice.Views;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class HostedServicesSqlDb
{
    private readonly ConfigurationSqlDbConnection<HostedServicesSqlDb> _con;
    private readonly ILogger<HostedServicesSqlDb> _logger;

    public HostedServicesSqlDb(ILogger<HostedServicesSqlDb> logger, ConfigurationSqlDbConnection<HostedServicesSqlDb> con)
    {
        _con = con;
        _logger = logger;
    }
    
    public async Task UpdateAppointmentStatus()
        => await _con.ExecuteAsync(@"UPDATE MedicalAppointmentCalendar SET AppointmentStatus = 'Inactiva' WHERE EndOfAppointmentDateTime <= GETUTCDATE() AND AppointmentStatus = 'Activa';").ConfigureAwait(false);

    public async Task<IEnumerable<MedicalAppointmentReminderCalendarHostedService>> GetMedicalAppointmentRemindersCalendarList()
        => await _con.QueryAsync<MedicalAppointmentReminderCalendarHostedService>(@"
                SELECT 
                MAC.[Id],
                MAC.[IDPatient],
                CONCAT(PD.Name, ' ', PD.FathersSurname, ' ', PD.MothersSurname) AS [PatientFullName],
                PD.Email,
                PD.PhoneNumber,
                MAC.[IDDoctor],
                CONCAT(D.FirstName, ' ', D.LastName) AS [DoctorFullName],
                dbo.[UfnToLocalTime](MAC.[AppointmentDateTime]) AS [AppointmentDateTime],
                MAC.[ReasonForVisit],
                MAC.[AppointmentStatus],
                MAC.[Notes],
                MAC.[EndOfAppointmentDateTime],
                MAC.[CreatedAt],
                MAC.[UpdatedAt],
                MAC.[TypeOfAppointment]
                FROM 
                [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] MAC
                INNER JOIN 
                PatientData PD ON PD.[ID] = MAC.[IDPatient]
                INNER JOIN 
                Doctors D ON MAC.[IDDoctor] = D.[ID]
                WHERE 
                MAC.[AppointmentStatus] = 'Activa' 
                AND MAC.[AppointmentDateTime] BETWEEN GETUTCDATE() + 1 AND DATEADD(HOUR, 1, GETUTCDATE() + 1);
                ", new {}).ConfigureAwait(false);

}