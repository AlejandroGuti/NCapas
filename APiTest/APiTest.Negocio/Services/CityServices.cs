using APiTest.Common.Request;
using APiTest.Common.Responses;
using APiTest.Data.Entities.Data;
using APiTest.Data.Repositories.Intefaces;
using APiTest.Negocio.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APiTest.Negocio.Services
{
   public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;

        public CityServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Response> Create(CityRequest model)
        {

            int result = await _cityRepository.Create(model);

            if (result == 1)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Se creo exitosamente"

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No fue creada"
                };
            }
        }

        public async Task<Response> FindAll()
        {
            List<City> result = await _cityRepository.FindAll();

            if (result.Count > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Se creo exitosamente",
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No fue creada"
                };
            }
        }

        public async Task<Response> FindById(int id)
        {
            City result = await _cityRepository.FindById(id);

            if (result.Id > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Se consulto exitosamente",
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Error"
                };
            }
        }

        public async Task<Response> Delete(int id)
        {
            int result = await _cityRepository.Delete(id);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Se elimino exitosamente",
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No fue creada"
                };
            }
        }

        public async Task<Response> Update(int id,CityRequest request)
        {
            int result = await _cityRepository.Update(id,request);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Se actualizó exitosamente",
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No fue actualizada correctamente"
                };
            }
        }

    }
}
