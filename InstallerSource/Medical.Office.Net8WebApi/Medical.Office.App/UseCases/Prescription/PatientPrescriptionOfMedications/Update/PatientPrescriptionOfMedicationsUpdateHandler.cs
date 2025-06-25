using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Update;

internal sealed class PatientPrescriptionOfMedicationsUpdateHandler : IInteractor<PatientPrescriptionOfMedicationsUpdateRequest, PatientPrescriptionOfMedicationsUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientPrescriptionOfMedicationsUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    
    public async Task<PatientPrescriptionOfMedicationsUpdateResponse> Handle(PatientPrescriptionOfMedicationsUpdateRequest request, CancellationToken cancellationToken)
    {

        if (request != null)
        {
            var patientPrescriptionOfMedications = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientPrescriptionOfMedications
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                Medications = request.Medications,
                Dose = request.Dose,
                Frequency = request.Frequency,
                Duration = request.Duration,
                Comments = request.Comments,
                CreatedAt = DateTime.UtcNow
            };
            
            await _patientPrescription.UpdatePatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(patientPrescriptionOfMedications).ConfigureAwait(false);
            
            var dto = new PatientPrescriptionOfMedicationsDto(
                0,
                IDPatient: patientPrescriptionOfMedications.IDPatient,
                IDAppointment: patientPrescriptionOfMedications.IDAppointment,
                Medications: patientPrescriptionOfMedications.Medications,
                Dose: patientPrescriptionOfMedications.Dose,
                Frequency: patientPrescriptionOfMedications.Frequency,
                Duration: patientPrescriptionOfMedications.Duration,
                Comments: patientPrescriptionOfMedications.Comments,
                CreatedAt: DateTime.Now
            );
            
            return new PatientPrescriptionOfMedicationsUpdateSuccess(dto);
        }
        
        return new PatientPrescriptionOfMedicationsUpdateFailure("Error updating patient prescription of medications");
    }
}