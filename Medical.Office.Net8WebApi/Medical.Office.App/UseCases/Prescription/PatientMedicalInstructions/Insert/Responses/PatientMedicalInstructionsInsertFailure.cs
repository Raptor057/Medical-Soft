using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert.Responses;

public record PatientMedicalInstructionsInsertFailure(string Message) : PatientMedicalInstructionsInsertResponse, IFailure; 