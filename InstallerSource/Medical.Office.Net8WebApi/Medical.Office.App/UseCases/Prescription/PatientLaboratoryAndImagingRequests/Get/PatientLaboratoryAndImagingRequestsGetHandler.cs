using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get;

internal sealed class PatientLaboratoryAndImagingRequestsGetHandler : IInteractor<PatientLaboratoryAndImagingRequestsGetRequest, PatientLaboratoryAndImagingRequestsGetResponse>
{
    private readonly IPatientPrescription _patientPrescription;

    public PatientLaboratoryAndImagingRequestsGetHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientLaboratoryAndImagingRequestsGetResponse> Handle(PatientLaboratoryAndImagingRequestsGetRequest request, CancellationToken cancellationToken)
    {
        if (request.PatientId > 0 && request.AppointmentId > 0)
        {
            var response = await _patientPrescription
                .GetLastPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoinment(request.PatientId, request.AppointmentId).ConfigureAwait(false);
            if (response == null)
                return new PatientLaboratoryAndImagingRequestsGetSuccess(null); // or return a failure response if appropriate

            var laboratoryAndImagingRequests = new PatientLaboratoryAndImagingRequestsDto(
                response.Id, 
                response.IDPatient,
                response.IDAppointment,
                response.MedicalStudiesOrImagesTypes,
                response.Comments,
                response.CreatedAt);
            return new PatientLaboratoryAndImagingRequestsGetSuccess(laboratoryAndImagingRequests);
        }
        
        if (request.PatientId > 0 && request.AppointmentId == 0)
        {
            var response = await _patientPrescription
                .GetHistoryOfPatientLaboratoryAndImagingRequestsByPatientIdAsync(request.AppointmentId).ConfigureAwait(false);

            var laboratoryAndImagingRequests = response.Select(pd => new PatientLaboratoryAndImagingRequestsDto(
                pd.Id,
                pd.IDPatient,
                pd.IDAppointment,
                pd.MedicalStudiesOrImagesTypes,
                pd.Comments,
                pd.CreatedAt));
            
            return new PatientLaboratoryAndImagingRequestsListGetSuccess(laboratoryAndImagingRequests);
        }
        //return new PatientLaboratoryAndImagingRequestsGetFailure("No data found");
        return new PatientLaboratoryAndImagingRequestsGetSuccess(null); // or return a failure response if appropriate
    }
}