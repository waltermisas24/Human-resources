using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Entities
{
    public class UserEntity
    {
        public string User { get; set; }
        public string Password { get; set; }
        public bool SuperUser { get; set; }
    }
}
