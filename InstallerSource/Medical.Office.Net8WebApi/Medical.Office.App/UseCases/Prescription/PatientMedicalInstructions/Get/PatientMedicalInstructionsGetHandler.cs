using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get;

internal sealed class PatientMedicalInstructionsGetHandler : IInteractor<PatientMedicalInstructionsGetRequest, PatientMedicalInstructionsGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalInstructionsGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientMedicalInstructionsGetResponse> Handle(PatientMedicalInstructionsGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdPatient > 0 || request.IdAppointment > 0)
        {
            var response = await _patientPrescription
                .GetLastPatientMedicalInstructionsByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment).ConfigureAwait(false);
            
            if (response == null)
                return new PatientMedicalInstructionsGetSuccess(null); // or return a failure response if appropriate

            var medicalInstructions = new PatientMedicalInstructionsDto(
                response.Id, 
                response.IDPatient,
                response.IDAppointment,
                response.MedicalInstructions,
                response.CreatedAt);
            return new PatientMedicalInstructionsGetSuccess(medicalInstructions);
        }
        
        if (request.IdPatient > 0 && request.IdAppointment == 0)
        {
            var response = await _patientPrescription
                .GetHistoryOfPatientMedicalInstructionsByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            
            if (response == null)
                return new PatientMedicalInstructionsGetFailure("No data found");

            var medicalInstructions = response.Select(pd => new PatientMedicalInstructionsDto(
                pd.Id,
                pd.IDPatient,
                pd.IDAppointment,
                pd.MedicalInstructions,
                pd.CreatedAt));
            
            return new PatientMedicalInstructionsListGetSuccess(medicalInstructions);
        }
        
        //return new PatientMedicalInstructionsGetFailure("No data found");
        return new PatientMedicalInstructionsGetSuccess(null); // or return a failure response if appropriate
    }
}