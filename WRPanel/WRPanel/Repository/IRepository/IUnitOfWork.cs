namespace WRPanel.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }
        IStorageRepository Storage { get; }
        IToDoRepository ToDo { get; }
        IEventRepository Event { get; }
        void Save();
    }
}
