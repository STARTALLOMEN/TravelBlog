using System.Net.Mail;
using System.Net;

namespace API.Services
{
    public class EmailSevice
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("21521576@gm.uit.edu.vn", "1013240898"),
                EnableSsl = true,
            };

            smtpClient.Send("21521576@gm.uit.edu.vn", toEmail, subject, body);
        }
    }
}
