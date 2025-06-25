namespace Medical.Office.Domain.Entities.MedicalOffice.Views
{
    public class MedicalAppointmentReminderCalendarHostedService
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public string PatientFullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public long IDDoctor { get; set; }

        public string DoctorFullName { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string ReasonForVisit { get; set; }

        public string AppointmentStatus { get; set; }

        public string Notes { get; set; }

        public DateTime? EndOfAppointmentDateTime { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string TypeOfAppointment { get; set; }

    }
}
