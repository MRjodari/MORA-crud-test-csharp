namespace Mc2.CrudTest.Application.Interfaces.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        Task Save();
    }
}
