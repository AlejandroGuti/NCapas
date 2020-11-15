using APiTest.Common.Request;
using APiTest.Common.Responses;
using System.Threading.Tasks;

namespace APiTest.Negocio.Services.Interface
{
    public interface ICityServices
    {
        Task<Response> Create(CityRequest model);
        Task<Response> FindAll();
        Task<Response> FindById(int id);
        Task<Response> Delete(int id);
        Task<Response> Update(int id,CityRequest request);
    }
}
