using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert;

public sealed class PatientPrescriptionInsertRequest : IRequest<PatientPrescriptionInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string ConsultationNotes { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public decimal? BodyMassIndex { get; set; }

    public decimal? Temperature { get; set; }

    public decimal? RespiratoryRate { get; set; }

    public decimal? SystolicPressure { get; set; }

    public decimal? DiastolicPressure { get; set; }

    public decimal? HeartRate { get; set; }

    public decimal? BodyFatPercentage { get; set; }

    public decimal? MuscleMassPercentage { get; set; }

    public decimal? HeadCircumference { get; set; }

    public decimal? OxygenSaturation { get; set; }
    
}