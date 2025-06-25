using Medical.Office.Domain.Entities.MedicalOffice.Prescription;

namespace Medical.Office.Domain.Repository;

public interface IPatientPrescription
{
    #region PatientConsultationCharges
    
    //Get
    Task <PatientConsultationCharges> GetLastPatientConsultationChargesByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task <IEnumerable<PatientConsultationCharges>> GetHistoryOfPatientConsultationChargesByPatientIdAsync(long IDPatient);
    
    //Insert
    Task InsertPatientConsultationChargesByPatientIdAsyncAndIDAppoiment(PatientConsultationCharges patientConsultationCharges);

    //Update
    Task UpdatePatientConsultationChargesByPatientIdAsyncAndIDAppoiment(PatientConsultationCharges patientConsultationCharges);

    #endregion

    #region PatientDiagnostics

    //Get
    Task<PatientDiagnostics> GetLastPatientDiagnosticsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task <IEnumerable<PatientDiagnostics>> GetHistoryOfPatientDiagnosticsByPatientIdAsync(long IDPatient);

    //Insert
    Task InsertPatientDiagnosticsByPatientIdAsyncAndIDAppoiment(PatientDiagnostics patientDiagnostics);

    //Update
    Task UpdatePatientDiagnosticsByPatientIdAsyncAndIDAppoiment(PatientDiagnostics patientDiagnostics);

    #endregion

    #region PatientLaboratoryAndImagingRequests

    //Get
    Task<PatientLaboratoryAndImaging> GetLastPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientLaboratoryAndImaging>> GetHistoryOfPatientLaboratoryAndImagingRequestsByPatientIdAsync(long IDPatient);

    //Insert
    Task InsertPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests);
    
    //Update
    Task UpdatePatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests);

    #endregion

    #region PatientMedicalInstructions

    //Get
    Task<PatientMedicalInstructions> GetLastPatientMedicalInstructionsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientMedicalInstructions>> GetHistoryOfPatientMedicalInstructionsByPatientIdAsync(long IDPatient);

    //Insert
    Task InsertPatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(PatientMedicalInstructions patientMedicalInstructions);

    //Update
    Task UpdatePatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(PatientMedicalInstructions patientMedicalInstructions);

    #endregion

    #region PatientMedicalProcedures

    //Get
    Task<PatientMedicalProcedures> GetLastPatientMedicalProceduresByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientMedicalProcedures>> GetHistoryOfPatientMedicalProceduresByPatientIdAsync(long IDPatient);

    //Insert
    Task InsertPatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(PatientMedicalProcedures patientMedicalProcedures);

    //Update
    Task UpdatePatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(PatientMedicalProcedures patientMedicalProcedures);

    #endregion

    #region PatientPrescription

    //Get
    Task<PatientPrescription> GetLastPatientPrescriptionByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientPrescription>> GetHistoryOfPatientPrescriptionByPatientIdAsync(long IDPatient);

    //Insert
    Task InsertPatientPrescriptionByPatientIdAsyncAndIDAppoiment(PatientPrescription patientPrescription);

    //Update
    Task UpdatePatientPrescriptionByPatientIdAsyncAndIDAppoiment(PatientPrescription patientPrescription);

    #endregion

    #region PatientPrescriptionOfMedications

    //Get
    Task<PatientPrescriptionOfMedications> GetLastPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientPrescriptionOfMedications>> GetHistoryOfPatientPrescriptionOfMedicationsByPatientIdAsync(int IDPatient);

    //Insert
    Task InsertPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(PatientPrescriptionOfMedications patientPrescriptionOfMedications);

    //Update
    Task UpdatePatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(PatientPrescriptionOfMedications patientPrescriptionOfMedications);

    #endregion

    #region PatientTreatmentPlan

    //Get
    Task<PatientTreatmentPlan> GetLastPatientTreatmentPlanByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment);
    Task<IEnumerable<PatientTreatmentPlan>> GetHistoryOfPatientTreatmentPlanByPatientIdAsync(int IDPatient);

    //Insert
    Task InsertPatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(PatientTreatmentPlan patientTreatmentPlan);

    //Update
    Task UpdatePatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(PatientTreatmentPlan patientTreatmentPlan);

    #endregion

}