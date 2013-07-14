using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestLab
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            this.Text = Application.ProductName + " " + Application.ProductVersion.Substring(0, 5);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 104);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 145);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(280, 127);
            this.textBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hecele";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 21);
            this.button2.TabIndex = 3;
            this.button2.Text = "Çevir";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Biztam",
            "Emmi",
            "Haxor",
            "Küfürbaz",
            "Kuþdili",
            "Laz",
            "Mors",
            "Peltek",
            "Pisi",
            "Sms",
            "Tiki"});
            this.comboBox1.Location = new System.Drawing.Point(78, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Dialector.Turkish t = new Dialector.Turkish();
			ArrayList al = new ArrayList();

			al = t.getTextSyllabus(textBox1.Text);

			textBox2.Clear();
			for (int n = 0; n < al.Count; n++)
			{
				textBox2.Text += al[n].ToString() + "-";
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            Dialector.Dialect d = null;

            switch (comboBox1.Items[comboBox1.SelectedIndex].ToString())
            {
                case "Biztam": d = new Dialector.Biztam(); break;
                case "Emmi": d = new Dialector.Emmi(); break;
                case "Haxor": d = new Dialector.Haxor(); break;
                case "Küfürbaz": d = new Dialector.Kufurbaz(); break;
                case "Kuþdili": d = new Dialector.Kus(); break;
                case "Laz": d = new Dialector.Laz(); break;
                case "Mors": d = new Dialector.Mors(); break;
                case "Peltek": d = new Dialector.Peltek(); break;
                case "Pisi": d = new Dialector.Pisi(); break;
                case "Sms": d = new Dialector.Sms(); break;
                case "Tiki": d = new Dialector.Tiki(); break;
            }
            if (d == null) return;
			textBox2.Text = d.getDialect(textBox1.Text);
		}
	}
}
