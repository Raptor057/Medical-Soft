namespace Medical.Office.App.Dtos.Prescription;

public record PatientMedicalInstructionsDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string MedicalInstructions,
    DateTime? CreatedAt
);