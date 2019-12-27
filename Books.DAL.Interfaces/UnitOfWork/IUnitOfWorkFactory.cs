namespace Books.DAL.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(bool useTransaction = false);
    }
}
