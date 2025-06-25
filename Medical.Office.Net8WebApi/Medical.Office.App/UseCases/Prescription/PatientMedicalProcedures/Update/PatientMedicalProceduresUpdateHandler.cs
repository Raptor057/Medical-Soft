using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update;

internal sealed class PatientMedicalProceduresUpdateHandler : IInteractor<PatientMedicalProceduresUpdateRequest, PatientMedicalProceduresUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalProceduresUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientMedicalProceduresUpdateResponse> Handle(PatientMedicalProceduresUpdateRequest request, CancellationToken cancellationToken)
    {
        if (request != null)
        {
            var patientMedicalProcedures = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientMedicalProcedures
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                MedicalProceduresTypes = request.MedicalProceduresTypes,
                Comments = request.Comments,
                CreatedAt = DateTime.UtcNow
            };
            
            await _patientPrescription.UpdatePatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(patientMedicalProcedures).ConfigureAwait(false);
            
            var dto = new PatientMedicalProceduresDto(
                0,
                IDPatient: patientMedicalProcedures.IDPatient,
                IDAppointment: patientMedicalProcedures.IDAppointment,
                MedicalProceduresTypes: patientMedicalProcedures.MedicalProceduresTypes,
                Comments: patientMedicalProcedures.Comments,
                DateTime.Now
            );
            
            return new PatientMedicalProceduresUpdateSuccess(dto);
        }
        
        return new PatientMedicalProceduresUpdateFailure("Error updating medical procedures");
    }
}