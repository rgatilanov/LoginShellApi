using System;
using System.Collections.Generic;
using System.Text;

namespace LoginShell.Services.Routing
{
    using System.Threading.Tasks;

    public interface IRoutingService
    {
        Task GoBack();
        Task NavigateTo(string route);
    }
}
