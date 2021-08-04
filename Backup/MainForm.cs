/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/10/2017
 * Time: 10:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Configuration;

namespace Backup
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public int a=0;
		public static int OfficialClose=0;
		private const int CP_NOCLOSE_BUTTON = 0x200;
		public static string MySqlDump=System.Configuration.ConfigurationManager.AppSettings["MySqlDump"].ToString();
		public static string ftpUsername=System.Configuration.ConfigurationManager.AppSettings["ftpUsername"].ToString();
		public static string ftpPassword=System.Configuration.ConfigurationManager.AppSettings["ftpPassword"].ToString();
		public static string ftpAdress=System.Configuration.ConfigurationManager.AppSettings["ftpAdress"].ToString();
		public static string mySqlName=System.Configuration.ConfigurationManager.AppSettings["mySqlName"].ToString();
		public static string mySqlPassword=System.Configuration.ConfigurationManager.AppSettings["mySqlPassword"].ToString();
		public static string mySqlAdress=System.Configuration.ConfigurationManager.AppSettings["mySqlAdress"].ToString();
		public static string MysqlBackLocation=System.Configuration.ConfigurationManager.AppSettings["MysqlBackLocation"].ToString();
		public static string numeBaza=System.Configuration.ConfigurationManager.AppSettings["numeBaza"].ToString();
		public static Form MainFormForCLose;
		String lastTime="0";
		[DllImport("user32.dll", EntryPoint = "FindWindowEx")]
    	public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    	[DllImport("User32.dll")]
    	public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			MakeInterface();
			//CheckConfig();//wip
			//readConfig();
			StartTimer();
			LoadListBox();
			MainFormForCLose=this;
			//goBackground();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void MakeInterface()
		{
			MakeWaterMarks();
		}
		public void LoadListBox()
		{
			List<string> MyList = new List<string>();
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		if(words[0]=="COPY")
    		{
    			MyList.Add(words[1]+"--->>>"+words[2]);
    		}
    		if(words[0]=="FTPIN")
    		{
    			MyList.Add(words[0]+"-"+words[1]+"---->>>"+words[2]);
    		}
    		if(words[0]=="FTPOUT")
    		{
    			MyList.Add(words[0]+"-"+words[1]+"---->>>"+words[2]);
    		}
    		if(words[0]=="BACKUP")
    		{
    			MyList.Add(words[1]+"---->>>"+words[2]);
    		}
    		}
        	listBox1.DataSource = MyList;
		}
		public void goBackground()
		{
			
			this.WindowState=FormWindowState.Minimized;
			this.Hide();
     	//this.Visible = false;
		//this.Opacity = 0;
		//this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		//this.ShowInTaskbar = false;
		}
		protected override CreateParams CreateParams
{
    get
    {
       CreateParams myCp = base.CreateParams;
       myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON ;
       return myCp;
    }
}
		public void StartTimer()
		{
			System.Timers.Timer aTimer = new System.Timers.Timer();
    		aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
    		aTimer.Interval=20000;
    		aTimer.Enabled=true;

    		//Console.WriteLine("Press \'q\' to quit the sample.");
    		//while(Console.Read()!='q');
		}
		public void StartProcces()//WIP
		{
			//new Code
			//get backup time
			String TimeBackupMysql=System.Configuration.ConfigurationManager.AppSettings["TimpBackup"].ToString();
			String TimeCopyFiles=System.Configuration.ConfigurationManager.AppSettings["TimpCopy"].ToString();
			String TimeCopyFTP=System.Configuration.ConfigurationManager.AppSettings["TimpCopy"].ToString();
			//get current time
			var date = DateTime.Now;
    		String hour=date.Hour.ToString();
    		String Minute = date.Minute.ToString();
    		//CompareTime
    		if(TimeBackupMysql==(hour+":"+Minute))
    		{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						//DoBackup
    						Backup();
    					}
    		}
    		if(TimeCopyFiles==(hour+":"+Minute))
    		{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						//DoBackup
    						Copy();
    					}
    		}
    		if(TimeCopyFTP==(hour+":"+Minute))
    		{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						//DoBackup
    						FTP();
    					}
    		}
			//old code
			/*String time;
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
       		 	{
				string[] words = line.Split('-');
				if(words[0]=="BACKUP")
    			{
    				time=words[2];
    			
    				//MessageBox.Show(hour+":"+Minute);
    				if("10:30"==(hour+":"+Minute))
    				{
    					a=0;
    				}
    				if(time==(hour+":"+Minute))
    					{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						lastTime=hour+":"+Minute;
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Pornit Backup-"+lastTime});
    						Backup();
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Terminat functie backup-"+lastTime});
    						//Copy();
    						//Rest
    					}
    					}
    			}
				if(words[0]=="CONFIG_COPY_FTP")
				{
					String timeCopy=words[1];
    				String timeFTP=words[2];
    				
    				if(timeCopy==hour+":"+Minute)
    				{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						lastTime=hour+":"+Minute;
    						//Backup();
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Pronit functie copiere-"+lastTime});
    						Copy();
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Terminat functia copiere-"+lastTime});
    						//Rest
    					}
    				}
    				if(timeFTP==hour+":"+Minute)
    				{
    					if(lastTime==(hour+":"+Minute))
    					{
    						
    					}else
    					{
    						lastTime=hour+":"+Minute;
    						//Backup();
    						//Copy();
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Pornit FTP-"+lastTime});
    						FTP();
    						File.AppendAllLines(
   	@"c:\dep\Legaturi_externe\BackupLog.txt", 
    new string[] { "Terminat Functia FTP-"+lastTime});
    					}
    				
				}
				}
			}*/
		}
		// Specify what you want to happen when the Elapsed event is raised.
 private void OnTimedEvent(object source, ElapsedEventArgs e)
 {
 	StartProcces();
 	if(a==0)
 	{
 		Copy();
 	}
 }
 		public void CheckLog()
 		{
 			if (File.Exists(@"c:\dep\Legaturi_externe\BackupLog.txt"))
        {
            //exista
        }else
        {
        	if(!Directory.Exists(@"c:\dep"))
			{
  			  Directory.CreateDirectory(@"c:\dep");
			}
			if(!Directory.Exists(@"c:\dep\Legaturi_externe"))
			{
  			  Directory.CreateDirectory(@"c:\dep\Legaturi_externe");
			}
using(var tw = new StreamWriter(@"c:\dep\Legaturi_externe\BackupLog.txt", true))
    {
    }			
        }	
 		}
		public void CheckConfig()
		{
        // See if this file exists in the C:\ directory. [Note the @]
        if (File.Exists(@"c:\dep\Legaturi_externe\FilesToCopy.txt"))
        {
            //exista
        }else
        {
        	if(!Directory.Exists(@"c:\dep"))
			{
  			  Directory.CreateDirectory(@"c:\dep");
			}
			if(!Directory.Exists(@"c:\dep\Legaturi_externe"))
			{
  			  Directory.CreateDirectory(@"c:\dep\Legaturi_externe");
			}
using(var tw = new StreamWriter(@"c:\dep\Legaturi_externe\FilesToCopy.txt", true))
    {
        tw.WriteLine("CONFIGFTP-FTPNume-FTPPAssword-FTPIP");
        tw.WriteLine("CONFIGMYSQL-mySQLName-mysqlPArola-mySQLAdrres----");
        tw.WriteLine("CONFIG_COPY_FTP-10:20-10:30");
        tw.Close();
    }			
        }
		}//wip
		public void FTP()
		{
			//new Code
			String CopyBuffer=System.Configuration.ConfigurationManager.AppSettings["CopyFTP"].ToString();
			string[] words = CopyBuffer.Split(';');
			foreach(String word in words)
			{
				//arhivare
				string[] copy2thPath = word.Split(':');
				if(copy2thPath[0]=="FTPIN")
    			{
    				DownloadFile(copy2thPath[1],copy2thPath[2]);
    			}
				if(copy2thPath[0]=="FTPOUT")
    			{
    				UploadFile(copy2thPath[2],copy2thPath[1]);
    			}
			}
			//old code
			/*
			foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
       		 	{
				//string[] words = line.Split('-');
				//ConfigFTP
				if(words[0]=="FTPIN")
    		{
    			DownloadFile(words[1],words[2]);
    		}
    		//Upload
    		if(words[0]=="FTPOUT")
    		{
    			UploadFile(words[2],words[1]);
    		}
			}*/
		}
		public static void SaveACopyfileToServer(string filePath, string savePath)
    	{
        var directory = Path.GetDirectoryName(savePath).Trim();
        var username = "admin";
        var password = "Qwert1234";
        var filenameToSave = Path.GetFileName(savePath);

        if (!directory.EndsWith("\\"))
            filenameToSave = "\\" + filenameToSave;

        var command = "NET USE " + directory + " /delete";
        ExecuteCommand(command, 5000);

        command = "NET USE " + directory + " /user:" + username + " " + password;
        ExecuteCommand(command, 5000);

        command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";

        ExecuteCommand(command, 5000);


        command = "NET USE " + directory + " /delete";
        ExecuteCommand(command, 5000);
    	}
		public static int ExecuteCommand(string command, int timeout)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
                              {
                                  CreateNoWindow = true, 
                                  UseShellExecute = false, 
                                  WorkingDirectory = "C:\\",
                              };

        var process = Process.Start(processInfo);
        process.WaitForExit(timeout);
        var exitCode = process.ExitCode;
        process.Close();
        return exitCode;
    } 
		public void Copy()
		{
			//new Code
			//String Array
			try{
			String CopyBuffer=System.Configuration.ConfigurationManager.AppSettings["CopyFiles"].ToString();
			string[] words = CopyBuffer.Split(';');
			foreach(String word in words)
			{
				//arhivare
				string[] copy2thPath = word.Split('-');
				string Target=copy2thPath[0]+"arhive.zip";
				compress(copy2thPath[0],Target);
				//datetime clean
				DateTime now = DateTime.Now;
				string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
    			String dataToday=now.ToString();
    			foreach (char c in invalid)
				{
    				dataToday = dataToday.Replace(c.ToString(), ""); 
				}
				//copiere
				String copy=copy2thPath[1]+"\\arhive_"+dataToday+".zip";
				SaveACopyfileToServer(Target, copy);
				//stergere
    				if (File.Exists(Target)){
    				File.Delete(Target);
    				}
			}
			}catch(Exception e)
			{
				
			}
			//old code
			/*foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
       		 	{
				//string[] words = line.Split('-');
				//ConfigFTP
				string drive = Path.GetPathRoot(words[1]);
				// e.g. K:\
				if (!Directory.Exists(drive))
				{
     				return;
				}else{
				if(words[0]=="COPY")
				{
					a=1;
					String Target=words[1]+".zip";
					compress(words[1],Target);
					DateTime now = DateTime.Now;
    				string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

    				

    String dataToday=now.ToString();
    foreach (char c in invalid)
{
    dataToday = dataToday.Replace(c.ToString(), ""); 
}
    				File.Copy(Target, words[2]+"-"+dataToday+".zip");
    				if (File.Exists(Target)){
    				File.Delete(Target);
    				}
				}
				}
			}
			*/
		}
		public void readConfig()
		{
			
    				ftpUsername=System.Configuration.ConfigurationManager.AppSettings["ftpUsername"].ToString();
    				ftpPassword=System.Configuration.ConfigurationManager.AppSettings["ftpPassword"].ToString();
    				ftpAdress=System.Configuration.ConfigurationManager.AppSettings["ftpAdress"].ToString();
    				textBox4.Text=System.Configuration.ConfigurationManager.AppSettings["ftpUsername"].ToString();
    				textBox5.Text=System.Configuration.ConfigurationManager.AppSettings["ftpPassword"].ToString();
    				textBox6.Text=System.Configuration.ConfigurationManager.AppSettings["ftpAdress"].ToString();
    				mySqlName=System.Configuration.ConfigurationManager.AppSettings["mySqlName"].ToString();
    				mySqlPassword=System.Configuration.ConfigurationManager.AppSettings["mySqlPassword"].ToString();
    				mySqlAdress=System.Configuration.ConfigurationManager.AppSettings["mySqlAdress"].ToString();
    				numeBaza=System.Configuration.ConfigurationManager.AppSettings["numeBaza"].ToString();
    				MySqlDump=System.Configuration.ConfigurationManager.AppSettings["MySqlDump"].ToString();
    				MysqlBackLocation=System.Configuration.ConfigurationManager.AppSettings["MysqlBackLocation"].ToString();
    				textBox1.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlName"].ToString();
    				textBox2.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlPassword"].ToString();
    				textBox3.Text=System.Configuration.ConfigurationManager.AppSettings["mySqlAdress"].ToString();
		}
		public void MakeWaterMarks()
		{
			textBox4.ForeColor = SystemColors.GrayText;
			textBox5.ForeColor = SystemColors.GrayText;
			textBox6.ForeColor = SystemColors.GrayText;
			textBox1.ForeColor = SystemColors.GrayText;
			textBox2.ForeColor = SystemColors.GrayText;
			textBox3.ForeColor = SystemColors.GrayText;
			textBox7.ForeColor = SystemColors.GrayText;
		}
		 public void compress(string sourceName, string targetName)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            //first change
            p.FileName = "7z.exe";
            //second change
            p.Arguments = "a -tzip \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);
            x.WaitForExit();
            Thread.Sleep(1000);
        }
		public void UploadFile(String FisierDeUploadat,String NameFiles)
		{
			String Target=FisierDeUploadat+".zip";
			compress(FisierDeUploadat,Target);
			using (WebClient client = new WebClient())
			{
    			client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
    			String namesTarked=Path.GetFileName(Target);
    			client.UploadFile("ftp://"+ftpAdress+"/"+namesTarked, "STOR", Target);
    			client.Dispose();
			}
			if (File.Exists(Target)){
			File.Delete(Target);
			}
		}
		public void DownloadFile(string url, string savePath)
		{
   			 var client = new WebClient();
   			 client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
   			 client.DownloadFile(url, savePath);
		}
		void Button6Click(object sender, EventArgs e)
		{
		AdaugaCopiere CopyAdd = new AdaugaCopiere();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void TextBox4Enter(object sender, EventArgs e)
		{
			if (textBox4.Text == "Username")
        {
            textBox4.Text = "";
            textBox4.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox4Leave(object sender, EventArgs e)
		{
	 if (textBox4.Text.Length == 0)
        {
            textBox4.Text = "Username";
            textBox4.ForeColor = SystemColors.GrayText;
        }
		}
		void TextBox5Enter(object sender, EventArgs e)
		{
	if (textBox5.Text == "Password")
        {
            textBox5.Text = "";
            textBox5.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox5Leave(object sender, EventArgs e)
		{
	 if (textBox5.Text.Length == 0)
        {
            textBox5.Text = "Password";
            textBox5.ForeColor = SystemColors.GrayText;
        }
		}
		void TextBox6Enter(object sender, EventArgs e)
		{
		if (textBox6.Text == "Ip Server")
        {
            textBox6.Text = "";
            textBox6.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox6Leave(object sender, EventArgs e)
		{
	 if (textBox6.Text.Length == 0)
        {
            textBox6.Text = "Ip Server";
            textBox6.ForeColor = SystemColors.GrayText;
        }
		}
		void TextBox1Enter(object sender, EventArgs e)
		{
	if (textBox1.Text == "Username")
        {
            textBox1.Text = "";
            textBox1.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox1Leave(object sender, EventArgs e)
		{
	 if (textBox1.Text.Length == 0)
        {
            textBox1.Text = "Username";
            textBox1.ForeColor = SystemColors.GrayText;
        }
		}
		void TextBox2Enter(object sender, EventArgs e)
		{
	if (textBox2.Text == "Password")
        {
            textBox2.Text = "";
            textBox2.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox2Leave(object sender, EventArgs e)
		{
	 if (textBox2.Text.Length == 0)
        {
            textBox2.Text = "Password";
            textBox2.ForeColor = SystemColors.GrayText;
        }
		}
		void TextBox3Enter(object sender, EventArgs e)
		{
		if (textBox3.Text == "Ip Server")
        {
            textBox3.Text = "";
            textBox3.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox3Leave(object sender, EventArgs e)
		{
	 if (textBox3.Text.Length == 0)
        {
            textBox3.Text = "Ip Server";
            textBox3.ForeColor = SystemColors.GrayText;
        }
		}
		//update
		void Button2Click(object sender, EventArgs e)
		{
			int a=0;
	foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		//Config
    		if(words[0]=="CONFIGFTP")
    		{
    			break;
    		}
    		a++;
	}
	
	lineChanger("CONFIGFTP-"+textBox4.Text+"-"+textBox5.Text+"-"+textBox6.Text,"c:\\dep\\Legaturi_externe\\FilesToCopy.txt",a);
		}
		//schimba linile
		static void lineChanger(string newText, string fileName, int line_to_edit)
{
     string[] arrLine = File.ReadAllLines(fileName);
     arrLine[line_to_edit] = newText;
     File.WriteAllLines(fileName, arrLine);
}
		void Button1Click(object sender, EventArgs e)
		{
	int a=0;
	foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
        	{
    		string[] words = line.Split('-');
    		//Config
    		if(words[0]=="CONFIGMYSQL")
    		{
    			break;
    		}
    		a++;
	}
	lineChanger("CONFIGMYSQL-"+textBox1.Text+"-"+textBox2.Text+"-"+textBox3.Text+"-"+textBox7.Text+"-"+MySqlDump+"-"+MysqlBackLocation,"c:\\dep\\Legaturi_externe\\FilesToCopy.txt",a);

		}
		void Button8Click(object sender, EventArgs e)
		{
		ModificaCopiere CopyAdd = new ModificaCopiere();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		public void Backup()
		{
			String mysqlLocation=MySqlDump;
			String username=mySqlName;
			String password=mySqlPassword;
			String Locatie=MysqlBackLocation;
			String Baza=numeBaza;
    var date = DateTime.Now;
    //delete
    string path = Path.Combine(Application.StartupPath, "test.bat");
if (File.Exists(path))
{
    File.Delete(path);
    using (StreamWriter w = new StreamWriter(path))
    {
        w.WriteLine(mysqlLocation+" -u "+username+" -p"+password+" -h "+mySqlAdress+" "+Baza+" >"+Locatie+@"\"+Baza+".sql");
        
        w.Close();
    }
}else{
 using (StreamWriter w = new StreamWriter(path))
    {
       w.WriteLine(mysqlLocation+" -u "+username+" -p"+password+" -h "+mySqlAdress+" "+Baza+" >"+Locatie+@"\"+Baza+".sql");
        
        w.Close();
    }
}
    var process =System.Diagnostics.Process.Start(path);
	process.WaitForExit();
    DateTime now = DateTime.Now;
string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());


    String dataToday=now.ToString();
    foreach (char c in invalid)
{
    dataToday = dataToday.Replace(c.ToString(), ""); 
}
    compress(Locatie+Baza+".sql",Locatie+Baza+".sql.zip");
    if (File.Exists(Locatie+Baza+".sql")){
     File.Delete(Locatie+Baza+".sql");
    }
		}
		void TextBox7Enter(object sender, EventArgs e)
		{
	if (textBox3.Text == "Baza")
        {
            textBox3.Text = "";
            textBox3.ForeColor = SystemColors.WindowText;
        }
		}
		void TextBox7Leave(object sender, EventArgs e)
		{
	 if (textBox3.Text.Length == 0)
        {
            textBox3.Text = "Baza";
            textBox3.ForeColor = SystemColors.GrayText;
        }
		}
		void Button7Click(object sender, EventArgs e)
		{
	 DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            	MySqlDump=openFileDialog1.FileName;
            }
		}
		void Button9Click(object sender, EventArgs e)
		{
		//schimba locatie
		using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
	dlg.SelectedPath = textBox2.Text;
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	MysqlBackLocation=dlg.SelectedPath;
    }
}
		}
		void Button3Click(object sender, EventArgs e)
		{
	
		AdaugaMYSQL CopyAdd = new AdaugaMYSQL();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button5Click(object sender, EventArgs e)
		{
	
		ModificaMYSQL CopyAdd = new ModificaMYSQL();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button4Click(object sender, EventArgs e)
		{
	AdaugaFTP CopyAdd = new AdaugaFTP();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button10Click(object sender, EventArgs e)
		{
ModificaFTP CopyAdd = new ModificaFTP();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button11Click(object sender, EventArgs e)
		{
			Backup();
		}
		void Button12Click(object sender, EventArgs e)
		{
			Copy();
		}
		void NotifyIcon1DoubleClick(object sender, EventArgs e)
		{
this.Visible = true;
this.Opacity = 100;
this.FormBorderStyle = FormBorderStyle.FixedSingle; //or whatever it was previously set to
this.ShowInTaskbar = true;
	this.Show();
     this.WindowState = FormWindowState.Normal;
		}
		void MainFormResize(object sender, EventArgs e)
		{
	 if (FormWindowState.Minimized == this.WindowState)
     {
          notifyIcon1.Visible = true;
          notifyIcon1.ShowBalloonTip(50000);
          this.Hide();    
     }
     else if (FormWindowState.Normal == this.WindowState)
     {
          notifyIcon1.Visible = false;
     }
		}
		void Button13Click(object sender, EventArgs e)
		{
	using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "Select a folder";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
    	
    	compress(dlg.SelectedPath,dlg.SelectedPath+".zip");
    }
}
		}
		void Button14Click(object sender, EventArgs e)
		{
	foreach (string line in File.ReadLines("c:\\dep\\Legaturi_externe\\FilesToCopy.txt"))
       		 	{
				string[] words = line.Split('-');
				//ConfigFTP
				if(words[0]=="COPY")
				{
string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());


					String Target=words[1]+".zip";
					compress(words[1],Target);
					DateTime now = DateTime.Now;
    				String dataToday=now.ToString();
    				foreach (char c in invalid)
{
    dataToday = dataToday.Replace(c.ToString(), ""); 
}
    				File.Copy(Target, words[2]+"-"+dataToday+".zip");
    				if (File.Exists(Target)){
    				File.Delete(Target);
    				}
				}
			}
		}
		void Button15Click(object sender, EventArgs e)
		{
	RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Backup BIF1", Application.ExecutablePath.ToString());
	}
		void Button16Click(object sender, EventArgs e)
		{
	RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
	rk.DeleteValue("Backup BIF1");
		}
		void Button17Click(object sender, EventArgs e)
		{
			FTP();
		}
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(OfficialClose==0)
			{//Aplication Restarts
				MessageBox.Show("Aplicatia Intra inapoi in Background",
    "Important Message");
				Application.Restart();
			}else
			{
				MessageBox.Show("Aplicatia se Inchide completa, Nu se vor face backup",
    "Important Message");
			}
		}
		void Button18Click(object sender, EventArgs e)
		{
			OfficialClose=1;
			this.Close();
		}
		void Button19Click(object sender, EventArgs e)
		{
		AdaugaForm CopyAdd = new AdaugaForm();
        CopyAdd.ShowDialog(); // adauga button
		}
		void Button20Click(object sender, EventArgs e)
		{
		EditForm CopyAdd = new EditForm();
        CopyAdd.ShowDialog(); // adauga button
		}
		void Button21Click(object sender, EventArgs e)
		{
		ConfigForm CopyAdd = new ConfigForm();
        CopyAdd.ShowDialog(); // adauga button
		}
		void Button22Click(object sender, EventArgs e)
		{
			this.WindowState=FormWindowState.Minimized;
			//this.Visible = false;
			//this.Opacity = 0;
			//this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			//this.ShowInTaskbar = false;
		}
		void Button23Click(object sender, EventArgs e)
		{
			StartProcces();
		}
	}
}
