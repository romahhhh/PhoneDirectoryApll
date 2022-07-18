using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer;
using RepositoryLayer.Respository;
//using RepositoryLayer.Respository.Abstraction;
using RepositoryLayer.Respository.Implementation;
using ServicesLayer.Abstraction;

namespace PhoneDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Property  
        private readonly IDepartmentService _departmentRepository;
        #endregion

        #region Constructor  
        public DepartmentController(IDepartmentService departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        [HttpGet(nameof(GetEntityById))]
        public IActionResult GetEntityById(int id)
        {
            var result = _departmentRepository.GetEntityById(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(GetEntities))]
        public IActionResult GetEntities(bool x)
        {
            var result = _departmentRepository.GetEntities(x);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(Create))]
        public IActionResult Create(DepartmentModel directoryModel)
        {
            _departmentRepository.Create(directoryModel);
            return Ok("Data inserted");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(DepartmentModel directoryModel)
        {
            _departmentRepository.Update(directoryModel);
            return Ok("Updation done");
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int ids)
        {
            _departmentRepository.Delete(ids);
            return Ok("Data Deleted");

        }
        [HttpPost(nameof(Search))]
        public IActionResult Search(string word)
        {
            var result = _departmentRepository.Search(word);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(GetEntitiesHierarchy))]
        public IActionResult GetEntitiesHierarchy(List<DepartmentDto> departmentModel, int? id)
        {
            var result = _departmentRepository.GetEntitiesHierarchy(departmentModel, id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
    }
}
