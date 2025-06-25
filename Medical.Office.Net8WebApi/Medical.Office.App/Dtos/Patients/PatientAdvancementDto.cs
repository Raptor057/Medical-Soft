namespace Medical.Office.App.Dtos.Patients;

public record PatientAdvancementDto(
    long Id,
    long IDPatient,
    string Concept,
    decimal? Quantity,
    bool Active,
    DateTime? DateTimeSnap
)
{
    public PatientAdvancementDto() : this(default, default, default, default, default, default)
    {
    }
}