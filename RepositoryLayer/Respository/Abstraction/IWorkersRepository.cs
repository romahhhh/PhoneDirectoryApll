using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Respository.Abstraction
{
    public interface IWorkersRepository
    {
        public Task<List<WorkersModel>> GetEntities();
        public Task<WorkersModel> GetEntityById(int id);
        public void Create(WorkersModel entities);
        public void Update(WorkersModel entities);
        public void Delete(int ids);
        public Task<List<WorkersModel>> Search(string word);
    }
}
