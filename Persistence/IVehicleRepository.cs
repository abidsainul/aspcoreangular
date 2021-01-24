using System.Threading.Tasks;
using aspnetcore_spa.Models;

namespace aspnetcore_spa.Persistence
{
    public interface IVehicleRepository
    {
         Task<Vehicle> GetVehicle(int id, bool includeRelated = true);

         Task AddVehicle(Vehicle vehicle);

         void RemoveVehicle(Vehicle vehicle);
    }
}