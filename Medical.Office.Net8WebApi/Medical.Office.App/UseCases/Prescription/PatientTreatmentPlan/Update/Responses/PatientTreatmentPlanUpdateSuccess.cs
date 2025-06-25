using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update.Responses;

public record PatientTreatmentPlanUpdateSuccess(PatientTreatmentPlanDto PatientTreatmentPlan) : PatientTreatmentPlanUpdateResponse, ISuccess;