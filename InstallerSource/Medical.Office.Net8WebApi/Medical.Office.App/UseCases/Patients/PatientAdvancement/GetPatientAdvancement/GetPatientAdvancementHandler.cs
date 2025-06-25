using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement;

internal sealed class GetPatientAdvancementHandler : IInteractor<GetPatientAdvancementRequest,GetPatientAdvancementResponse>
{
    private readonly IPatientsData _patients;
    private readonly ILogger<GetPatientAdvancementHandler> _logger;

    public GetPatientAdvancementHandler(ILogger<GetPatientAdvancementHandler> logger, IPatientsData patients)
    {
        _patients = patients;
        _logger = logger;
    }

    public async Task<GetPatientAdvancementResponse> Handle(GetPatientAdvancementRequest request, CancellationToken cancellationToken)
    {
        var PatientAdvancement = await _patients.GetPatientAdvancementByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
        
        if (PatientAdvancement == null || PatientAdvancement.Count() == 0)
        {
            return new FailureGetPatientAdvancementResponse($"No se encontró abonos para el paciente #{request.IDPatient}");
        }

        var PatientAdvancementList = PatientAdvancement.Select(p => 
            new PatientAdvancementDto(p.Id,p.IDPatient,p.Concept,p.Quantity,p.Active,p.DateTimeSnap)).ToList();
            
        return new SuccessGetPatientAdvancementResponse(PatientAdvancementList);
    }
}