using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update;

internal sealed class PatientTreatmentPlanUpdateHandler : IInteractor<PatientTreatmentPlanUpdateRequest, PatientTreatmentPlanUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientTreatmentPlanUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }

    public async Task<PatientTreatmentPlanUpdateResponse> Handle(PatientTreatmentPlanUpdateRequest request, CancellationToken cancellationToken)
    {
        if (request != null)
        {
            var patientTreatmentPlan = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientTreatmentPlan
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                TreatmentPlan = request.TreatmentPlan,
                CreatedAt = DateTime.UtcNow
            };

            await _patientPrescription.UpdatePatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(patientTreatmentPlan).ConfigureAwait(false);

            var dto = new PatientTreatmentPlanDto(
                0,
                IDPatient: patientTreatmentPlan.IDPatient,
                IDAppointment: patientTreatmentPlan.IDAppointment,
                TreatmentPlan: patientTreatmentPlan.TreatmentPlan,
                CreatedAt: DateTime.Now
            );

            return new PatientTreatmentPlanUpdateSuccess(dto);
        }
        return new PatientTreatmentPlanUpdateFailure("Error updating treatment plan");
    }
}