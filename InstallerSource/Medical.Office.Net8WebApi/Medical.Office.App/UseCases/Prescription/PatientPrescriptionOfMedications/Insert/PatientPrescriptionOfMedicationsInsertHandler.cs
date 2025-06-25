using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert;

internal sealed class PatientPrescriptionOfMedicationsInsertHandler : IInteractor<PatientPrescriptionOfMedicationsInsertRequest, PatientPrescriptionOfMedicationsInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientPrescriptionOfMedicationsInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientPrescriptionOfMedicationsInsertResponse> Handle(PatientPrescriptionOfMedicationsInsertRequest request, CancellationToken cancellationToken)
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
                CreatedAt = DateTime.UtcNow
            };
            await _patientPrescription.InsertPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(patientPrescriptionOfMedications).ConfigureAwait(false);
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
            return new PatientPrescriptionOfMedicationsInsertSuccess(dto);
        }
        
        return new PatientPrescriptionOfMedicationsInsertFailure("Error inserting patient prescription of medications");
    }
}