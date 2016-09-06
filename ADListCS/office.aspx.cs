using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

namespace ADListCS
{
	public partial class office : System.Web.UI.Page
	{
		bool useQueryString = true;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) useQueryString = false; else useQueryString = true;
			if (Request.QueryString["office"]!=null && useQueryString)
			{
				TextBox4.Text = Request.QueryString["office"];
				DirectorySearcher adsSearch = Helpers.DirectorySearcher();
				if (!String.IsNullOrEmpty(TextBox4.Text))
				{
					try
					{
						adsSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");
						adsSearch.Filter = "physicalDeliveryOfficeName=" + TextBox4.Text;
						SearchResultCollection oResults = adsSearch.FindAll();
						foreach(SearchResult oResult in oResults)
						{
							if (Helpers.GetPropertyString(oResult,"physicalDeliveryOfficeName") != "") 
							{ 
								LinkButton lb = new LinkButton();
								lb.ForeColor = System.Drawing.Color.FromArgb(234, 78, 81);
								lb.Font.Underline = false;
								lb.Font.Name = "Arial";
								lb.Font.Size = 10;
								Literal breakline = new Literal();
								lb.Text = Helpers.GetPropertyString(oResult,"cn");
								lb.PostBackUrl = "PhoneBook.aspx?account=" + lb.Text;
								breakline.Text = "<br>";
								Panel1.Controls.Add(lb);
								Panel1.Controls.Add(breakline);
							}
						}
					}
					catch (Exception ex)
					{
						SiteMaster master = (SiteMaster)Page.Master;
						master.ErrorLabelText = ex.Message;
					}
				}
			}
			useQueryString = true;
		}

		protected void TextBox4_TextChanged(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			if (TextBox4.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");
					adsSearch.Filter = "physicalDeliveryOfficeName=" + TextBox4.Text;
					SearchResultCollection oResults = adsSearch.FindAll();
					foreach(SearchResult oResult in oResults)
					{
						if (Helpers.GetPropertyString(oResult,"physicalDeliveryOfficeName") != "")
						{
							LinkButton lb = new LinkButton();
							lb.ForeColor = System.Drawing.Color.FromArgb(8, 150, 66);
							lb.Font.Underline = false;
							lb.Font.Name = "Arial";
							lb.Font.Size = 10;
							Literal breakline = new Literal();
							lb.Text = Helpers.GetPropertyString(oResult,"cn");
							lb.PostBackUrl = "PhoneBook.aspx?account=" + lb.Text;
							breakline.Text = "<br>";
							Panel1.Controls.Add(lb);
							Panel1.Controls.Add(breakline);
						}
					}
					
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message;
				}
			}
			
		}

		protected void FloorSelected(object sender, EventArgs e)
		{ 
			DDLRoom.Items.Clear();
			List<String> lista = new List<string>();
			String s = string.Empty;
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			if (DropDownListFloor.SelectedItem.Text != "-- select floor --")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");
					adsSearch.Filter = "physicalDeliveryOfficeName=" + DropDownListFloor.Text + "*";
					SearchResultCollection oResults = adsSearch.FindAll();

					foreach (SearchResult oResult in oResults)
					{
						s = Helpers.GetPropertyString(oResult,"physicalDeliveryOfficeName");
						if (s!="")
						{
							if (!lista.Contains(s))
							{
								lista.Add(s);
							}
						}
					}
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message;
				}
				DDLRoom.Items.Add("-- select room --");
				lista.Sort();
				foreach(string a in lista)
				{
					DDLRoom.Items.Add(a);
				}
			}
		}

		protected void RoomSelected(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			try
			{
				adsSearch.PropertiesToLoad.Add("physicalDeliveryOfficeName");
				adsSearch.Filter = "physicalDeliveryOfficeName=" + DDLRoom.Text;
				SearchResultCollection oResults = adsSearch.FindAll();

				foreach (SearchResult oResult in oResults)
				{
					LinkButton lb = new LinkButton();
					lb.ForeColor = System.Drawing.Color.FromArgb(8, 150, 66);
					lb.Font.Underline = false;
					lb.Font.Name = "Arial";
					lb.Font.Size = 10;
					Literal breakline = new Literal();
					lb.Text = Helpers.GetPropertyString(oResult,"cn");
					lb.PostBackUrl = "PhoneBook.aspx?account=" + lb.Text;
					breakline.Text = "<br>";
					Panel1.Controls.Add(lb);
					Panel1.Controls.Add(breakline);
				}
			}
			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
			}
		}

		
	}
}