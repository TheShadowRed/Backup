/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/13/2017
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backup
{
	/// <summary>
	/// Description of ModificaMYSQL.
	/// </summary>
	public partial class ModificaMYSQL : Form
	{
		int currentIndexInFisier;
		public ModificaMYSQL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//dateTimePicker1.Format=DateTimePickerFormat.Time;
			//dateTimePicker1.ShowUpDown=true;
			listAllItems();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void listAllItems()
		{
			int a=0;
			List<string> MyList = new List<string>();
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		if(words[0]=="BACKUP")
    		{
    			MyList.Add(words[1]+"-"+words[2]+"-"+a);
    		}
    		a++;
    		}
        	listBox1.DataSource = MyList;
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		static void lineChanger(string newText, string fileName, int line_to_edit)
{
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit] = newText;
     File.WriteAllLines(fileName, arrLine);
}
		void Button2Click(object sender, EventArgs e)
		{
			UpdateSetting("TimpBackup", "");
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = listBox1.GetItemText(listBox1.SelectedItem);
			string[] words = text.Split('-');
			currentIndexInFisier = Int32.Parse(words[2]);
		}
		void Panel1Paint(object sender, PaintEventArgs e)
		{
	
		}
	}
}
