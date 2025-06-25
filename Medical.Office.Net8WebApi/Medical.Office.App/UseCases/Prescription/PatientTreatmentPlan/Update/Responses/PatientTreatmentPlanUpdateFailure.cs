using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update.Responses;

public record PatientTreatmentPlanUpdateFailure(string Message):PatientTreatmentPlanUpdateResponse,IFailure;