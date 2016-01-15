using Capgemini.Models;

namespace Capgemini.Interfaces
{
    public interface IDataManager
    {
        IRepository<Customer> Customers { get; }

    }
}
