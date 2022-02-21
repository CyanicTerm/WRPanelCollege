using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Client obj)
        {
            _db.Update(obj);
        }
    }
}
