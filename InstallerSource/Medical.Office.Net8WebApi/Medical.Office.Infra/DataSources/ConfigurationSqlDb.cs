using Medical.Office.Domain.Entities.MedicalOffice;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources;

public class ConfigurationSqlDb
{
    private readonly ConfigurationSqlDbConnection<ConfigurationSqlDb> _con;
    private readonly ILogger<ConfigurationSqlDb> _logger;

    public ConfigurationSqlDb(ILogger<ConfigurationSqlDb> logger, ConfigurationSqlDbConnection<ConfigurationSqlDb> con)
    {
        _con = con;
        _logger = logger;
    }
    
       /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LaboralDays> GetLaboralDayByID(int Id)
            => await _con.QuerySingleAsync<LaboralDays>("SELECT * FROM LaboralDays WHERE Id = @Id", new { Id }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LaboralDays>> GetLaboralDaysList()
            => await _con.QueryAsync<LaboralDays>("SELECT *  FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        public async Task UpdateLaboralDaysById(LaboralDays laboralDays)
            => await _con.ExecuteAsync("UPDATE [LaboralDays] SET [Laboral] = @Laboral, [OpeningTime] = @OpeningTime, [ClosingTime] = @ClosingTime WHERE [Id] = @Id;", new { laboralDays .Laboral, laboralDays.OpeningTime, laboralDays .ClosingTime, laboralDays .Id}).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfAppointment"></param>
        /// <returns></returns>
        public async Task InsertTypeOfAppointment(string typeOfAppointment)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]([NameTypeOfAppointment])VALUES(@typeOfAppointment)", new {typeOfAppointment}).ConfigureAwait(false);

        public async Task <IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentsList()
            => await _con.QueryAsync<TypeOfAppointment>("SELECT [Id] ,[NameTypeOfAppointment] FROM [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<LoginHistory> GetLoginHistoryByUsr(string Usr)
            => await _con.QueryFirstAsync<LoginHistory>(@"SELECT TOP (1) [Id]
              ,[Usr]
              ,[UsrName]
              ,[UsrToken]
              ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
          FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] WHERE Usr = @Usr ORDER BY DateTimeSnap DESC", new { Usr }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<LaboralDays> GetTodaysWorkSchedule()
            => await _con.QuerySingleAsync<LaboralDays>("SELECT *  FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays] WHERE [Days] = (SELECT * FROM TodayInLettersView);").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LaboralDays>> GetWorkSchedule()
            => await _con.QueryAsync<LaboralDays>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays] ORDER BY Id ASC;").ConfigureAwait(false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        public async Task UpdateWorkSchedule(LaboralDays laboralDays)
            => await _con.ExecuteAsync("UPDATE LaboralDays SET [Laboral] = @Laboral,OpeningTime = @OpeningTime, ClosingTime = @ClosingTime WHERE [Days] = @Days", new {laboralDays.Laboral,laboralDays.OpeningTime,laboralDays.ClosingTime, laboralDays.Days}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<OfficeSetup> GetOfficeSetup()
            => await _con.QueryFirstAsync<OfficeSetup>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="NameOfOffice"></param>
        /// <param name="Address"></param>
        /// <param name="OpeningTime"></param>
        /// <param name="ClosingTime"></param>
        /// <returns></returns>
        public async Task InsertOfficeSetup(string NameOfOffice, string Address)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]" +
                "([NameOfOffice],[Address])" +
                "VALUES(@NameOfOffice, @Address)",
                new { NameOfOffice, Address }).ConfigureAwait(false);

        public async Task UpdateOfficeSetup(OfficeSetup officeSetup)
            => await _con.ExecuteAsync("UPDATE OfficeSetup SET NameOfOffice = @NameOfOffice , [Address] = @Address WHERE Id = 1", new {officeSetup.NameOfOffice,officeSetup.Address }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genders>> GetGenders()
            => await _con.QueryAsync<Genders>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Genders]").ConfigureAwait(false);

