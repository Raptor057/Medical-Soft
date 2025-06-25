namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientTreatmentPlan
{
    public class PatientTreatmentPlanRequestBody
    {
        public long IDPatient { get; set; }

        public long IDAppointment { get; set; }

        public string TreatmentPlan { get; set; }
    }
}
