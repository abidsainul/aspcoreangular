using System.Threading.Tasks;

namespace aspnetcore_spa.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private VehicleRepository _vehicleRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IVehicleRepository VehicleRepository
        {
            get { return _vehicleRepository = _vehicleRepository ?? new VehicleRepository(context); }
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}