using APiTest.Common.Request;
using APiTest.Data.Entities;
using APiTest.Data.Entities.Data;
using APiTest.Data.Repositories.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiTest.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CityRepository(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Create(CityRequest data)
        {
            City city = _mapper.Map<City>(data);
            _context.Cities.Add(city);
           int resp= await _context.SaveChangesAsync();
            return resp;
        }

        public async Task<int> Delete(int id)
        {
            City data = await _context.Cities.FindAsync(id);
            if (data == null)
            {
                return 404;
            }

             _context.Cities.Remove(data);
            try
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }

        public Task<List<City>> FindAll()
        {
            return _context.Cities.ToListAsync();
        }

        public async Task<City> FindById(int id)
        {
            var data = await _context.Cities.FindAsync(id);

            return data;
        }

        public async Task<int> Update(int id,CityRequest data)
        {
            var city = await _context.Cities.FindAsync(id);
            city.Name = data.name;
            _context.Cities.Update(city);

            try
            {
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
