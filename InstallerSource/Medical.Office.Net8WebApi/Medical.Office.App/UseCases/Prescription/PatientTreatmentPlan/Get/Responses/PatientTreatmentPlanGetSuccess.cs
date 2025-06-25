using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get.Responses;

public record PatientTreatmentPlanGetSuccess(PatientTreatmentPlanDto PatientTreatmentPlan):PatientTreatmentPlanGetResponse,ISuccess;