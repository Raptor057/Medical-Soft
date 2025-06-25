using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Update.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Update;

public sealed class PatientLaboratoryAndImagingRequestsUpdateRequest : IRequest<PatientLaboratoryAndImagingRequestsUpdateResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalStudiesOrImagesTypes { get; set; }

    public string Comments { get; set; }
}