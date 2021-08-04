/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 2/10/2017
 * Time: 12:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Backup
{
	partial class ModificaCopiere
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificaCopiere));
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button6 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 5);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(651, 407);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.Location = new System.Drawing.Point(117, 213);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(117, 105);
			this.button1.TabIndex = 1;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(3, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 87);
			this.button2.TabIndex = 2;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(3, 47);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(238, 20);
			this.textBox1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(238, 21);
			this.label1.TabIndex = 4;
			this.label1.Text = "Fisier ce al copiez";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// button3
			// 
			this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(2, 102);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(84, 87);
			this.button3.TabIndex = 5;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// textBox2
			// 
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(3, 47);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(238, 20);
			this.textBox2.TabIndex = 6;
			// 
			// button4
			// 
			this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
			this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button4.Enabled = false;
			this.button4.Location = new System.Drawing.Point(3, 213);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(108, 105);
			this.button4.TabIndex = 7;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button5
			// 
			this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
			this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button5.Enabled = false;
			this.button5.Location = new System.Drawing.Point(240, 213);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(114, 105);
			this.button5.TabIndex = 8;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(3, 36);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(247, 20);
			this.dateTimePicker1.TabIndex = 9;
			// 
			// button6
			// 
			this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
			this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button6.Location = new System.Drawing.Point(264, 0);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(90, 77);
			this.button6.TabIndex = 10;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel7);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1024, 422);
			this.panel1.TabIndex = 11;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.button6);
			this.panel7.Location = new System.Drawing.Point(660, 336);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(359, 81);
			this.panel7.TabIndex = 12;
			// 
			// panel8
			// 
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.dateTimePicker1);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(255, 73);
			this.panel8.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(247, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "Timpul la Care Muta Fisierele";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new System.Drawing.Point(660, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(359, 327);
			this.panel2.TabIndex = 11;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(351, 204);
			this.panel3.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.label2);
			this.panel6.Controls.Add(this.textBox2);
			this.panel6.Location = new System.Drawing.Point(100, 108);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(246, 91);
			this.panel6.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(238, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "Unde Copiez";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.textBox1);
			this.panel5.Location = new System.Drawing.Point(100, 5);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(246, 91);
			this.panel5.TabIndex = 12;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Location = new System.Drawing.Point(3, 5);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(91, 194);
			this.panel4.TabIndex = 0;
			// 
			// ModificaCopiere
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1048, 446);
			this.Controls.Add(this.panel1);
			this.Enabled = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ModificaCopiere";
			this.Text = "ModificaCopiere";
			this.panel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
