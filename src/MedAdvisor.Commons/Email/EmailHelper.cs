
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace rentX.Common.Email
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public  bool SendEmail(string userEmail)
        {
            var From = _configuration.GetSection("EmailConfiguration:From").Value;
            var Password = _configuration.GetSection("EmailConfiguration:Password").Value;


            MailAddress to = new MailAddress(From);
            MailAddress from = new MailAddress(userEmail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Good morning, Charles";
            message.Body = "Charles, Long time no talk. Would you be up for lunch in Soho on Monday? I'm paying.;";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(From, Password),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}