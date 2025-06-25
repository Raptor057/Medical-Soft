using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get;

public sealed class PatientDiagnosticsGetRequest : IRequest<PatientDiagnosticsGetResponse>
{
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
    public PatientDiagnosticsGetRequest(long idPatient, long idAppointment)
    {
        IdPatient = idPatient;
        IdAppointment = idAppointment;
    }

    public static bool CanGet(long idPatient, long idAppointment,out ErrorList errors)
    {
        errors = new();
        if (idPatient <= 0 && idAppointment <= 0)
        {
            errors.Add("IdPatient or IdAppointment must be greater than 0");
        }
        return errors.IsEmpty;
    }
    public static PatientDiagnosticsGetRequest Get(long idPatient, long idAppointment)
    {
        if (!CanGet(idPatient, idAppointment, out ErrorList errors)) throw errors.AsException();
        return new PatientDiagnosticsGetRequest(idPatient, idAppointment);
    }
    
}