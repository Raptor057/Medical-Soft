namespace Medical.Office.Domain.Entities.MedicalOffice.Prescription;

public class PatientTreatmentPlan
{
    public long Id { get; set; }

    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string TreatmentPlan { get; set; }

    public DateTime? CreatedAt { get; set; }

}