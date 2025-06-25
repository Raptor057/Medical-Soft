using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get.Responses;

public record PatientTreatmentPlanGetFailure(string Message) : PatientTreatmentPlanGetResponse,IFailure;