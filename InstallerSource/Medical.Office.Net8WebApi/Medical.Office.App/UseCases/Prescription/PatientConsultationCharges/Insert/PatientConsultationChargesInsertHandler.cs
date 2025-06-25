using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert;

internal sealed class PatientConsultationChargesInsertHandler : IInteractor<PatientConsultationChargesInsertRequest, PatientConsultationChargesInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientConsultationChargesInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientConsultationChargesInsertResponse> Handle(PatientConsultationChargesInsertRequest request, CancellationToken cancellationToken)
    {
        var data = await _patientPrescription
            .GetLastPatientConsultationChargesByPatientIdAsyncAndIDAppoinment(request.IDPatient, request.IDAppointment)
            .ConfigureAwait(false);

        if (data == null)
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
                .InsertPatientConsultationChargesByPatientIdAsyncAndIDAppoiment(patientConsultationCharges)
                .ConfigureAwait(false);

            var dto = new PatientConsultationChargesDto(
                patientConsultationCharges.Id,
                patientConsultationCharges.IDPatient,
                patientConsultationCharges.IDAppointment,
                patientConsultationCharges.Description,
                patientConsultationCharges.Total,
                patientConsultationCharges.CreatedAt);

            return new PatientConsultationChargesInsertSuccess(dto);
        }
        else
        {
            return new PatientConsultationChargesInsertFailure("PatientConsultationCharges already exists");
        }

    }
}