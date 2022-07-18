using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServicesLayer.Abstraction
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentDto>> GetEntities(bool x);
        public Task<DepartmentModel> GetEntityById(int id);
        public void Create(DepartmentModel entities);
        public void Update(DepartmentModel entities);
        public void Delete(int ids);
        public Task<List<DepartmentModel>> Search(string word);
        public Task<List<DepartmentDto>> GetEntitiesHierarchy(List<DepartmentDto> departmentModel, int? id);
    }
}
