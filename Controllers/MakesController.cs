using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega2.Data;
using vega2.Models;

namespace vega2.Controllers
{
    [Route("[controller]/[action]")]
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeViewModel>> GetMakes()
        {
            var makes= await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeViewModel>>(makes);
        }
    }
}