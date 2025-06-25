using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get.Responses;

public record PatientDiagnosticsGetSuccess(PatientDiagnosticsDto PatientDiagnostics) : PatientDiagnosticsGetResponse, ISuccess;
public record PatientDiagnosticsListGetSuccess(IEnumerable<PatientDiagnosticsDto> PatientDiagnostics) : PatientDiagnosticsGetResponse, ISuccess;