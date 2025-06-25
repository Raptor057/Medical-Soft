using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice.Views;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;
using Medical.Office.Infra.Services;

namespace Medical.Office.Infra.Repositories
{
    class PatientsData : IPatientsData
    {
        private readonly GoogleCalendarService _googleCalendarService;
        private readonly MedicalOfficeSqlLocalDB _medicalOfficeSql;
        private readonly HostedServicesSqlDb _hostedServicesSqlDb;
        private readonly MedicalAppointmentCalendarSqlDb _appointmentCalendarSqlDb;
        private readonly AntecedentPatientSqlDb _antecedentPatientSqlDb;

        public PatientsData(MedicalOfficeSqlLocalDB medicalOfficeSql, AntecedentPatientSqlDb antecedentPatientSqlDb ,MedicalAppointmentCalendarSqlDb appointmentCalendarSqlDb ,HostedServicesSqlDb hostedServicesSqlDb,GoogleCalendarService googleCalendarService)
        { 
            _antecedentPatientSqlDb=antecedentPatientSqlDb;
            _medicalOfficeSql=medicalOfficeSql;
            _appointmentCalendarSqlDb = appointmentCalendarSqlDb;
            _hostedServicesSqlDb = hostedServicesSqlDb;
            _googleCalendarService = googleCalendarService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PatientData> GetPatientDataByIDPatientAsync(long ID)
            => await _medicalOfficeSql.GetPatientDataByIDPatient(ID).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<PatientData>> GetPatientsDataListAsync()
            => await _medicalOfficeSql.GetPatientsDataList().ConfigureAwait(false);

        public async Task<IEnumerable<PatientsFiles>> GetPatientsFilesListAsync(long IDPatient)
        => await _antecedentPatientSqlDb.GetPatientsFilesListByIDPatient(IDPatient).ConfigureAwait(false);

        public async Task<PatientsFiles> GetPatientFileByIDPatientAndIdAsync(long IDPatient, long Id)
        => await _antecedentPatientSqlDb.GetPatientFileByIDPatient(IDPatient,Id).ConfigureAwait(false);
        public async Task DeletePatientFileAsync(long IDPatient, long Id)
        => await _antecedentPatientSqlDb.DeletePatientFiles(IDPatient, Id).ConfigureAwait(false);

        public async Task InsertPatientFileAsync(long IDPatient, string FileName, string FileType, string FileExtension, string Description, byte[] FileData, DateTime DateTimeUploaded)
        {
            var PatientFile = new PatientsFiles
            {
                Id=0,
                IDPatient = IDPatient,
                FileName = FileName,
                FileType = FileType,
                FileExtension = FileExtension,
                Description = Description,
                FileData = FileData,
                DateTimeUploaded = DateTimeUploaded
            };

            await _antecedentPatientSqlDb.InsertPatientFiles(PatientFile);
        }

        public Task<int> MedicalAppointmentCalendarIsOverlappingAsync(long IDDoctor, DateTime AppointmentDateTime)
        => _appointmentCalendarSqlDb.MedicalAppointmentCalendarIsOverlapping(IDDoctor, AppointmentDateTime);

        public async Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname,
            DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes)
            => await _medicalOfficeSql.InsertPatientData(Name, FathersSurname, MothersSurname, DateOfBirth, Gender, Address, Country, City, State, ZipCode, OutsideNumber, InsideNumber, PhoneNumber, Email,EmergencyContactName, EmergencyContactPhone, InsuranceProvider, PolicyNumber, BloodType, Photo, InternalNotes).ConfigureAwait(false);

        #region MedicalAppointmentCalendar

        public Task UpdateAppointmentStatusAsync()
            => _hostedServicesSqlDb.UpdateAppointmentStatus();

        public async Task InsertMedicalAppointmentCalendarAsync(long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment)
        {
            var MedicalAppointmentCalendar = new MedicalAppointmentCalendar
            {
                IDPatient = IDPatient,
                IDDoctor = IDDoctor,
                AppointmentDateTime = AppointmentDateTime,
                ReasonForVisit = ReasonForVisit,
                Notes = Notes,
                TypeOfAppointment = TypeOfAppointment
            };
            
            // Insertar la cita médica en la base de datos
            long appointmentId = await _appointmentCalendarSqlDb.InsertMedicalAppointmentCalendar(MedicalAppointmentCalendar).ConfigureAwait(false);
           
            //TODO: Verificar si la cita se creó correctamente
            /*
            // Obtener los detalles de la cita recién creada
            var appointment = await _appointmentCalendarSqlDb.GetAppointmentById(appointmentId);

            // Crear evento en Google Calendar
            await _googleCalendarService.CreateEventAsync(
                "Cita Médica",
                "Consultorio",
                "Cita Medica del paciente " + appointment.patientName,
                appointment.AppointmentDateTime,
                appointment.EndOfAppointmentDateTime,
                "America/Mexico_City");
                */
        }

        public async Task UpdateMedicalAppointmentCalendarAsync(long Id ,long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment)
        {
            var MedicalAppointmentCalendar = new MedicalAppointmentCalendar
            {
                Id = Id,
                IDPatient = IDPatient,
                IDDoctor = IDDoctor,
                AppointmentDateTime = AppointmentDateTime,
                ReasonForVisit = ReasonForVisit,
                Notes = Notes,
                TypeOfAppointment = TypeOfAppointment
            };
            await _appointmentCalendarSqlDb.UpdateMedicalAppointmentCalendar(MedicalAppointmentCalendar).ConfigureAwait(false);
        }

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatientAsync(
            long IdPatient)
            => await _appointmentCalendarSqlDb.GetMedicalAppointmentCalendarListByIDPatient(IdPatient).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctorAsync(
            long IdDoctor)
            => await _appointmentCalendarSqlDb.GetMedicalAppointmentCalendarListByIDDoctor(IdDoctor).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendarAsync()
            => await _appointmentCalendarSqlDb.GetAllsMedicalAppointmentCalendar().ConfigureAwait(false);

        public Task<IEnumerable<MedicalAppointmentReminderCalendarHostedService>> GetMedicalAppointmentRemindersCalendarListAsync()
            => _hostedServicesSqlDb.GetMedicalAppointmentRemindersCalendarList();

        public async Task<IEnumerable<PatientAdvancement>> GetPatientAdvancementByIDPatientAsync(long IDPatient)
            => await _antecedentPatientSqlDb.GetPatientAdvancementByIDPatient(IDPatient).ConfigureAwait(false);

        public async Task<PatientAdvancement> GetPatientAdvancementByIDAsync(long ID)
            => await _antecedentPatientSqlDb.GetPatientAdvancementByID(ID).ConfigureAwait(false);

        public async Task InsertPatientAdvancementAsync(long IDPatient, string Concept, decimal? Quantity)
        => await _antecedentPatientSqlDb.InsertPatientAdvancement(IDPatient, Concept, Quantity).ConfigureAwait(false);

        public async Task UpdatePatientAdvancementAsync(string Concept, decimal? Quantity, bool Active, long Id)
        => await _antecedentPatientSqlDb.UpdatePatientAdvancement(Concept, Quantity, Active, Id).ConfigureAwait(false);

        #endregion
    }
}
