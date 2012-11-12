using System;
using System.Linq;
using System.Security.Principal;

namespace WCF.Service {
	internal class XmlPrincipal : IPrincipal {
		private string[] _roles;
		private XmlIdentity _identity;

		public XmlPrincipal(XmlIdentity identity, string[] roles) {
			this._identity = identity;
			this._roles = roles;
		}

		public IIdentity Identity {
			get {
				return this._identity;
			}
		}

		public string[] Roles {
			get {
				return this._roles;
			}
		}

		public bool IsInRole(string role) {
			return (from r in this.Roles where r == role select r).Count() > 0;
		}
	}
}