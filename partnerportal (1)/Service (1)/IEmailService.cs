using System.Threading.Tasks;

namespace partnerportal.Service
{
    public interface IEmailService
    {
        Task SendEmail(string to, string body, string subject);
    }
}
