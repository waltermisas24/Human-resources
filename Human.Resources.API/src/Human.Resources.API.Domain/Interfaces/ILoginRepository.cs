using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> Login(string username, string password);
    }
}
