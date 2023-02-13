using VacationRental.Domain.Core.Dtos.Model;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Infra.Data.Repositories
{
    public  class Repository<T> : IRepository<T> where T : BaseDomain
    {

        protected readonly IDictionary<int, T> _dataPersistence;

        public Repository()
        { 
            if(this._dataPersistence == null)
                _dataPersistence = new Dictionary<int, T>();
        }

        public T Add(T entity)
        {
            entity.Id = _dataPersistence.Keys.Count + 1;
            _dataPersistence.Add(entity.Id, entity);

            return _dataPersistence[entity.Id];
        }

        public void Delete(T entity)
        {
            if (_dataPersistence.ContainsKey(entity.Id))
                _dataPersistence.Remove(entity.Id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataPersistence.Values.ToList();
        }

        public T? Get(int id)
        {
            if (!_dataPersistence.ContainsKey(id))
                return null;

            return _dataPersistence[id];
        }

        public T? Update(T entity)
        {
            if (!_dataPersistence.ContainsKey(entity.Id))
                return null;

            _dataPersistence[entity.Id] = entity;
            return entity;
        }
    }
}
