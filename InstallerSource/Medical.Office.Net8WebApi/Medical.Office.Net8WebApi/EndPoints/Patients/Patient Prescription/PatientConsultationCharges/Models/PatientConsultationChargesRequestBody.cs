namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get.Models;

public class PatientConsultationChargesRequestBody
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string Description { get; set; }

    public decimal? Total { get; set; }
}