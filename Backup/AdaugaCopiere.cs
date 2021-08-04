/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/10/2017
 * Time: 11:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backup
{
	/// <summary>
	/// Description of AdaugaCopiere.
	/// </summary>
	public partial class AdaugaCopiere : Form
	{
		String DeUndeCopiez;
		String UndeCopiez;
		public AdaugaCopiere()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	DeUndeCopiez=dlg.SelectedPath;
         textBox1.Text=DeUndeCopiez;
    }
}
		}
		void Button2Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	UndeCopiez=dlg.SelectedPath;
         textBox2.Text=UndeCopiez;
    }
}
		}
		void Button4Click(object sender, EventArgs e)
		{
			String original=System.Configuration.ConfigurationManager.AppSettings["CopyFiles"].ToString();
			UpdateSetting("CopyFiles", original+DeUndeCopiez+"-"+UndeCopiez+";");
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		void Label1Click(object sender, EventArgs e)
		{
	
		}
	}
}
