using Common.Common;
using Medical.Office.App.Dtos.Prescription;

namespace Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;

public record PatientPrescriptionInsertSuccess(PatientPrescriptionDto PatientPrescription):PatientPrescriptionInsertResponse,ISuccess;