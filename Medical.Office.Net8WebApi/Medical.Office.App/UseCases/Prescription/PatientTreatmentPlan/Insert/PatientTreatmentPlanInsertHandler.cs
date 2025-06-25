using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert;

internal sealed class PatientTreatmentPlanInsertHandler : IInteractor<PatientTreatmentPlanInsertRequest, PatientTreatmentPlanInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientTreatmentPlanInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientTreatmentPlanInsertResponse> Handle(PatientTreatmentPlanInsertRequest request, CancellationToken cancellationToken)
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
            
            await _patientPrescription.InsertPatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(patientTreatmentPlan).ConfigureAwait(false);
            
            var dto = new PatientTreatmentPlanDto(
                0,
                IDPatient: patientTreatmentPlan.IDPatient,
                IDAppointment: patientTreatmentPlan.IDAppointment,
                TreatmentPlan: patientTreatmentPlan.TreatmentPlan,
                CreatedAt: DateTime.Now
            );
            
            return new PatientTreatmentPlanInsertSuccess(dto);
        }
        return new PatientTreatmentPlanInsertFailure("Error inserting treatment plan");
    }
}