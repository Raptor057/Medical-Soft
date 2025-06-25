using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;
namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get;

public sealed class PatientConsultationChargesGetRequest : IRequest<PatientConsultationChargesGetResponse>
{
    public static bool CanGet(long idPatient, long idAppointment, out ErrorList errors)
    {
        //return idPatient > 0 || idAppointment > 0;
        errors = new();
        if (idPatient <= 0 && idAppointment <= 0)
        {
            errors.Add("IdPatient or IdAppointment must be greater than 0");
        }
        return errors.IsEmpty;
    }

    public static PatientConsultationChargesGetRequest Get(long idPatient, long idAppointment)
    {
        if (!CanGet(idPatient, idAppointment, out ErrorList errors)) throw errors.AsException();
        return new PatientConsultationChargesGetRequest(idPatient, idAppointment);
    }

    public PatientConsultationChargesGetRequest(long idPatient, long idAppointment)
    {
        IdPatient = idPatient;
        IdAppointment = idAppointment;
    }
    public long IdPatient { get; }
    public long IdAppointment { get; }
    
    
}