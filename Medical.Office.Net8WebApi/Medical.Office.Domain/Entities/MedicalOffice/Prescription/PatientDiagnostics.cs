namespace Medical.Office.Domain.Entities.MedicalOffice.Prescription;

public class PatientDiagnostics
{
    public long Id { get; set; }

    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string DiagnosticsType { get; set; }

    public string Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

}