using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement.Responses;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement;

public record class GetPatientAdvancementRequest(long IDPatient): IRequest<GetPatientAdvancementResponse>;