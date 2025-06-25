namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications.Models
{
    public class PatientPrescriptionOfMedicationsRequestBody
    {
        public long IDPatient { get; set; }

        public long IDAppointment { get; set; }

        public string Medications { get; set; }

        public string Dose { get; set; }

        public string Frequency { get; set; }

        public string Duration { get; set; }

        public string Comments { get; set; }
    }
}
