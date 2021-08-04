/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/22/2017
 * Time: 11:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Backup
{
	/// <summary>
	/// Description of ConfigForm.
	/// </summary>
	public partial class ConfigForm : Form
	{
		public ConfigForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			readConfig();
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label6.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label7.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label8.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label9.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label10.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox6.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox7.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button6.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button7.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
	 DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            	UpdateSetting("MySqlDump", openFileDialog1.FileName);
            	//System.Configuration.ConfigurationManager.AppSettings["MySqlDump"]=openFileDialog1.FileName;
            }
		}
		void Button2Click(object sender, EventArgs e)
		{
	//schimba locatie
		using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	UpdateSetting("MysqlBackLocation", dlg.SelectedPath);
    }
		}
	}
		static void lineChanger(string newText, string fileName, int line_to_edit)
{
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit] = newText;
     File.WriteAllLines(fileName, arrLine);
}
		void Button3Click(object sender, EventArgs e)
		{
			//app config configuration
			UpdateSetting("mySqlName", textBox1.Text);
			UpdateSetting("mySqlPassword", textBox2.Text);
			UpdateSetting("mySqlAdress", textBox3.Text);
			UpdateSetting("numeBaza", textBox7.Text);
			//app config non cofiguration
	
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		public void readConfig()
		{
			textBox1.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlName"].ToString();
			textBox2.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlPassword"].ToString();
			textBox3.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlAdress"].ToString();
			textBox7.Text=System.Configuration.ConfigurationManager.AppSettings["numeBaza"].ToString();
			textBox4.Text=System.Configuration.ConfigurationManager.AppSettings["ftpUsername"].ToString();
			textBox5.Text=System.Configuration.ConfigurationManager.AppSettings["ftpPassword"].ToString();
			textBox6.Text=System.Configuration.ConfigurationManager.AppSettings["ftpAdress"].ToString();
		}
		void Button4Click(object sender, EventArgs e)
		{
			System.Configuration.ConfigurationManager.AppSettings["ftpUsername"]=textBox4.Text.ToString();
			System.Configuration.ConfigurationManager.AppSettings["ftpPassword"]=textBox5.Text.ToString();
			System.Configuration.ConfigurationManager.AppSettings["ftpAdress"]=textBox6.Text.ToString();
		}
		void Button5Click(object sender, EventArgs e)
		{
	
	RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Backup BIF1", Application.ExecutablePath.ToString());
		}
		void Button6Click(object sender, EventArgs e)
		{
	RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
	rk.DeleteValue("Backup BIF1");
		}
		void Button7Click(object sender, EventArgs e)
		{
			MainForm.OfficialClose=1;
			this.Close();
			MainForm.MainFormForCLose.Close();
		}
	}
}
