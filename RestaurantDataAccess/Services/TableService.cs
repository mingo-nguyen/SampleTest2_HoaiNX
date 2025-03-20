using RestaurantBusiness.Entities;
using RestaurantDataAccess.ServiceContracts;
using RestaurantRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        public Task<Table> AddAsync(Table table)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Table> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
