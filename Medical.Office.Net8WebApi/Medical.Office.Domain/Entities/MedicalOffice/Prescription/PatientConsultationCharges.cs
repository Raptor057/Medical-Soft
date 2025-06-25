namespace Medical.Office.Domain.Entities.MedicalOffice.Prescription;

public class PatientConsultationCharges
{
    public long Id { get; set; }

    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string Description { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreatedAt { get; set; }

}