namespace Medical.Office.App.Dtos.Prescription;

public record PatientPrescriptionOfMedicationsDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string Medications,
    string Dose,
    string Frequency,
    string Duration,
    string Comments,
    DateTime? CreatedAt
);