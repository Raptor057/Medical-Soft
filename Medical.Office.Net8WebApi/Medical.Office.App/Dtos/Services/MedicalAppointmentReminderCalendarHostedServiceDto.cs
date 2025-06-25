namespace Medical.Office.App.Dtos.Services
{
    public record MedicalAppointmentReminderCalendarHostedServiceDto(

        long Id,
        long IDPatient,
        string PatientFullName,
        string Email,
        string PhoneNumber,
        long IDDoctor,
        string DoctorFullName,
        DateTime? AppointmentDateTime,
        string ReasonForVisit,
        string AppointmentStatus,
        string Notes,
        DateTime? EndOfAppointmentDateTime,
        DateTime? CreatedAt,
        DateTime? UpdatedAt,
        string TypeOfAppointment
    );
}
