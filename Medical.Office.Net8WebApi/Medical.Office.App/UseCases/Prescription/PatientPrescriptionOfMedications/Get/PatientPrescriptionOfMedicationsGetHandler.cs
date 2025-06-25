using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get;

internal sealed class PatientPrescriptionOfMedicationsGetHandler : IInteractor<PatientPrescriptionOfMedicationsGetRequest, PatientPrescriptionOfMedicationsGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientPrescriptionOfMedicationsGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientPrescriptionOfMedicationsGetResponse> Handle(PatientPrescriptionOfMedicationsGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdPatient > 0 && request.IdAppointment > 0)
        {
            var response = await _patientPrescription
                .GetLastPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment).ConfigureAwait(false);

            if (response == null)
                return new PatientPrescriptionOfMedicationsGetSuccess(null); // or return a failure response if appropriate
            var responseDto = new PatientPrescriptionOfMedicationsDto(
                response.Id,
                response.IDPatient,
                response.IDAppointment,
                response.Medications,
                response.Dose,
                response.Frequency,
                response.Duration,
                response.Comments,
                response.CreatedAt);

            return new PatientPrescriptionOfMedicationsGetSuccess(responseDto);
        }

        /*
        if (request.PatientId > 0 && request.AppointmentId == 0)
        {
            var response = await _patientPrescription
                .GetHistoryOfPatientPrescriptionOfMedicationsByPatientIdAsync(request.PatientId).ConfigureAwait(false);

            if (response == null || !response.Any())
                return new PatientPrescriptionOfMedicationsGetFailure("No data found");
            

            return new PatientPrescriptionOfMedicationsListGetSuccess(response);
        }
        */

        //return new PatientPrescriptionOfMedicationsGetFailure("Invalid request parameters");
        return new PatientPrescriptionOfMedicationsGetSuccess(null); // or return a failure response if appropriate
    }
}