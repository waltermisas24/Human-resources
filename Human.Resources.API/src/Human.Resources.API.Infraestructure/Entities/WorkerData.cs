using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Infraestructure.Entities
{
    public class WorkerData
    {
        public int Id { get; set; }
        public string? WorkerName { get; set; }
        public string? WorkerLastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int WorkerStatus { get; set; }
        public int WorkerId { get; set; }
        public string? WorkerTitleName { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? Reasson { get; set; }
    }
}
