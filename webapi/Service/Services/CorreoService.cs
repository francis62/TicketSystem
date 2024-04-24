using System.Net.Mail;
using System.Net;
using webapi.Service.IServices;
using Microsoft.Extensions.Options;

namespace webapi.Service.Services
{
    public class CorreoService : ICorreoService
    {
        private readonly ICorreoService _correoService;

        public async Task EnviarCorreoAsync(string destino, string asunto, string cuerpo)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("chatbotuda@gmail.com", "ChatBotUda2023%"),
                EnableSsl = true,
            };

            var mensaje = new MailMessage("chatbotuda@gmail.com", destino, asunto, cuerpo);

            await smtpClient.SendMailAsync(mensaje);
        }
    }
}
