using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update;

internal sealed class PatientMedicalInstructionsUpdateHandler : IInteractor<PatientMedicalInstructionsUpdateRequest, PatientMedicalInstructionsUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalInstructionsUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    
    public async Task<PatientMedicalInstructionsUpdateResponse> Handle(PatientMedicalInstructionsUpdateRequest request, CancellationToken cancellationToken)
    {
        if (request != null)
        {
            var PatientMedicalInstructions = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientMedicalInstructions
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                MedicalInstructions = request.MedicalInstructions,
            };

            await _patientPrescription.UpdatePatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(PatientMedicalInstructions)
                .ConfigureAwait(false);
            
            var dto = new PatientMedicalInstructionsDto(
                0,
                PatientMedicalInstructions.IDPatient,
                PatientMedicalInstructions.IDAppointment,
                PatientMedicalInstructions.MedicalInstructions,
                DateTime.Now);
            
            return new PatientMedicalInstructionsUpdateSuccess(dto);
        }
        return new PatientMedicalInstructionsUpdateFailure("Error updating medical instructions");
    }
}