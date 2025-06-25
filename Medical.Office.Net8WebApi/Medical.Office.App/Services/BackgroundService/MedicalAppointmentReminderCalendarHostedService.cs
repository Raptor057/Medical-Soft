using Azure.Core;
using Medical.Office.App.UseCases.Email.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Medical.Office.App.Services.BackgroundService
{
    internal class MedicalAppointmentReminderCalendarHostedService : IHostedService
    {
        private readonly ILogger<MedicalAppointmentReminderCalendarHostedService> _logger;
        private readonly IPatientsData _patients;
        private readonly EmailService _emailService;
        private readonly EmailTemplates _emailTemplates;
        private Timer? _timer;
        string emailPattern = @"^(?<username>[\w\.\-]+)@(?<domain>[\w\-]+)(?<tld>(\.(\w){2,3})+)$";

        public MedicalAppointmentReminderCalendarHostedService(ILogger<MedicalAppointmentReminderCalendarHostedService> logger, IPatientsData patients, EmailService emailService, EmailTemplates emailTemplates)
        {
            _logger = logger;
            _patients = patients;
            _emailService = emailService;
            _emailTemplates = emailTemplates;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Medical Appointment Calendar Background Worker started.");

            // Configura el Timer para ejecutar la tarea periódicamente.
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            await Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            var getAppAppointment = await _patients.GetMedicalAppointmentRemindersCalendarListAsync().ConfigureAwait(false);

            if (getAppAppointment == null)
            {
                _logger.LogInformation($"Medical Appointment Calendar Background Worker: {DateTimeOffset.Now} NULL ");
            }
            else
            {
                int CountAppointments = getAppAppointment.Count();

                for (int i = 0; i < CountAppointments; i++)
                {
                    var appointment = getAppAppointment.ElementAt(i);
                    var appointmentDateTime = appointment.AppointmentDateTime;
                    var appointmentStatus = appointment.AppointmentStatus;
                    var patientFullName = appointment.PatientFullName;
                    var email = appointment.Email;
                    var phoneNumber = appointment.PhoneNumber;
                    var doctorFullName = appointment.DoctorFullName;
                    var reasonForVisit = appointment.ReasonForVisit;
                    var notes = appointment.Notes;
                    var endOfAppointmentDateTime = appointment.EndOfAppointmentDateTime;
                    var typeOfAppointment = appointment.TypeOfAppointment;

                    if (email != null && Regex.IsMatch(email, emailPattern))
                    {
                        if (appointmentStatus == "Activa")
                        {
                            _logger.LogInformation($"Count: {i + 1}/{CountAppointments}  \nSend Reminder to {patientFullName} to email {email} at {DateTimeOffset.Now}");

                            _emailService.SendEmailAsync(email, $"Recordatorio de cita para {patientFullName} Con el Dr. {doctorFullName} con fecha de {appointmentDateTime}", _emailTemplates.GetAppointmentReminderTemplate(patientFullName, doctorFullName, appointmentDateTime));
                        }
                        await Task.Delay(1000);
                    }
                    else
                    {
                        _logger.LogInformation($"Email is not valid for {patientFullName} at {DateTimeOffset.Now}");
                    }
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Medical Appointment Calendar Background Worker is stopping.");
            _timer?.Change(Timeout.Infinite, 0); // Detiene el Timer.
            await Task.CompletedTask;
        }
    }
}
