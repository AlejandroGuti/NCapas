using System;
using System.Threading.Tasks;
using APiTest.Common.Request;
using APiTest.Common.Responses;
using APiTest.Negocio.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APiTest.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityServices _cityService;

        public CityController(
             ICityServices cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CityRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _cityService.Create(request));

            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [HttpGet("FindAll")]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _cityService.FindAll());

            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpGet("FindById")]
        public async Task<ActionResult> FindById([FromQuery] IdRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _cityService.FindById(request.Id));

            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromQuery] IdRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _cityService.Delete(request.Id));

            }
            catch (Exception ex)
            {

                return BadRequest(new Response
                {
                    IsSuccess = true,
                    Message = ex.Message

                });
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CityRequest city)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _cityService.Update(id,city));

            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

    }
}
