using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Update;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientPrescriptionOfMedicationsController : ControllerBase
    {
        public PatientPrescriptionOfMedicationsController(ILogger<PatientPrescriptionOfMedicationsController> logger,
            IMediator mediator, GenericViewModel<PatientPrescriptionOfMedicationsController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        private readonly ILogger<PatientPrescriptionOfMedicationsController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientPrescriptionOfMedicationsController> _viewModel;

        [HttpGet("GetPatientPrescriptionOfMedications/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientPrescriptionOfMedicationsGetRequest
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
        [HttpPost("InsertPatientPrescriptionOfMedications")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientPrescriptionOfMedicationsRequestBody requestBody)
        {
            var request = new PatientPrescriptionOfMedicationsInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                Medications = requestBody.Medications,
                Dose = requestBody.Dose,
                Frequency = requestBody.Frequency,
                Duration = requestBody.Duration,
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

        [HttpPut("UpdatePatientPrescriptionOfMedications")]
        public async Task<IActionResult> ExecuteUpdate(
            [FromBody] PatientPrescriptionOfMedicationsRequestBody requestBody)
        {
            var request = new PatientPrescriptionOfMedicationsUpdateRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                Medications = requestBody.Medications,
                Dose = requestBody.Dose,
                Frequency = requestBody.Frequency,
                Duration = requestBody.Duration,
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
