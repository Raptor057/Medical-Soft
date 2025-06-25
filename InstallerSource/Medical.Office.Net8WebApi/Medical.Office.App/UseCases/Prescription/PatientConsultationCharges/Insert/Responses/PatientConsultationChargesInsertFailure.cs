using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;

public record PatientConsultationChargesInsertFailure (string Message) : PatientConsultationChargesInsertResponse,IFailure;