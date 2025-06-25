namespace Medical.Office.App.Dtos.Prescription;

public record PatientPrescriptionDto(
    long Id,
    long IDPatient,
    long IDAppointment,
    string ConsultationNotes,
    decimal? Height,
    decimal? Weight,
    decimal? BodyMassIndex,
    decimal? Temperature,
    decimal? RespiratoryRate,
    decimal? SystolicPressure,
    decimal? DiastolicPressure,
    decimal? HeartRate,
    decimal? BodyFatPercentage,
    decimal? MuscleMassPercentage,
    decimal? HeadCircumference,
    decimal? OxygenSaturation,
    DateTime? CreatedAt,
    DateTime? UpdatedAt
);