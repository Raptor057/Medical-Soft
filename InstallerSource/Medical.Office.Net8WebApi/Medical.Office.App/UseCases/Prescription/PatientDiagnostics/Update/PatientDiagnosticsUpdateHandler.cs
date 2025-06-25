using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update;

internal sealed class PatientDiagnosticsUpdateHandler : IInteractor<PatientDiagnosticsUpdateRequest, PatientDiagnosticsUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientDiagnosticsUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientDiagnosticsUpdateResponse> Handle(PatientDiagnosticsUpdateRequest request, CancellationToken cancellationToken)
    {
        var data = await _patientPrescription
            .GetLastPatientDiagnosticsByPatientIdAsyncAndIDAppoinment(request.IDPatient, request.IDAppointment)
            .ConfigureAwait(false);
        if (data == null)
        {
            return new PatientDiagnosticsUpdateFailure("No data found");
        }
        var patientDiagnostics = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientDiagnostics
        {
            Id = data.Id,
            IDPatient = request.IDPatient,
            IDAppointment = request.IDAppointment,
            DiagnosticsType = request.DiagnosticsType,
            Comments = request.Comments,
            CreatedAt = data.CreatedAt
        };
        await _patientPrescription
            .UpdatePatientDiagnosticsByPatientIdAsyncAndIDAppoiment(patientDiagnostics)
            .ConfigureAwait(false);
        var dto = new PatientDiagnosticsDto(
            patientDiagnostics.Id,
            patientDiagnostics.IDPatient,
            patientDiagnostics.IDAppointment,
            patientDiagnostics.DiagnosticsType,
            patientDiagnostics.Comments,
            patientDiagnostics.CreatedAt);
        return new PatientDiagnosticsUpdateSuccess(dto);
    }
}