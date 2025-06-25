using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert;

public sealed class PatientTreatmentPlanInsertRequest : IRequest<PatientTreatmentPlanInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string TreatmentPlan { get; set; }
}