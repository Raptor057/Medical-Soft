namespace Medical.Office.Domain.Entities.MedicalOffice.Prescription;

public class PatientPrescriptionOfMedications
{
    public long Id { get; set; }

    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string Medications { get; set; }

    public string Dose { get; set; }

    public string Frequency { get; set; }

    public string Duration { get; set; }

    public string Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

}