using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert.Responses;

public record PatientMedicalProceduresInsertSuccess(PatientMedicalProceduresDto PatientMedicalProcedures) : PatientMedicalProceduresInsertResponse,ISuccess;