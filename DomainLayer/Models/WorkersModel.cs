using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class WorkersModel
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public int UnderDepsId { get; set; }

    }
}
