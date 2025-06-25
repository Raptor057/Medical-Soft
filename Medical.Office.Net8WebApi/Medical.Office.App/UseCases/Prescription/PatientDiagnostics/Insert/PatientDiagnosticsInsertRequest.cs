using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert;

public sealed class PatientDiagnosticsInsertRequest : IRequest<PatientDiagnosticsInsertResponse>
{
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
    public string DiagnosticsType { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;

    public PatientDiagnosticsInsertRequest(long idPatient, long idAppointment, string diagnosticsType, string comments)
    {
        IdPatient = idPatient;
        IdAppointment = idAppointment;
        DiagnosticsType = diagnosticsType;
        Comments = comments;
    }

    public static bool CanInsert(long idPatient, long idAppointment, string diagnosticsType, string comments, out ErrorList errors)
    {
        errors = new();
        if (idPatient <= 0 || idAppointment <= 0)
        {
            errors.Add("IdPatient or IdAppointment must be greater than 0");
        }
        if (string.IsNullOrEmpty(diagnosticsType))
        {
            errors.Add("DiagnosticsType cannot be empty");
        }
        if (string.IsNullOrEmpty(comments))
        {
            errors.Add("Comments cannot be empty");
        }
        return errors.IsEmpty;
    }

    public static PatientDiagnosticsInsertRequest Insert(long idPatient, long idAppointment, string diagnosticsType, string comments)
    {
        if (!CanInsert(idPatient, idAppointment, diagnosticsType, comments, out ErrorList errors)) throw errors.AsException();
        return new PatientDiagnosticsInsertRequest(idPatient, idAppointment, diagnosticsType, comments);
    }
    
}