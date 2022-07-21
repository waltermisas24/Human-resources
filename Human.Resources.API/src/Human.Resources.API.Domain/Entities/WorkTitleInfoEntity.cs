using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Entities
{
    public class WorkTitleInfoEntity
    {
        public int Id { get; set; }
        public string? WorkTitle { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? Reason { get; set; }
    }
}
