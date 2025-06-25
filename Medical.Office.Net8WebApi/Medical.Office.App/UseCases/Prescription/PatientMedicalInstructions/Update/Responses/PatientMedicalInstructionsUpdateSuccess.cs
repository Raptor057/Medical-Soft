using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update.Responses;

public record PatientMedicalInstructionsUpdateSuccess(PatientMedicalInstructionsDto PatientMedicalInstructions): PatientMedicalInstructionsUpdateResponse, ISuccess;