using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.GetPatientAdvancement
{
    [Route("[controller]")]
    [ApiController]
    public class GetPatientAdvancementController : ControllerBase
    {
        private readonly ILogger<GetPatientAdvancementController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<GetPatientAdvancementController> _viewModel;

        public GetPatientAdvancementController(ILogger<GetPatientAdvancementController> logger,IMediator mediator, GenericViewModel<GetPatientAdvancementController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet, Route("/api/GetPatientAdvancement/{IDPatient}")]
        public async Task<IActionResult> Execute([FromRoute] long IDPatient)
        {
            
            var request = new GetPatientAdvancementRequest(IDPatient);
            
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
