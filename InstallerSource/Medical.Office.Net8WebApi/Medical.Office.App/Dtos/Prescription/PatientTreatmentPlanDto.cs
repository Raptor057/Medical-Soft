namespace Medical.Office.App.Dtos.Prescription;

public record PatientTreatmentPlanDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string TreatmentPlan,
    DateTime? CreatedAt
);