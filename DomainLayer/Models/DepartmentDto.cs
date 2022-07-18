using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDepId { get; set; }
        public List<DepartmentDto> Departments { get; set; }
        public List<WorkersModel> Workers { get; set; } = new List<WorkersModel>();
    }
}
