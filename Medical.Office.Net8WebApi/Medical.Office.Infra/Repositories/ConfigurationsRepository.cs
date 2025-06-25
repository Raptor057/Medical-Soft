using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly MedicalOfficeSqlLocalDB _db;
        private readonly ConfigurationSqlDb _configurationSqlDb;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="configurationSqlDb"></param>
        public ConfigurationsRepository(MedicalOfficeSqlLocalDB db, ConfigurationSqlDb configurationSqlDb)
        {
            _db = db;
            _configurationSqlDb = configurationSqlDb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genders>> GetGendersAsync()
        {
            return await _configurationSqlDb.GetGenders().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositionsAsync()
        {
            return await _configurationSqlDb.GetPositions().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {

            return await _configurationSqlDb.GetRoles().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialtiesAsync()
        {
            return await _configurationSqlDb.GetSpecialties().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatusesAsync()
        {
            return await _configurationSqlDb.GetUserStatuses().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryAsync()
            => await _configurationSqlDb.GetLoginHistory().ConfigureAwait(false);


        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _configurationSqlDb.GetLoginHistoryByParams(Param, StartDate, EndDate).ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsAsync()
            => await _configurationSqlDb.GetUsersMovements().ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _configurationSqlDb.GetUsersMovementsByParams(Param,StartDate,EndDate).ConfigureAwait(false);


        public async Task InsertLoginHistoryAsync(string Usr, string UsrName, string? Token)
            => await _configurationSqlDb.InsertLoginHistory(Usr, UsrName, Token).ConfigureAwait(false);


        public async Task InsertUsersMovementsAsync(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token)
            => await _configurationSqlDb.InsertUsersMovements(Usr,UsrName, UsrRole, UsrMovement, Token).ConfigureAwait(false);

        public async Task<OfficeSetup> GetOfficeSetupAsync()
            => await _configurationSqlDb.GetOfficeSetup().ConfigureAwait(false);

        public async Task InsertOfficeSetupAsync(string NameOfOffice, string Address)
            => await _configurationSqlDb.InsertOfficeSetup(NameOfOffice, Address).ConfigureAwait(true);

        public async Task InsertPositionsAsync(string PositionName)
            => await _configurationSqlDb.InsertPositions(PositionName).ConfigureAwait(false);

        public async Task InsertSpecialtiesAsync(string Specialty)
            => await _configurationSqlDb.InsertSpecialties(Specialty).ConfigureAwait(false);

        public async Task<LaboralDays> GetTodaysWorkScheduleAsync()
            => await _configurationSqlDb.GetTodaysWorkSchedule().ConfigureAwait(false);

        public async Task<IEnumerable<LaboralDays>> GetWorkScheduleAsync()
            => await _configurationSqlDb.GetWorkSchedule().ConfigureAwait(false);

        public async Task UpdateOfficeSetupAsync(string NameOfOffice, string Address)
        {
            OfficeSetup OfficeSetupData = new()
            {
                NameOfOffice = NameOfOffice,
                Address = Address
            };

            await _configurationSqlDb.UpdateOfficeSetup(OfficeSetupData).ConfigureAwait(false);
        }
        public async Task UpdateWorkScheduleAsync(LaboralDays laboralDays)
            => await _configurationSqlDb.UpdateWorkSchedule(laboralDays).ConfigureAwait(false);

        public async Task<IEnumerable<Doctors>> GetDoctorsAsync()
            => await _db.GetDoctors().ConfigureAwait(false);

        public async Task<Doctors> GetDoctorAsync(long IDDoctor)
        => await _db.GetDoctor(IDDoctor).ConfigureAwait(false);

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentsListAsync()
            => await _configurationSqlDb.GetTypeOfAppointmentsList().ConfigureAwait(false);

        public async Task InsertTypeOfAppointmentAsync(string typeOfAppointment)
        => await _configurationSqlDb.InsertTypeOfAppointment(typeOfAppointment).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public Task UpdateLaboralDaysByIdAsync(LaboralDays laboralDays)
        //    => _db.UpdateLaboralDaysById(laboralDays);
        public async Task UpdateLaboralDaysByIdAsync(int Id, bool Laboral, TimeSpan OpeningTime, TimeSpan ClosingTime)
        {

            LaboralDays laboralDays = new();
            {
                laboralDays.Id = Id;
                laboralDays.Laboral= Laboral;
                laboralDays.OpeningTime = OpeningTime;
                laboralDays.ClosingTime = ClosingTime;
            };

            await _configurationSqlDb.UpdateLaboralDaysById(laboralDays).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<LaboralDays>> GetLaboralDaysListAsync()
            => _configurationSqlDb.GetLaboralDaysList();

        public async Task<LaboralDays> GetLaboralDayByIdAsync(int Id)
            => await _configurationSqlDb.GetLaboralDayByID(Id).ConfigureAwait(false);


        public async Task InsertDoctorAsync(string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
            => await _db.InsertDoctors(FirstName, LastName, Specialty, PhoneNumber,Email).ConfigureAwait(false);

        public Task DeleteDoctorAsync(long IDDoctor)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDoctorAsync(long Id, string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
        {
            Doctors doctors = new();
            {
                doctors.ID = Id;
                doctors.FirstName = FirstName;
                doctors.LastName = LastName;
                doctors.Specialty = Specialty;
                doctors.PhoneNumber = PhoneNumber;
                doctors.Email = Email;
            }
            await _db.UpdateDoctor(doctors).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentAsync()
            => await _configurationSqlDb.GetTypeOfAppointment().ConfigureAwait(false);
    }
}
