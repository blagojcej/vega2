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
    public class FeaturesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public FeaturesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            
        }

        [HttpGet]
        public async Task<IEnumerable<FeatureViewModel>> GetFeatures()
        {
            var features= await context.Features.ToListAsync();
            return mapper.Map<List<Feature>,List<FeatureViewModel>>(features);
        }
    }
}