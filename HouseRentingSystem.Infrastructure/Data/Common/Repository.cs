using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data.Common
{
	public class Repository : IRepository
	{
		private readonly DbContext data;

		public Repository(HouseRentingDbContext context)
		{
			data = context;
		}
		public IQueryable<T> All<T>() where T : class
		{
			return DbSet<T>();
		}
		
		public IQueryable<T> AllReadOnly<T>() where T : class
		{
			return DbSet<T>()
				.AsNoTracking();
		}

		private DbSet<T> DbSet<T>() where T : class
		{
			return data.Set<T>();
		}
	}
}
