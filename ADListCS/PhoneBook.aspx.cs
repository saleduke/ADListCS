using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.DirectoryServices;
using System.Collections;
using System.Net;

namespace ADListCS
{
	public partial class PhoneBook : System.Web.UI.Page
	{

		public Byte[] byteArray;
		String path = System.Configuration.ConfigurationManager.AppSettings["images_Path"];
		String name;
		TreeNode manager;
		Boolean useQueryString = true;
		protected void Page_Load(object sender, EventArgs e)
		{
			SiteMaster master = (SiteMaster)Page.Master;
			master.ErrorLabelText = "";
			Label1.Text = "";
			Label2.Text = "";
			Label3.Text = "";
			Label41.Text = "";
			Label42.Text = "";
			Label5.Text = "";
			LinkButtondepartment.Text = "";
			TableRowSkype.Visible = false;
			TableRow71.Visible = false;
			ImageButton1.Visible = false;
			if (IsPostBack) {Table4.Visible = true;} else {Table4.Visible = false;}
			//Table4.Visible = true;
			if (IsPostBack) {useQueryString = false;} else {useQueryString = true;}
			//useQueryString = true;
			if (Request.QueryString["account"]!=null && useQueryString)
			{
			TextBox4.Text = Request.QueryString["account"];
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			TextBox2.Text = "";
			TextBox3.Text = "";
		   if (!String.IsNullOrEmpty(TextBox4.Text))
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("cn");
					adsSearch.Filter = "cn=" + TextBox4.Text;

					SearchResult oResult =adsSearch.FindOne();
					FormPhoneBookPage(oResult);

					FillTree();
				}
				catch (Exception ex)
				{
					master.ErrorLabelText = ex.Message;
				}

			}
		}
		
