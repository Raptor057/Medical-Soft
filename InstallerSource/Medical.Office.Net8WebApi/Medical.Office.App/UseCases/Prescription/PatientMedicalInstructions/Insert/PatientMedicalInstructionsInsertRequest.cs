using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert;

public sealed class PatientMedicalInstructionsInsertRequest : IRequest<PatientMedicalInstructionsInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalInstructions { get; set; }

    
}