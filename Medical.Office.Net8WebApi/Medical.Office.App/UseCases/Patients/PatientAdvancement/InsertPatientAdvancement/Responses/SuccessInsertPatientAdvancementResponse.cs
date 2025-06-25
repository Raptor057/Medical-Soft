using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement.Responses;

public record SuccessInsertPatientAdvancementResponse(PatientAdvancementDto PatientAdvancement):InsertPatientAdvancementResponse,ISuccess;