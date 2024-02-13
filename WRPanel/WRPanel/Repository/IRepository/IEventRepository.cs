using WRPanel.Models;

namespace WRPanel.Repository.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        void Update(Event obj);
    }
}
