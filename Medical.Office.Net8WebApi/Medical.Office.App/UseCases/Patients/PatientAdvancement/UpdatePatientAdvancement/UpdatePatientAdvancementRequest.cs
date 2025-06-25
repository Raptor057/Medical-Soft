using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement.Responses;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement;

public class UpdatePatientAdvancementRequest : IRequest<UpdatePatientAdvancementResponse>
{
    
    public static void ValidateData(PatientAdvancementDto PatientAdvancement, ErrorList errors)
    {
        if (PatientAdvancement.Id < 1)
        {
            errors.Add("El ID no es valido");
        }

        if (string.IsNullOrWhiteSpace(PatientAdvancement.Concept))
        {
            errors.Add("El concepto es obligatorio");
        }
        if (PatientAdvancement.Quantity < 1)
        {
            errors.Add("El monto no es valido");
        }
    }
    
    public static bool CanUpdateAdvancement(PatientAdvancementDto PatientAdvancement, out ErrorList errors)
    {
        errors = new();
        ValidateData(PatientAdvancement, errors);
        return errors.IsEmpty;
    }
    
    public static UpdatePatientAdvancementRequest InsertPatientAdvancement(PatientAdvancementDto PatientAdvancement)
    {
        if (!CanUpdateAdvancement(PatientAdvancement, out ErrorList errors)) throw errors.AsException();
        return new UpdatePatientAdvancementRequest(PatientAdvancement);
    }

    public UpdatePatientAdvancementRequest(PatientAdvancementDto PatientAdvancement)
    {
        ID = PatientAdvancement.Id;
        IDPatient = PatientAdvancement.IDPatient;
        Concept = PatientAdvancement.Concept;
        Quantity = PatientAdvancement.Quantity;
        Active = PatientAdvancement.Active;
    }

    public bool Active { get; set; }

    public long ID { get; set; }

    public decimal? Quantity { get; set; }

    public string Concept { get; set; }

    public long IDPatient { get; set; }
    
}