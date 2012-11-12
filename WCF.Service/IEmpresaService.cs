using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Entities;

namespace WCF.Service {
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IEmpresaService {

		[OperationContract]
		List<Empresa> GetEmpresas();

		[OperationContract]
		Empresa GetEmpresaByID(Int32 id);

		

		// TODO: Add your service operations here
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class Empresa {
		[DataMember]
		public Int32 IdEmpresa { get; set; }

		[DataMember]
		public String Nome { get; set; }

		[DataMember]
		public String Codigo { get; set; }
	}
}
