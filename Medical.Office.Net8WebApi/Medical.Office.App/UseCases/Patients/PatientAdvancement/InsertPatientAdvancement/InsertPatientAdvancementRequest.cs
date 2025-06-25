using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement;

public class InsertPatientAdvancementRequest: IRequest<InsertPatientAdvancementResponse>
{
    public static void ValidateData(PatientAdvancementDto PatientAdvancement, ErrorList errors)
    {
        if (PatientAdvancement.IDPatient < 1)
        {
            errors.Add("El ID del paciente no es valido");
        }

        if (string.IsNullOrWhiteSpace(PatientAdvancement.Concept))
        {
            
        }
        if (PatientAdvancement.Quantity < 1)
        {
            errors.Add("El monto no es valido");
        }
    }
    
    public static bool CanInsertPatientAdvancement(PatientAdvancementDto PatientAdvancement, out ErrorList errors)
    {
        errors = new();
        ValidateData(PatientAdvancement, errors);
        return errors.IsEmpty;
    }
    
    public static InsertPatientAdvancementRequest InsertPatientAdvancement(PatientAdvancementDto PatientAdvancement)
    {
        if (!CanInsertPatientAdvancement(PatientAdvancement, out ErrorList errors)) throw errors.AsException();
        return new InsertPatientAdvancementRequest(PatientAdvancement);
    }

    public InsertPatientAdvancementRequest(PatientAdvancementDto PatientAdvancement)
    {
        IDPatient = PatientAdvancement.IDPatient;
        Concept = PatientAdvancement.Concept;
        Quantity = PatientAdvancement.Quantity;
    }

    public decimal? Quantity { get; set; }

    public string Concept { get; set; }

    public long IDPatient { get; set; }
}