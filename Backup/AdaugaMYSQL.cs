/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/13/2017
 * Time: 10:31
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
	/// Description of AdaugaMYSQL.
	/// </summary>
	public partial class AdaugaMYSQL : Form
	{
		String Time;
		String NumeBaza;
		public AdaugaMYSQL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			dateTimePicker1.Format=DateTimePickerFormat.Time;
			dateTimePicker1.ShowUpDown=true;
			dateTimePicker1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			String hour = dateTimePicker1.Value.Hour.ToString();
			String minute= dateTimePicker1.Value.Minute.ToString();
			Time=hour+":"+minute;
			NumeBaza=textBox1.Text;
			UpdateSetting("TimpBackup", Time);
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		void Button1Click(object sender, EventArgs e)
		{
	
		}
		void DateTimePicker1ValueChanged(object sender, EventArgs e)
		{
	
		}
		void AdaugaMYSQLResize(object sender, EventArgs e)
		{
	
		}
	}
}
