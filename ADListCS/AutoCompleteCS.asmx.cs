using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;
using System.DirectoryServices;
using System.ComponentModel;

namespace ADListCS
{
	/// <summary>
	/// Summary description for AutoCompleteCS
	/// </summary>
	[WebService(Namespace = "http://localhost/autocompletecs/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class AutoCompleteCS : System.Web.Services.WebService
	{
        String domainString = System.Configuration.ConfigurationManager.AppSettings["domainString"];

		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
		public string[] GetCompletionList( string prefixText, int count)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			
			adsSearch.PropertiesToLoad.Add("cn");
	  
			adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(cn=*" + prefixText + "*))(!(description=Disabled user)))";
			SearchResultCollection oResults =adsSearch.FindAll();
   
			int i = 0;
	   
			string[] items = new string[oResults.Count];
			foreach (SearchResult oResult in oResults)
				{
					if (Helpers.GetPropertyString(oResult,"cn") != "")
					items.SetValue(Helpers.GetPropertyString(oResult,"cn"), i);
					i = i + 1;
				}
			Array.Sort(items);
			items = items.Distinct().ToArray();
			return items.ToArray();

		}

		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
		public string[] GetCompletionListmobile(string prefixText, int count)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			adsSearch.PropertiesToLoad.Add("mobile");

			adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(mobile=*" + prefixText + "*))(!(description=Disabled user)))";
			SearchResultCollection oResults = adsSearch.FindAll();

			int i = 0;

			string[] items = new string[oResults.Count];
			foreach (SearchResult oResult in oResults)
			{
				if (Helpers.GetPropertyString(oResult,"mobile") != "")
					items.SetValue(Helpers.GetPropertyString(oResult,"mobile"), i);
				i = i + 1;
			}
			Array.Sort(items);
			items = items.Distinct().ToArray();
			return items.ToArray();

		}

		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
		public string[] GetCompletionListfix(string prefixText, int count)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			adsSearch.PropertiesToLoad.Add("telephoneNumber");

			adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(telephoneNumber=*" + prefixText + "*))(!(description=Disabled user)))";
			SearchResultCollection oResults = adsSearch.FindAll();

			int i = 0;

			string[] items = new string[oResults.Count];
			foreach (SearchResult oResult in oResults)
			{
				if (Helpers.GetPropertyString(oResult,"telephoneNumber") != "")
					items.SetValue(oResult.GetDirectoryEntry().Properties["telephoneNumber"].Value, i);
				i = i + 1;
			}
			Array.Sort(items);
			items = items.Distinct().ToArray();
			return items.ToArray();

		}

		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
		public string[] GetCompletionListOffice(string prefixText, int count)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			adsSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");

			adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(physicalDeliveryOfficeName=*" + prefixText + "*))(!(description=Disabled user)))";
			SearchResultCollection oResults = adsSearch.FindAll();

			int i = 0;

			string[] items = new string[oResults.Count];
			foreach (SearchResult oResult in oResults)
			{
				if (Helpers.GetPropertyString(oResult,"physicalDeliveryOfficeName") != "")
					items.SetValue(Helpers.GetPropertyString(oResult,"physicalDeliveryOfficeName"), i);
				i = i + 1;
			}
			Array.Sort(items);
			items = items.Distinct().ToArray();
			return items.ToArray();

		}

		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
		public string[] GetCompletionListTeam(string prefixText, int count)
		{
			
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			adsSearch.PropertiesToLoad.Add("department");

			adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(department=*" + prefixText + "*))(!(description=Disabled user)))";
			SearchResultCollection oResults = adsSearch.FindAll();

			int i = 0;

			string[] items = new string[oResults.Count];
			foreach (SearchResult oResult in oResults)
			{
				if (Helpers.GetPropertyString(oResult,"department") != "")
					items.SetValue(Helpers.GetPropertyString(oResult,"department"), i);
				i = i + 1;
			}
			Array.Sort(items);
			items = items.Distinct().ToArray();
			return items.ToArray();

		}

	}
}
