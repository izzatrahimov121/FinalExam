using Core.Interfaces;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class Reposiyory<T> : IReposiyory<T> where T : class,IEntity, new()
{
	private readonly AppDbContext _context;
	private readonly DbSet<T> _table;
	public Reposiyory(AppDbContext context)
	{
		_context = context;
		_table = _context.Set<T>();
	}

	public async Task<IEnumerable<T>> GetAllAsync() => await _table.ToListAsync();

	public async Task<T> GetAsync(int? id) => await _table.FindAsync(id);
	public async Task CretedAsync(T entity)
	{
		await _table.AddAsync(entity);
	}

	public void Delete(T Entity)
	{
		_table.Remove(Entity);
	}

	public void Update(T entity)
	{
		_context.Entry(entity).State= EntityState.Modified;
	}

	public async Task SaveAsync()
	{
		 await _context.SaveChangesAsync();
	}

}
