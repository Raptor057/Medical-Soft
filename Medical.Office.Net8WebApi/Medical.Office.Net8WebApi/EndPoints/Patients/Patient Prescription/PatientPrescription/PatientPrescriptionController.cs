using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Get;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Update;
using Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientPrescriptionController : ControllerBase
    {
        private readonly ILogger<PatientPrescriptionController> _logger;
        private readonly IMediator _mediator;
        private readonly GenericViewModel<PatientPrescriptionController> _viewModel;

        public PatientPrescriptionController(ILogger<PatientPrescriptionController> logger,
            IMediator mediator, GenericViewModel<PatientPrescriptionController> viewModel)
        {
            _logger = logger;
            _mediator = mediator;
            _viewModel = viewModel;
        }

        [HttpGet("GetPatientPrescription/{idPatient}/{idAppointment}")]
        public async Task<IActionResult> Execute([FromRoute] long idPatient, [FromRoute] long idAppointment)
        {
            var request = new PatientPrescriptionGetRequest
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
        [HttpPost("InsertPatientPrescription")]
        public async Task<IActionResult> ExecutePost([FromBody] PatientPrescriptionRequestBody requestBody)
        {
            var request = new PatientPrescriptionInsertRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                ConsultationNotes = requestBody.ConsultationNotes,
                Height = requestBody.Height,
                Weight = requestBody.Weight,
                BodyMassIndex = requestBody.BodyMassIndex,
                Temperature = requestBody.Temperature,
                RespiratoryRate = requestBody.RespiratoryRate,
                SystolicPressure = requestBody.SystolicPressure,
                DiastolicPressure = requestBody.DiastolicPressure,
                HeartRate = requestBody.HeartRate,
                BodyFatPercentage = requestBody.BodyFatPercentage,
                MuscleMassPercentage = requestBody.MuscleMassPercentage,
                HeadCircumference = requestBody.HeadCircumference,
                OxygenSaturation = requestBody.OxygenSaturation
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

        [HttpPut("UpdatePatientPrescription")]
        public async Task<IActionResult> ExecutePut([FromBody] PatientPrescriptionRequestBody requestBody)
        {
            var request = new PatientPrescriptionUpdateRequest
            {
                IDPatient = requestBody.IDPatient,
                IDAppointment = requestBody.IDAppointment,
                ConsultationNotes = requestBody.ConsultationNotes,
                Height = requestBody.Height,
                Weight = requestBody.Weight,
                BodyMassIndex = requestBody.BodyMassIndex,
                Temperature = requestBody.Temperature,
                RespiratoryRate = requestBody.RespiratoryRate,
                SystolicPressure = requestBody.SystolicPressure,
                DiastolicPressure = requestBody.DiastolicPressure,
                HeartRate = requestBody.HeartRate,
                BodyFatPercentage = requestBody.BodyFatPercentage,
                MuscleMassPercentage = requestBody.MuscleMassPercentage,
                HeadCircumference = requestBody.HeadCircumference,
                OxygenSaturation = requestBody.OxygenSaturation
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
