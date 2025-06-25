namespace Medical.Office.App.Dtos.Prescription;

public record PatientLaboratoryAndImagingRequestsDto(

    long Id,
    long IDPatient,
    long IDAppointment,
    string MedicalStudiesOrImagesTypes,
    string Comments,
    DateTime? CreatedAt
);