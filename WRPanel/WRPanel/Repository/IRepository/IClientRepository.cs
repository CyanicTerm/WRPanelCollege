using WRPanel.Models;

namespace WRPanel.Repository.IRepository
{
    public interface IClientRepository : IRepository<Client>
    {
        void Update(Client obj);
    }
}
