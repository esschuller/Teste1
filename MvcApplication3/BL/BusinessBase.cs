using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity.Infrastructure;
using MvcApplication3.Models;
using MvcApplication3.DAL;

namespace MvcApplication3.BL {
	public class BusinessBase<TEntity> : IDisposable where TEntity : class, IEntity {

		protected ModelStateDictionary modelState;
		protected DataAccess<TEntity> da;
		protected SchoolContext context = new SchoolContext();

		public BusinessBase(ModelStateDictionary modelState) {
			this.da = new DataAccess<TEntity>(this.context);
			this.modelState = modelState;
		}


		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "") {

			return this.da.Get(filter, orderBy, includeProperties);
		}

		public virtual TEntity GetByID(object id) {
			return this.da.GetByID(id);
		}

		public virtual bool Insert(TEntity entity) {
			if (modelState.IsValid) {
				return this.da.Insert(entity);
			}

			return false;
		}

		public virtual bool DeletePermanent(object id) {
			return this.da.DeletePermanent(id);
		}

		public virtual bool DeletePermanent(TEntity entityToDelete) {
			return this.da.DeletePermanent(entityToDelete);
		}

		public virtual bool Delete(TEntity entityToDelete) {
			return this.da.Delete(entityToDelete);
		}

		public virtual bool Delete(object id) {
			return this.da.Delete(id);
		}

		public virtual bool Update(TEntity entityToUpdate) {

			try {
				if (modelState.IsValid) {
					return this.da.Update(entityToUpdate);
				}

				return false;

			} catch (DbUpdateConcurrencyException ex) {
				var entry = ex.Entries.Single();
				var databaseValues = entry.GetDatabaseValues();
				var clientValues = entry.CurrentValues;


				foreach (String propName in clientValues.PropertyNames) {
					if (propName != "Timestamp" && propName != "Deleted") {
						
						if (clientValues.GetValue<Object>(propName).ToString() != databaseValues.GetValue<Object>(propName).ToString()) {
							Object propVal = databaseValues.GetValue<Object>(propName);
							String formatVal = "";

							if (propVal is Decimal || propVal is Double)
								formatVal = String.Format("{0:0.00}", propVal);
							else if(propVal is DateTime)
								formatVal= String.Format("{0:d}", propVal);
							else
								formatVal = propVal.ToString();
							
							modelState.AddModelError(propName, "Valor Atual: " + formatVal);
						}
					}
				}




				/*var databaseValues = (Department)entry.GetDatabaseValues().ToObject();
				 * 
				var clientValues = (Department)entry.Entity;
				if (databaseValues.Name != clientValues.Name)
					modelState.AddModelError("Name", "Current value: "
						+ databaseValues.Name);
				if (databaseValues.Budget != clientValues.Budget)
					modelState.AddModelError("Budget", "Current value: "
						+ String.Format("{0:c}", databaseValues.Budget));
				if (databaseValues.StartDate != clientValues.StartDate)
					modelState.AddModelError("StartDate", "Current value: "
						+ String.Format("{0:d}", databaseValues.StartDate));
				if (databaseValues.PersonID != clientValues.PersonID)
					modelState.AddModelError("InstructorID", "Current value: "
						+ db.Instructors.Find(databaseValues.PersonID).FullName);
				
				 */

				modelState.AddModelError(string.Empty, "O registro que você tentou editar "
				 + "foi modificado por outro usuário depois que você exibiu os valores originais. "
				 + "A operação de edição foi cancelada e os valores atuais do banco de dados foram "
				 + "exibidos. Se você ainda deseja editar este registro, clique no botão \"Salvar\" novamente. "
				 + "Caso contrário, clique em \"Cancelar\" para voltar para a listagem");

				/*modelState.AddModelError(string.Empty, "The record you attempted to edit "
				  + "was modified by another user after you got the original value. The "
				  + "edit operation was canceled and the current values in the database "
				  + "have been displayed. If you still want to edit this record, click "
				  + "the Save button again. Otherwise click the Back to List hyperlink.");*/

				entityToUpdate.Timestamp = databaseValues.GetValue<Byte[]>("Timestamp");
				return false;
			} catch (DataException) {
				//Log the error (add a variable name after Exception)
				modelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
				return false;
			}
		}

		public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters) {
			return this.da.GetWithRawSql(query, parameters);
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing) {
			if (!this.disposed) {
				if (disposing) {
					this.context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}


	}
}