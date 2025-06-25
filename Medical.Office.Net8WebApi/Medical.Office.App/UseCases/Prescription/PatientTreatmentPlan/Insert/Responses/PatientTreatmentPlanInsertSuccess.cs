using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert.Responses;

public record PatientTreatmentPlanInsertSuccess(PatientTreatmentPlanDto PatientTreatmentPlan):PatientTreatmentPlanInsertResponse, ISuccess;