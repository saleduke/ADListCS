using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.DirectoryServices;

namespace ADListCS
{
    /// <summary>
    /// Summary description for GetADData
    /// </summary>
    [WebService(Namespace = "http://localhost/getaddata/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetADData : System.Web.Services.WebService
    {
        String domainString = System.Configuration.ConfigurationManager.AppSettings["domainString"];
        [WebMethod]
        public UserData GetADUserData(string cn)
        {
            UserData userData = new UserData();
            DirectorySearcher adsSearch = Helpers.DirectorySearcher();
             
            adsSearch.PropertiesToLoad.Add("mobile");

            adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(cn=" + cn + "))(!(description=Disabled user)))";
            SearchResultCollection oResults = adsSearch.FindAll();

            
            foreach (SearchResult oResult in oResults)
            {
                if (Helpers.GetPropertyString(oResult, "mobile") != "")
                    userData.mobile=Helpers.GetPropertyString(oResult, "mobile");
                if (Helpers.GetPropertyString(oResult, "telephoneNumber") != "")
                    userData.fix = Helpers.GetPropertyString(oResult, "telephoneNumber");
                if (Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName") != "")
                    userData.office = Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName");
                if (Helpers.GetPropertyString(oResult, "department") != "")
                    userData.team = Helpers.GetPropertyString(oResult, "department");
                if (Helpers.GetPropertyString(oResult, "mail") != "")
                    userData.mail = Helpers.GetPropertyString(oResult, "mail");
                if (Helpers.GetPropertyString(oResult, "extensionAttribute1") != "")
                    userData.skype = Helpers.GetPropertyString(oResult, "extensionAttribute1");
                if (Helpers.GetPropertyString(oResult, "title") != "")
                    userData.title = Helpers.GetPropertyString(oResult, "title");
                try 
                { 
                if (Helpers.GetPropertyString(oResult, "lastLogon") != "")
                    userData.lastlogon = Helpers.GetPropertyString(oResult, "lastLogon");
                }
                catch(Exception exc)
                {
                    userData.lastlogon = "";
                }
                
                if (Helpers.GetPropertyString(oResult, "manager") != "")
                    {
                        string[] niz = Helpers.GetPropertyString(oResult, "manager").Split(',');
                        userData.manager = niz[0].Substring(3); 
                    }
                Byte[] ba = (Byte[])oResult.GetDirectoryEntry().Properties["thumbnailPhoto"].Value;
                if (ba == null) {
                    string s = "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";
                          //  userData.slika = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }; 
                    userData.slika = Convert.FromBase64String(s);
                }
                else 
                    userData.slika = (Byte[])oResult.GetDirectoryEntry().Properties["thumbnailPhoto"].Value;
            }
                       
            return userData;
        }

        [WebMethod]
        public string[] GetTeamMembers(string teamName)
        {
            DirectorySearcher adsSearch = Helpers.DirectorySearcher();

            adsSearch.PropertiesToLoad.Add("cn");

            adsSearch.PropertiesToLoad.Add("objectClass");

            adsSearch.Filter = "(&(&(objectCategory=CN=Person,CN=Schema,CN=Configuration," + domainString + ")(department=*" + teamName + "*))(!(description=Disabled user)))";
            SearchResultCollection oResults = adsSearch.FindAll();

            int i = 0;

            string[] items = new string[oResults.Count];
            foreach (SearchResult oResult in oResults)
            {
                if (Helpers.GetPropertyString(oResult, "cn") != "")
                    items.SetValue(Helpers.GetPropertyString(oResult, "cn"), i);
                i = i + 1;
            }
            Array.Sort(items);
            items = items.Distinct().ToArray();
            return items.ToArray();
        }

    }
    public class UserData
    {
        public string mobile { get; set; }
        public string fix { get; set; }
        public string office { get; set; }
        public string team { get; set; }
        public string mail { get; set; }
        public string skype { get; set; }
        public string title { get; set; }
        public string lastlogon { get; set; }
        public string manager { get; set; }
        public Byte[] slika { get; set; }
    }
}
