using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get;

public sealed class PatientMedicalInstructionsGetRequest : IRequest<PatientMedicalInstructionsGetResponse>
{
    public PatientMedicalInstructionsGetRequest() { }
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
    
}