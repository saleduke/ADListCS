using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

namespace ADListCS
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch= Helpers.DirectorySearcher();
			adsSearch.PropertiesToLoad.Add("sAMAccountName");
			//adsSearch.Filter = "sAMAccountName=" + Page.User.Identity.Name.Substring(4);
            adsSearch.Filter = "sAMAccountName=aleksandar.vojvodic"/* + Page.User.Identity.Name.Substring(4)*/;
			SearchResult oResult = adsSearch.FindOne();
			if (Helpers.GetPropertyString(oResult,"cn") != "")
				ImageButton1.PostBackUrl = "PhoneBook.aspx?account=" + Helpers.GetPropertyString(oResult,"cn");
			if (Helpers.GetPropertyString(oResult, "department") != "")
				ImageButton3.PostBackUrl = "Team.aspx?team=" + Server.UrlEncode(Helpers.GetPropertyString(oResult, "department"));
			if (Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName") != "")
				ImageButton4.PostBackUrl = "Office.aspx?office=" + Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName");
		}
	}
}
