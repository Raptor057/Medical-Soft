using Common.Common;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get.Responses;

public record PatientLaboratoryAndImagingRequestsGetFailure(string Message) : PatientLaboratoryAndImagingRequestsGetResponse,IFailure;