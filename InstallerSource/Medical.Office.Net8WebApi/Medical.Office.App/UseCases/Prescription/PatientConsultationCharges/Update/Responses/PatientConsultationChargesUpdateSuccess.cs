using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update.Responses;

public record PatientConsultationChargesUpdateSuccess (PatientConsultationChargesDto PatientConsultationCharges) : PatientConsultationChargesUpdateResponse, ISuccess;