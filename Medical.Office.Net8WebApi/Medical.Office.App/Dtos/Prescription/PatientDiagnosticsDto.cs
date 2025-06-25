namespace Medical.Office.App.Dtos.Prescription;

public record PatientDiagnosticsDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string DiagnosticsType,
    string Comments,
    DateTime? CreatedAt
);