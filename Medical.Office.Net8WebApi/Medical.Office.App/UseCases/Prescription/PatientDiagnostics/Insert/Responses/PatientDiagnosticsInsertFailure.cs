using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert.Responses;

public record PatientDiagnosticsInsertFailure(string Message) : PatientDiagnosticsInsertResponse, IFailure;