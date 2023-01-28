using Core.Interfaces;

namespace DataAccess.Interfaces;

public interface IReposiyory<T> where T : class,IEntity,new()
{
	public Task<IEnumerable<T>> GetAllAsync();
	public Task<T> GetAsync(int? id);
	Task CretedAsync(T entity);
	void Update(T entity);
	void Delete(T Entity);
	Task SaveAsync();
}
