namespace WRPanel.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        void Save();
    }
}
