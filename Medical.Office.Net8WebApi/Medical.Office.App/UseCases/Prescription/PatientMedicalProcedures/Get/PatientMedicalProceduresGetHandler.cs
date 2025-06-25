using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get;

internal sealed class PatientMedicalProceduresGetHandler : IInteractor<PatientMedicalProceduresGetRequest, PatientMedicalProceduresGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientMedicalProceduresGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientMedicalProceduresGetResponse> Handle(PatientMedicalProceduresGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdPatient > 0 || request.IdAppointment > 0)
        {
            var patientMedicalProcedures = await _patientPrescription.GetLastPatientMedicalProceduresByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment).ConfigureAwait(false);
            
            if (patientMedicalProcedures == null)
                return new PatientMedicalProceduresGetSuccess(null); // or return a failure response if appropriate
            
            var patientMedicalProceduresDto = new PatientMedicalProceduresDto(
                patientMedicalProcedures.Id,
                patientMedicalProcedures.IDPatient,
                patientMedicalProcedures.IDAppointment,
                patientMedicalProcedures.MedicalProceduresTypes,
                patientMedicalProcedures.Comments,
                patientMedicalProcedures.CreatedAt);
            
            return new PatientMedicalProceduresGetSuccess(patientMedicalProceduresDto);
            
        }
        if (request.IdPatient > 0 || request.IdAppointment == 0)
        {
            var patientMedicalProceduresList = await  _patientPrescription.GetHistoryOfPatientMedicalProceduresByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            
            if (patientMedicalProceduresList == null)
                return new PatientMedicalProceduresGetFailure("Patient not found");
            
            var patientMedicalProceduresListDto = patientMedicalProceduresList.Select(x => new PatientMedicalProceduresDto(
                x.Id,
                x.IDPatient,
                x.IDAppointment,
                x.MedicalProceduresTypes,
                x.Comments,
                x.CreatedAt));
            return new PatientMedicalProceduresListGetSuccess(patientMedicalProceduresListDto);
        }
        //return new PatientMedicalProceduresGetFailure("Patient not found");
        return new PatientMedicalProceduresGetSuccess(null); // or return a failure response if appropriate
    }
}