		useQueryString = true;

		}
		/// <summary>
		/// Fills Organization Hierarchy tree
		/// </summary>
		private void FillTree()
		{
			TreeView1.Nodes.Clear();
			//********** NA POCETKU - SHEF ***********
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			try
			{
				adsSearch.PropertiesToLoad.Add("displayName");

				adsSearch.Filter = "displayName=" + Label1.Text;


				SearchResult oResult = adsSearch.FindOne();

				if (Label1.Text != System.Configuration.ConfigurationManager.AppSettings["general_manager"] && Helpers.GetPropertyString(oResult, "manager") != "")
				{
					DirectoryEntry myUser = Helpers.DirectoryEntry(Helpers.GetPropertyString(oResult, "manager"));

					manager = new TreeNode();
					manager.Text = myUser.Properties["displayName"].Value.ToString();
					TreeView1.Nodes.Add(manager);
				}
				else
				{
					manager = new TreeNode();
					manager.Text = "...";
					TreeView1.Nodes.Add(manager);
				}

			}
			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
			}
					
			//********** NA POCETKU - SHEF ***********

			String vime;

			DirectorySearcher adsSearch1 = Helpers.DirectorySearcher();


			adsSearch1.PropertiesToLoad.Add("cn");
			adsSearch1.PropertiesToLoad.Add("manager");
			adsSearch1.PropertiesToLoad.Add("distinguishedName");
			if (name != "")
			{ adsSearch1.Filter = "(manager=" + name + ")"; }

			else
			{   adsSearch1.Filter = "(manager=nobody)";}
		
			Hashtable RetArray1 = new Hashtable();

			TreeNode cvor;

			if (name != "")
			{
				SearchResultCollection oResults1 = adsSearch1.FindAll();
				foreach (SearchResult oResult1 in oResults1)
				{

					RetArray1.Add(oResult1.GetDirectoryEntry().Properties["cn"].Value, oResult1.GetDirectoryEntry().Properties["sAMAccountName"].Value);


				}
				//*****************  DODAVANJE NODOVA NA ISTOM NIVOU *************
				List<DictionaryEntry> SortedRetArray = new List<DictionaryEntry>();

				foreach (DictionaryEntry entry in RetArray1)
				{
					SortedRetArray.Add(entry);
				}

				var sortedDict = (from entry in SortedRetArray orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
				foreach (KeyValuePair<object, object> entry in sortedDict)

				 //   foreach(DictionaryEntry entry in RetArray1)
				{
					cvor = new TreeNode();
					cvor.Text = entry.Key.ToString();
					cvor.Value = entry.Value.ToString();
					manager.ChildNodes.Add(cvor);
				}
			}
			else
			{
				adsSearch1.Filter = "(cn=" + Label1.Text + ")";
				SearchResult oResult2 = adsSearch1.FindOne();

				cvor = new TreeNode();
				cvor.Text = Helpers.GetPropertyString(oResult2,"cn");

				cvor.Value = Helpers.GetPropertyString(oResult2,"sAMAccountName");
				manager.ChildNodes.Add(cvor);
			}


			for (int i = 0; i < manager.ChildNodes.Count; i++)
			{
				if (IsThereAChild(manager.ChildNodes[i].Value) && (manager.ChildNodes[i].Text == Label1.Text)) 
				{
				   //*************************
					DirectorySearcher adsSearch3 = Helpers.DirectorySearcher();
				
					adsSearch3.PropertiesToLoad.Add("cn");
					adsSearch3.Filter = "cn=" + manager.ChildNodes[i].Text;

					Hashtable RetArray3 = new Hashtable();

					SearchResult oResult3 = adsSearch3.FindOne();

					vime = oResult3.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString();

				   //*************************

					DirectorySearcher adsSearch2 = Helpers.DirectorySearcher();
				
					adsSearch2.PropertiesToLoad.Add("cn");
					adsSearch2.PropertiesToLoad.Add("manager");
					adsSearch2.PropertiesToLoad.Add("distinguishedName");
					adsSearch2.Filter = "(manager=" + vime + ")";
				
					Hashtable RetArray2 = new Hashtable();
					SearchResultCollection oResults2 = adsSearch2.FindAll();
				
					foreach(SearchResult oResult2 in oResults2)
					{
						RetArray2.Add(oResult2.GetDirectoryEntry().Properties["cn"].Value, oResult2.GetDirectoryEntry().Properties["sAMAccountName"].Value);
					}

					List<DictionaryEntry> SortedRetArray2 = new List<DictionaryEntry>();

					foreach (DictionaryEntry entry in RetArray2)
					{
						SortedRetArray2.Add(entry);
					}

					var sortedDict2 = (from entry in SortedRetArray2 orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

					foreach (KeyValuePair<object, object> entry in sortedDict2)
					//foreach (DictionaryEntry entry in RetArray2)
					{
						cvor = new TreeNode();
						cvor.Text = entry.Key.ToString();
						cvor.Value = entry.Value.ToString();
						manager.ChildNodes[i].ChildNodes.Add(cvor);
					}
				}
			}

				TreeView1.ExpandAll();

				for (int i = 0; i < manager.ChildNodes.Count - 1; i++)
				{
					if (manager.ChildNodes[i].Text == Label1.Text)
					{
						manager.ChildNodes[i].Select();
					}
				}
		}

		/// <summary>
		/// Checks if there are users that report directly to current user
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		private bool IsThereAChild(String parent)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();

			try
			{
			adsSearch.PropertiesToLoad.Add("directReports");

			adsSearch.Filter = "(&(directReports=*)(sAMAccountName=" + parent + "))";

			SearchResult oResult = adsSearch.FindOne();
				if (oResult != null) 
				{
					return true;
				}
				else
				{
					return false;
				}
			
			}

			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
				return false;
			}
	
		}

		protected void TextBox4_TextChanged(object sender, EventArgs e)
		{	
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			TextBox2.Text = "";
			TextBox3.Text = "";
			if (TextBox4.Text != "null" && TextBox4.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("cn");
					adsSearch.Filter = "cn=" + TextBox4.Text;
					SearchResult oResult = adsSearch.FindOne();
					FormPhoneBookPage(oResult);
					FillTree();
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message;
				}
			}
		}

		protected void TextBox2_TextChanged(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			TextBox4.Text = "";
			TextBox3.Text = "";
			if (TextBox2.Text != "null" && TextBox2.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("mobile");
					adsSearch.Filter = "mobile=" + TextBox2.Text;
					SearchResult oResult = adsSearch.FindOne();
					FormPhoneBookPage(oResult);
					FillTree();
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message;
				}
			}
		}

		protected void TextBox3_TextChanged(object sender, EventArgs e)
		{
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			TextBox4.Text = "";
			TextBox2.Text = "";
			if (TextBox3.Text != "null" && TextBox3.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("telephoneNumber");
					adsSearch.Filter = "telephoneNumber=" + TextBox3.Text;
					SearchResult oResult = adsSearch.FindOne();
					FormPhoneBookPage(oResult);
					FillTree();
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message;
				}
			}
		}

		protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
		{
			TextBox4.Text = TreeView1.SelectedNode.Text;
			DirectorySearcher adsSearch = Helpers.DirectorySearcher();
			TextBox2.Text = "";
			TextBox3.Text = "";
			if (TextBox4.Text != "null" && TextBox4.Text != "")
			{
				try
				{
					adsSearch.PropertiesToLoad.Add("cn");
					adsSearch.Filter = "cn=" + TextBox4.Text;
					SearchResult oResult = adsSearch.FindOne();
					if (oResult != null)
					{ 
						FormPhoneBookPage(oResult);
						FillTree();
					}
				}
				catch (Exception ex)
				{
					SiteMaster master = (SiteMaster)Page.Master;
					master.ErrorLabelText = ex.Message+"tri tacke";
				}
			}
		}

		/// <summary>
		/// Forms a phone book page for selected user
		/// </summary>
		/// <param name="oResult"></param>
		private void FormPhoneBookPage(SearchResult oResult)
		{
			ImageButton1.Visible = false;
			FileStream outFile;
			Label1.Text = Helpers.GetPropertyString(oResult, "cn");
			try
			{
				if (Helpers.GetPropertyString(oResult, "mobile") != "")
				{
					if (Helpers.GetPropertyString(oResult, "mobile").StartsWith("+381"))
					{
						Label2.Text = "(0" + Helpers.GetPropertyString(oResult, "mobile").Substring(4, 2) + ") " + Helpers.GetPropertyString(oResult, "mobile").Substring(6, 3) + " " + Helpers.GetPropertyString(oResult, "mobile").Substring(9);
					}
					else
					{
						Label2.Text = Helpers.GetPropertyString(oResult, "mobile");
					}
				}
				else
				{
					Label2.Text = "...";
				}
			}
			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
			}

			try
			{
				if (Helpers.GetPropertyString(oResult, "telephoneNumber") != "")
				{
					if (Helpers.GetPropertyString(oResult, "telephoneNumber").StartsWith("+381"))
					{
						Label3.Text = "(0" + Helpers.GetPropertyString(oResult, "telephoneNumber").Substring(4, 2) + ") " + Helpers.GetPropertyString(oResult, "telephoneNumber").Substring(6, 3) + " " + Helpers.GetPropertyString(oResult, "telephoneNumber").Substring(9);
					}
					else
					{
						Label3.Text = Helpers.GetPropertyString(oResult, "telephoneNumber");
					}
				}
				else
				{
					Label3.Text = "...";
				}
			}
			catch (Exception ex)
			{
				SiteMaster master = (SiteMaster)Page.Master;
				master.ErrorLabelText = ex.Message;
			}

			HyperLink1.Text = "Send mail";
			HyperLink1.NavigateUrl = "mailto:" + Helpers.GetPropertyString(oResult, "mail");
			HyperLink2.Text = "Chat";
			HyperLink2.NavigateUrl = "skype:" + Helpers.GetPropertyString(oResult, "extensionAttribute1") + "?chat";
			HyperLink3.Text = "Call";
			HyperLink3.NavigateUrl = "skype:" + Helpers.GetPropertyString(oResult, "extensionAttribute1") + "?call";
			if (Helpers.GetPropertyString(oResult, "extensionAttribute1") == "")
			{
				TableRowSkype.Visible = false;
			}
			else
			{
				TableRowSkype.Visible = true;
			}

			if (Helpers.GetPropertyString(oResult, "mail") == "")
			{
				TableRow71.Visible = false;
			}
			else
			{
				TableRow71.Visible = true;
			}

			Label41.Text = Helpers.GetPropertyString(oResult, "ipPhone");
			Label42.Text = Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName");
			LinkButton1.Text = Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName");
			LinkButton1.PostBackUrl = "office.aspx?office=" + Helpers.GetPropertyString(oResult, "physicalDeliveryOfficeName");
			ImageButton1.ToolTip = "Last logged on: " +Helpers.GetPropertyString(oResult, "lastLogon");
			Label5.Text = Helpers.GetPropertyString(oResult, "title");
			LinkButtondepartment.Text = Helpers.GetPropertyString(oResult, "department");
			LinkButtondepartment.PostBackUrl = "team.aspx?team=" + Server.UrlEncode(Helpers.GetPropertyString(oResult, "department"));
			name = Helpers.GetPropertyString(oResult, "manager");

			if (oResult.Path.Contains("DisabledAccounts"))
			{
				LabelNoPicture.Visible = true;
				LabelNoPicture.Text = "Disabled Account";
			}
			else
			{
				////Retrieve picture into byte array
				//String strFileName = path + Label1.Text + ".jpg";
				//byteArray = (Byte[])oResult.GetDirectoryEntry().Properties["thumbnailPhoto"].Value;
				//if (byteArray == null)
				//{
				//    LabelNoPicture.Visible = true;
				//    LabelNoPicture.Text = "No photo";
				//    if (File.Exists(strFileName))
				//    {
				//        ImageButton1.ImageUrl = "images\\" + Label1.Text + ".jpg";

				//        ImageButton1.Visible = true;
				//        LabelNoPicture.Visible = false;
				//    }
				//    Table4.Visible = true;
				//}
				//else
				//{
				//    LabelNoPicture.Visible = false;
				//    if (byteArray.Length > 10)
				//    {
				//        //   'Open file to export (delete if exists)
				//        if (File.Exists(strFileName))
				//        {
				//            File.Delete(strFileName);
				//        }
				//        outFile = new System.IO.FileStream(strFileName, FileMode.CreateNew, FileAccess.ReadWrite);
				//        // 'Loop through bytes and write to file
				//        foreach (Byte singleByte in byteArray)
				//        { outFile.WriteByte(singleByte); }

				//        ImageButton1.ImageUrl = "images\\" + Label1.Text + ".jpg";
				//        Table4.Visible = true;
				//        ImageButton1.Visible = true;
				//        outFile.Close();
				//    }

				String strFileName = path + Label1.Text + ".jpg";
				ImageButton1.PostBackUrl = "PhoneBook.aspx?account="+Label1.Text;
				        
				if (File.Exists(strFileName))
				    {
				        ImageButton1.ImageUrl = "images\\" + Label1.Text + ".jpg";
						ImageButton1.Visible = true;
				        LabelNoPicture.Visible = false;
				    }
				else
					{
						byteArray = (Byte[])oResult.GetDirectoryEntry().Properties["thumbnailPhoto"].Value;
						if (byteArray == null)
						{
							ImageButton1.ImageUrl = "noPhoto.png";
							ImageButton1.Visible = true;
							LabelNoPicture.Visible = false;
							//LabelNoPicture.Visible = true;
							//LabelNoPicture.Text = "No photo";
							//ImageButton1.Visible = false;
						}
						else 
						{
							if (byteArray.Length > 10)
							{
							
								outFile = new System.IO.FileStream(strFileName, FileMode.CreateNew, FileAccess.ReadWrite);
								// 'Loop through bytes and write to file
								foreach (Byte singleByte in byteArray)
								{ outFile.WriteByte(singleByte); }

								ImageButton1.ImageUrl = "images\\" + Label1.Text + ".jpg";
								LabelNoPicture.Visible = false;
								ImageButton1.Visible = true;
								outFile.Close();
						
							}
						}
					
					}
					Table4.Visible = true;
				}
		}
		

	}
}