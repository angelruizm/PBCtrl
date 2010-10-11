namespace PB
{
	partial class TestStub
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.editableListBox = new PB.EditableListBox();
			this.htmlRenderer = new PB.HTMLRenderer();
			this.SuspendLayout();
			// 
			// editableListBox
			// 
			this.editableListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.editableListBox.BackColor = System.Drawing.Color.Transparent;
			this.editableListBox.ButtonSize = PB.EditableListBox.SimpleSize.Small;
			this.editableListBox.ColumnWidth = 0;
			this.editableListBox.HorizontalExtent = 0;
			this.editableListBox.HorizontalScrollbar = false;
			this.editableListBox.Location = new System.Drawing.Point(12, 12);
			this.editableListBox.MultiColumn = false;
			this.editableListBox.Name = "editableListBox";
			this.editableListBox.ScrollAlwaysVisible = false;
			this.editableListBox.SelectedIndex = -1;
			this.editableListBox.Size = new System.Drawing.Size(237, 176);
			this.editableListBox.Sorted = false;
			this.editableListBox.TabIndex = 0;
			this.editableListBox.UseTabStops = true;
			// 
			// htmlRenderer
			// 
			this.htmlRenderer.AllowDrop = true;
			this.htmlRenderer.AllowNavigation = true;
			this.htmlRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.htmlRenderer.EnableAcceleratorKeys = true;
			this.htmlRenderer.EnableScrollBars = true;
			this.htmlRenderer.Location = new System.Drawing.Point(12, 203);
			this.htmlRenderer.Name = "htmlRenderer";
			this.htmlRenderer.Size = new System.Drawing.Size(237, 219);
			this.htmlRenderer.SuppressErrors = false;
			this.htmlRenderer.TabIndex = 1;
			this.htmlRenderer.UseDefaultContextMenu = true;
			// 
			// TestStub
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 434);
			this.Controls.Add(this.htmlRenderer);
			this.Controls.Add(this.editableListBox);
			this.Name = "TestStub";
			this.Text = "EditableListBox Test Stub";
			this.ResumeLayout(false);

		}

		#endregion

		private EditableListBox editableListBox;
		private HTMLRenderer htmlRenderer;
	}
}

