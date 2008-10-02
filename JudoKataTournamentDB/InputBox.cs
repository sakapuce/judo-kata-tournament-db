using System;
using System.Windows.Forms;

namespace JudoKataTournamentDB
{
	/// <summary>
	/// Summary description for InputBox.
	/// </summary>
	public class InputBox : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public delegate bool ValidatorDelegate(string input);
		private readonly ValidatorDelegate _validator;
		
		private string _prompt;
		private string _title;
		private Label label1;
		private Panel panel1;
		private Label labelPrompt;
		private Splitter splitter1;
		private Panel panel2;
		private Splitter splitter2;
		private Panel panel3;
		private TextBox txtInput;
		private Button btnOk;
		private Button btnCancel;

		public static string Show(string prompt, string title)
		{
			using(InputBox frm = new InputBox(prompt, title))
			{
					if(frm.ShowDialog()==DialogResult.OK)
					{
						return frm.InputValue;
					}
					return "";
			}
		}

		public static string Show(string prompt, string title, ValidatorDelegate validator)
		{
			using(InputBox frm = new InputBox(prompt, title,validator))
			{
				if(frm.ShowDialog()==DialogResult.OK)
				{
					return frm.InputValue;
				}
				return "";
			}
		}

		public InputBox(string prompt, string title)
		{
			InitializeComponent();
			Prompt = prompt;
			Title = title;
		}

		public InputBox(string prompt, string title, string defaultValue)
		{
			InitializeComponent();
			Prompt = prompt;
			Title = title;
			txtInput.Text = defaultValue;
		}

		public InputBox(string prompt, string title, ValidatorDelegate validator)
		{
			InitializeComponent();
			Prompt = prompt;
			Title = title;
			_validator = validator;
		}

		public InputBox(string prompt, string title, string defaultValue, ValidatorDelegate validator)
		{
			InitializeComponent();
			Prompt = prompt;
			Title = title;
			txtInput.Text = defaultValue;
			_validator = validator;
		}

		private string InputValue
		{
			get
			{
				return txtInput.Text;
			}
		}

		private string Prompt
		{
			set
			{
				_prompt = value;
				labelPrompt.Text = _prompt;
			}
		}

		private string Title
		{
			set
			{
				_title = value;
				Text = _title;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(64, 8);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(400, 20);
            this.txtInput.TabIndex = 3;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "value:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPrompt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 32);
            this.panel1.TabIndex = 5;
            // 
            // labelPrompt
            // 
            this.labelPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPrompt.Location = new System.Drawing.Point(0, 0);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(480, 32);
            this.labelPrompt.TabIndex = 0;
            this.labelPrompt.Text = "Please insert a value";
            this.labelPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 32);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(480, 8);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 32);
            this.panel2.TabIndex = 7;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 72);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(480, 8);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 40);
            this.panel3.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(392, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(304, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            // 
            // InputBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 120);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.InputBox_Closing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void InputBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(DialogResult==DialogResult.Cancel)
				return;
			if(txtInput.Text=="")
				return;
			if(_validator != null)
			{
				if(!_validator(txtInput.Text))
				{
					MessageBox.Show("The input is invalid. Please verify the format of the input","Input format invalid",MessageBoxButtons.OK);
					e.Cancel = true;
				}
			}
		}

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r") return;
            DialogResult = DialogResult.OK;
            Close();
        }

	}
}
