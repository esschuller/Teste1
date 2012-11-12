using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using MvcApplication3.Models;
using System.Linq.Expressions;

namespace MvcApplication3.DAL {
	public class DataAccess<TEntity> where TEntity : class, IEntity {
		internal SchoolContext context;
		internal DbSet<TEntity> dbSet;

		public DataAccess(SchoolContext context) {
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "") {
			IQueryable<TEntity> query = dbSet;

			if (filter != null) {
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
				query = query.Include(includeProperty);
			}

			query = query.Where(e => !e.Deleted);

			if (orderBy != null) {
				return orderBy(query).ToList();
			} else {
				return query.ToList();
			}
		}

		public virtual TEntity GetByID(object id) {
			return dbSet.Find(id);
		}

		public virtual bool Insert(TEntity entity) {
			dbSet.Add(entity);
			this.context.SaveChanges();
			return true;
		}

		public virtual bool DeletePermanent(object id) {
			TEntity entityToDelete = dbSet.Find(id);
			return DeletePermanent(entityToDelete);
		}

		public virtual bool DeletePermanent(TEntity entityToDelete) {
			if (this.context.Entry(entityToDelete).State == EntityState.Detached) {
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
			this.context.SaveChanges();
			return true;
		}

		public virtual bool Delete(TEntity entityToDelete) {
			entityToDelete.Deleted = true;
			dbSet.Attach(entityToDelete);
			this.context.Entry(entityToDelete).State = EntityState.Modified;
			this.context.SaveChanges();
			return true;
		}

		public virtual bool Delete(object id) {
			TEntity entityToDelete = dbSet.Find(id);
			return Delete(entityToDelete);
		}

		public virtual bool Update(TEntity entityToUpdate) {
			dbSet.Attach(entityToUpdate);
			this.context.Entry(entityToUpdate).State = EntityState.Modified;
			this.context.SaveChanges();
			return true;
		}


		public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters) {
			return dbSet.SqlQuery(query, parameters).ToList();
		}


	}
}