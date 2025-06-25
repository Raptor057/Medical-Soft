using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert.Responses;

public record PatientDiagnosticsInsertSuccess(PatientDiagnosticsDto PatientDiagnostics) : PatientDiagnosticsInsertResponse, ISuccess;