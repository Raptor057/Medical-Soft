using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Update.Responses;

public record PatientPrescriptionUpdateSuccess(PatientPrescriptionDto PatientPrescription): PatientPrescriptionUpdateResponse, ISuccess;