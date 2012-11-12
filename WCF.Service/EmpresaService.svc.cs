using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Security.Permissions;
using WCF.Entities;

namespace WCF.Service {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	public class EmpresaService : IEmpresaService {

		//[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
		public List<Empresa> GetEmpresas() {
			
			var data = new AgentesCVCEntities();
			var q = from e in data.EmpresaEntity 
					select new Empresa{
						IdEmpresa = e.idEmpresa,
						Nome = e.nome,
						Codigo = e.codigo
					};

			return q.ToList();

		}

		//[PrincipalPermission(SecurityAction.Demand, Role = "Ti")]
		public Empresa GetEmpresaByID(Int32 id) {
			var data = new AgentesCVCEntities();
			var q = from e in data.EmpresaEntity
					where e.idEmpresa == id
					select new Empresa {
						IdEmpresa = e.idEmpresa,
						Nome = e.nome,
						Codigo = e.codigo
					};

			return q.FirstOrDefault();
		}
	}
}
