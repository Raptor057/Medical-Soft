using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;

public record PatientConsultationChargesGetFailure(string Message) : PatientConsultationChargesGetResponse,IFailure { }