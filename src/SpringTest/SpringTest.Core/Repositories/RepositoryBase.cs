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

		protected readonly EfDbContext efContext;

		public RepositoryBase(EfDbContext efContext) {
			this.efContext = efContext;
		}

		public RepositoryBase() {
			this.efContext = new EfDbContext();
		} 

		private DbSet<TEntity> Entity { get { return efContext.Set<TEntity>(); } }

		public void Add(TEntity entity) {
			entity.CreatedAt = DateTime.Now;	
			Entity.Add(entity);
		}
			
		public void Update(TEntity entity) {
			entity.UpdateAt = DateTime.Now;
			efContext.Entry(entity).State = EntityState.Modified;
		}

		public void AddOrUpdate(TEntity entity) {
			if (entity.Id > 0)
				Update(entity);
			else
				Add(entity);
		}
		public void Delete(int id) {
			efContext.Set<TEntity>().Remove(efContext.Set<TEntity>().Find(id));
		}

		public void Delete(Expression<Func<TEntity, bool>> where) {
			var objects = efContext.Set<TEntity>().Where(where).AsEnumerable();

			foreach (var obj in objects)
				efContext.Set<TEntity>().Remove(obj);
		}

		public TEntity Get(Expression<Func<TEntity, bool>> where, string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return efContext.Set<TEntity>().FirstOrDefault(where);

			return efContext.Set<TEntity>().Include(includes).FirstOrDefault(where);
		}

		public IEnumerable<TEntity> GetAll(string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return efContext.Set<TEntity>().ToList();

			return efContext.Set<TEntity>().Include(includes).ToList();
		}

		public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, string includes = "") {
			if (string.IsNullOrEmpty(includes))
				return efContext.Set<TEntity>().Where(where).ToList();

			return efContext.Set<TEntity>().Include(includes).Where(where).ToList();
		}

		public void Commit() {
			try {
				efContext.SaveChanges();
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
