using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert.Responses;

public record PatientLaboratoryAndImagingRequestsInsertSuccess(
    PatientLaboratoryAndImagingRequestsDto PatientLaboratoryAndImaging) : PatientLaboratoryAndImagingRequestsInsertResponse ,ISuccess; 