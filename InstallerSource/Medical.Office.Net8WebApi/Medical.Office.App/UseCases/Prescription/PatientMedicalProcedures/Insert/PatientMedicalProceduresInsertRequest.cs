using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert;

public sealed class PatientMedicalProceduresInsertRequest : IRequest<PatientMedicalProceduresInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalProceduresTypes { get; set; }

    public string Comments { get; set; }

}