/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/13/2017
 * Time: 11:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backup
{
	/// <summary>
	/// Description of ModificaFTP.
	/// </summary>
	public partial class ModificaFTP : Form
	{
		int currentIndexInFisier;
		public ModificaFTP()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			addListITems();
			dateTimePicker1.Format=DateTimePickerFormat.Time;
			dateTimePicker1.ShowUpDown=true;
			dateTimePicker1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void addListITems()
		{
			int a=0;
			List<string> MyList = new List<string>();
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		if(words[0]=="FTPIN")
    		{
    			MyList.Add(words[0]+"-"+words[1]+"-"+words[2]+"-"+a);
    		}
    		if(words[0]=="FTPOUT")
    		{
    			MyList.Add(words[0]+"-"+words[1]+"-"+words[2]+"-"+a);
    		}
    		a++;
    		}
        	listBox1.DataSource = MyList;
		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
	string text = listBox1.GetItemText(listBox1.SelectedItem);
			string[] words = text.Split('-');
			//textBox1.Text=words[0];
			textBox1.Text=words[1];
			textBox2.Text=words[2];
			currentIndexInFisier = Int32.Parse(words[3]);
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		static void lineChanger(string newText, string fileName, int line_to_edit)
{
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit] = newText;
     File.WriteAllLines(fileName, arrLine);
}
		void Button1Click(object sender, EventArgs e)
		{
	//lineChanger(TipOp+"-"+textBox1.Text+"-"+textBox2.Text,"c:\\dep\\Legaturi_externe\\FilesToCopy.txt",currentIndexInFisier);
		}
		void Button2Click(object sender, EventArgs e)
		{
UpdateSetting("CopyFTP", "");
			//lineChanger("","c:\\dep\\Legaturi_externe\\FilesToCopy.txt",currentIndexInFisier);
		}
		private static void UpdateSetting(string key, string value)
    {
        Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        configuration.AppSettings.Settings[key].Value = value;
        configuration.Save();

        ConfigurationManager.RefreshSection("appSettings");
    }
		void Button4Click(object sender, EventArgs e)
		{
			String hour = dateTimePicker1.Value.Hour.ToString();
			String minute= dateTimePicker1.Value.Minute.ToString();
			String NewTime=hour+":"+minute;
			String Time="";
		int a=0;
	foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		//Config
    		if(words[0]=="CONFIG_COPY_FTP")
    		{
    			Time=words[1];
    			break;
    		}
    		a++;
	}
	lineChanger("CONFIG_COPY_FTP"+"-"+Time+"-"+NewTime,"c:\\dep\\Legaturi_externe\\FilesToCopy.txt",a);

		}
	}
}
