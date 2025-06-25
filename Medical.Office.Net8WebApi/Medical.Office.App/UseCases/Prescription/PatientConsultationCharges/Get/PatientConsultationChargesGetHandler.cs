using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get;

internal sealed class PatientConsultationChargesGetHandler : IInteractor<PatientConsultationChargesGetRequest,PatientConsultationChargesGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientConsultationChargesGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }

    public async Task<PatientConsultationChargesGetResponse> Handle(PatientConsultationChargesGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdAppointment > 0 || request.IdPatient > 0)
        {
            var patientConsultation  = await _patientPrescription.GetLastPatientConsultationChargesByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment).ConfigureAwait(false);
            
            if (patientConsultation == null)
                return new PatientConsultationChargesGetSuccess(null); // or return a failure response if appropriate

            var response = new PatientConsultationChargesDto(
                patientConsultation.Id,
                patientConsultation.IDPatient,
                patientConsultation.IDAppointment,
                patientConsultation.Description,
                patientConsultation.Total,
                patientConsultation.CreatedAt);
            
            return new PatientConsultationChargesGetSuccess(response);
        }

        if (request.IdAppointment == 0 && request.IdPatient > 0)
        {
            var patientConsultation = await _patientPrescription
                .GetHistoryOfPatientConsultationChargesByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            if (patientConsultation == null)
            {
                return new PatientConsultationChargesGetFailure("No data found");
            }
            
            var response = patientConsultation.Select(pc => new PatientConsultationChargesDto(
                pc.Id,
                pc.IDPatient,
                pc.IDAppointment,
                pc.Description,
                pc.Total,
                pc.CreatedAt));
            return new PatientConsultationChargesListGetSuccess(response);
        }
        //return new PatientConsultationChargesGetFailure("No data found");
        return new PatientConsultationChargesGetSuccess(null); // or return a failure response if appropriate
    }
}