namespace DiplomeProject.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string EntityId);
        void Insert(T entity);
        void Delete(string EntityId);
        void Save();
    }
}
