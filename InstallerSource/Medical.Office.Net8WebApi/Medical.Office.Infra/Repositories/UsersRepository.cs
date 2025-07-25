﻿using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;
using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Infra.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly ConfigurationSqlDb _configurationSqlDb;

        public UsersRepository(ConfigurationSqlDb configurationSqlDb)
        {
            _configurationSqlDb=configurationSqlDb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByIdAsync(long Id)
            => await _configurationSqlDb.GetDataUserById(Id).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserByUsrAsync(string Usr)
            => await _configurationSqlDb.GetDataUserByUsr(Usr).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task <IEnumerable<Users>> GetDataUserByUsrListAsync(string Usr)
        => await _configurationSqlDb.GetDataUserByUsrList(Usr).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<LoginHistory> GetLoginHistoryByUsrAsync(string Usr)
            => await _configurationSqlDb.GetLoginHistoryByUsr(Usr).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            //var GetUsers = await _db.GetUsers();
            //if (GetUsers == null || GetUsers.Count() == 0)
            //{
            //    await _db.RegisterUsers("rarriaga", "1A09DF34D876AC0562CDE4723F105436C2D02616ADD65EA50EF83707DFE59BB5", "Rogelio", "Arriaga", "Programador", "Programador", "Desarollador").ConfigureAwait(false);
            //    return await _db.GetUsers().ConfigureAwait(false); ;
            //}
            return await _configurationSqlDb.GetUsers().ConfigureAwait(false); ;
        }
            //=> await _db.GetUsers().ConfigureAwait(false);

            public async Task UpdateUsersAsync(long Id, string Psswd, string Name, string Lastname, string Role,
                string Position, string Status,
                string Specialtie)
            {
                var UserData = new Users
                {
                    Id = Id,
                    Psswd = Psswd,
                    Name = Name,
                    Lastname = Lastname,
                    Role = Role,
                    Position = Position,
                    Status = Status,
                    Specialtie = Specialtie
                }; 
                await _configurationSqlDb.UpdateUsers(UserData).ConfigureAwait(false);
            }

            /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <returns></returns>
        public async Task<Users> LoginUserAsync(string Usr, string Psswd)
            => await _configurationSqlDb.LoginUser(Usr, Psswd).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <param name="Psswd"></param>
        /// <param name="Name"></param>
        /// <param name="Lastname"></param>
        /// <param name="Role"></param>
        /// <param name="Position"></param>
        /// <param name="Specialtie"></param>
        /// <returns></returns>
        public async Task RegisterUsersAsync(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie)
            => await _configurationSqlDb.RegisterUsers(Usr,Psswd,Name,Lastname,Role,Position,Specialtie).ConfigureAwait(false);
    }
}
