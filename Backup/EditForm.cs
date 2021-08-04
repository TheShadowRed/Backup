/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/22/2017
 * Time: 11:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Backup
{
	/// <summary>
	/// Description of EditForm.
	/// </summary>
	public partial class EditForm : Form
	{
		public EditForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void EditFormLoad(object sender, EventArgs e)
		{
	
		}
		void Button4Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			ModificaMYSQL CopyAdd = new ModificaMYSQL();
       		CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button2Click(object sender, EventArgs e)
		{
			ModificaCopiere CopyAdd = new ModificaCopiere();
			CopyAdd.Enabled=true;
        	CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button3Click(object sender, EventArgs e)
		{
			ModificaFTP CopyAdd = new ModificaFTP();
        	CopyAdd.ShowDialog(); // Shows copy add
		}
	}
}
