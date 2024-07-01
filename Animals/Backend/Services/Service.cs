using Backend.Repositories.Interfaces;

namespace Backend.Services
{
    public class Service<T>
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
            Save();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
