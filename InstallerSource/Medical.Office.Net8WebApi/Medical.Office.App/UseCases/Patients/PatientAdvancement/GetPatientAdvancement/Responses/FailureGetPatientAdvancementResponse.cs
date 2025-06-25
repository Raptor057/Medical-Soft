using Common.Common;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement.Responses;

public record FailureGetPatientAdvancementResponse(string Message):GetPatientAdvancementResponse,IFailure;