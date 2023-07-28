using Crud.Core.Model.Response;

namespace Crud.Core.Services.Contracts
{
    public interface ITestService
    {
        Task<Response> Add(string firstName, string lastName);
    }
}
