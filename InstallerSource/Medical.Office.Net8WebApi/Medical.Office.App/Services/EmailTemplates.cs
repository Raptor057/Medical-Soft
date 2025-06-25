namespace Medical.Office.App.Services
{
    public class EmailTemplates
    {
        public string GetAppointmentReminderTemplate(string PatientFullName,string DoctorFullName, DateTime Date)
        {
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <meta name='x-apple-disable-message-reformatting'>
                <title>Recordatorio de Cita</title>
                <style type='text/css'>
                    body {{
                        margin: 0;
                        padding: 0;
                        -webkit-text-size-adjust: 100%;
                        background-color: #f4f4f4;
                        color: #333333;
                        font-family: Arial, sans-serif;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 0 auto;
                        background-color: #ffffff;
                        padding: 20px;
                        border-radius: 5px;
                    }}
                    .header {{
                        background-color: #0073e6;
                        color: #ffffff;
                        text-align: center;
                        padding: 15px;
                        font-size: 20px;
                        font-weight: bold;
                        border-top-left-radius: 5px;
                        border-top-right-radius: 5px;
                    }}
                    .content {{
                        padding: 20px;
                        font-size: 16px;
                        line-height: 1.5;
                    }}
                    .footer {{
                        text-align: center;
                        font-size: 14px;
                        color: #666666;
                        padding: 15px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>Recordatorio de Cita</div>
                    <div class='content'>
                        <p>Hola {PatientFullName},</p>
                        <p>Este es un recordatorio de su próxima cita.</p>
                        <p><strong>Fecha:</strong> {Date}</p>
                        <p>Con el Doctor {DoctorFullName}.</p>
                        <p>Si tiene alguna pregunta, no dude en contactarnos.</p>
                    </div>
                    <div class='footer'>
                          &copy; {DateTime.Now.Year} <a href='https://linktr.ee/Raptor057' style='color:#0073e6; text-decoration:none;'>Medical Office Software</a>. Todos los derechos reservados.
                    </div>
                </div>
            </body>
            </html>";
        }
        public string GetBasicTemplate(string bodyContent)
        {
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <meta name='x-apple-disable-message-reformatting'>
                <title>Mensaje</title>
                <style type='text/css'>
                    body {{
                        margin: 0;
                        padding: 0;
                        -webkit-text-size-adjust: 100%;
                        background-color: #f4f4f4;
                        color: #333333;
                        font-family: Arial, sans-serif;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 0 auto;
                        background-color: #ffffff;
                        padding: 20px;
                        border-radius: 5px;
                    }}
                    .header {{
                        background-color: #0073e6;
                        color: #ffffff;
                        text-align: center;
                        padding: 15px;
                        font-size: 20px;
                        font-weight: bold;
                        border-top-left-radius: 5px;
                        border-top-right-radius: 5px;
                    }}
                    .content {{
                        padding: 20px;
                        font-size: 16px;
                        line-height: 1.5;
                    }}
                    .footer {{
                        text-align: center;
                        font-size: 14px;
                        color: #666666;
                        padding: 15px;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>Mensaje</div>
                    <div class='content'>
                        <p>{bodyContent}</p>
                    </div>
                    <div class='footer'>
                          &copy; {DateTime.Now.Year} <a href='https://linktr.ee/Raptor057' style='color:#0073e6; text-decoration:none;'>Medical Office Software</a>. Todos los derechos reservados.
                    </div>
                </div>
            </body>
            </html>";
        }
    }
}
