using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert.Responses;

public record PatientMedicalInstructionsInsertSuccess(PatientMedicalInstructionsDto PatientMedicalInstructions) : PatientMedicalInstructionsInsertResponse, ISuccess;