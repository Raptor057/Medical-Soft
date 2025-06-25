using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update.Responses;

public record PatientMedicalProceduresUpdateSuccess(PatientMedicalProceduresDto PatientMedicalProcedures) :PatientMedicalProceduresUpdateResponse, ISuccess;