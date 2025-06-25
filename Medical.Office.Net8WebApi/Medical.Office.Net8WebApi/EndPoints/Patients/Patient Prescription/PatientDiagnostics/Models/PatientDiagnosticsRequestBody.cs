namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Models;

public class PatientDiagnosticsRequestBody
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string DiagnosticsType { get; set; }

    public string Comments { get; set; }
}