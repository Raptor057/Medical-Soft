using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.Services;

public class GoogleCalendarService
{
    private readonly CalendarService _service;
    private readonly ILogger<CalendarService> _logger;
    private readonly string _calendarId;
    
    public GoogleCalendarService(ILogger<CalendarService> logger, IConfiguration configuration)
    {
        _calendarId = configuration["GoogleCalendar:CalendarId"]
                      ?? throw new InvalidOperationException("GoogleCalendar:CalendarId no está configurado.");

        _service = AuthenticateServiceAccount();
        _logger = logger;
    }

    [Obsolete]
    private CalendarService AuthenticateServiceAccount(string credentialsPath)
    {
        GoogleCredential credential;
        using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(new[]
                {
                    CalendarService.Scope.Calendar,
                    CalendarService.Scope.CalendarEvents
                });
        }

        return new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Calendar API C#"
        });
    }
    
    private CalendarService AuthenticateServiceAccount()
    {
        string? credentialsPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

        if (string.IsNullOrWhiteSpace(credentialsPath) || !File.Exists(credentialsPath))
            throw new FileNotFoundException("Archivo de credenciales de Google no encontrado.");

        var credential = GoogleCredential.FromFile(credentialsPath)
            .CreateScoped(CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents);

        return new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Calendar API C#"
        });
    }

    
    public async Task<List<Event>> GetUpcomingEventsAsync(int maxResults = 1000)
    {
        ListCalendarsAsync();
        EventsResource.ListRequest request = _service.Events.List(_calendarId);
        request.MaxResults = maxResults;
        //request.TimeMin = DateTime.UtcNow.Date;
        request.TimeMin = null;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.SingleEvents = true;

        Events events = await request.ExecuteAsync();
        return events.Items != null ? new List<Event>(events.Items) : new List<Event>();
    }
    public async Task ListCalendarsAsync()
    {
        CalendarListResource.ListRequest request = _service.CalendarList.List();
        CalendarList calendars = await request.ExecuteAsync();

        foreach (var calendar in calendars.Items)
        {
            _logger.LogInformation($"Nombre: {calendar.Summary}");
            _logger.LogInformation($"ID: {calendar.Id}");
            _logger.LogInformation("------------------------");
        }
    }
    public async Task<Event> CreateEventAsync(string summary, string location, string description, DateTime startTime, DateTime? endTime, string timeZone)
    {
        try
        {
            Event newEvent = new Event()
            {
                Summary = summary,
                Location = location,
                Description = description,
                Start = new EventDateTime()
                {
                    DateTimeDateTimeOffset = startTime,
                    TimeZone = timeZone
                },
                End = new EventDateTime()
                {
                    DateTimeDateTimeOffset = endTime,
                    TimeZone = timeZone
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new List<EventReminder>()
                    {
                        new EventReminder() { Method = "email", Minutes = 24 * 60 },
                        new EventReminder() { Method = "popup", Minutes = 10 }
                    }
                }
            };

            Event createdEvent = await _service.Events.Insert(newEvent, _calendarId).ExecuteAsync();
            _logger.LogInformation($"Evento creado: {createdEvent.HtmlLink}");
            return createdEvent;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creando evento en Google Calendar: {ex.Message}");
            throw;
        }
    }
    
}