using RestaurantBusiness.Data;
using RestaurantBusiness.Entities;
using RestaurantRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantDbContext _context;
        public ReservationRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public Task<Reservation> AddAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
