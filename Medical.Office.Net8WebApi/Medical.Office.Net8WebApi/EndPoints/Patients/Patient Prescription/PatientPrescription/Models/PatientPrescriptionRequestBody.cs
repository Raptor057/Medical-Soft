namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription.Models
{
    public class PatientPrescriptionRequestBody
    {
        public long IDPatient { get; set; }

        public long IDAppointment { get; set; }

        public string ConsultationNotes { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public decimal? BodyMassIndex { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? RespiratoryRate { get; set; }

        public decimal? SystolicPressure { get; set; }

        public decimal? DiastolicPressure { get; set; }

        public decimal? HeartRate { get; set; }

        public decimal? BodyFatPercentage { get; set; }

        public decimal? MuscleMassPercentage { get; set; }

        public decimal? HeadCircumference { get; set; }

        public decimal? OxygenSaturation { get; set; }
    }
}
