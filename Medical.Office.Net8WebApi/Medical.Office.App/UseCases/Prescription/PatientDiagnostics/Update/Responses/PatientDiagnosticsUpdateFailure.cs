using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update.Responses;

public record PatientDiagnosticsUpdateFailure(string Message) : PatientDiagnosticsUpdateResponse, IFailure;