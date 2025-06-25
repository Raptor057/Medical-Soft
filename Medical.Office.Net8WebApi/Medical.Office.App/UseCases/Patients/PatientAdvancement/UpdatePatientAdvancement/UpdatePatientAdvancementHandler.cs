using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement;

public class UpdatePatientAdvancementHandler: IInteractor<UpdatePatientAdvancementRequest, UpdatePatientAdvancementResponse>
{
    private readonly IPatientsData _patients;
    private readonly ILogger<UpdatePatientAdvancementHandler> _logger;

    public UpdatePatientAdvancementHandler(ILogger<UpdatePatientAdvancementHandler> logger, IPatientsData patients)
    {
        _patients = patients;
        _logger = logger;
    }
    public async Task<UpdatePatientAdvancementResponse> Handle(UpdatePatientAdvancementRequest request, CancellationToken cancellationToken)
    {
        await _patients.UpdatePatientAdvancementAsync(request.Concept,request.Quantity,request.Active,request.ID).ConfigureAwait(false);
        
        var PatientAdvancement = await _patients.GetPatientAdvancementByIDAsync(request.ID).ConfigureAwait(false);
        
        
        if (PatientAdvancement == null)
        {
            return new FailureUpdatePatientAdvancementResponse($"No se encontró abonos para el ID #{request.ID}");
        }

        var PatientAdvancementByID = new PatientAdvancementDto(PatientAdvancement.Id,PatientAdvancement.IDPatient,PatientAdvancement.Concept,PatientAdvancement.Quantity,PatientAdvancement.Active,PatientAdvancement.DateTimeSnap);

        return new SuccessUpdatePatientAdvancementResponse(PatientAdvancementByID);
    }
}