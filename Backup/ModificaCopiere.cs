/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/10/2017
 * Time: 12:08
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
	/// Description of ModificaCopiere.
	/// </summary>
	public partial class ModificaCopiere : Form
	{
		String deUndeCopiez;
		String UndeCopiez;
		int currentIndexInFisier;
		public ModificaCopiere()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			ListADdITems();
			dateTimePicker1.Format=DateTimePickerFormat.Time;
			dateTimePicker1.ShowUpDown=true;
			dateTimePicker1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void ListADdITems()
		{
			int a=0;
			List<string> MyList = new List<string>();
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		if(words[0]=="COPY")
    		{
    			MyList.Add(words[1]+"-"+words[2]+"-"+a);
    		}
    		a++;
    		}
        	listBox1.DataSource = MyList;
		}
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = listBox1.GetItemText(listBox1.SelectedItem);
			string[] words = text.Split('-');
			textBox1.Text=words[0];
			deUndeCopiez=words[0];
			textBox2.Text=words[1];
			UndeCopiez=words[1];
			currentIndexInFisier = Int32.Parse(words[2]);
		}
		void Button5Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			//modifica locatie fisier
			DialogResult result = openFileDialog1.ShowDialog();
			string path=textBox1.Text; // this is the path that you are checking.
if(Directory.Exists(path)) {
    openFileDialog1.InitialDirectory = path;
} else {
    openFileDialog1.InitialDirectory = @"C:\";
} 
			 
            if (result == DialogResult.OK) // Test result.
            {
            	deUndeCopiez=openFileDialog1.FileName;
            	textBox1.Text=deUndeCopiez;
            }
		}
		void Button3Click(object sender, EventArgs e)
		{
			//schimba locatie
		using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
	dlg.SelectedPath = textBox2.Text;
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
			String fileName = Path.GetFileName (deUndeCopiez);
	lineChanger("COPY-"+textBox1.Text+"-"+textBox2.Text+@"\"+fileName,"c:\\dep\\Legaturi_externe\\FilesToCopy.txt",currentIndexInFisier);
		}
		static void lineChanger(string newText, string fileName, int line_to_edit)
{
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit] = newText;
     File.WriteAllLines(fileName, arrLine);
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
			//clear copy
			UpdateSetting("CopyFiles", "");
			//lineChanger("","c:\\dep\\Legaturi_externe\\FilesToCopy.txt",currentIndexInFisier);
		}
		void Button6Click(object sender, EventArgs e)
		{
	String hour = dateTimePicker1.Value.Hour.ToString();
	String minute= dateTimePicker1.Value.Minute.ToString();
	String NewTime=hour+":"+minute;
	UpdateSetting("TimpCopy", NewTime);
		}
	}
}
