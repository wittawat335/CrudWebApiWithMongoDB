using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;

namespace Crud.Core.Services
{
    public class TestService : ITestService
    {
        public Task<Response> Add(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
