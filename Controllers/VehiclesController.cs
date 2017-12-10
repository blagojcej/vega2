using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega2.Data;
using vega2.Models;

namespace vega2.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public VehiclesController(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await context.Models.FindAsync(vehicleViewModel.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleViewModel, Vehicle>(vehicleViewModel);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(result);
        }


        [HttpPut("{id}")]// /api/vehicle/{id}
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await context.Models.FindAsync(vehicleViewModel.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            mapper.Map<VehicleViewModel, Vehicle>(vehicleViewModel, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(result);
        }
    }
}