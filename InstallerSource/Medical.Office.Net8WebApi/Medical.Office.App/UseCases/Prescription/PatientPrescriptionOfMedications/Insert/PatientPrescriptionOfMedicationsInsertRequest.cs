using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert;

public sealed class PatientPrescriptionOfMedicationsInsertRequest : IRequest<PatientPrescriptionOfMedicationsInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string Medications { get; set; }

    public string Dose { get; set; }

    public string Frequency { get; set; }

    public string Duration { get; set; }

    public string Comments { get; set; }
}