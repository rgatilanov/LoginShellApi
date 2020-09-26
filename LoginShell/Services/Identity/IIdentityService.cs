using LoginShell.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace LoginShell.Services.Identity
{
    interface IIdentityService
    {
        Task<bool> VerifyRegistration();
        Task Authenticate();

        Task<Login> Login(string username, string password);

    }
}
