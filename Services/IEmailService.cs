using BookStroe.ViewModel;
using System.Threading.Tasks;

namespace BookStroe.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}