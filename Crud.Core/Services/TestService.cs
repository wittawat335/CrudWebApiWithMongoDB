using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Crud.Core.Utility;

namespace Crud.Core.Services
{
    public class TestService : ITestService
    {
        private readonly IMongoRepository<Person> _peopleRepository;

        public TestService(IMongoRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<Response> Add(string firstName, string lastName)
        {
            var response = new Response();
            var person = new Person();
            try
            {
                person.FirstName = firstName;
                person.LastName = lastName;

                await _peopleRepository.InsertOneAsync(person);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.InsertComplete;
            }
            catch
            {
                throw;
            }

            return response;
        }
    }
}
