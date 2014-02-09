namespace PivotalTurtle.StoryList
{
	partial class StoryListWindow
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
			this.storiesListView = new System.Windows.Forms.ListView();
			this.columnHeaderCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// storiesListView
			// 
			this.storiesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.storiesListView.CheckBoxes = true;
			this.storiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheck,
            this.columnHeaderId,
            this.columnHeaderName});
			this.storiesListView.Location = new System.Drawing.Point(12, 12);
			this.storiesListView.Name = "storiesListView";
			this.storiesListView.Size = new System.Drawing.Size(413, 220);
			this.storiesListView.TabIndex = 0;
			this.storiesListView.UseCompatibleStateImageBehavior = false;
			this.storiesListView.View = System.Windows.Forms.View.Details;
			this.storiesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.storiesListView_ItemChecked);
			// 
			// columnHeaderCheck
			// 
			this.columnHeaderCheck.Text = "";
			this.columnHeaderCheck.Width = 20;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "Id";
			this.columnHeaderId.Width = 80;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 600;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(184, 249);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// StoryListWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(437, 284);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.storiesListView);
			this.Name = "StoryListWindow";
			this.Text = "StoryListWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView storiesListView;
		private System.Windows.Forms.ColumnHeader columnHeaderCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.Button button1;

	}
}