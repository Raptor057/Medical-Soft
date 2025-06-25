using Common.Common;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Update.Responses;

public record PatientPrescriptionUpdateFailure(string Message) : PatientPrescriptionUpdateResponse,IFailure;