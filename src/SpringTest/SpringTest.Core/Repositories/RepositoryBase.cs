using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using SpringTest.Domain.Entities;
using SpringTest.Domain.Repositories;
using System.Linq.Expressions;
using SpringTest.Core.EfContext;

namespace SpringTest.Core.Repositories {
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase {

		protected readonly EfDbContext Context;

		public RepositoryBase(EfDbContext context) {
			Context = context;
		}

		private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }

		public void Add(TEntity entity) {
			entity.CreatedAt = DateTime.Now;
			Entity.Add(entity);
		}
			
		public void Update(TEntity entity) {
			entity.UpdateAt = DateTime.Now;
			Context.Entry(entity).State = EntityState.Modified;
		}

		public void AddOrUpdate(TEntity entity) {
			if (entity.Id > 0)
				Update(entity);
			else
				Add(entity);
		}
		public void Delete(int id) {
			Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
		}

		public void Delete(Expression<Func<TEntity, bool>> where) {
			var objects = Context.Set<TEntity>().Where(where).AsEnumerable();

			foreach (var obj in objects)
				Context.Set<TEntity>().Remove(obj);
		}

		public TEntity Get(Expression<Func<TEntity, bool>> where, string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return Context.Set<TEntity>().FirstOrDefault(where);

			return Context.Set<TEntity>().Include(includes).FirstOrDefault(where);
		}

		public IEnumerable<TEntity> GetAll(string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return Context.Set<TEntity>().ToList();

			return Context.Set<TEntity>().Include(includes).ToList();
		}

		public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return Context.Set<TEntity>().Where(where).ToList();

			return Context.Set<TEntity>().Include(includes).Where(where).ToList();
		}

		public void Commit() {
			try {
				Context.SaveChanges();
			} catch (DbEntityValidationException e) {
				foreach (var eve in e.EntityValidationErrors) {
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
							eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors) {
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
								ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
		}

	}
}
