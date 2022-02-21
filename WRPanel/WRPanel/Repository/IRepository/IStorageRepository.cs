using WRPanel.Models;

namespace WRPanel.Repository.IRepository
{
    public interface IStorageRepository : IRepository<Storage>
    {
        void Update(Storage obj);
    }
}
