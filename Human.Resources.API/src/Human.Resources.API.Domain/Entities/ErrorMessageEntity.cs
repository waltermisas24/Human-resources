using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Entities
{
    public class ErrorMessageEntity
    {
        public int CodeError { get; set; }
        public string? Message { get; set; }
    }
}
