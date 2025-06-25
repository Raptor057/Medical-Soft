using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert;

internal sealed class PatientPrescriptionInsertHandler : IInteractor<PatientPrescriptionInsertRequest, PatientPrescriptionInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientPrescriptionInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    
    public async Task<PatientPrescriptionInsertResponse> Handle(PatientPrescriptionInsertRequest request, CancellationToken cancellationToken)
    {
        if (request != null)
        {
            
            var patientPrescription = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientPrescription
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                ConsultationNotes = request.ConsultationNotes,
                Height = request.Height,
                Weight = request.Weight,
                BodyMassIndex = request.BodyMassIndex,
                Temperature = request.Temperature,
                RespiratoryRate = request.RespiratoryRate,
                SystolicPressure = request.SystolicPressure,
                DiastolicPressure = request.DiastolicPressure,
                HeartRate = request.HeartRate,
                BodyFatPercentage = request.BodyFatPercentage,
                MuscleMassPercentage = request.MuscleMassPercentage,
                HeadCircumference = request.HeadCircumference,
                OxygenSaturation = request.OxygenSaturation,
                CreatedAt = DateTime.UtcNow
            };
            
            await _patientPrescription.InsertPatientPrescriptionByPatientIdAsyncAndIDAppoiment(patientPrescription).ConfigureAwait(false);
            
            var dto = new PatientPrescriptionDto(
                0,
                IDPatient: patientPrescription.IDPatient,
                IDAppointment: patientPrescription.IDAppointment,
                ConsultationNotes: patientPrescription.ConsultationNotes,
                Height: patientPrescription.Height,
                Weight: patientPrescription.Weight,
                BodyMassIndex: patientPrescription.BodyMassIndex,
                Temperature: patientPrescription.Temperature,
                RespiratoryRate: patientPrescription.RespiratoryRate,
                SystolicPressure: patientPrescription.SystolicPressure,
                DiastolicPressure: patientPrescription.DiastolicPressure,
                HeartRate: patientPrescription.HeartRate,
                BodyFatPercentage: patientPrescription.BodyFatPercentage,
                MuscleMassPercentage: patientPrescription.MuscleMassPercentage,
                HeadCircumference: patientPrescription.HeadCircumference,
                OxygenSaturation: patientPrescription.OxygenSaturation,
                CreatedAt: DateTime.Now, 
                UpdatedAt: DateTime.Now
            );
            
            return new PatientPrescriptionInsertSuccess(dto);

        }
        return new PatientPrescriptionInsertFailure("Error inserting patient prescription");
    }
}