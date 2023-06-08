namespace UserAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(K Key);
        Task<T> Get(K Key);
        Task<ICollection<T>> GetAll();  
    }
}
