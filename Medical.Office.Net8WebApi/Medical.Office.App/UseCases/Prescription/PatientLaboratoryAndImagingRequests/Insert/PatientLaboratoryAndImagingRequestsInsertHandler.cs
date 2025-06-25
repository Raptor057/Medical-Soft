using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert;

internal sealed class PatientLaboratoryAndImagingRequestsInsertHandler : IInteractor<PatientLaboratoryAndImagingRequestsInsertRequest, PatientLaboratoryAndImagingRequestsInsertResponse>
{
    private readonly IPatientPrescription _patientPrescription;
    public PatientLaboratoryAndImagingRequestsInsertHandler(IPatientPrescription patientPrescription)
    {
        _patientPrescription = patientPrescription;
    }
    
    public async Task<PatientLaboratoryAndImagingRequestsInsertResponse> Handle(PatientLaboratoryAndImagingRequestsInsertRequest request, CancellationToken cancellationToken)
    {

        if (request != null)
        {
            var PatientLaboratory =
                new Medical.Office.Domain.Entities.MedicalOffice.Prescription.PatientLaboratoryAndImaging
                {
                    IDPatient = request.IDPatient,
                    IDAppointment = request.IDAppointment,
                    MedicalStudiesOrImagesTypes = request.MedicalStudiesOrImagesTypes,
                    Comments = request.Comments,
                };

           await _patientPrescription.InsertPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(PatientLaboratory)
                .ConfigureAwait(false);
            
            var dto = new PatientLaboratoryAndImagingRequestsDto(
                0,
                PatientLaboratory.IDPatient,
                PatientLaboratory.IDAppointment,
                PatientLaboratory.MedicalStudiesOrImagesTypes,
                PatientLaboratory.Comments,
                DateTime.Now);
            
            return new PatientLaboratoryAndImagingRequestsInsertSuccess(dto);
        }
        
        return new PatientLaboratoryAndImagingRequestsInsertFailure("Error inserting laboratory and imaging requests");
    }
}