        public async Task StartInsertGenders()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Genders] (Gender) VALUES ('Masculino'),('Femenino');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatuses()
            => await _con.QueryAsync<UserStatuses>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[UserStatuses]").ConfigureAwait(false);

        public async Task StartInsertUserStatuses()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UserStatuses] (TypeUserStatuses) VALUES ('Activo'),('Inactivo');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRoles()
            => await _con.QueryAsync<Roles>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Roles]").ConfigureAwait(false);

        public async Task StartInsertRoles()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Roles] (RolesName) VALUES ('Programador'),('Doctor'),('Enfermera'),('Secretaria'),('Asistente');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositions()
            => await _con.QueryAsync<Positions>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Positions]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task StartInsertPositions()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES ('Programador');").ConfigureAwait(false);

        public async Task StartInsertPositions(string PositionName)
    => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES (@PositionName);", new { PositionName }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task InsertPositions(string position)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES (@position);", new { position }).ConfigureAwait(false);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialties()
            => await _con.QueryAsync<Specialties>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Specialties]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task InsertSpecialties()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES ('Desarollador');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specialtie"></param>
        /// <returns></returns>
        public async Task InsertSpecialties(string specialtie)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES (@specialtie);", new { specialtie }).ConfigureAwait(false);

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointment()
            => await _con.QueryAsync<TypeOfAppointment>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]").ConfigureAwait(false);

        #region Users
        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserById(long Id) =>
                        await _con.QuerySingleAsync<Users>(@"SELECT [Id]
                      ,[Usr]
                      ,[Psswd]
                      ,[Name]
                      ,[Lastname]
                      ,[Role]
                      ,[Position]
                      ,[Status]
                      ,[Specialtie]
                      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Id = @Id;", new { Id }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<Users> GetDataUserByUsr(string Usr) =>
                    await _con.QuerySingleAsync<Users>(@"SELECT TOP (1) [Id]
      ,[Usr]
      ,[Psswd]
      ,[Name]
      ,[Lastname]
      ,[Role]
      ,[Position]
      ,[Status]
      ,[Specialtie]
      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr;", new { Usr }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetDataUserByUsrList(string Usr) =>
                    await _con.QueryAsync<Users>(@"SELECT [Id]
                      ,[Usr]
                      ,[Name]
                      ,[Lastname]
                      ,[Role]
                      ,[Position]
                      ,[Status]
                      ,[Specialtie]
                      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr Like @Usr;", new { Usr = $"%{Usr}%" }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetUsers() =>
                                await _con.QueryAsync<Users>(@"SELECT [Id]
                                  ,[Usr]
                                  ,[Psswd]
                                  ,[Name]
                                  ,[Lastname]
                                  ,[Role]
                                  ,[Position]
                                  ,[Status]
                                  ,[Specialtie]
                                  ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                              FROM [Medical.Office.SqlLocalDB].[dbo].[Users]", new { }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="Psswd"></param>
                    /// <returns></returns>
                    public async Task<Users> LoginUser(string Usr, string Psswd) =>
                        await _con.QuerySingleAsync<Users>(@"SELECT TOP (1) 
                            [Id]
                          ,[Usr]
                          ,[Psswd]
                          ,[Name]
                          ,[Lastname]
                          ,[Role]
                          ,[Position]
                          ,[Status]
                          ,[Specialtie]
                          ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap] 
                            FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr AND Psswd = @Psswd;", new { Usr, Psswd }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="Psswd"></param>
                    /// <param name="Name"></param>
                    /// <param name="Lastname"></param>
                    /// <param name="Role"></param>
                    /// <param name="Position"></param>
                    /// <param name="Status"></param>
                    /// <param name="Specialtie"></param>
                    /// <returns></returns>
                    public async Task<Users> RegisterUsers(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie) =>
                        await _con.QuerySingleAsync<Users>("INSERT INTO [dbo].[Users] " +
                            "([Usr], [Psswd] ,[Name] ,[Lastname] ,[Role] ,[Position],[Specialtie]) " +
                            "VALUES(@Usr, @Psswd, @Name, @Lastname, @Role, @Position, @Specialtie);", new { Usr, Psswd, Name, Lastname, Role, Position, Specialtie }).ConfigureAwait(false);

                    public async Task UpdateUsers(Users users)
                        => await _con.ExecuteAsync(@"UPDATE [Medical.Office.SqlLocalDB].[dbo].[Users] 
                        SET Psswd = @Psswd, [Name] = @Name, [Role] = @Role, [Position] = @Position, [Status] = @Status, Specialtie = @Specialtie, TimeSnap = GETUTCDATE() 
                        WHERE Id = @Id", new {users.Psswd,users.Name,users.Role,users.Position,users.Status,users.Specialtie,users.Id }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistory()
                        => await _con.QueryAsync<LoginHistory>(@"SELECT  [Id]
                          ,[Usr]
                          ,[UsrName]
                          ,[UsrToken]
                          ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                      FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] ORDER BY DateTimeSnap DESC;").ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<LoginHistory>(@"
                        SELECT [Id]
                        ,[Usr]
                        ,[UsrName]
                        ,[UsrToken]
                        ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                        FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] 
                        WHERE (Usr LIKE @Param OR UsrName LIKE @Param) 
                        AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap 
                        BETWEEN @StartDate AND @EndDate) 
                        ORDER BY DateTimeSnap ASC;", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="UsrName"></param>
                    /// <param name="Token"></param>
                    /// <returns></returns>
                    public async Task InsertLoginHistory(string Usr, string UsrName, string Token)
                        => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                            "(Usr,UsrName,UsrToken) " +
                            "VALUES(@Usr,@UsrName,@Token);", new { Usr, UsrName, Token }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<UsersMovements>> GetUsersMovements()
                        => await _con.QueryAsync<UsersMovements>(@"
                        SELECT
                        [Id]
                        ,[Usr]
                        ,[UsrName]
                        ,[UsrRole]
                        ,[UsrMovement]
                        ,[UsrToken]
                        ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                        FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements];").ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<UsersMovements>(@"SELECT 
                            [Id]
                            ,[Usr]
                            ,[UsrName]
                            ,[UsrRole]
                            ,[UsrMovement]
                            ,[UsrToken]
                            ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                            FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements]
                            WHERE (Usr LIKE @Param OR UsrName 
                            LIKE @Param) AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap 
                            BETWEEN @StartDate AND @EndDate) 
                            ORDER BY DateTimeSnap ASC", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="UsrName"></param>
                    /// <param name="UsrRole"></param>
                    /// <param name="UsrMovement"></param>
                    /// <param name="Token"></param>
                    /// <returns></returns>
                    public async Task InsertUsersMovements(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token)
                        => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UsersMovements] " +
                            "(Usr,UsrName,UsrRole,UsrMovement,UsrToken) " +
                            "VALUES (@Usr,@UsrName,@UsrRole,@UsrMovement,@Token);", new { Usr, UsrName, UsrRole, UsrMovement, Token }).ConfigureAwait(false);

                    #endregion



 
}