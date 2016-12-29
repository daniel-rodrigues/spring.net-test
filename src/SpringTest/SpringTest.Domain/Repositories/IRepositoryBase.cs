using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpringTest.Domain.Entities;

namespace SpringTest.Domain.Repositories {
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase {
		void Add(TEntity entity);
		void AddOrUpdate(TEntity entity);
		void Update(TEntity entity);
		void Delete(int id);
		void Delete(Expression<Func<TEntity, bool>> where);
		TEntity Get(Expression<Func<TEntity, bool>> where, string includes = "");
		IEnumerable<TEntity> GetAll(string includes = "");
		IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, string includes = "");
		void Commit();
	}
}
