namespace Medical.Office.App.Dtos.Prescription;

public record PatientConsultationChargesDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string Description,
    decimal? Total,
    DateTime? CreatedAt
);