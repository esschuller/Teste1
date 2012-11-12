using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace WCF.Service {
	internal class XmlAuthentication : UserNamePasswordValidator {
		public override void Validate(string userName, string password) {
			if (!XmlSecurityHelper.ValidateUser(userName, password))
				throw new SecurityTokenValidationException("Usuario Invalido.");
		}
	}
}