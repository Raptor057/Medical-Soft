using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Get;

internal sealed class PatientPrescriptionGetHandler : IInteractor<PatientPrescriptionGetRequest, PatientPrescriptionGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientPrescriptionGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientPrescriptionGetResponse> Handle(PatientPrescriptionGetRequest request, CancellationToken cancellationToken)
    {
        if (request.IdPatient > 0 || request.IdAppointment > 0)
        {
            var patientPrescription = await _patientPrescription.GetLastPatientPrescriptionByPatientIdAsyncAndIDAppoinment(request.IdPatient, request.IdAppointment).ConfigureAwait(false);
            
            if (patientPrescription == null)
                return new PatientPrescriptionGetFailure("Patient not found");
            
            var patientPrescriptionDto = new PatientPrescriptionDto(
                patientPrescription.Id,
                patientPrescription.IDPatient,
                patientPrescription.IDAppointment,
                patientPrescription.ConsultationNotes,
                patientPrescription.Height,
                patientPrescription.Weight,
                patientPrescription.BodyMassIndex,
                patientPrescription.Temperature,
                patientPrescription.RespiratoryRate,
                patientPrescription.SystolicPressure,
                patientPrescription.DiastolicPressure,
                patientPrescription.HeartRate,
                patientPrescription.BodyFatPercentage,
                patientPrescription.MuscleMassPercentage,
                patientPrescription.HeadCircumference,
                patientPrescription.OxygenSaturation,
                patientPrescription.CreatedAt,
                patientPrescription.UpdatedAt);
            
            return new PatientPrescriptionGetSuccess(patientPrescriptionDto);
        }
        
        if (request.IdPatient > 0 || request.IdAppointment == 0)
        {
            var patientPrescriptionList = await _patientPrescription.GetHistoryOfPatientPrescriptionByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            
            if (patientPrescriptionList == null)
                return new PatientPrescriptionGetSuccess(null); // or return a failure response if appropriate
            
            var patientPrescriptionListDto = patientPrescriptionList.Select(x => new PatientPrescriptionDto(
                x.Id,
                x.IDPatient,
                x.IDAppointment,
                x.ConsultationNotes,
                x.Height,
                x.Weight,
                x.BodyMassIndex,
                x.Temperature,
                x.RespiratoryRate,
                x.SystolicPressure,
                x.DiastolicPressure,
                x.HeartRate,
                x.BodyFatPercentage,
                x.MuscleMassPercentage,
                x.HeadCircumference,
                x.OxygenSaturation,
                x.CreatedAt,
                x.UpdatedAt));
            return new PatientPrescriptionListGetSuccess(patientPrescriptionListDto);
        }
        //return new PatientPrescriptionGetFailure("Patient not found");
        return new PatientPrescriptionGetSuccess(null); // or return a failure response if appropriate
    }
}