using FlightManagementRadar.Models;

namespace FlightManagementRadar.Services
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}