using Backend.Repositories.Interfaces;
using Observer;

namespace Backend.Services
{
    public class Service<T> : Subject
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
            NotifyObservers();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            NotifyObservers();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            NotifyObservers();
        }
    }
}
