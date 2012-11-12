using System;
using System.Linq;
using System.Xml.Linq;

namespace WCF.Service {
	internal static class XmlSecurityHelper {

		private const string XML_AUTHENTICATION_FILE = @"C:\Users\emerson\Documents\Visual Studio 2010\Projects\WCF_Testes\Teste1\WCF.Service\Data\UsersRepository.xml";
		private const string XML_AUTHORIZATION_FILE = @"C:\Users\emerson\Documents\Visual Studio 2010\Projects\WCF_Testes\Teste1\WCF.Service\Data\RolesRepository.xml";

		public static bool ValidateUser(string userName, string password) {
			return (from user in XDocument.Load(XML_AUTHENTICATION_FILE).Descendants("user")
					where
					   user.Attribute("name").Value == userName &&
					   user.Attribute("password").Value == password
					select user).Count() == 1;
		}

		public static string[] GetRolesByUserName(string userName) {
			var userRoles =
				from user in XDocument.Load(XML_AUTHORIZATION_FILE).Descendants("user")
				where user.Attribute("name").Value == userName
				select new {
					Roles =
						Array.ConvertAll<XElement, string>(
							user.Elements("role").ToArray(), c => c.Attribute("name").Value)
				};

			return userRoles.FirstOrDefault().Roles;
		}
	}
}