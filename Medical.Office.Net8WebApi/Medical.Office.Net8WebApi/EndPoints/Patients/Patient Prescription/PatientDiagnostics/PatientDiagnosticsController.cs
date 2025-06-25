using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientDiagnosticsController : ControllerBase
    {
        private readonly ILogger<PatientDiagnosticsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientDiagnosticsController> _viewModel;

        public PatientDiagnosticsController(ILogger<PatientDiagnosticsController> logger, IMediator mediator, GenericViewModel<PatientDiagnosticsController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }
        
        [HttpGet("GetPatientDiagnostics/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            if(!PatientDiagnosticsGetRequest.CanGet(idPatient, idAppointment, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            var request = PatientDiagnosticsGetRequest.Get(idPatient, idAppointment);
            
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
        [HttpPost("InsertPatientDiagnostics")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientDiagnosticsRequestBody requestBody)
        {
            var data = new PatientDiagnosticsDto(
                0,
                IDPatient: requestBody.IDPatient,
                IDAppointment: requestBody.IDAppointment,
                DiagnosticsType: requestBody.DiagnosticsType,
                Comments: requestBody.Comments,
                DateTime.Now
            );
            
            if(!PatientDiagnosticsInsertRequest.CanInsert(data.IDPatient,data.IDAppointment, data.DiagnosticsType, data.Comments, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            
            var request = PatientDiagnosticsInsertRequest.Insert(data.IDPatient,data.IDAppointment, data.DiagnosticsType, data.Comments);
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
        [HttpPut("UpdatePatientDiagnostics")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientDiagnosticsRequestBody requestBody)
        {
            var data = new PatientDiagnosticsDto(
                0,
                IDPatient: requestBody.IDPatient,
                IDAppointment: requestBody.IDAppointment,
                DiagnosticsType: requestBody.DiagnosticsType,
                Comments: requestBody.Comments,
                DateTime.Now
            );
            
            if(!PatientDiagnosticsUpdateRequest.CanUpdate(data.IDPatient,data.IDAppointment, data.DiagnosticsType, data.Comments,DateTime.Now,  out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            
            var request = PatientDiagnosticsUpdateRequest.Update(data.IDPatient,data.IDAppointment, data.DiagnosticsType, data.Comments, DateTime.Now);
            
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
