using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert;

internal sealed class PatientDiagnosticsInsertHandler : IInteractor<PatientDiagnosticsInsertRequest, PatientDiagnosticsInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientDiagnosticsInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientDiagnosticsInsertResponse> Handle(PatientDiagnosticsInsertRequest request, CancellationToken cancellationToken)
    {
        var data = await _patientPrescription
            .GetLastPatientDiagnosticsByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment)
            .ConfigureAwait(false);

        if (data == null)
        {
            var patientDiagnostics = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientDiagnostics
            {
                IDPatient = request.IdPatient,
                IDAppointment = request.IdAppointment,
                DiagnosticsType = request.DiagnosticsType,
                Comments = request.Comments,
                CreatedAt = DateTime.UtcNow
            };

            await _patientPrescription
                .InsertPatientDiagnosticsByPatientIdAsyncAndIDAppoiment(patientDiagnostics)
                .ConfigureAwait(false);

            var dto = new PatientDiagnosticsDto(
                patientDiagnostics.Id,
                patientDiagnostics.IDPatient,
                patientDiagnostics.IDAppointment,
                patientDiagnostics.DiagnosticsType,
                patientDiagnostics.Comments,
                patientDiagnostics.CreatedAt);

            return new PatientDiagnosticsInsertSuccess(dto);
        }
        else
        {
            return new PatientDiagnosticsInsertFailure("Patient diagnostics already exists");
        }
        
    }
}