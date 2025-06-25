using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;

public record PatientConsultationChargesInsertSuccess(PatientConsultationChargesDto PatientConsultationCharges) : PatientConsultationChargesInsertResponse, ISuccess;