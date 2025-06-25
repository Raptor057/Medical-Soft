namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.UpdatePatientAdvancement;

public class UpdatePatientAdvancementRequestBody
{
    //public long ID { get; set; }
    //public long IDPatient { get; set; }
    public string Concept { get; set; }
    public decimal Quantity { get; set; }
    public bool Active { get; set; }
}