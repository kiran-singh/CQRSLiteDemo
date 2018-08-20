using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.ReadModel.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IId
    {
        Task Add(T item);
        
        Task<T> Get(int id);

        Task<bool> Exists(int id);
        
        Task<IEnumerable<T>> GetAll();

        Task<IList<T>> GetMany(int[] ids);

        Task<bool> Save(T item);
    }
}