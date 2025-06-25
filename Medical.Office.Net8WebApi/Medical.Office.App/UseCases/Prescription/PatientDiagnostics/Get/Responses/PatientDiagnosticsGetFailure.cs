using Common.Common;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get.Responses;

public record PatientDiagnosticsGetFailure(string Message) : PatientDiagnosticsGetResponse, IFailure;