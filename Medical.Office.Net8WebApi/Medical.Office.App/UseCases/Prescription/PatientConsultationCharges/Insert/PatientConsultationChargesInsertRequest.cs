using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert;

public sealed class PatientConsultationChargesInsertRequest: IRequest<PatientConsultationChargesInsertResponse>
{
    public long Id { get; set; }
    public long IDPatient { get; set; }
    public long IDAppointment { get; set; }
    public string Description { get; set; }
    public decimal? Total { get; set; }
    public DateTime? CreatedAt { get; set; }
    public PatientConsultationChargesInsertRequest(PatientConsultationChargesDto patientConsultationCharges)
    {
        Id = patientConsultationCharges.Id;
        IDPatient = patientConsultationCharges.IDPatient;
        IDAppointment = patientConsultationCharges.IDAppointment;
        Description = patientConsultationCharges.Description;
        Total = patientConsultationCharges.Total;
        CreatedAt = patientConsultationCharges.CreatedAt;
    }

    public static bool CanInsert(PatientConsultationChargesDto patientConsultationCharges, out ErrorList errors)
    {
        errors = new();
        if (patientConsultationCharges == null)
        {
            errors.Add("PatientConsultationChargesDto cannot be null");
        }
        if (patientConsultationCharges.IDPatient <= 0)
        {
            errors.Add("IdPatient must be greater than 0");
        }
        if (patientConsultationCharges.IDPatient <= 0)
        {
            errors.Add("IdAppointment must be greater than 0");
        }
        return errors.IsEmpty;
    }
    
    public static PatientConsultationChargesInsertRequest Insert(PatientConsultationChargesDto patientConsultationCharges)
    {
        if (!CanInsert(patientConsultationCharges, out ErrorList errors)) throw errors.AsException();
        return new PatientConsultationChargesInsertRequest(patientConsultationCharges);
    }
}