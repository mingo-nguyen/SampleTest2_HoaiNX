using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantBusiness.Entities;
using RestaurantRepositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantWebapp.Pages
{
    public class TableSearchModel : PageModel
    {
        private readonly ITableRepository _tableRepository;

        public TableSearchModel(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        [BindProperty(SupportsGet = true)]
        public int Seats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        public IEnumerable<Table> Tables { get; set; }

        public async Task OnGetAsync()
        {
            Tables = await _tableRepository.SearchTablesAsync(Seats, Status);
        }
    }
}
