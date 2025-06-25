using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;

public record PatientPrescriptionInsertFailure(string Message) : PatientPrescriptionInsertResponse, IFailure;