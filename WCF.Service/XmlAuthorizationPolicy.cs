using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;

namespace WCF.Service {
	internal class XmlAuthorizationPolicy : IAuthorizationPolicy {

		private string _authorizationPolicyId;
		
		public bool Evaluate(EvaluationContext evaluationContext, ref object state) {
			IIdentity identity = GetIdentityFromClient(evaluationContext);
			XmlIdentity xmlIdentity =
				new XmlIdentity(identity.AuthenticationType, identity.Name);

			evaluationContext.Properties["Principal"] =
				new XmlPrincipal(
					xmlIdentity,
					XmlSecurityHelper.GetRolesByUserName(xmlIdentity.Name));

			return true;
		}

		private static IIdentity GetIdentityFromClient(EvaluationContext evaluationContext) {
			IIdentity identity = null;
			object propertyIdentities = null;

			if (!evaluationContext.Properties.TryGetValue("Identities",
				out propertyIdentities))
				throw new Exception("Nenhuma identidade foi encontrada.");

			IList<IIdentity> identities = propertyIdentities as IList<IIdentity>;

			if (identities != null && identities.Count > 0)
				identity = identities[0];

			return identity;
		}

		public ClaimSet Issuer {
			get {
				return ClaimSet.System;
			}
		}

		public string Id {
			get {
				return this._authorizationPolicyId;
			}
		}

		
	}
}