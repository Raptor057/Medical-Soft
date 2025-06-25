using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get.Responses;

public record PatientMedicalInstructionsGetFailure(string Message):PatientMedicalInstructionsGetResponse, IFailure;