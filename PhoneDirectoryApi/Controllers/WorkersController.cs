using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer;
using RepositoryLayer.Respository;
using RepositoryLayer.Respository.Abstraction;
using RepositoryLayer.Respository.Implementation;
using ServicesLayer.Abstraction;

namespace PhoneDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        #region Property  
        private readonly IWorkersService _workersRepository;
        #endregion

        #region Constructor  
        public WorkersController(IWorkersService workersRepository)
        {
            _workersRepository = workersRepository;
        }
        #endregion

        [HttpGet(nameof(GetEntityById))]
        public IActionResult GetEntityById(int id)
        {
            var result = _workersRepository.GetEntityById(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(GetEntities))]
        public IActionResult GetEntities()
        {
            var result = _workersRepository.GetEntities();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpPost(nameof(Create))]
        public IActionResult Create(WorkersModel workersModel)
        {
            _workersRepository.Create(workersModel);
            return Ok("Data inserted");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(WorkersModel workersModel)
        {
            _workersRepository.Update(workersModel);
            return Ok("Updation done");
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(int ids)
        {
            _workersRepository.Delete(ids);
            return Ok("Data Deleted");

        }
        [HttpPost(nameof(Search))]
        public IActionResult Search(string word)
        {
            var result = _workersRepository.Search(word);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
    }
}
