using System.Threading.Tasks;
using aspnetcore_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext context;
        public VehicleRepository(ApplicationDbContext context)
        {
            this.context = context;

        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            await context.Vehicles.AddAsync(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }


        public async Task<Vehicle> GetVehicle(int id,bool includeRelated = true) {

            if(!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles.Include(x=>x.Features).
             Include(v => v.Model).ThenInclude(m=>m.Make).
             SingleOrDefaultAsync(vehicle=>vehicle.Id == id);
        }
    }
}