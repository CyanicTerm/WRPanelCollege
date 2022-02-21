using WRPanel.Data;
using WRPanel.Repository.IRepository;

namespace WRPanel.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Client = new ClientRepository(_db);
            Storage = new StorageRepository(_db);

        }
        public IClientRepository Client { get; private set; }
        public IStorageRepository Storage { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
