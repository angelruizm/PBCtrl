namespace PB
{
	partial class EditableListBox
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditableListBox));
			this.textbox = new System.Windows.Forms.TextBox();
			this.listbox = new System.Windows.Forms.ListBox();
			this.buttonSort = new System.Windows.Forms.Button();
			this.imagelistSmallButtons = new System.Windows.Forms.ImageList(this.components);
			this.imagelistLargeButtons = new System.Windows.Forms.ImageList(this.components);
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textbox
			// 
			this.textbox.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
			this.textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textbox.Location = new System.Drawing.Point(1, 28);
			this.textbox.Name = "textbox";
			this.textbox.Size = new System.Drawing.Size(148, 20);
			this.textbox.TabIndex = 0;
			this.textbox.TabStop = false;
			this.textbox.Visible = false;
			this.textbox.Leave += new System.EventHandler(this.textbox_Leave);
			// 
			// listbox
			// 
			this.listbox.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
			this.listbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listbox.FormattingEnabled = true;
			this.listbox.Location = new System.Drawing.Point(0, 27);
			this.listbox.Name = "listbox";
			this.listbox.Size = new System.Drawing.Size(150, 121);
			this.listbox.TabIndex = 5;
			this.listbox.DoubleClick += new System.EventHandler(this.listbox_DoubleClick);
			// 
			// buttonSort
			// 
			this.buttonSort.AccessibleDescription = "Sort the list alphanumerically";
			this.buttonSort.AccessibleName = "Sort";
			this.buttonSort.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSort.ImageIndex = 0;
			this.buttonSort.ImageList = this.imagelistSmallButtons;
			this.buttonSort.Location = new System.Drawing.Point(30, 0);
			this.buttonSort.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSort.Name = "buttonSort";
			this.buttonSort.Size = new System.Drawing.Size(24, 24);
			this.buttonSort.TabIndex = 0;
			this.buttonSort.UseVisualStyleBackColor = true;
			this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
			// 
			// imagelistSmallButtons
			// 
			this.imagelistSmallButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelistSmallButtons.ImageStream")));
			this.imagelistSmallButtons.TransparentColor = System.Drawing.Color.Transparent;
			this.imagelistSmallButtons.Images.SetKeyName(0, "sort_small.png");
			this.imagelistSmallButtons.Images.SetKeyName(1, "up_small.png");
			this.imagelistSmallButtons.Images.SetKeyName(2, "down_small.png");
			this.imagelistSmallButtons.Images.SetKeyName(3, "add_small.png");
			this.imagelistSmallButtons.Images.SetKeyName(4, "remove_small.png");
			// 
			// imagelistLargeButtons
			// 
			this.imagelistLargeButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelistLargeButtons.ImageStream")));
			this.imagelistLargeButtons.TransparentColor = System.Drawing.Color.Transparent;
			this.imagelistLargeButtons.Images.SetKeyName(0, "icons/sort_large.png");
			this.imagelistLargeButtons.Images.SetKeyName(1, "icons/up_large.png");
			this.imagelistLargeButtons.Images.SetKeyName(2, "icons/down_large.png");
			this.imagelistLargeButtons.Images.SetKeyName(3, "icons/add_large.png");
			this.imagelistLargeButtons.Images.SetKeyName(4, "icons/remove_large.png");
			// 
			// buttonUp
			// 
			this.buttonUp.AccessibleDescription = "Move the selected item up the list";
			this.buttonUp.AccessibleName = "Move up";
			this.buttonUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUp.ImageIndex = 1;
			this.buttonUp.ImageList = this.imagelistSmallButtons;
			this.buttonUp.Location = new System.Drawing.Point(54, 0);
			this.buttonUp.Margin = new System.Windows.Forms.Padding(0);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size(24, 24);
			this.buttonUp.TabIndex = 1;
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
			// 
			// buttonDown
			// 
			this.buttonDown.AccessibleDescription = "Move the selected item down the list";
			this.buttonDown.AccessibleName = "Move down";
			this.buttonDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDown.ImageIndex = 2;
			this.buttonDown.ImageList = this.imagelistSmallButtons;
			this.buttonDown.Location = new System.Drawing.Point(78, 0);
			this.buttonDown.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(24, 24);
			this.buttonDown.TabIndex = 2;
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.AccessibleDescription = "Add a new item to the list";
			this.buttonAdd.AccessibleName = "Add item";
			this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.ImageIndex = 3;
			this.buttonAdd.ImageList = this.imagelistSmallButtons;
			this.buttonAdd.Location = new System.Drawing.Point(102, 0);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonAdd.TabIndex = 3;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRemove
			// 
			this.buttonRemove.AccessibleDescription = "Remove the selected item from the list";
			this.buttonRemove.AccessibleName = "Remove item";
			this.buttonRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemove.ImageIndex = 4;
			this.buttonRemove.ImageList = this.imagelistSmallButtons;
			this.buttonRemove.Location = new System.Drawing.Point(126, 0);
			this.buttonRemove.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(24, 24);
			this.buttonRemove.TabIndex = 4;
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// EditableListBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.textbox);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonDown);
			this.Controls.Add(this.buttonUp);
			this.Controls.Add(this.buttonSort);
			this.Controls.Add(this.listbox);
			this.Name = "EditableListBox";
			this.Size = new System.Drawing.Size(150, 148);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listbox;
		private System.Windows.Forms.TextBox textbox;
		private System.Windows.Forms.Button buttonSort;
		private System.Windows.Forms.ImageList imagelistLargeButtons;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonDown;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.ImageList imagelistSmallButtons;
	}
}
