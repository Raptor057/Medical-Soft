using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Insert;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalInstructions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalInstructions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMedicalInstructionsController : ControllerBase
    {
        public PatientMedicalInstructionsController(ILogger<PatientMedicalInstructionsController> logger,
            IMediator mediator, GenericViewModel<PatientMedicalInstructionsController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        private readonly ILogger<PatientMedicalInstructionsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientMedicalInstructionsController> _viewModel;

        [HttpGet("GetPatientMedicalInstructions/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientMedicalInstructionsGetRequest
            {
                IdPatient = idPatient,
                IdAppointment = idAppointment
            };


            try
            {
                _ = await _mediator.Send(request).ConfigureAwait(false);
                return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
            }
            catch (Exception ex)
            {
                var innerEx = ex;
                while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
                return StatusCode(500, _viewModel.Fail(innerEx.Message));
            }
        }

        [HttpPost("InsertPatientMedicalInstructions")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientMedicalInstructionsRequestBody requestBody)
        {
            var request = new PatientMedicalInstructionsInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalInstructions = requestBody.MedicalInstructions
            };
            
            try
            {
                _ = await _mediator.Send(request).ConfigureAwait(false);
                return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
            }
            catch (Exception ex)
            {
                var innerEx = ex;
                while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
                return StatusCode(500, _viewModel.Fail(innerEx.Message));
            }
        }

        [HttpPut("UpdatePatientMedicalInstructions")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientMedicalInstructionsRequestBody requestBody)
        {
            var request = new PatientMedicalInstructionsInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalInstructions = requestBody.MedicalInstructions
            };

            try
            {
                _ = await _mediator.Send(request).ConfigureAwait(false);
                return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
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
