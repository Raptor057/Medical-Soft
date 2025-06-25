using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get.Responses;

public record PatientMedicalProceduresGetFailure(string Message):PatientMedicalProceduresGetResponse, IFailure;