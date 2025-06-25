using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update.Responses;

public record PatientConsultationChargesUpdateFailure (string Message) : PatientConsultationChargesUpdateResponse, IFailure;