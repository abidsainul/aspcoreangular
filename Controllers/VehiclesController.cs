using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using aspnetcore_spa.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public VehiclesController(IMapper mapper, ApplicationDbContext context)
        {
            this._context = context;
            this._mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _context.Models.FindAsync(vehicleResource.ModelId);
            if(model == null) {
                ModelState.AddModelError("ModelId","Invalid Model Id");
                return BadRequest(ModelState);
            }

            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            //vehicle.Features = new Collection<Feature>();

            // Add existing features to vehicle
            // foreach(var featureId in vehicleResource.Features){
            //         var feature = await _context.Features.FindAsync(featureId);
            //         if(feature != null){
            //             vehicle.Features.Add(feature);
            //         }
            // }

            //update to db
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleResource vehicleResource)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _context.Vehicles.Include(x=>x.Features).SingleOrDefaultAsync(vehicle=>vehicle.Id == id);

            vehicleResource.Id = id;
            _mapper.Map<VehicleResource, Vehicle>(vehicleResource,vehicle);
            vehicle.LastUpdate = DateTime.Now;

            //vehicle.Id = id;  // ?? not setting Id after automap

            // Add existing features to vehicle
            foreach(var featureId in vehicleResource.Features){
                    var feature = await _context.Features.FindAsync(featureId);
                    if(feature != null && !vehicle.Features.Any(f => f.Id == featureId)){
                        vehicle.Features.Add(feature);
                    }
            }
            
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(result);
        }

    }
}