/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/13/2017
 * Time: 11:12
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
	/// Description of AdaugaFTP.
	/// </summary>
	public partial class AdaugaFTP : Form
	{
		String CurrentOperation="FTPIN";
		String SavePath;
		public AdaugaFTP()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button4Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(CurrentOperation=="FTPIN")
			{
				using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	SavePath=dlg.SelectedPath;
    }
			}
			}else
			{
				DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            	SavePath=openFileDialog1.FileName;
            }
			}
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			if(CurrentOperation=="FTPIN")
			{
				MessageBox.Show("FTPOUT - Uploadez");
				CurrentOperation="FTPOUT";
				button1.Text="de unde Uploadez";
				label1.Text="unde Uploadez";
			}else
			{
				MessageBox.Show("FTPIN - Downloadez");
				CurrentOperation="FTPIN";
				button1.Text="unde downloadez";
				label1.Text="de unde downloadez";
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			

UpdateSetting("CopyFTP", CurrentOperation+":"+textBox1.Text+":"+SavePath+";");
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		void Panel3Paint(object sender, PaintEventArgs e)
		{
	
		}
	}
}
