using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert.Responses;

public record PatientPrescriptionOfMedicationsInsertFailure(string Message) : PatientPrescriptionOfMedicationsInsertResponse, IFailure;