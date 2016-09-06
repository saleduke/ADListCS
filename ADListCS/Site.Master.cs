using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADListCS
{
	public partial class SiteMaster : System.Web.UI.MasterPage
	{
		public String ErrorLabelText
		{
			get { return ErrorLabel.Text; }
			set { ErrorLabel.Text = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
