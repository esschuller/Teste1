using System;
using System.Security.Principal;
using System.ServiceModel;

namespace WCF.Service {
	internal class XmlAuthorizationManager : ServiceAuthorizationManager {
		protected override bool CheckAccessCore(OperationContext operationContext) {
			base.CheckAccessCore(operationContext);
			XmlPrincipal xmlPrincipal = GetCurrentXmlPrincipal(operationContext);

			if (operationContext.IncomingMessageHeaders.Action ==
				"http://localhost:37610")
				if (!xmlPrincipal.IsInRole("Admin"))
					return false;

			return true;
		}

		private static XmlPrincipal GetCurrentXmlPrincipal(OperationContext operationContext) {
			return (XmlPrincipal)operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"];
		}
	}
}