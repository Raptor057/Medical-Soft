using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientTreatmentPlan
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTreatmentPlanController : ControllerBase
    {
        public PatientTreatmentPlanController(ILogger<PatientTreatmentPlanController> logger,
            IMediator mediator, GenericViewModel<PatientTreatmentPlanController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        private readonly ILogger<PatientTreatmentPlanController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientTreatmentPlanController> _viewModel;

        [HttpGet("GetPatientTreatmentPlan/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientTreatmentPlanGetRequest
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
        [HttpPost("InsertPatientTreatmentPlan")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientTreatmentPlanRequestBody requestBody)
        {
            var request = new PatientTreatmentPlanInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                TreatmentPlan = requestBody.TreatmentPlan
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
        [HttpPut("UpdatePatientTreatmentPlan")]
        public async Task<IActionResult> ExecuteUpdate([FromBody] PatientTreatmentPlanRequestBody requestBody)
        {
            var request = new PatientTreatmentPlanUpdateRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                TreatmentPlan = requestBody.TreatmentPlan
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
