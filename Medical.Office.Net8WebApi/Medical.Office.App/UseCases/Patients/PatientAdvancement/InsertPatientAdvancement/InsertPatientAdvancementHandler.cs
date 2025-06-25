using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement;

public class InsertPatientAdvancementHandler:IInteractor<InsertPatientAdvancementRequest, InsertPatientAdvancementResponse>
{
    private readonly IPatientsData _patients;
    private readonly ILogger<InsertPatientAdvancementHandler> _logger;

    public InsertPatientAdvancementHandler(ILogger<InsertPatientAdvancementHandler> logger, IPatientsData patients)
    {
        _patients = patients;
        _logger = logger;
    }
    
    public async Task<InsertPatientAdvancementResponse> Handle(InsertPatientAdvancementRequest request, CancellationToken cancellationToken)
    {
        await _patients.InsertPatientAdvancementAsync(request.IDPatient,request.Concept,request.Quantity).ConfigureAwait(false);
        
        var PatientAdvancement = await _patients.GetPatientAdvancementByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
        
        var LastPatientAdvancement = PatientAdvancement.OrderByDescending(p => p.DateTimeSnap).FirstOrDefault();
        
        if (LastPatientAdvancement == null)
        {
            return new FailureInsertPatientAdvancementResponse($"No se encontró abonos para el paciente #{request.IDPatient}");
        }

        return new SuccessInsertPatientAdvancementResponse(new PatientAdvancementDto(LastPatientAdvancement.Id,LastPatientAdvancement.IDPatient,LastPatientAdvancement.Concept,LastPatientAdvancement.Quantity,LastPatientAdvancement.Active,LastPatientAdvancement.DateTimeSnap));
    }
}