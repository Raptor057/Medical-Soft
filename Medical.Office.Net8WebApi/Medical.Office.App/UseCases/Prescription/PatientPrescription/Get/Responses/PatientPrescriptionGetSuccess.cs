using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Get.Responses;

public record PatientPrescriptionGetSuccess(PatientPrescriptionDto PatientPrescription) : PatientPrescriptionGetResponse, ISuccess;

public record PatientPrescriptionListGetSuccess(IEnumerable<PatientPrescriptionDto> PatientPrescription) : PatientPrescriptionGetResponse, ISuccess;