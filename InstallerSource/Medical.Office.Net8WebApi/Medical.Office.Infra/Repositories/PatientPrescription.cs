using Medical.Office.Domain.Entities.MedicalOffice.Prescription;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories;

public class PatientPrescription : IPatientPrescription
{
    private readonly PrescriptionSqlDb _prescriptionSqlDb;

    public PatientPrescription(PrescriptionSqlDb prescriptionSqlDb)
    {
        _prescriptionSqlDb=prescriptionSqlDb;
    }
    
    #region PatientConsultationCharges
    //Get
    
    /// <summary>
    /// Get the last PatientConsultationCharges by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientConsultationCharges> GetLastPatientConsultationChargesByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientConsultationCharges = await _prescriptionSqlDb.GetPatientConsultationChargesByIdPatientAndIdAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientConsultationCharges;
    }

    /// <summary>
    /// Get the history of PatientConsultationCharges by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientConsultationCharges>> GetHistoryOfPatientConsultationChargesByPatientIdAsync(long IDPatient)
    {
        var patientConsultationCharges = await _prescriptionSqlDb.GetPatientConsultationChargesByIdPatient(IDPatient)
            .ConfigureAwait(false);
        return patientConsultationCharges;
    }

    //Insert
    
    /// <summary>
    /// Insert the PatientConsultationCharges by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientConsultationCharges"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientConsultationChargesByPatientIdAsyncAndIDAppoiment(
        PatientConsultationCharges patientConsultationCharges)
    {
        await _prescriptionSqlDb.InsertPatientConsultationCharges(patientConsultationCharges).ConfigureAwait(false);
    }

    //Update
    /// <summary>
    /// Update the PatientConsultationCharges by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientConsultationCharges"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientConsultationChargesByPatientIdAsyncAndIDAppoiment(
        PatientConsultationCharges patientConsultationCharges)
    {
        await _prescriptionSqlDb.UpdatePatientConsultationCharges(patientConsultationCharges).ConfigureAwait(false);
    }
    #endregion

    #region PatientDiagnostics
    
    /// <summary>
    /// Get the last PatientDiagnostics by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientDiagnostics> GetLastPatientDiagnosticsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientDiagnostics = await _prescriptionSqlDb.GetPatientDiagnosticsByIdPatientAndIdAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientDiagnostics;
    }

    /// <summary>
    /// Get the history of PatientDiagnostics by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientDiagnostics>> GetHistoryOfPatientDiagnosticsByPatientIdAsync(long IDPatient)
    {
       var patientDiagnostics = await _prescriptionSqlDb.GetPatientDiagnosticsByIdPatient(IDPatient)
            .ConfigureAwait(false);
        return patientDiagnostics;
    }

    /// <summary>
    /// Insert the PatientDiagnostics by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientDiagnostics"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientDiagnosticsByPatientIdAsyncAndIDAppoiment(PatientDiagnostics patientDiagnostics)
    {
        await _prescriptionSqlDb.InsertPatientDiagnostics(patientDiagnostics).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientDiagnostics by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientDiagnostics"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientDiagnosticsByPatientIdAsyncAndIDAppoiment(PatientDiagnostics patientDiagnostics)
    {
        await _prescriptionSqlDb.UpdatePatientDiagnostics(patientDiagnostics).ConfigureAwait(false);
    }
    #endregion

    #region PatientLaboratoryAndImagingRequests
    
    /// <summary>
    /// Get the last PatientLaboratoryAndImagingRequests by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientLaboratoryAndImaging> GetLastPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientLaboratoryAndImagingRequests = await _prescriptionSqlDb.GetPatientLaboratoryAndImagingRequestsByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientLaboratoryAndImagingRequests;
    }

    /// <summary>
    /// Get the history of PatientLaboratoryAndImagingRequests by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientLaboratoryAndImaging>> GetHistoryOfPatientLaboratoryAndImagingRequestsByPatientIdAsync(long IDPatient)
    {
        var patientLaboratoryAndImagingRequests = await _prescriptionSqlDb.GetPatientLaboratoryAndImagingRequestsByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientLaboratoryAndImagingRequests;
    }

    /// <summary>
    /// Insert the PatientLaboratoryAndImagingRequests by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientLaboratoryAndImagingRequests"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(
        PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests)
    {
        await _prescriptionSqlDb.InsertPatientLaboratoryAndImagingRequests(patientLaboratoryAndImagingRequests).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientLaboratoryAndImagingRequests by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientLaboratoryAndImagingRequests"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientLaboratoryAndImagingRequestsByPatientIdAsyncAndIDAppoiment(
        PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests)
    {

        await _prescriptionSqlDb.UpdatePatientLaboratoryAndImagingRequests(patientLaboratoryAndImagingRequests).ConfigureAwait(false);
    }
    #endregion
    
    #region PatientMedicalInstructions
    
    /// <summary>
    /// Get the last PatientMedicalInstructions by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientMedicalInstructions> GetLastPatientMedicalInstructionsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientMedicalInstructions = await _prescriptionSqlDb.GetPatientMedicalInstructionsByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientMedicalInstructions;
    }
    
    /// <summary>
    /// Get the history of PatientMedicalInstructions by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientMedicalInstructions>> GetHistoryOfPatientMedicalInstructionsByPatientIdAsync(long IDPatient)
    {
        var patientMedicalInstructions = await _prescriptionSqlDb.GetPatientMedicalInstructionsByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientMedicalInstructions;
    }

    /// <summary>
    /// Insert the PatientMedicalInstructions by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientMedicalInstructions"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(
        PatientMedicalInstructions patientMedicalInstructions)
    {
        await _prescriptionSqlDb.InsertPatientMedicalInstructions(patientMedicalInstructions).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientMedicalInstructions by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientMedicalInstructions"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientMedicalInstructionsByPatientIdAsyncAndIDAppoiment(
        PatientMedicalInstructions patientMedicalInstructions)
    {
        await _prescriptionSqlDb.UpdatePatientMedicalInstructions(patientMedicalInstructions).ConfigureAwait(false);
    }
    #endregion

    #region PatientMedicalProcedures
    /// <summary>
    /// Get the last PatientMedicalProcedures by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientMedicalProcedures> GetLastPatientMedicalProceduresByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientMedicalProcedures = await _prescriptionSqlDb.GetPatientMedicalProceduresByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientMedicalProcedures;
    }

    /// <summary>
    /// Get the history of PatientMedicalProcedures by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientMedicalProcedures>> GetHistoryOfPatientMedicalProceduresByPatientIdAsync(long IDPatient)
    {
        var patientMedicalProcedures = await _prescriptionSqlDb.GetPatientMedicalProceduresByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientMedicalProcedures;
    }

    /// <summary>
    /// Insert the PatientMedicalProcedures by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientMedicalProcedures"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(PatientMedicalProcedures patientMedicalProcedures)
    {
        await _prescriptionSqlDb.InsertPatientMedicalProcedures(patientMedicalProcedures).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientMedicalProcedures by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientMedicalProcedures"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientMedicalProceduresByPatientIdAsyncAndIDAppoiment(PatientMedicalProcedures patientMedicalProcedures)
    {
        await _prescriptionSqlDb.UpdatePatientMedicalProcedures(patientMedicalProcedures).ConfigureAwait(false);
    }
    #endregion

    #region PatientPrescription
    /// <summary>
    /// Get the last PatientPrescription by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Domain.Entities.MedicalOffice.Prescription.PatientPrescription> GetLastPatientPrescriptionByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientPrescription = await _prescriptionSqlDb.GetPatientPrescriptionsByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientPrescription;
    }

    /// <summary>
    /// Get the history of PatientPrescription by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<Domain.Entities.MedicalOffice.Prescription.PatientPrescription>> GetHistoryOfPatientPrescriptionByPatientIdAsync(long IDPatient)
    {
        var patientPrescription = await _prescriptionSqlDb.GetPatientPrescriptionsByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientPrescription;
    }

    /// <summary>
    /// Insert the PatientPrescription by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientPrescription"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientPrescriptionByPatientIdAsyncAndIDAppoiment(Domain.Entities.MedicalOffice.Prescription.PatientPrescription patientPrescription)
    {
        await _prescriptionSqlDb.InsertPatientPrescription(patientPrescription).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientPrescription by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientPrescription"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientPrescriptionByPatientIdAsyncAndIDAppoiment(Domain.Entities.MedicalOffice.Prescription.PatientPrescription patientPrescription)
    {
        await _prescriptionSqlDb.UpdatePatientPrescription(patientPrescription).ConfigureAwait(false);
    }
    #endregion

    #region PatientPrescriptionOfMedications
    
    /// <summary>
    /// Get the last PatientPrescriptionOfMedications by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientPrescriptionOfMedications> GetLastPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientPrescriptionOfMedications = await _prescriptionSqlDb.GetPatientPrescriptionOfMedicationsByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientPrescriptionOfMedications;
    }

    /// <summary>
    /// Get the history of PatientPrescriptionOfMedications by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientPrescriptionOfMedications>> GetHistoryOfPatientPrescriptionOfMedicationsByPatientIdAsync(int IDPatient)
    {
        var patientPrescriptionOfMedications = await _prescriptionSqlDb.GetPatientPrescriptionOfMedicationsByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientPrescriptionOfMedications;
    }

    /// <summary>
    /// Insert the PatientPrescriptionOfMedications by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientPrescriptionOfMedications"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(
        PatientPrescriptionOfMedications patientPrescriptionOfMedications)
    {
        await _prescriptionSqlDb.InsertPatientPrescriptionOfMedications(patientPrescriptionOfMedications).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientPrescriptionOfMedications by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientPrescriptionOfMedications"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientPrescriptionOfMedicationsByPatientIdAsyncAndIDAppoiment(
        PatientPrescriptionOfMedications patientPrescriptionOfMedications)
    {
        await _prescriptionSqlDb.UpdatePatientPrescriptionOfMedications(patientPrescriptionOfMedications).ConfigureAwait(false);
    }
    #endregion

    #region PatientTreatmentPlan
    
    /// <summary>
    /// Get the last PatientTreatmentPlan by PatientId and AppointmentId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PatientTreatmentPlan> GetLastPatientTreatmentPlanByPatientIdAsyncAndIDAppoinment(long IDPatient, long IDAppointment)
    {
        var patientTreatmentPlan = await _prescriptionSqlDb.GetPatientTreatmentPlanByIDPatientAndIDAppointment(IDPatient, IDAppointment)
            .ConfigureAwait(false);
        
        return patientTreatmentPlan;
    }

    /// <summary>
    /// Get the history of PatientTreatmentPlan by PatientId
    /// </summary>
    /// <param name="IDPatient"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<PatientTreatmentPlan>> GetHistoryOfPatientTreatmentPlanByPatientIdAsync(int IDPatient)
    {
        var patientTreatmentPlan = await _prescriptionSqlDb.GetPatientTreatmentPlanByIDPatient(IDPatient)
            .ConfigureAwait(false);
        return patientTreatmentPlan;
    }

    /// <summary>
    /// Insert the PatientTreatmentPlan by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientTreatmentPlan"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InsertPatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(PatientTreatmentPlan patientTreatmentPlan)
    {
        await _prescriptionSqlDb.InsertPatientTreatmentPlan(patientTreatmentPlan).ConfigureAwait(false);
    }

    /// <summary>
    /// Update the PatientTreatmentPlan by PatientId and AppointmentId
    /// </summary>
    /// <param name="patientTreatmentPlan"></param>
    /// <param name="IDPatient"></param>
    /// <param name="IDAppointment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdatePatientTreatmentPlanByPatientIdAsyncAndIDAppoiment(PatientTreatmentPlan patientTreatmentPlan)
    {
        await _prescriptionSqlDb.UpdatePatientTreatmentPlan(patientTreatmentPlan).ConfigureAwait(false);
    }
    #endregion
}