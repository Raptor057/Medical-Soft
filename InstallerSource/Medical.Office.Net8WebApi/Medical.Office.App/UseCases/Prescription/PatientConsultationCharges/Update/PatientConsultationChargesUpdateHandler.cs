using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update;

internal sealed class PatientConsultationChargesUpdateHandler : IInteractor<PatientConsultationChargesUpdateRequest, PatientConsultationChargesUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientConsultationChargesUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientConsultationChargesUpdateResponse> Handle(PatientConsultationChargesUpdateRequest request, CancellationToken cancellationToken)
    {
        var data = await _patientPrescription
            .GetLastPatientConsultationChargesByPatientIdAsyncAndIDAppoinment(request.IDPatient, request.IDAppointment)
            .ConfigureAwait(false);
        
        if (data != null)
        {
            var patientConsultationCharges =
                new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientConsultationCharges
                {
                    IDPatient = request.IDPatient,
                    IDAppointment = request.IDAppointment,
                    Description = request.Description,
                    Total = request.Total,
                    CreatedAt = request.CreatedAt
                };
            
            await _patientPrescription
                    .UpdatePatientConsultationChargesByPatientIdAsyncAndIDAppoiment(patientConsultationCharges)
                .ConfigureAwait(false);
            
            
            var dto = new PatientConsultationChargesDto(
                request.Id,
                request.IDPatient,
                request.IDAppointment,
                request.Description,
                request.Total,
                request.CreatedAt);
            
            return new PatientConsultationChargesUpdateSuccess(dto);
        }
        else
        {
            return new PatientConsultationChargesUpdateFailure("PatientConsultationCharges not found");
        }

    }
}