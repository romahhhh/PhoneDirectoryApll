using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Respository.Abstraction
{
    public interface IDepartmentRepository
    {
        public Task<List<DepartmentDto>> GetEntities(bool x);
        public Task<DepartmentModel> GetEntityById(int id);
        public void Create(DepartmentModel entities);
        public void Update(DepartmentModel entities);
        public void Delete(int ids);
        public Task<List<DepartmentModel>> Search(string word);
    }
}
