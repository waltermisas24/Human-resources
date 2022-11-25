using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Infraestructure.Entities
{
    public class UserData
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool SuperUser { get; set; }
    }
}
