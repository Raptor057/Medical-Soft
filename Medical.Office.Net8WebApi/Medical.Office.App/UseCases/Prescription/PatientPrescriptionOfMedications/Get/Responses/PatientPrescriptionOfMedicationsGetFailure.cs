using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get.Responses;

public record PatientPrescriptionOfMedicationsGetFailure(string Message): PatientPrescriptionOfMedicationsGetResponse, IFailure;