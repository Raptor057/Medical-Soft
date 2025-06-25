using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Get;

public sealed class PatientPrescriptionGetRequest : IRequest<PatientPrescriptionGetResponse>
{
    public PatientPrescriptionGetRequest()
    {
        
    }
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
}