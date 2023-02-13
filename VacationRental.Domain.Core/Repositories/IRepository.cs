using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Repositories
{
    public interface IRepository<T> where T : BaseDomain
    {
        IEnumerable<T> GetAll();

        T? Get(int id);

        T Add(T entity);
    }
}
