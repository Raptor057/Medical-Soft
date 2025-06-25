using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get.Responses;

public record PatientMedicalProceduresGetSuccess(PatientMedicalProceduresDto PatientMedicalProcedures)
    : PatientMedicalProceduresGetResponse,ISuccess;
public record PatientMedicalProceduresListGetSuccess(IEnumerable<PatientMedicalProceduresDto> PatientMedicalProcedures)
    : PatientMedicalProceduresGetResponse,ISuccess;