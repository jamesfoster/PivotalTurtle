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
			this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.projectDropDown = new System.Windows.Forms.ComboBox();
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
            this.columnHeaderName,
            this.columnHeaderState,
            this.columnHeaderProject});
			this.storiesListView.Location = new System.Drawing.Point(12, 43);
			this.storiesListView.Name = "storiesListView";
			this.storiesListView.Size = new System.Drawing.Size(705, 228);
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
			this.columnHeaderName.Width = 400;
			// 
			// columnHeaderState
			// 
			this.columnHeaderState.Text = "State";
			this.columnHeaderState.Width = 100;
			// 
			// columnHeaderProject
			// 
			this.columnHeaderProject.Text = "Project";
			this.columnHeaderProject.Width = 116;
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(290, 288);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(372, 288);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// projectDropDown
			// 
			this.projectDropDown.DisplayMember = "Name";
			this.projectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.projectDropDown.FormattingEnabled = true;
			this.projectDropDown.Location = new System.Drawing.Point(484, 12);
			this.projectDropDown.Name = "projectDropDown";
			this.projectDropDown.Size = new System.Drawing.Size(233, 21);
			this.projectDropDown.TabIndex = 3;
			this.projectDropDown.SelectedIndexChanged += new System.EventHandler(this.projectDropDown_SelectedIndexChanged);
			// 
			// StoryListWindow
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(729, 323);
			this.Controls.Add(this.projectDropDown);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.storiesListView);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StoryListWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StoryListWindow";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView storiesListView;
		private System.Windows.Forms.ColumnHeader columnHeaderCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ColumnHeader columnHeaderProject;
		private System.Windows.Forms.ColumnHeader columnHeaderState;
		private System.Windows.Forms.ComboBox projectDropDown;

	}
}