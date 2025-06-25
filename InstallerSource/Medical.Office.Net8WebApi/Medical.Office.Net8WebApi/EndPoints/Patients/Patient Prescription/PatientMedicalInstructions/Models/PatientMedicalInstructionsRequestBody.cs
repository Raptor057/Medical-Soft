namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalInstructions.Models
{
    public class PatientMedicalInstructionsRequestBody
    {
        public long IDPatient { get; set; }

        public long IDAppointment { get; set; }

        public string MedicalInstructions { get; set; }
    }
}
