using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepository _loginRepository;
        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Task<bool> LoginAsync(UserEntity userData)
        {
            Task<bool> response = _loginRepository.Login(userData.User, userData.Password);

            return response;
        }

        public Task<bool> RestorePassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
