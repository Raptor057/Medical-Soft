using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert;

internal sealed class PatientMedicalProceduresInsertHandler : IInteractor<PatientMedicalProceduresInsertRequest, PatientMedicalProceduresInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalProceduresInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientMedicalProceduresInsertResponse> Handle(PatientMedicalProceduresInsertRequest request, CancellationToken cancellationToken)
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
            
            await _patientPrescription.InsertPatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(patientMedicalProcedures).ConfigureAwait(false);

            
            var dto = new PatientMedicalProceduresDto(
                0,
                IDPatient: patientMedicalProcedures.IDPatient,
                IDAppointment: patientMedicalProcedures.IDAppointment,
                MedicalProceduresTypes: patientMedicalProcedures.MedicalProceduresTypes,
                Comments: patientMedicalProcedures.Comments,
                DateTime.Now
            );
            
            return new PatientMedicalProceduresInsertSuccess(dto);

        }
        
        return new PatientMedicalProceduresInsertFailure("Error inserting medical procedures");
    }
}
