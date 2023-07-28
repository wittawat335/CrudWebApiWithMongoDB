using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _service;
        private readonly IMongoRepository<Person> _peopleRepository;

        public TestController(ITestService service, IMongoRepository<Person> peopleRepository)
        {
            _service = service;
            _peopleRepository = peopleRepository;
        }

        [HttpPost("registerPerson")]
        public async Task<IActionResult> AddPerson(string firstName, string lastName)
        {
            var response = new Response();
            try
            {
                response = await _service.Add(firstName, lastName);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("getAll")]
        public List<Person> GetAll()
        {
            var people = _peopleRepository.AsQueryable();
            
            return people.ToList();
        }

        [HttpGet("getPeopleData")]
        public IEnumerable<string> GetPeopleData()
        {
            var people = _peopleRepository.FilterBy(
                filter => filter.FirstName != "test",
                projection => projection.FirstName
            );
            return people;
        }
    }
}
