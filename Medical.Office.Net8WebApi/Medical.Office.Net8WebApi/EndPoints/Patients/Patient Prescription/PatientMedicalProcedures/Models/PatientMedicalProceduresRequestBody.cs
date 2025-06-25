namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures.Models
{
    public class PatientMedicalProceduresRequestBody
    {
        public long IDPatient { get; set; }

        public long IDAppointment { get; set; }

        public string MedicalProceduresTypes { get; set; }

        public string Comments { get; set; }
    }
}
