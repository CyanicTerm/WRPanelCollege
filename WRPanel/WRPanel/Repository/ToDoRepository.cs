using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Repository
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ToDo obj)
        {
            _db.Update(obj);
        }
    }
}
