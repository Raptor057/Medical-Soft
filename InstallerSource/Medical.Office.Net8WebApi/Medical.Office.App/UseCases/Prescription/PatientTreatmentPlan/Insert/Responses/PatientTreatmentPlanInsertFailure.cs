using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert.Responses;

public record PatientTreatmentPlanInsertFailure (string Message):PatientTreatmentPlanInsertResponse,IFailure; 