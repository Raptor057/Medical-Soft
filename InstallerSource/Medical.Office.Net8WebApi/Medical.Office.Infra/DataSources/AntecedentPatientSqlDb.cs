using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class AntecedentPatientSqlDb
{
    private readonly ILogger<AntecedentPatientSqlDb> _logger;
    private readonly ConfigurationSqlDbConnection<AntecedentPatientSqlDb> _con;

    public AntecedentPatientSqlDb(ILogger<AntecedentPatientSqlDb> logger, ConfigurationSqlDbConnection<AntecedentPatientSqlDb> con)
    {
        _logger = logger;
        _con = con;
    }
    
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientsFiles"></param>
        public async Task InsertPatientFiles(PatientsFiles patientsFiles)
            => await _con.ExecuteAsync(
                "INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles]([IDPatient],[FileName],[FileType],[FileExtension],[Description],[FileData])VALUES(@IDPatient,@FileName,@FileType,@FileExtension,@Description,@FileData)",
                new {patientsFiles.IDPatient,
                    patientsFiles.FileName,patientsFiles.FileType,patientsFiles.FileExtension,patientsFiles.Description,patientsFiles.FileData }).ConfigureAwait(false);

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FileName"></param>
        /// <param name="FileType"></param>
        public async Task DeletePatientFiles(long IDPatient ,long Id)
            => await _con.ExecuteAsync("DELETE PatientsFiles WHERE IDPatient = @IDPatient AND [Id] = @Id",new {IDPatient,Id}).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PatientsFiles>> GetPatientsFilesListByIDPatient(long IDPatient)
        => await _con.QueryAsync<PatientsFiles>(@"SELECT [Id]
      ,[IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]
      ,dbo.ufntolocaltime([DateTimeUploaded]) AS [DateTimeUploaded]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles] WHERE IDPatient = @IDPatient", new {IDPatient}).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PatientsFiles> GetPatientFileByIDPatient(long IDPatient, long Id)
            => await _con.QueryFirstAsync<PatientsFiles>(@"SELECT [Id]
      ,[IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]
      ,[FileData]
      ,dbo.ufntolocaltime([DateTimeUploaded]) AS [DateTimeUploaded]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles] WHERE IDPatient = @IDPatient AND Id = @Id", new {IDPatient,Id}).ConfigureAwait(false);

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="ActiveMedicationsData"></param>
        /// <returns></returns>
        public async Task InsertActiveMedications(long IDPatient, string ActiveMedicationsData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[ActiveMedications] " +
                "([IDPatient],[ActiveMedicationsData]) " +
                "VALUES (@IDPatient,@ActiveMedicationsData)",
                new {IDPatient, ActiveMedicationsData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<ActiveMedications> GetActiveMedicationsByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<ActiveMedications>(@"SELECT TOP 1 [Id]
      ,[IDPatient]
      ,[ActiveMedicationsData]
      ,dbo.ufntolocaltime([DateTimeSnap]) as [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[ActiveMedications] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Diabetes"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Hypertension"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <returns></returns>
        public async Task InsertFamilyHistory(long IDPatient, bool? Diabetes, bool? Cardiopathies, bool? Hypertension, bool? ThyroidDiseases, bool? ChronicKidneyDisease, bool? Others, string? OthersData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[FamilyHistory]" +
                "([IDPatient],[Diabetes],[Cardiopathies],[Hypertension],[ThyroidDiseases],[ChronicKidneyDisease],[Others],[OthersData])" +
                "VALUES(@IDPatient, @Diabetes, @Cardiopathies, @Hypertension, @ThyroidDiseases, @ChronicKidneyDisease, @Others, @OthersData)", 
                new { IDPatient, Diabetes, Cardiopathies, Hypertension, ThyroidDiseases, ChronicKidneyDisease, Others, OthersData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<FamilyHistory> GetFamilyHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<FamilyHistory>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[Diabetes]
      ,[Cardiopathies]
      ,[Hypertension]
      ,[ThyroidDiseases]
      ,[ChronicKidneyDisease]
      ,[Others]
      ,[OthersData]
      ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[FamilyHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="MedicalHistoryNotesData"></param>
        /// <returns></returns>
        public async Task InsertMedicalHistoryNotes(long IDPatient, string MedicalHistoryNotesData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[MedicalHistoryNotes]" +
                "([IDPatient],[MedicalHistoryNotesData])" +
                "VALUES(@IDPatient,@MedicalHistoryNotesData);",
                new {IDPatient,MedicalHistoryNotesData}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<MedicalHistoryNotes> GetMedicalHistoryNotesByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<MedicalHistoryNotes>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[MedicalHistoryNotesData]
      ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalHistoryNotes] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PhysicalActivity"></param>
        /// <param name="Smoking"></param>
        /// <param name="Alcoholism"></param>
        /// <param name="SubstanceAbuse"></param>
        /// <param name="SubstanceAbuseData"></param>
        /// <param name="RecentVaccination"></param>
        /// <param name="RecentVaccinationData"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <returns></returns>
        public async Task InsertNonPathologicalHistory(long IDPatient, int? PhysicalActivity, int? Smoking, int? Alcoholism, int? SubstanceAbuse, string? SubstanceAbuseData, int? RecentVaccination, string? RecentVaccinationData, int? Others, string? OthersData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[NonPathologicalHistory]" +
                "([IDPatient],[PhysicalActivity],[Smoking],[Alcoholism],[SubstanceAbuse],[SubstanceAbuseData],[RecentVaccination],[RecentVaccinationData],[Others],[OthersData])" +
                "VALUES(@IDPatient, @PhysicalActivity, @Smoking, @Alcoholism, @SubstanceAbuse, @SubstanceAbuseData, @RecentVaccination, @RecentVaccinationData, @Others, @OthersData )",
                new { IDPatient, PhysicalActivity, Smoking, Alcoholism, SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<NonPathologicalHistory> GetNonPathologicalHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<NonPathologicalHistory>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[PhysicalActivity]
      ,[Smoking]
      ,[Alcoholism]
      ,[SubstanceAbuse]
      ,[SubstanceAbuseData]
      ,[RecentVaccination]
      ,[RecentVaccinationData]
      ,[Others]
      ,[OthersData]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[NonPathologicalHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PreviousHospitalization"></param>
        /// <param name="PreviousSurgeries"></param>
        /// <param name="Diabetes"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="Hypertension"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Trauma"></param>
        /// <param name="Cancer"></param>
        /// <param name="Tuberculosis"></param>
        /// <param name="Transfusions"></param>
        /// <param name="RespiratoryDiseases"></param>
        /// <param name="GastrointestinalDiseases"></param>
        /// <param name="STDs"></param>
        /// <param name="STDsData"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <returns></returns>
        public async Task InsertPathologicalBackground(long IDPatient, int? PreviousHospitalization, int? PreviousSurgeries, int? Diabetes, int? ThyroidDiseases, int? Hypertension, int? Cardiopathies, int? Trauma, int? Cancer, int? Tuberculosis, int? Transfusions, int? RespiratoryDiseases, int? GastrointestinalDiseases, int? STDs, string? STDsData, int? ChronicKidneyDisease, string? Others)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PathologicalBackground]" +
                "([IDPatient],[PreviousHospitalization],[PreviousSurgeries],[Diabetes],[ThyroidDiseases],[Hypertension],[Cardiopathies],[Trauma],[Cancer],[Tuberculosis],[Transfusions],[RespiratoryDiseases],[GastrointestinalDiseases],[STDs],[STDsData],[ChronicKidneyDisease],[Others])" +
                "VALUES(@IDPatient, @PreviousHospitalization, @PreviousSurgeries, @Diabetes, @ThyroidDiseases, @Hypertension, @Cardiopathies, @Trauma, @Cancer, @Tuberculosis, @Transfusions, @RespiratoryDiseases, @GastrointestinalDiseases, @STDs, @STDsData, @ChronicKidneyDisease, @Others )",
                new { IDPatient, PreviousHospitalization, PreviousSurgeries, Diabetes, ThyroidDiseases,  Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis, Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData, ChronicKidneyDisease, Others }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PathologicalBackground> GetPathologicalBackgroundByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PathologicalBackground>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[PreviousHospitalization]
      ,[PreviousSurgeries]
      ,[Diabetes]
      ,[ThyroidDiseases]
      ,[Hypertension]
      ,[Cardiopathies]
      ,[Trauma]
      ,[Cancer]
      ,[Tuberculosis]
      ,[Transfusions]
      ,[RespiratoryDiseases]
      ,[GastrointestinalDiseases]
      ,[STDs]
      ,[STDsData]
      ,[ChronicKidneyDisease]
      ,[Others]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PathologicalBackground] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Allergies"></param>
        /// <returns></returns>
        public async Task InsertPatientAllergies(long IDPatient, string Allergies)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientAllergies]" +
                "([IDPatient],[Allergies])" +
                "VALUES(@IDPatient , @Allergies )",
                new { IDPatient , Allergies }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PatientAllergies> GetPatientAllergiesByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PatientAllergies>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[Allergies]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientAllergies] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FamilyHistory"></param>
        /// <param name="FamilyHistoryData"></param>
        /// <param name="AffectedAreas"></param>
        /// <param name="PastAndCurrentTreatments"></param>
        /// <param name="FamilySocialSupport"></param>
        /// <param name="FamilySocialSupportData"></param>
        /// <param name="WorkLifeAspects"></param>
        /// <param name="SocialLifeAspects"></param>
        /// <param name="AuthorityRelationship"></param>
        /// <param name="ImpulseControl"></param>
        /// <param name="FrustrationManagement"></param>
        /// <returns></returns>
        public async Task InsertPsychiatricHistory(long IDPatient, int? FamilyHistory, string? FamilyHistoryData, string? AffectedAreas, string? PastAndCurrentTreatments, int? FamilySocialSupport, string? FamilySocialSupportData, string? WorkLifeAspects, string? SocialLifeAspects, string? AuthorityRelationship, string? ImpulseControl, string? FrustrationManagement)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PsychiatricHistory]" +
                "([IDPatient],[FamilyHistory],[FamilyHistoryData],[AffectedAreas],[PastAndCurrentTreatments],[FamilySocialSupport],[FamilySocialSupportData],[WorkLifeAspects],[SocialLifeAspects],[AuthorityRelationship],[ImpulseControl],[FrustrationManagement])" +
                "VALUES(@IDPatient, @FamilyHistory, @FamilyHistoryData, @AffectedAreas, @PastAndCurrentTreatments, @FamilySocialSupport, @FamilySocialSupportData, @WorkLifeAspects, @SocialLifeAspects, @AuthorityRelationship, @ImpulseControl, @FrustrationManagement )",
                new { IDPatient, FamilyHistory, FamilyHistoryData, AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData, WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl, FrustrationManagement }).ConfigureAwait(false);
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PsychiatricHistory> GetPsychiatricHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PsychiatricHistory>(@"SELECT TOP (1) [id]
      ,[IDPatient]
      ,[FamilyHistory]
      ,[FamilyHistoryData]
      ,[AffectedAreas]
      ,[PastAndCurrentTreatments]
      ,[FamilySocialSupport]
      ,[FamilySocialSupportData]
      ,[WorkLifeAspects]
      ,[SocialLifeAspects]
      ,[AuthorityRelationship]
      ,[ImpulseControl]
      ,[FrustrationManagement]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PsychiatricHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        #region Update Methods

        /// <summary>
        /// Actualiza la información de los medicamentos activos de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="ActiveMedicationsData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateActiveMedications(long IDPatient, string ActiveMedicationsData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[ActiveMedications]
                            SET ActiveMedicationsData = @ActiveMedicationsData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, ActiveMedicationsData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia familiar de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Diabetes"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Hypertension"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateFamilyHistory(long IDPatient, bool? Diabetes, bool? Cardiopathies, bool? Hypertension,
            bool? ThyroidDiseases, bool? ChronicKidneyDisease, bool? Others, string OthersData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[FamilyHistory]
                            SET Diabetes = @Diabetes,
                                Cardiopathies = @Cardiopathies,
                                Hypertension = @Hypertension,
                                ThyroidDiseases = @ThyroidDiseases,
                                ChronicKidneyDisease = @ChronicKidneyDisease,
                                Others = @Others,
                                OthersData = @OthersData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, Diabetes, Cardiopathies, Hypertension, ThyroidDiseases, ChronicKidneyDisease, Others, OthersData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza las notas de la historia médica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="MedicalHistoryNotesData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateMedicalHistoryNotes(long IDPatient, string MedicalHistoryNotesData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[MedicalHistoryNotes]
                                SET MedicalHistoryNotesData = @MedicalHistoryNotesData,
                                    DateTimeSnap = @DateTimeSnap
                                WHERE IDPatient = @IDPatient;",
                                        new { IDPatient, MedicalHistoryNotesData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia no patológica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PhysicalActivity"></param>
        /// <param name="Smoking"></param>
        /// <param name="Alcoholism"></param>
        /// <param name="SubstanceAbuse"></param>
        /// <param name="SubstanceAbuseData"></param>
        /// <param name="RecentVaccination"></param>
        /// <param name="RecentVaccinationData"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateNonPathologicalHistory(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism,
            int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData,
            int Others, string OthersData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[NonPathologicalHistory]
                            SET PhysicalActivity = @PhysicalActivity,
                                Smoking = @Smoking,
                                Alcoholism = @Alcoholism,
                                SubstanceAbuse = @SubstanceAbuse,
                                SubstanceAbuseData = @SubstanceAbuseData,
                                RecentVaccination = @RecentVaccination,
                                RecentVaccinationData = @RecentVaccinationData,
                                Others = @Others,
                                OthersData = @OthersData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, PhysicalActivity, Smoking, Alcoholism, SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza el historial patológico de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PreviousHospitalization"></param>
        /// <param name="PreviousSurgeries"></param>
        /// <param name="Diabetes"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="Hypertension"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Trauma"></param>
        /// <param name="Cancer"></param>
        /// <param name="Tuberculosis"></param>
        /// <param name="Transfusions"></param>
        /// <param name="RespiratoryDiseases"></param>
        /// <param name="GastrointestinalDiseases"></param>
        /// <param name="STDs"></param>
        /// <param name="STDsData"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePathologicalBackground(long IDPatient, int PreviousHospitalization, int PreviousSurgeries,
            int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma,
            int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases,
            int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease,
            string Others, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PathologicalBackground]
                            SET PreviousHospitalization = @PreviousHospitalization,
                                PreviousSurgeries = @PreviousSurgeries,
                                Diabetes = @Diabetes,
                                ThyroidDiseases = @ThyroidDiseases,
                                Hypertension = @Hypertension,
                                Cardiopathies = @Cardiopathies,
                                Trauma = @Trauma,
                                Cancer = @Cancer,
                                Tuberculosis = @Tuberculosis,
                                Transfusions = @Transfusions,
                                RespiratoryDiseases = @RespiratoryDiseases,
                                GastrointestinalDiseases = @GastrointestinalDiseases,
                                STDs = @STDs,
                                STDsData = @STDsData,
                                ChronicKidneyDisease = @ChronicKidneyDisease,
                                Others = @Others,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, PreviousHospitalization, PreviousSurgeries, Diabetes, ThyroidDiseases, Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis, Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData, ChronicKidneyDisease, Others, DateTimeSnap }).ConfigureAwait(false);
    }

        /// <summary>
        /// Actualiza las alergias de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Allergies"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePatientAllergies(long IDPatient, string Allergies, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PatientAllergies]
                            SET Allergies = @Allergies,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, Allergies, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia psiquiátrica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FamilyHistory"></param>
        /// <param name="FamilyHistoryData"></param>
        /// <param name="AffectedAreas"></param>
        /// <param name="PastAndCurrentTreatments"></param>
        /// <param name="FamilySocialSupport"></param>
        /// <param name="FamilySocialSupportData"></param>
        /// <param name="WorkLifeAspects"></param>
        /// <param name="SocialLifeAspects"></param>
        /// <param name="AuthorityRelationship"></param>
        /// <param name="ImpulseControl"></param>
        /// <param name="FrustrationManagement"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePsychiatricHistory(long IDPatient, int FamilyHistory, string FamilyHistoryData,
            string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport,
            string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects,
            string AuthorityRelationship, string ImpulseControl, string FrustrationManagement, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PsychiatricHistory]
                            SET FamilyHistory = @FamilyHistory,
                                FamilyHistoryData = @FamilyHistoryData,
                                AffectedAreas = @AffectedAreas,
                                PastAndCurrentTreatments = @PastAndCurrentTreatments,
                                FamilySocialSupport = @FamilySocialSupport,
                                FamilySocialSupportData = @FamilySocialSupportData,
                                WorkLifeAspects = @WorkLifeAspects,
                                SocialLifeAspects = @SocialLifeAspects,
                                AuthorityRelationship = @AuthorityRelationship,
                                ImpulseControl = @ImpulseControl,
                                FrustrationManagement = @FrustrationManagement,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                            new { IDPatient, FamilyHistory, FamilyHistoryData, AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData, WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl, FrustrationManagement, DateTimeSnap }).ConfigureAwait(false);
        }

        #endregion

        
        #region PatientAdvancement
        public async Task<IEnumerable<PatientAdvancement>> GetPatientAdvancementByIDPatient(long IDPatient)
            => await _con.QueryAsync<PatientAdvancement>(@"
                SELECT [Id]
                ,[IDPatient]
                ,[Concept]
                ,[Quantity]
                ,[Active]
                ,dbo.UfnToLocalTime([DateTimeSnap]) AS [DateTimeSnap]
                FROM [Medical.Office.SqlLocalDB].[dbo].[PatientAdvancement]
                WHERE IDPatient = @IDPatient AND Active = 1 
                ORDER BY DateTimeSnap DESC"
                ,new {IDPatient}).ConfigureAwait(false);
        
        public async Task<PatientAdvancement> GetPatientAdvancementByID(long ID)
            => await _con.QueryFirstAsync<PatientAdvancement>(@"
                SELECT [Id]
                ,[IDPatient]
                ,[Concept]
                ,[Quantity]
                ,[Active]
                ,dbo.UfnToLocalTime([DateTimeSnap]) AS [DateTimeSnap]
                FROM [Medical.Office.SqlLocalDB].[dbo].[PatientAdvancement]
                WHERE IDPatient = @ID AND Active = 1 
                ORDER BY DateTimeSnap DESC"
                ,new {ID}).ConfigureAwait(false);
        
        public async Task InsertPatientAdvancement(long IDPatient, string Concept, decimal? Quantity)
            => await _con.ExecuteAsync(@"
            INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientAdvancement]
            ([IDPatient],[Concept],[Quantity])
            VALUES(@IDPatient,@Concept,@Quantity)"
                ,new {IDPatient,Concept,Quantity}).ConfigureAwait(false);

        public async Task UpdatePatientAdvancement(string Concept, decimal? Quantity, bool Active, long Id)
            => await _con.ExecuteAsync(@"
                UPDATE PatientAdvancement SET Concept = @Concept, Quantity = @Quantity ,Active = @Active
                WHERE Id = @Id AND Active = 1 ",
                new{Concept,Quantity, Active ,Id}).ConfigureAwait(false);
        
        #endregion
        

}