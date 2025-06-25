using Medical.Office.Domain.Entities.MedicalOffice.Prescription;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class PrescriptionSqlDb
{
    private readonly ConfigurationSqlDbConnection<PrescriptionSqlDb> _con;
    private readonly ILogger<PrescriptionSqlDb> _logger;
    
    public PrescriptionSqlDb(ILogger<PrescriptionSqlDb> logger,ConfigurationSqlDbConnection<PrescriptionSqlDb> con)
    {
        _con = con;
        _logger=logger;
    }

    #region patientConsultationCharges
    
    /// <summary>
    /// Insert PatientConsultationCharges
    /// </summary>
    /// <param name="patientConsultationCharges"></param>
    public async Task InsertPatientConsultationCharges(PatientConsultationCharges patientConsultationCharges) =>
        await _con.ExecuteAsync(
            @"INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientConsultationCharges]
                ([IDPatient],[IDAppointment],[Description],[Total])
                VALUES (@IDPatient,@IDAppointment,@Description,@Total)",
            new {patientConsultationCharges.IDPatient,patientConsultationCharges.IDAppointment, patientConsultationCharges.Description,patientConsultationCharges.Total })
            .ConfigureAwait(false);

    /// <summary>
    /// Get PatientConsultationCharges by IDPatient and IDAppointment
    /// </summary>
    /// <param name="idPatient"></param>
    /// <param name="idAppointment"></param>
    /// <returns></returns>
    public async Task<PatientConsultationCharges> GetPatientConsultationChargesByIdPatientAndIdAppointment(long idPatient, long idAppointment)=>
    await _con.QueryFirstAsync<PatientConsultationCharges>(
        @"SELECT *
            FROM [Medical.Office.SqlLocalDB].[dbo].[PatientConsultationCharges] 
            WHERE IDPatient = @idPatient AND IDAppointment = @idAppointment",
        new {idPatient,idAppointment}).ConfigureAwait(false);
    
    /// <summary>
    /// Get PatientConsultationCharges by IDPatient
    /// </summary>
    /// <param name="idPatient"></param>
    /// <returns></returns>
    public async Task<IEnumerable<PatientConsultationCharges>> GetPatientConsultationChargesByIdPatient(long idPatient)=>
        await _con.QueryAsync<PatientConsultationCharges>(
            @"SELECT *
            FROM [Medical.Office.SqlLocalDB].[dbo].[PatientConsultationCharges] 
            WHERE IDPatient = @idPatient",
            new {idPatient}).ConfigureAwait(false);

    /// <summary>
    /// Update PatientConsultationCharges
    /// </summary>
    /// <param name="patientConsultationCharges"></param>
    public async Task UpdatePatientConsultationCharges(PatientConsultationCharges patientConsultationCharges) =>
        await _con.ExecuteAsync(
            @"UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientConsultationCharges] 
                SET
                [Description]=@Description
                ,[Total] = @Total
                WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment",
            new {patientConsultationCharges.Description,patientConsultationCharges.Total,
                patientConsultationCharges.IDPatient,patientConsultationCharges.IDAppointment})
            .ConfigureAwait(false);
    #endregion

    #region patientDiagnostics
    
    /// <summary>
    /// Insert PatientDiagnostics
    /// </summary>
    /// <param name="patientDiagnostics"></param>
    public async Task InsertPatientDiagnostics(PatientDiagnostics patientDiagnostics) =>
        await _con.ExecuteAsync(
            @"INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientDiagnostics]
                ([IDPatient],[IDAppointment],[DiagnosticsType],[Comments])
                VALUES(@IDPatient,@IDAppointment,@DiagnosticsType,@Comments)",
            new {patientDiagnostics.IDPatient,patientDiagnostics.IDAppointment,
                patientDiagnostics.DiagnosticsType,patientDiagnostics.Comments }).ConfigureAwait(false);

    
    
    /// <summary>
    /// Update PatientDiagnostics by IDPatient and IDAppointment
    /// </summary>
    /// <param name="patientDiagnostics"></param>
    public async Task UpdatePatientDiagnostics(PatientDiagnostics patientDiagnostics) =>
        await _con.ExecuteAsync(
            @"UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientDiagnostics] 
                SET
                [DiagnosticsType]=@DiagnosticsType
                ,[Comments]=@Comments
                WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment",
            new {patientDiagnostics.DiagnosticsType,patientDiagnostics.Comments,patientDiagnostics.IDPatient,patientDiagnostics.IDAppointment }).ConfigureAwait(false);

    /// <summary>
    /// Get PatientDiagnostics by IDPatient and IDAppointment
    /// </summary>
    /// <param name="idPatient"></param>
    /// <param name="idAppointment"></param>
    /// <returns></returns>
    public async Task<PatientDiagnostics> GetPatientDiagnosticsByIdPatientAndIdAppointment(long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientDiagnostics>(
                @"SELECT *
                    FROM [Medical.Office.SqlLocalDB].[dbo].[PatientDiagnostics] 
                    WHERE IDPatient = @idPatient AND IDAppointment = @idAppointment",
                new {idPatient,idAppointment }).ConfigureAwait(false);
    
    /// <summary>
    /// Get PatientDiagnostics by IDPatient
    /// </summary>
    /// <param name="idPatient"></param>
    /// <returns></returns>
    public async Task<IEnumerable<PatientDiagnostics>> GetPatientDiagnosticsByIdPatient(long idPatient) =>
        await _con.QueryAsync<PatientDiagnostics>(
                @"SELECT *
                    FROM [Medical.Office.SqlLocalDB].[dbo].[PatientDiagnostics] 
                    WHERE IDPatient = @idPatient",
                new {idPatient })
            .ConfigureAwait(false);
    #endregion

    #region PatientLaboratoryAndImagingRequests
    
    /// <summary>
    /// Insert PatientLaboratoryAndImagingRequests
    /// </summary>
    /// <param name="idPatient"></param>
    /// <param name="idAppointment"></param>
    /// <returns></returns>
    
    /*
    public async Task<PatientLaboratoryAndImaging> GetPatientLaboratoryAndImagingRequestsByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
    await _con.QueryFirstAsync<PatientLaboratoryAndImaging>(
        @"SELECT *
            FROM [Medical.Office.SqlLocalDB].[dbo].[PatientLaboratoryAndImagingRequests] 
            WHERE IDPatient =@idPatient  AND IDAppointment = @idAppointment",
        new {idPatient,idAppointment}).ConfigureAwait(false);*/
    public async Task<PatientLaboratoryAndImaging> GetPatientLaboratoryAndImagingRequestsByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientLaboratoryAndImaging>(
            @"SELECT top 1 *
                FROM [Medical.Office.SqlLocalDB].[dbo].[PatientLaboratoryAndImagingRequests] 
                WHERE IDPatient = @idPatient  AND IDAppointment = @idAppointment
                ORDER BY CreatedAt DESC",
            new {idPatient,idAppointment}).ConfigureAwait(false);
    

    /// <summary>
    /// Get PatientLaboratoryAndImagingRequests by IDPatient and IDAppointment
    /// </summary>
    /// <param name="idPatient"></param>
    /// <returns></returns>
    public async Task<IEnumerable<PatientLaboratoryAndImaging>> GetPatientLaboratoryAndImagingRequestsByIDPatient(long idPatient) =>
        await _con.QueryAsync<PatientLaboratoryAndImaging>(
            @"SELECT *
            FROM [Medical.Office.SqlLocalDB].[dbo].[PatientLaboratoryAndImagingRequests] 
            WHERE IDPatient =@idPatient",
            new {idPatient}).ConfigureAwait(false);
    
    /// <summary>
    /// Insert PatientLaboratoryAndImagingRequests
    /// </summary>
    /// <param name="patientLaboratoryAndImagingRequests"></param>
    public async Task InsertPatientLaboratoryAndImagingRequests(PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests) =>
        await _con.ExecuteAsync(
            @"INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientLaboratoryAndImagingRequests]
                ([IDPatient],[IDAppointment],[MedicalStudiesOrImagesTypes],[Comments])
                VALUES(@IDPatient,@IDAppointment,@MedicalStudiesOrImagesTypes,@Comments)",
            new {patientLaboratoryAndImagingRequests.IDPatient,patientLaboratoryAndImagingRequests.IDAppointment,
                patientLaboratoryAndImagingRequests.MedicalStudiesOrImagesTypes,patientLaboratoryAndImagingRequests.Comments }).ConfigureAwait(false);

    /// <summary>
    /// Insert PatientLaboratoryAndImagingRequests
    /// </summary>
    /// <param name="patientLaboratoryAndImagingRequests"></param>
    public async Task UpdatePatientLaboratoryAndImagingRequests(
        PatientLaboratoryAndImaging patientLaboratoryAndImagingRequests) =>
        await _con.ExecuteAsync(
            @"UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientLaboratoryAndImagingRequests] 
                SET
                [MedicalStudiesOrImagesTypes]=@MedicalStudiesOrImagesTypes
                ,[Comments]=@Comments
                WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment",
            new {patientLaboratoryAndImagingRequests.MedicalStudiesOrImagesTypes,patientLaboratoryAndImagingRequests.Comments, 
                patientLaboratoryAndImagingRequests.IDPatient,patientLaboratoryAndImagingRequests.IDAppointment }).ConfigureAwait(false);
    #endregion

    #region PatientMedicalInstructions

    public async Task<IEnumerable<PatientMedicalInstructions>>
        GetPatientMedicalInstructionsByIDPatient(long idPatient) =>
        await _con.QueryAsync<PatientMedicalInstructions>(@"
         SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[MedicalInstructions]
		,[CreatedAt]
        FROM [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalInstructions] 
        WHERE IDPatient = @idPatient"
            , new {idPatient}).ConfigureAwait(false);
    
    public async Task <PatientMedicalInstructions> GetPatientMedicalInstructionsByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
    await _con.QueryFirstAsync<PatientMedicalInstructions>(@"
        SELECT TOP 1
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[MedicalInstructions]
		,[CreatedAt]
         FROM [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalInstructions] 
         WHERE IDPatient = @idPatient and IDAppointment = @idAppointment
         ORDER BY CreatedAt DESC",
        new {idPatient,idAppointment}).ConfigureAwait(false);
    
    public async Task InsertPatientMedicalInstructions(PatientMedicalInstructions patientMedicalInstructions) =>
    await _con.ExecuteAsync(@"
    INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalInstructions]
    ([IDPatient],[IDAppointment],[MedicalInstructions])
    VALUES(@IDPatient,@IDAppointment,@MedicalInstructions)"
        ,new {patientMedicalInstructions.IDPatient,patientMedicalInstructions.IDAppointment,patientMedicalInstructions.MedicalInstructions}).ConfigureAwait(false);
    
    public async Task UpdatePatientMedicalInstructions(PatientMedicalInstructions patientMedicalInstructions) =>
    await _con.ExecuteAsync(@"
    UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalInstructions] 
    SET [MedicalInstructions]= @MedicalInstructions
    WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment"
        ,new {patientMedicalInstructions.MedicalInstructions,patientMedicalInstructions.IDPatient,patientMedicalInstructions.IDAppointment}).ConfigureAwait(false);
    
    #endregion

    #region PatientMedicalProcedures
    
    public async Task<IEnumerable<PatientMedicalProcedures>> GetPatientMedicalProceduresByIDPatient(long idPatient) =>
        await _con.QueryAsync<PatientMedicalProcedures>(@"
        SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[MedicalProceduresTypes]
		,[Comments]
		,[CreatedAt]
        FROM [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalProcedures] where IDPatient = @idPatient"
            ,new {idPatient}).ConfigureAwait(false);

    public async Task<PatientMedicalProcedures> GetPatientMedicalProceduresByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientMedicalProcedures>(@"
        SELECT TOP 1
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[MedicalProceduresTypes]
		,[Comments]
		,[CreatedAt]
        FROM [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalProcedures] where IDPatient = @idPatient AND IDAppointment = @idAppointment
        ORDER BY CreatedAt DESC"
            ,new {idPatient,idAppointment}).ConfigureAwait(false);

    public async Task InsertPatientMedicalProcedures(PatientMedicalProcedures patientMedicalProcedures) =>
        await _con.ExecuteAsync(@"
        INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalProcedures]
        ([IDPatient],[IDAppointment],[MedicalProceduresTypes],[Comments])
        VALUES(@IDPatient,@IDAppointment,@MedicalProceduresTypes,@Comments)"
            ,new {patientMedicalProcedures.IDPatient,patientMedicalProcedures.IDAppointment,patientMedicalProcedures.MedicalProceduresTypes,patientMedicalProcedures.Comments}).ConfigureAwait(false);

    public async Task UpdatePatientMedicalProcedures(PatientMedicalProcedures patientMedicalProcedures) =>
        await _con.ExecuteAsync(@"
        UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientMedicalProcedures] 
        SET [MedicalProceduresTypes]= @MedicalProceduresTypes
        ,[Comments]= @Comments
        WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment"
            ,new {patientMedicalProcedures.MedicalProceduresTypes,patientMedicalProcedures.Comments,patientMedicalProcedures.IDPatient,patientMedicalProcedures.IDAppointment}).ConfigureAwait(false);

    #endregion

    #region PatientPrescription
    
    public async Task<IEnumerable<PatientPrescription>> GetPatientPrescriptionsByIDPatient(long idPatient) =>
    await _con.QueryAsync<PatientPrescription>(@"
    SELECT 
		     [Id]
		    ,[IDPatient]
		    ,[IDAppointment]
		    ,[ConsultationNotes]
		    ,[Height]
		    ,[Weight]
		    ,[BodyMassIndex]
		    ,[Temperature]
		    ,[RespiratoryRate]
		    ,[SystolicPressure]
		    ,[DiastolicPressure]
		    ,[HeartRate]
		    ,[BodyFatPercentage]
		    ,[MuscleMassPercentage]
		    ,[HeadCircumference]
		    ,[OxygenSaturation]
		    ,[CreatedAt]
		    ,[UpdatedAt]
    FROM [Medical.Office.SqlLocalDB].[dbo].[PatientPrescription] where IDPatient = @idPatient"
    ,new {idPatient}).ConfigureAwait(false);

    public async Task<PatientPrescription> GetPatientPrescriptionsByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientPrescription>(@"
    SELECT 
		     [Id]
		    ,[IDPatient]
		    ,[IDAppointment]
		    ,[ConsultationNotes]
		    ,[Height]
		    ,[Weight]
		    ,[BodyMassIndex]
		    ,[Temperature]
		    ,[RespiratoryRate]
		    ,[SystolicPressure]
		    ,[DiastolicPressure]
		    ,[HeartRate]
		    ,[BodyFatPercentage]
		    ,[MuscleMassPercentage]
		    ,[HeadCircumference]
		    ,[OxygenSaturation]
		    ,[CreatedAt]
		    ,[UpdatedAt]
    FROM [Medical.Office.SqlLocalDB].[dbo].[PatientPrescription] where IDPatient = @idPatient AND IDAppointment = @idAppointment"
            ,new {idPatient,idAppointment}).ConfigureAwait(false);

    public async Task InsertPatientPrescription(PatientPrescription patientPrescription) =>
        await _con.ExecuteAsync(@"
INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientPrescription]
([IDPatient],[IDAppointment],[ConsultationNotes],[Height],[Weight],[BodyMassIndex],[Temperature],[RespiratoryRate],[SystolicPressure],[DiastolicPressure],[HeartRate],[BodyFatPercentage],[MuscleMassPercentage],[HeadCircumference],[OxygenSaturation])
VALUES(@IDPatient, @IDAppointment, @ConsultationNotes, @Height, @Weight, @BodyMassIndex, @Temperature, @RespiratoryRate, @SystolicPressure, @DiastolicPressure, @HeartRate, @BodyFatPercentage, @MuscleMassPercentage, @HeadCircumference, @OxygenSaturation)"
            , new
        {
            patientPrescription.IDPatient,
            patientPrescription.IDAppointment,
            patientPrescription.ConsultationNotes,
            patientPrescription.Height,
            patientPrescription.Weight,
            patientPrescription.BodyMassIndex,
            patientPrescription.Temperature,
            patientPrescription.RespiratoryRate,
            patientPrescription.SystolicPressure,
            patientPrescription.DiastolicPressure,
            patientPrescription.HeartRate,
            patientPrescription.BodyFatPercentage,
            patientPrescription.MuscleMassPercentage,
            patientPrescription.HeadCircumference,
            patientPrescription.OxygenSaturation
        }).ConfigureAwait(false);

    public async Task UpdatePatientPrescription(PatientPrescription patientPrescription) =>
        await _con.ExecuteAsync(@"
        UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientPrescription] 
        SET
        [IDPatient]=@IDPatient
        ,[IDAppointment]=@IDAppointment
        ,[ConsultationNotes]=@ConsultationNotes
        ,[Height]=@Height
        ,[Weight]=@Weight
        ,[BodyMassIndex]=@BodyMassIndex
        ,[Temperature]=@Temperature
        ,[RespiratoryRate]=@RespiratoryRate
        ,[SystolicPressure]=@SystolicPressure
        ,[DiastolicPressure]=@DiastolicPressure
        ,[HeartRate]=@HeartRate
        ,[BodyFatPercentage]=@BodyFatPercentage
        ,[MuscleMassPercentage]=@MuscleMassPercentage
        ,[HeadCircumference]=@HeadCircumference
        ,[OxygenSaturation]=@OxygenSaturation
        WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment"
            ,new
            {
                patientPrescription.IDPatient,patientPrescription.IDAppointment,patientPrescription.ConsultationNotes,patientPrescription.Height,
                patientPrescription.Weight,patientPrescription.BodyMassIndex,patientPrescription.Temperature,patientPrescription.RespiratoryRate,
                patientPrescription.SystolicPressure,patientPrescription.DiastolicPressure,patientPrescription.HeartRate,patientPrescription.BodyFatPercentage,
                patientPrescription.MuscleMassPercentage,patientPrescription.HeadCircumference,patientPrescription.OxygenSaturation
            }).ConfigureAwait(false);
    #endregion

    #region PatientPrescriptionOfMedications
    public async Task<IEnumerable<PatientPrescriptionOfMedications>> GetPatientPrescriptionOfMedicationsByIDPatient(long idPatient) =>
        await _con.QueryAsync<PatientPrescriptionOfMedications>(@"
         SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[Medications]
		,[Dose]
		,[Frequency]
		,[Duration]
		,[Comments]
		,[CreatedAt]
         FROM [Medical.Office.SqlLocalDB].[dbo].[PatientPrescriptionOfMedications] 
         WHERE IDPatient = @idPatient"     
            ,new {idPatient}).ConfigureAwait(false);

    public async Task<PatientPrescriptionOfMedications> GetPatientPrescriptionOfMedicationsByIDPatientAndIDAppointment(
        long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientPrescriptionOfMedications>(@"
        SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[Medications]
		,[Dose]
		,[Frequency]
		,[Duration]
		,[Comments]
		,[CreatedAt]
        FROM [Medical.Office.SqlLocalDB].[dbo].[PatientPrescriptionOfMedications]  
        WHERE IDPatient = @idPatient AND IDAppointment = @idAppointment
        ORDER BY CreatedAt DESC"
            ,new {idPatient,idAppointment}).ConfigureAwait(false);
    
    public async Task InsertPatientPrescriptionOfMedications(PatientPrescriptionOfMedications patientPrescriptionOfMedications) =>
        await _con.ExecuteAsync(@"
        INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientPrescriptionOfMedications]
        ([IDPatient],[IDAppointment],[Medications],[Dose],[Frequency],[Duration],[Comments])
        VALUES(@IDPatient,@IDAppointment,@Medications,@Dose,@Frequency,@Duration,@Comments)"
            ,new {patientPrescriptionOfMedications.IDPatient,patientPrescriptionOfMedications.IDAppointment,patientPrescriptionOfMedications.Medications,
                patientPrescriptionOfMedications.Dose,patientPrescriptionOfMedications.Frequency,patientPrescriptionOfMedications.Duration,patientPrescriptionOfMedications.Comments}).ConfigureAwait(false);

    public async Task UpdatePatientPrescriptionOfMedications(PatientPrescriptionOfMedications patientPrescriptionOfMedications) =>
        await _con.ExecuteAsync(@"
        UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientPrescriptionOfMedications] 
        SET
        [IDPatient]=@IDPatient
        ,[IDAppointment]=@IDAppointment
        ,[Medications]=@Medications
        ,[Dose]=@Dose
        ,[Frequency]=@Frequency
        ,[Duration]=@Duration
        ,[Comments]=@Comments
        WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment"
            ,new {patientPrescriptionOfMedications.IDPatient,patientPrescriptionOfMedications.IDAppointment,patientPrescriptionOfMedications.Medications,
                patientPrescriptionOfMedications.Dose,patientPrescriptionOfMedications.Frequency,patientPrescriptionOfMedications.Duration,patientPrescriptionOfMedications.Comments}).ConfigureAwait(false);


    #endregion

    #region PatientTreatmentPlan
    public async Task<IEnumerable<PatientTreatmentPlan>> GetPatientTreatmentPlanByIDPatient(long idPatient) =>
    await _con.QueryAsync<PatientTreatmentPlan>(@"
SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[TreatmentPlan]
		,[CreatedAt]
FROM [Medical.Office.SqlLocalDB].[dbo].[PatientTreatmentPlan] WHERE IDPatient = @idPatient"
        ,new {idPatient}).ConfigureAwait(false);

    public async Task<PatientTreatmentPlan> GetPatientTreatmentPlanByIDPatientAndIDAppointment(long idPatient, long idAppointment) =>
        await _con.QueryFirstAsync<PatientTreatmentPlan>(@"
SELECT 
		 [Id]
		,[IDPatient]
		,[IDAppointment]
		,[TreatmentPlan]
		,[CreatedAt]
FROM [Medical.Office.SqlLocalDB].[dbo].[PatientTreatmentPlan] WHERE IDPatient = @idPatient AND IDAppointment = @idAppointment"
            ,new {idPatient,idAppointment}).ConfigureAwait(false);

    public async Task InsertPatientTreatmentPlan(PatientTreatmentPlan patientTreatmentPlan) =>
    await _con.ExecuteAsync(@"
    INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientTreatmentPlan]
    ([IDPatient],[IDAppointment],[TreatmentPlan])
    VALUES(@IDPatient,@IDAppointment,@TreatmentPlan)"
        ,new {patientTreatmentPlan.IDPatient,patientTreatmentPlan.IDAppointment,patientTreatmentPlan.TreatmentPlan}).ConfigureAwait(false);

    public async Task UpdatePatientTreatmentPlan(PatientTreatmentPlan patientTreatmentPlan) =>
        await _con.ExecuteAsync(@"
        UPDATE [Medical.Office.SqlLocalDB].[dbo].[PatientTreatmentPlan] 
        SET
		[IDPatient]=@IDPatient
		,[IDAppointment]=@IDAppointment
		,[TreatmentPlan]=@TreatmentPlan
        WHERE IDPatient = @IDPatient AND IDAppointment = @IDAppointment"
                ,new {patientTreatmentPlan.IDPatient,patientTreatmentPlan.IDAppointment,patientTreatmentPlan.TreatmentPlan})
            .ConfigureAwait(false);
    #endregion

}