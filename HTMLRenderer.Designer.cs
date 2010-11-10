namespace PB
{
	partial class HTMLRenderer
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
				components.Dispose();

			this.browser.Stop();
			this.browser.Dispose();
			this.browser = null;

			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.browser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// browser
			// 
			this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.browser.Location = new System.Drawing.Point(0, 0);
			this.browser.Margin = new System.Windows.Forms.Padding(0);
			this.browser.Name = "browser";
			this.browser.Size = new System.Drawing.Size(150, 150);
			this.browser.TabIndex = 0;
			// 
			// HTMLRenderer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.browser);
			this.Name = "HTMLRenderer";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser browser;
	}
}
