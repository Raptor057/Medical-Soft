namespace Medical.Office.Domain.Entities.MedicalOffice;

public class PatientAdvancement
{
    public long Id { get; set; }

    public long IDPatient { get; set; }

    public string Concept { get; set; }

    public decimal? Quantity { get; set; }
    
    public bool Active { get; set; }
    
    public DateTime? DateTimeSnap { get; set; }

}