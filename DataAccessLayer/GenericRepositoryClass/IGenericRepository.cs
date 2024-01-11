namespace DataAccessLayer.GenericRepositoryClass
{
    public interface IGenericRepository<T>
    {
        Task Delete(object id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Insert(T obj);
        Task Save();
        Task Update(T obj);
    }
}