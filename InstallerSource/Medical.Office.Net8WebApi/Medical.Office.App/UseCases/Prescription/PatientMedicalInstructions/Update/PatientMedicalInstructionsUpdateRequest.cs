using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update;

public sealed class PatientMedicalInstructionsUpdateRequest : IRequest<PatientMedicalInstructionsUpdateResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalInstructions { get; set; }
}