using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Get.Responses;

public record PatientPrescriptionGetFailure(string Message) : PatientPrescriptionGetResponse,IFailure;