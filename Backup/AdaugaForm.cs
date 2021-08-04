/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/22/2017
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Backup
{
	/// <summary>
	/// Description of AdaugaForm.
	/// </summary>
	public partial class AdaugaForm : Form
	{
		public AdaugaForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void AdaugaFormLoad(object sender, EventArgs e)
		{
			
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
		AdaugaFTP CopyAdd = new AdaugaFTP();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button1Click(object sender, EventArgs e)
		{
		AdaugaCopiere CopyAdd = new AdaugaCopiere();
        CopyAdd.ShowDialog(); // Shows copy add
		}
		void Button19Click(object sender, EventArgs e)
		{
		AdaugaMYSQL CopyAdd = new AdaugaMYSQL();
        CopyAdd.ShowDialog(); // Shows copy add
		}
	}
}
