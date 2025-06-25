using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update;

public sealed class PatientTreatmentPlanUpdateRequest : IRequest<PatientTreatmentPlanUpdateResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string TreatmentPlan { get; set; }
}