using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update;

public sealed class PatientDiagnosticsUpdateRequest : IRequest<PatientDiagnosticsUpdateResponse>
{
   public long IDPatient { get; set; }
   public long IDAppointment { get; set; }
   public string DiagnosticsType { get; set; } = string.Empty;
   public string Comments { get; set; } = string.Empty;
   public DateTime? CreatedAt { get; set; } = null;

   public PatientDiagnosticsUpdateRequest(long idPatient, long idAppointment, string diagnosticsType, string comments, DateTime? createdAt)
   {
      IDPatient = idPatient;
      IDAppointment = idAppointment;
      DiagnosticsType = diagnosticsType;
      Comments = comments;
      CreatedAt = createdAt;
   }
   public static bool CanUpdate(long idPatient, long idAppointment, string diagnosticsType, string comments, DateTime? createdAt, out ErrorList errors)
   {
      errors = new();
      if (idPatient <= 0 || idAppointment <= 0)
      {
         errors.Add("IdPatient or IdAppointment must be greater than 0");
      }
      if (string.IsNullOrEmpty(diagnosticsType))
      {
         errors.Add("DiagnosticsType cannot be empty");
      }
      if (string.IsNullOrEmpty(comments))
      {
         errors.Add("Comments cannot be empty");
      }
      return errors.IsEmpty;
   }
   public static PatientDiagnosticsUpdateRequest Update( long idPatient, long idAppointment, string diagnosticsType, string comments, DateTime? createdAt)
   {
      if (!CanUpdate(idPatient, idAppointment, diagnosticsType, comments, createdAt, out ErrorList errors)) throw errors.AsException();
      return new PatientDiagnosticsUpdateRequest(idPatient, idAppointment, diagnosticsType, comments, createdAt);
   }
   
}