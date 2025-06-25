namespace Medical.Office.App.Dtos.Prescription;

public record PatientMedicalProceduresDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string MedicalProceduresTypes,
    string Comments,
    DateTime? CreatedAt
);