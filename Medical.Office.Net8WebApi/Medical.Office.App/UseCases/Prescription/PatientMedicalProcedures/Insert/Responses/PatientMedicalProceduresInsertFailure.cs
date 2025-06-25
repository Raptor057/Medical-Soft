using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert.Responses;

public record PatientMedicalProceduresInsertFailure(string Message): PatientMedicalProceduresInsertResponse, IFailure;