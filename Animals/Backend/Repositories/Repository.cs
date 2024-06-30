using Newtonsoft.Json;
using Observer;

namespace Backend.Repositories
{
    public class Repository<T> : Subject, IRepository<T> where T : class
    {
        private readonly string _filePath;
        private List<T> _entities;

        public Repository(string filePath)
        {
            _filePath = filePath;
            _entities = File.Exists(_filePath) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(_filePath))! : new List<T>()!;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => GetPropertyValue<int>(e, "Id") == id)!;
        }

        public void Create(T entity)
        {
            dynamic obj = entity;
            var maxId = _entities.Any() ? _entities.Max(e => GetPropertyValue<int>(e, "Id")) : 0;
            obj.Id = maxId + 1;
            _entities.Add(obj);
            Save();
            NotifyObservers();
        }

        public void Update(T entity)
        {
            var existingEntity = GetById(GetPropertyValue<int>(entity, "Id"));
            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                _entities.Add(entity);
                Save();
                NotifyObservers();
            }
        }

        public void Delete(int id)
        {
            var entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                _entities.Remove(entityToDelete);
                Save();
                NotifyObservers();
            }
        }

        public void Save()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_entities, Formatting.Indented));
        }

        private static TValue GetPropertyValue<TValue>(object obj, string propertyName)
        {
            return (TValue)obj.GetType().GetProperty(propertyName)!.GetValue(obj)!;
        }
    }
}
