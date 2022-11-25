using Dapper;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Infraestructure.Entities;
using Human.Resources.API.Infraestructure.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Infraestructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlSettings _sqlSettings;

        public LoginRepository(IOptions<Settings> settings)
        {
            _sqlSettings = settings.Value.SqlSettings;
        }
       
        public async Task<bool> Login(string username, string password)
        {
            IEnumerable<UserData> userData;

            string query = "SELECT SuperUser ";
                   query += "FROM dbo.Users ";
                   query += "WHERE Usuario = '" + username + "' AND Contrasena = '" + password + "'";

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                userData = await connection.QueryAsync<UserData>(query);
            }

            return userData.FirstOrDefault().SuperUser;

        }
    }
}
