using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event obj)
        {
            _db.Update(obj);
        }
    }
}
