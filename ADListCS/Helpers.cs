using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using ActiveDs;

namespace ADListCS
{
	public class Helpers
	{
		
		 public static String GetPropertyString(SearchResult searchResult, string propertyName)
		{
			string propertyString = string.Empty;
			if (propertyName == "lastLogon")
			{
				DateTime dTemp = new DateTime();
				LargeInteger largeInt = (LargeInteger)searchResult.GetDirectoryEntry().Properties["lastLogon"][0];
				Int64 liTicks = (Int64)largeInt.HighPart * 0x100000000 + largeInt.LowPart;
				if (DateTime.MaxValue.Ticks >= liTicks && DateTime.MinValue.Ticks <= liTicks)
				{
					dTemp = DateTime.FromFileTime(liTicks);
				}
				propertyString = Environment.NewLine + dTemp.ToLongDateString() + Environment.NewLine + dTemp.ToLongTimeString();
			}
			else
			{
				if (searchResult!=null && searchResult.GetDirectoryEntry().Properties[propertyName].Value != null)
				propertyString = searchResult.GetDirectoryEntry().Properties[propertyName].Value.ToString();
			}
			

			 
			return propertyString;
		}
		 public static DirectorySearcher DirectorySearcher()
		 {
			//DirectoryEntry adsRoot = new DirectoryEntry("LDAP://PCDC1.dms.local", account, password, AuthenticationTypes.Secure);
			//DirectoryEntry adsRoot = new DirectoryEntry("LDAP://PCDC1.dms.local");
			DirectoryEntry adsRoot = new DirectoryEntry(System.Configuration.ConfigurationManager.AppSettings["LDAP_Path"]);
			DirectorySearcher adsSearch = new DirectorySearcher(adsRoot);
			adsSearch.Sort = new SortOption("cn", SortDirection.Ascending);
			//DirectoryEntry adsRoot = new DirectoryEntry("LDAP://PCDC1.dms.local/ou=Users,ou=TDMS,dc=dms,dc=local", account, password, AuthenticationTypes.Secure);
			//DirectorySearcher adsSearch = new DirectorySearcher(adsRoot);
			return adsSearch;
		 }

		public static DirectoryEntry DirectoryEntry(string strDN)
		 {
			//DirectoryEntry myUser =new System.DirectoryServices.DirectoryEntry("LDAP://PCDC1.dms.local/" + strDN, account, password, AuthenticationTypes.Secure);
			DirectoryEntry myUser = new System.DirectoryServices.DirectoryEntry("LDAP://PCDC1.dms.local/" + strDN);
			return myUser;
		 }

		
	}
}