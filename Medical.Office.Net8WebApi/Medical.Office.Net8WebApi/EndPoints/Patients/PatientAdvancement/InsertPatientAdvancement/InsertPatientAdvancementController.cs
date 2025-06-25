using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.InsertPatientAdvancement
{
    [Route("[controller]")]
    [ApiController]
    public class InsertPatientAdvancementController : ControllerBase
    {
        private readonly ILogger<InsertPatientAdvancementController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<InsertPatientAdvancementController> _viewModel;

        public InsertPatientAdvancementController(ILogger<InsertPatientAdvancementController> logger,
            IMediator mediator, GenericViewModel<InsertPatientAdvancementController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpPost, Route("/api/InsertPatientAdvancement")]
        public async Task<IActionResult> Execute([FromBody] InsertPatientAdvancementRequestBody requestBody)
        {
            //Crear el DTO
            var patientAdvancementDto = new PatientAdvancementDto
            {
                Id = 0,
                IDPatient = requestBody.IDPatient,
                Concept = requestBody.Concept,
                Quantity = requestBody.Quantity,
                Active = true,
                DateTimeSnap = DateTime.Now
            };
            
            // Validar los datos
            var data = InsertPatientAdvancementRequest.CanInsertPatientAdvancement(patientAdvancementDto,out var error);
            
            if(!InsertPatientAdvancementRequest.CanInsertPatientAdvancement(patientAdvancementDto,out var errors))
            {
                // En lugar de lanzar una excepción, devolver los errores
                return BadRequest(_viewModel.Fail(string.Join("\n", errors)));
            }
            
            // Crear la solicitud correcta
            var request = InsertPatientAdvancementRequest.InsertPatientAdvancement(patientAdvancementDto);
         
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
                while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
                return StatusCode(500, _viewModel.Fail(innerEx.Message));
            }
        }

    }
}
