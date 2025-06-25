using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update;

public sealed class PatientMedicalProceduresUpdateRequest : IRequest<PatientMedicalProceduresUpdateResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalProceduresTypes { get; set; }

    public string Comments { get; set; }
}