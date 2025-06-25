using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement.Responses;

public record SuccessGetPatientAdvancementResponse(IEnumerable<PatientAdvancementDto> PatientAdvancement):GetPatientAdvancementResponse,ISuccess;