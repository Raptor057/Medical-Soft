using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get;

public sealed class PatientMedicalProceduresGetRequest : IRequest<PatientMedicalProceduresGetResponse>
{
    public PatientMedicalProceduresGetRequest() { }
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
}