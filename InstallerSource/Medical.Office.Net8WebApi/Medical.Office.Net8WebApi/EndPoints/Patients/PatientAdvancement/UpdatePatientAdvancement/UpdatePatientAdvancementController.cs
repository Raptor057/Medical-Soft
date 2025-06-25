using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.UpdatePatientAdvancement
{
    [Route("[controller]")]
    [ApiController]
    public class UpdatePatientAdvancementController : ControllerBase
    {
        private readonly ILogger<UpdatePatientAdvancementController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<UpdatePatientAdvancementController> _viewModel;

        public UpdatePatientAdvancementController(ILogger<UpdatePatientAdvancementController> logger,
            IMediator mediator, GenericViewModel<UpdatePatientAdvancementController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        
        [HttpPatch, Route("/api/UpdatePatientAdvancement/{Id}")]
        public async Task<IActionResult> Execute([FromRoute]long Id,[FromBody] UpdatePatientAdvancementRequestBody requestBody)
        {
            // Crear el DTO
            var patientAdvancementDto = new PatientAdvancementDto
            {
                Id = Id,
                IDPatient = 0,
                Concept = requestBody.Concept,
                Quantity = requestBody.Quantity,
                Active = requestBody.Active,
                DateTimeSnap = DateTime.Now
            };
            
            if(!UpdatePatientAdvancementRequest.CanUpdateAdvancement(patientAdvancementDto,out var errors))
            {
                // En lugar de lanzar una excepción, devolver los errores
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }
            
            // Crear la solicitud correcta
            var request = new UpdatePatientAdvancementRequest(patientAdvancementDto);

            try
            {
                // Enviar la solicitud al mediador
                var response = await _mediator.Send(request).ConfigureAwait(false);

                // Verificar la respuesta y devolver el resultado adecuado
                return _viewModel.IsSuccess ? Ok(response) : StatusCode(500, _viewModel);
            }
            catch (Exception ex)
            {
                var innerEx = ex;
                return StatusCode(500, _viewModel.Fail(ex.Message));
            }
        }

    }
}
