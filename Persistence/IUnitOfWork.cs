using System.Threading.Tasks;

namespace aspnetcore_spa.Persistence
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}