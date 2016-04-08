namespace DomainFramework
{
    public interface IRepositoryAsync<T> : IReadOnlyRepositoryAsync<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
