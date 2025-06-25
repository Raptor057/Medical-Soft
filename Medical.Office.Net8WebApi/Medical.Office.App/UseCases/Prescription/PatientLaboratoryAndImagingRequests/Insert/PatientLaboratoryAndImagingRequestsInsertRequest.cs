using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Prescription;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert.Responses;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert;

public sealed class PatientLaboratoryAndImagingRequestsInsertRequest()
    : IRequest<PatientLaboratoryAndImagingRequestsInsertResponse>
{
    public long IDPatient { get; set; }

    public long IDAppointment { get; set; }

    public string MedicalStudiesOrImagesTypes { get; set; }

    public string Comments { get; set; }
}