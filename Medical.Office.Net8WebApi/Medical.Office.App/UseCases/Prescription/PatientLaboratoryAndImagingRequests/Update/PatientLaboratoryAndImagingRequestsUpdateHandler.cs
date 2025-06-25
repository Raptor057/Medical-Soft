using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Update.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Update;

internal sealed class PatientLaboratoryAndImagingRequestsUpdateHandler  : IInteractor<PatientLaboratoryAndImagingRequestsUpdateRequest, PatientLaboratoryAndImagingRequestsUpdateResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientLaboratoryAndImagingRequestsUpdateHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    public async Task<PatientLaboratoryAndImagingRequestsUpdateResponse> Handle(PatientLaboratoryAndImagingRequestsUpdateRequest request, CancellationToken cancellationToken)
    {
        if(request != null)
        {
            var PatientLaboratory = new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientLaboratoryAndImaging
            {
                IDPatient = request.IDPatient,
                IDAppointment = request.IDAppointment,
                MedicalStudiesOrImagesTypes = request.MedicalStudiesOrImagesTypes,
                Comments = request.Comments,
            };

           await  _patientPrescription.UpdatePatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(PatientLaboratory)
                .ConfigureAwait(false);
            
            var dto = new PatientLaboratoryAndImagingRequestsDto(
                0,
                PatientLaboratory.IDPatient,
                PatientLaboratory.IDAppointment,
                PatientLaboratory.MedicalStudiesOrImagesTypes,
                PatientLaboratory.Comments,
                DateTime.Now);

            return new PatientLaboratoryAndImagingRequestsUpdateSuccess(dto);
        }
        
        return new PatientLaboratoryAndImagingRequestsUpdateFailure("Error updating laboratory and imaging requests");
    }
}