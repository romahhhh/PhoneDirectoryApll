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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkersService _workersService;
        public DepartmentService(IDepartmentRepository departmentRepository, IWorkersService workersService)
        {
            _departmentRepository = departmentRepository;
            _workersService = workersService;
        }

        public void Create(DepartmentModel entities)
        {
            _departmentRepository.Create(entities);
        }

        public void Delete(int ids)
        {
            _departmentRepository.Delete(ids);
        }

        public Task<List<DepartmentDto>> GetEntities(bool x)
        {
            return _departmentRepository.GetEntities(x);
        }

        public Task<DepartmentModel> GetEntityById(int id)
        {
            return _departmentRepository.GetEntityById(id);
        }

        public void Update(DepartmentModel entities)
        {
            _departmentRepository.Update(entities);
        }

        public Task<List<DepartmentModel>> Search(string word)
        {
            return _departmentRepository.Search(word);
        }

        public async Task<List<DepartmentDto>> GetEntitiesHierarchy(List<DepartmentDto> departmentModel, int? id)
        {
            bool x = false;
            List<WorkersModel> workersModel = new List<WorkersModel>();
            departmentModel = await _departmentRepository.GetEntities(x);

            List<DepartmentDto> dto = new List<DepartmentDto>();
            var Child = departmentModel.Where(x => x.ParentDepId == id).ToList();
            foreach (var department in Child)
            {
                dto.Add(new DepartmentDto()
                {
                    Id = department.Id,
                    Name = department.Name,
                    ParentDepId = department.ParentDepId,
                    Departments = await GetEntitiesHierarchy(departmentModel, department.Id),
                    Workers = await _workersService.GetWorkersForHierarchy(workersModel, department.Id)
                });
            }
            return dto;
        }

    }
}
