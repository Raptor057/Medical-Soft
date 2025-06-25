using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get;

internal sealed class PatientDiagnosticsGetHandler : IInteractor<PatientDiagnosticsGetRequest, PatientDiagnosticsGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientDiagnosticsGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientDiagnosticsGetResponse> Handle(PatientDiagnosticsGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdAppointment > 0 || request.IdPatient > 0)
        {
            var patientDiagnostics = await _patientPrescription
                .GetLastPatientDiagnosticsByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment)
                .ConfigureAwait(false);
            if (patientDiagnostics == null)
                return new PatientDiagnosticsGetSuccess(null); // or return a failure response if appropriate

            var response = new PatientDiagnosticsDto(
                patientDiagnostics.Id,
                patientDiagnostics.IDPatient,
                patientDiagnostics.IDAppointment,
                patientDiagnostics.DiagnosticsType,
                patientDiagnostics.Comments,
                patientDiagnostics.CreatedAt);

            return new PatientDiagnosticsGetSuccess(response);
        }
        if (request.IdAppointment == 0 && request.IdPatient > 0)
        {
            var patientDiagnostics = await _patientPrescription
                .GetHistoryOfPatientDiagnosticsByPatientIdAsync(request.IdPatient)
                .ConfigureAwait(false);
            if (patientDiagnostics == null)
            {
                return new PatientDiagnosticsGetFailure("No data found");
            }

            var response = patientDiagnostics.Select(pd => new PatientDiagnosticsDto(
                pd.Id,
                pd.IDPatient,
                pd.IDAppointment,
                pd.DiagnosticsType,
                pd.Comments,
                pd.CreatedAt));
            return new PatientDiagnosticsListGetSuccess(response);
        }
        //return new PatientDiagnosticsGetFailure("No data found");
        return new PatientDiagnosticsGetSuccess(null); // or return a failure response if appropriate
    }
}