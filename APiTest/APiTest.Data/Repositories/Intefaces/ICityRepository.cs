using APiTest.Common.Request;
using APiTest.Data.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APiTest.Data.Repositories.Intefaces
{
     public interface ICityRepository
    {
        Task<int> Create(CityRequest data);
        Task<List<City>> FindAll();
        Task<City> FindById(int id);
        Task<int> Delete(int id);
        Task<int> Update(int id,CityRequest data);
    }
}
