using Human.Resources.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface ILoginServices
    {
        Task<bool> LoginAsync(UserEntity userData);
        Task<bool> RestorePassword(string email, string password);
    }
}
