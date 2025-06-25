using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get;

public sealed class PatientPrescriptionOfMedicationsGetRequest : IRequest<PatientPrescriptionOfMedicationsGetResponse>
{
    public PatientPrescriptionOfMedicationsGetRequest()
    {
        
    }
    public long IdPatient { get; set; }
    public long IdAppointment { get; set; }
}