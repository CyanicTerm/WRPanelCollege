using WRPanel.Models;

namespace WRPanel.Repository.IRepository
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        void Update(ToDo obj);
    }
}
