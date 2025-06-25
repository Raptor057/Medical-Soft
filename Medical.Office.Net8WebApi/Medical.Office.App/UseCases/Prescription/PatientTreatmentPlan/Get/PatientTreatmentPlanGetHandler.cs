using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get;

internal sealed class
    PatientTreatmentPlanGetHandler : IInteractor<PatientTreatmentPlanGetRequest, PatientTreatmentPlanGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientTreatmentPlanGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }

    public async Task<PatientTreatmentPlanGetResponse> Handle(PatientTreatmentPlanGetRequest request,
        CancellationToken cancellationToken)
    {
        if (request.IdPatient > 0 || request.IdAppointment > 0)
        {
            var response = await _patientPrescription
                .GetLastPatientTreatmentPlanByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment)
                .ConfigureAwait(false);

            if (response == null)
                return new PatientTreatmentPlanGetSuccess(null);

            var treatmentPlan = new PatientTreatmentPlanDto(
                response.Id,
                response.IDPatient,
                response.IDAppointment,
                response.TreatmentPlan,
                response.CreatedAt);
            return new PatientTreatmentPlanGetSuccess(treatmentPlan);
        }
        //return new  PatientTreatmentPlanGetFailure("No data found");
        return new PatientTreatmentPlanGetSuccess(null);
    }
}