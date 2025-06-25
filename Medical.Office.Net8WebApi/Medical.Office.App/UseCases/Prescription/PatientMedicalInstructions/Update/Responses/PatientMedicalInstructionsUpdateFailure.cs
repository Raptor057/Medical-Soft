using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update.Responses;

public record PatientMedicalInstructionsUpdateFailure(string Message) : PatientMedicalInstructionsUpdateResponse, IFailure;