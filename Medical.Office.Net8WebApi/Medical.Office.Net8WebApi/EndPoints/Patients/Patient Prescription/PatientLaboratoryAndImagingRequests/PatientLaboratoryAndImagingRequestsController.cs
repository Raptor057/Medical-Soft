using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientLaboratoryAndImagingRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientLaboratoryAndImagingRequestsController : ControllerBase
    {
        private readonly ILogger<PatientLaboratoryAndImagingRequestsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientLaboratoryAndImagingRequestsController> _viewModel;

        public PatientLaboratoryAndImagingRequestsController(ILogger<PatientLaboratoryAndImagingRequestsController> logger, IMediator mediator, GenericViewModel<PatientLaboratoryAndImagingRequestsController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        
        [HttpGet("GetPatientLaboratoryAndImagingRequests/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientLaboratoryAndImagingRequestsGetRequest
            {
                PatientId = idPatient,
                AppointmentId = idAppointment
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
        [HttpPost("InsertPatientLaboratoryAndImagingRequests")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientDiagnosticsRequestBody requestBody)
        {
            // Implement your logic here
            var request = new PatientLaboratoryAndImagingRequestsInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalStudiesOrImagesTypes = requestBody.DiagnosticsType,
                Comments = requestBody.Comments
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
        [HttpPut("UpdatePatientLaboratoryAndImagingRequests")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientDiagnosticsRequestBody requestBody)
        {
            // Implement your logic here
            var request = new PatientLaboratoryAndImagingRequestsInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                MedicalStudiesOrImagesTypes = requestBody.DiagnosticsType,
                Comments = requestBody.Comments
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
