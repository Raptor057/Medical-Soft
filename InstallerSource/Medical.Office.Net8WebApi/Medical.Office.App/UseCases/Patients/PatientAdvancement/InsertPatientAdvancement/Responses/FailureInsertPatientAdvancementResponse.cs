using Common.Common;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement.Responses;

public record FailureInsertPatientAdvancementResponse(string Message):InsertPatientAdvancementResponse,IFailure;