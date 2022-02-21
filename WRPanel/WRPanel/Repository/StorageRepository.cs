using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Repository
{
    public class StorageRepository : Repository<Storage>, IStorageRepository
    {
        private readonly ApplicationDbContext _db;
        public StorageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Storage obj)
        {
            _db.Update(obj);
        }
    }
}
