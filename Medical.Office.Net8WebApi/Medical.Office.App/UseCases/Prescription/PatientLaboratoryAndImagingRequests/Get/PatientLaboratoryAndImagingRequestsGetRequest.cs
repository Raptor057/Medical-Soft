using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get;

public sealed class PatientLaboratoryAndImagingRequestsGetRequest : IRequest<PatientLaboratoryAndImagingRequestsGetResponse>
{
    //public PatientLaboratoryAndImagingRequestsGetRequest()  { }
    public long PatientId { get; set; }
    public long AppointmentId { get; set; }
}