using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get;

public sealed class PatientTreatmentPlanGetRequest : IRequest<PatientTreatmentPlanGetResponse>
{
    public PatientTreatmentPlanGetRequest()
    {
        
    }
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
    
}