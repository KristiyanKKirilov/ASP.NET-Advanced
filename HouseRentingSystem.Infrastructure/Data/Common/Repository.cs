﻿using Microsoft.EntityFrameworkCore;

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

		public async Task AddAsync<T>(T entity) where T : class 
		{ 
			await DbSet<T>().AddAsync(entity);	
		}

		public async Task<int> SaveChangesAsync()
		{
			return await data.SaveChangesAsync();
		}

		private DbSet<T> DbSet<T>() where T : class
		{
			return data.Set<T>();
		}
	}
}
