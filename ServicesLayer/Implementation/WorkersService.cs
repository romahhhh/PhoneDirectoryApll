using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLayer.Abstraction;
using System.Data.SQLite;
using RepositoryLayer.Respository.Abstraction;
using DomainLayer.Models;

namespace ServicesLayer.Implementation
{
    public class WorkersService : IWorkersService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkersRepository _workersRepository;
        public WorkersService(IDepartmentRepository departmentRepository, IWorkersRepository workersRepository)
        {
            _departmentRepository = departmentRepository;
            _workersRepository = workersRepository;
        }

        public void Create(WorkersModel entities)
        {
            _workersRepository.Create(entities);
        }

        public void Delete(int ids)
        {
            _workersRepository.Delete(ids);
        }

        public Task<List<WorkersModel>> GetEntities()
        {
            return _workersRepository.GetEntities();
        }

        public Task<WorkersModel> GetEntityById(int id)
        {
            return _workersRepository.GetEntityById(id);
        }

        public void Update(WorkersModel entities)
        {
            _workersRepository.Update(entities);
        }
        public Task<List<WorkersModel>> Search(string word)
        {
            return _workersRepository.Search(word);
        }
        public async Task<List<WorkersModel>> GetWorkersForHierarchy(List<WorkersModel> workersModel, int? id)
        {
            workersModel = await _workersRepository.GetEntities();
            var Child = workersModel.Where(x => x.UnderDepsId == id).ToList();
            var dto = Child.Select(x => new WorkersModel()
            {
                Id = x.Id,
                FIO = x.FIO,
                Phone = x.Phone,
            }).ToList();
            return dto;

        }
    }
}
