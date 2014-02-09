namespace PivotalTurtle.Auth
{
	partial class LogInWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.token = new System.Windows.Forms.TextBox();
			this.login = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pivotal Tracker API Token";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// token
			// 
			this.token.Location = new System.Drawing.Point(175, 12);
			this.token.Name = "token";
			this.token.Size = new System.Drawing.Size(182, 20);
			this.token.TabIndex = 1;
			// 
			// login
			// 
			this.login.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.login.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.login.Location = new System.Drawing.Point(109, 58);
			this.login.Name = "login";
			this.login.Size = new System.Drawing.Size(75, 23);
			this.login.TabIndex = 4;
			this.login.Text = "Authenticate";
			this.login.UseVisualStyleBackColor = true;
			this.login.Click += new System.EventHandler(this.login_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(191, 58);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// LogInWindow
			// 
			this.AcceptButton = this.login;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(369, 93);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.login);
			this.Controls.Add(this.token);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LogInWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pivotal Tracker Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox token;
		private System.Windows.Forms.Button login;
		private System.Windows.Forms.Button cancel;
	}
}