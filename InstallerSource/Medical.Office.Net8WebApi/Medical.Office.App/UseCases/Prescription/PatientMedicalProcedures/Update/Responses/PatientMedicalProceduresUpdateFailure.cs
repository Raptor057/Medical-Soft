using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update.Responses;

public record PatientMedicalProceduresUpdateFailure(string Message) :PatientMedicalProceduresUpdateResponse, IFailure;