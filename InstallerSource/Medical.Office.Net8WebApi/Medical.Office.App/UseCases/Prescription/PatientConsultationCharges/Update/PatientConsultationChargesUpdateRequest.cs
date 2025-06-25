using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update;

public sealed class PatientConsultationChargesUpdateRequest : IRequest<PatientConsultationChargesUpdateResponse>
{
    public long Id { get; set; }
    public long IDPatient { get; set; }
    public long IDAppointment { get; set; }
    public string Description { get; set; }
    public decimal? Total { get; set; }
    public DateTime? CreatedAt { get; set; }
    public PatientConsultationChargesUpdateRequest(long id, long idPatient, long idAppointment, string description, decimal? total, DateTime? createdAt)
    {
        Id = id;
        IDPatient = idPatient;
        IDAppointment = idAppointment;
        Description = description;
        Total = total;
        CreatedAt = createdAt;
    }
    public static bool CanUpdate(PatientConsultationChargesDto patientConsultationCharges, out ErrorList errors)
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
    public static PatientConsultationChargesUpdateRequest Update(PatientConsultationChargesDto patientConsultationCharges)
    {
        if (!CanUpdate(patientConsultationCharges, out ErrorList errors)) throw errors.AsException();
        return new PatientConsultationChargesUpdateRequest(patientConsultationCharges.Id, patientConsultationCharges.IDPatient, patientConsultationCharges.IDAppointment, patientConsultationCharges.Description, patientConsultationCharges.Total, patientConsultationCharges.CreatedAt);
    }
    /*
    public static PatientConsultationChargesUpdateRequest Update(long id, long idPatient, long idAppointment, string description, decimal? total, DateTime? createdAt)
    {
        var patientConsultationCharges = new PatientConsultationChargesUpdateRequest(id, idPatient, idAppointment, description, total, createdAt);
        if (!CanUpdate(patientConsultationCharges, out ErrorList errors)) throw errors.AsException();
        return patientConsultationCharges;
    }
    */
}