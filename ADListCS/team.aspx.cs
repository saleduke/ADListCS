using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Collections;

namespace ADListCS
{
	public partial class team : System.Web.UI.Page
	{
		bool useQuerystring =true;
		string rootPath = System.Configuration.ConfigurationManager.AppSettings["root_Path"];
		protected void Page_Load(object sender, EventArgs e)
		{

			if (IsPostBack) 
			{ 
				useQuerystring = false; 
			} 
			else 
			{ 
				
				useQuerystring = true;
				foreach (string s in System.IO.File.ReadAllLines(rootPath+"Teams.txt")) 
				{
					TeamDDL.Items.Add(s);
				}
				
				
			}

		if (Request.QueryString["team"]!=null && useQuerystring)
			{
				string teamName = Request.RawUrl.Substring(Request.RawUrl.IndexOf("?team=")+6);
			teamName = teamName.Replace("+", " ");
			if (teamName.Contains("%26")) 
				{ 
					teamName=teamName.Replace("%26", "&"); 
				}
				TextBox4.Text = teamName;// Request.QueryString["team"];
				
			TeamDDL.Items.FindByValue(teamName).Selected = true;
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
				
			if (TextBox4.Text != "null" && TextBox4.Text != "")
			{
				try
				{

					adsSearch.PropertiesToLoad.Add("department");
                    adsSearch.Filter = "(&(department=" + TextBox4.Text + ")(!(description=Disabled user)))";

					
					SearchResultCollection oResults = adsSearch.FindAll();

					foreach (SearchResult oResult in oResults)
					{
						if (Helpers.GetPropertyString(oResult,"department") != "")
						{
							LinkButton lb = new LinkButton();
							lb.ForeColor = System.Drawing.Color.FromArgb(234,78,81);
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
		useQuerystring = true;
		}
		protected void TeamDDL_SelectedIndexChanged(object sender,EventArgs e)
		{
			TextBox4.Text = TeamDDL.Text;

			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			if (TextBox4.Text != "null" && TextBox4.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("department");
                    adsSearch.Filter = "(&(department=" + TextBox4.Text + ")(!(description=Disabled user)))";

				   SearchResultCollection oResults = adsSearch.FindAll();
			
					foreach (SearchResult oResult in oResults)
					{
						if (Helpers.GetPropertyString(oResult,"department") != "")
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

		protected void TextBox4_TextChanged(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			if (TextBox4.Text != "null" && TextBox4.Text != "" )
			{
				try
				{

					adsSearch.PropertiesToLoad.Add("department");
                    adsSearch.Filter = "(&(department=" + TextBox4.Text + ")(!(description=Disabled user)))";
				
					SearchResultCollection oResults = adsSearch.FindAll();
					foreach (SearchResult oResult in oResults)
					{
						if (Helpers.GetPropertyString(oResult,"department")!= "")
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
		protected SortedSet<string> GetTeamNames()
		{
			SortedSet<string> retSortedSet= new SortedSet<string>();
			try
			{
				DirectorySearcher adsSearch = Helpers.DirectorySearcher();
				adsSearch.PropertiesToLoad.Add("department");
                adsSearch.Filter = "(&(department=*)(!(description=Disabled user)))";
			
			
				SearchResultCollection oResults = adsSearch.FindAll();
			
				//int i = 0;
				foreach (SearchResult oResult in oResults)
				{
					retSortedSet.Add(Helpers.GetPropertyString(oResult, "department"));
				
				}

			}
			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
			}


			return retSortedSet;
		}

		protected void ReloadTeamNames(object sender, EventArgs e)
		{
			SortedSet<string> sortedSet = GetTeamNames();
			TeamDDL.Items.Clear();
			foreach (string s in sortedSet)
			{
				TeamDDL.Items.Add(s);
			}
			System.IO.File.WriteAllLines(rootPath+"Teams.txt", sortedSet);
		}

	}
}