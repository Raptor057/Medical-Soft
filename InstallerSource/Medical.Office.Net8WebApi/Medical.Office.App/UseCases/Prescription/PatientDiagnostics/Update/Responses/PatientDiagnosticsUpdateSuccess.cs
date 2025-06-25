using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update.Responses;

public record PatientDiagnosticsUpdateSuccess(PatientDiagnosticsDto PatientDiagnostics) : PatientDiagnosticsUpdateResponse, ISuccess;