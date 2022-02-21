namespace WRPanel.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        IStorageRepository Storage { get; }
        void Save();
    }
}
