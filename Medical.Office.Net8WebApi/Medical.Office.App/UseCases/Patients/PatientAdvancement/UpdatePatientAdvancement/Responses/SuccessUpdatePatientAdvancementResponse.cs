using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement.Responses;

public record SuccessUpdatePatientAdvancementResponse(PatientAdvancementDto PatientAdvancement):UpdatePatientAdvancementResponse,ISuccess;