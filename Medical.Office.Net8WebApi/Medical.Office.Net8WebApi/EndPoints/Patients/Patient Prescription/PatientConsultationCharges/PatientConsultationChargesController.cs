using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientConsultationChargesController : ControllerBase
    {
        private readonly ILogger<PatientConsultationChargesController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientConsultationChargesController> _viewModel;
        
        public PatientConsultationChargesController(ILogger<PatientConsultationChargesController> logger, IMediator mediator, GenericViewModel<PatientConsultationChargesController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("GetPatientConsultation/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            if(!PatientConsultationChargesGetRequest.CanGet(idPatient, idAppointment, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            var request = PatientConsultationChargesGetRequest.Get(idPatient, idAppointment);
            
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

        [HttpPost("InsertPatientConsultation")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientConsultationChargesRequestBody requestBody)
        {

            var data = new PatientConsultationChargesDto(
                0,
                IDPatient: requestBody.IDPatient,
                IDAppointment: requestBody.IDAppointment,
                Description: requestBody.Description,
                Total: requestBody.Total,
                DateTime.Now
            );
            
            if (!PatientConsultationChargesInsertRequest.CanInsert(data, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }
            
            var request = PatientConsultationChargesInsertRequest.Insert(data);

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

        [HttpPut("UpdatePatientConsultation")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientConsultationChargesRequestBody requestBody)
        {
            var data = new PatientConsultationChargesDto(
                requestBody.IDPatient,
                IDPatient: requestBody.IDPatient,
                IDAppointment: requestBody.IDAppointment,
                Description: requestBody.Description,
                Total: requestBody.Total,
                DateTime.Now
            );
            if (!PatientConsultationChargesUpdateRequest.CanUpdate(data, out var errors))
            {
                return StatusCode(400, _viewModel.Fail(errors.ToString()));
            }

            var request = PatientConsultationChargesUpdateRequest.Update(data);

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
