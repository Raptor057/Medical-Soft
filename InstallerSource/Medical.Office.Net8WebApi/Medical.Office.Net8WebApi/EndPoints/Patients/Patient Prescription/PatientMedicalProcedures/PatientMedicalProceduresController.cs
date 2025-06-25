using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMedicalProceduresController : ControllerBase
    {
        private readonly ILogger<PatientMedicalProceduresController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientMedicalProceduresController> _viewModel;

        public PatientMedicalProceduresController(ILogger<PatientMedicalProceduresController> logger,
            IMediator mediator, GenericViewModel<PatientMedicalProceduresController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        
        [HttpGet("GetPatientMedicalProcedures/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientMedicalProceduresGetRequest
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
        [HttpPost("InsertPatientMedicalProcedures")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientMedicalProceduresRequestBody requestBody)
        {
            var request = new PatientMedicalProceduresInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalProceduresTypes = requestBody.MedicalProceduresTypes,
                Comments = requestBody.Comments,
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

        [HttpPut("UpdatePatientMedicalProcedures")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientMedicalProceduresRequestBody requestBody)
        {
            var request = new PatientMedicalProceduresUpdateRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalProceduresTypes = requestBody.MedicalProceduresTypes,
                Comments = requestBody.Comments,
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
