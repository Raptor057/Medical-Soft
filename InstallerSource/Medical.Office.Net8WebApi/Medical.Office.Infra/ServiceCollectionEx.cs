using Common.Common.Logging;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;
using Medical.Office.Infra.Repositories;
using Medical.Office.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Medical.Office.Infra
{
    public static class ServiceCollectionEx
    {
        /// <summary>
        /// Método de extensión para agregar servicios de infraestructura a la colección de servicios.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services // Se agrega la configuración
                .AddLoggingServices(configuration) // Se agrega el servicio de logging
                .AddSingleton(typeof(ConfigurationSqlDbConnectionFactory<>)) // Se agrega la conexión a la base de datos
                .AddSingleton(typeof(ConfigurationSqlDbConnection<>)) // Se agrega la conexión a la base de datos
                .AddSingleton<MedicalOfficeSqlLocalDB>() // Se agrega la base de datos local
                .AddSingleton<ConfigurationSqlDb>() // Se agrega la base de datos de configuración
                .AddSingleton<AntecedentPatientSqlDb>() // Se agrega la base de datos de antecedentes
                .AddSingleton<ExpressPossSqlDb>() // Se agrega la base de datos de ExpressPos
                .AddSingleton<HostedServicesSqlDb>() // Se agrega la base de datos de servicios alojados
                .AddSingleton<MedicalOfficeSqlLocalDB>() // Se agrega la base de datos local
                .AddSingleton<PrescriptionSqlDb>() // Se agrega la base de datos de prescripción
                .AddSingleton<MedicalAppointmentCalendarSqlDb>()
                //.AddSingleton<GoogleCalendarService>()// Se agrega el servicio de Google Calendar
                
                // Repositorios generales
                .AddSingleton<IUsersRepository, UsersRepository>() // Se agrega el repositorio de usuarios
                .AddSingleton<IConfigurationsRepository, ConfigurationsRepository>() // Se agrega el repositorio de configuraciones
                .AddSingleton<IPatientsData, PatientsData>() // Se agrega el repositorio de datos de pacientes
                .AddSingleton<IAntecedentPatient, AntecedentPatientRepository>() // Se agrega el repositorio de antecedentes de pacientes
                .AddSingleton<IPatientPrescription, PatientPrescription>() // Se agrega el repositorio de prescripción de pacientes

                // Repositorios y servicios de ExpressPos
                .AddSingleton<IPOSInterfacesRepository.IProductoService, ExpressPosRepository>() // Se agrega el servicio de productos
                .AddSingleton<IPOSInterfacesRepository.IVentaService, ExpressPosRepository>() // Se agrega el servicio de ventas
                .AddSingleton<IPOSInterfacesRepository.ICorteService, ExpressPosRepository>() // Se agrega el servicio de cortes
                .AddSingleton<IPOSInterfacesRepository.IReporteService, ExpressPosRepository>(); // Se agrega el servicio de reportes
        }
    }
}
