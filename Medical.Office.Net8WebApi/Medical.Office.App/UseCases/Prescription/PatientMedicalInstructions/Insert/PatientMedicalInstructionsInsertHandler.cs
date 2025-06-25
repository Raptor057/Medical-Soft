using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert;

internal sealed class PatientMedicalInstructionsInsertHandler : IInteractor<PatientMedicalInstructionsInsertRequest, PatientMedicalInstructionsInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalInstructionsInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientMedicalInstructionsInsertResponse> Handle(PatientMedicalInstructionsInsertRequest request, CancellationToken cancellationToken)
    {
        if(request != null)
        {
            var PatientMedicalInstructions = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientMedicalInstructions
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                MedicalInstructions = request.MedicalInstructions,
            };

           await _patientPrescription.InsertPatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(PatientMedicalInstructions)
                .ConfigureAwait(false);
            
            var dto = new PatientMedicalInstructionsDto(
                0,
                PatientMedicalInstructions.IDPatient,
                PatientMedicalInstructions.IDAppointment,
                PatientMedicalInstructions.MedicalInstructions,
                DateTime.Now);
            
            return new PatientMedicalInstructionsInsertSuccess(dto);
        }
        
        return new PatientMedicalInstructionsInsertFailure("Error inserting medical instructions");
    }
}