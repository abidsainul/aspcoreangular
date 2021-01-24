using System.Threading.Tasks;

namespace aspnetcore_spa.Persistence
{

    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }
        Task CompleteAsync();
    }
}