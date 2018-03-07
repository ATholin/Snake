namespace Snake
{
	partial class SnakeGame
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
			this.sidepanel = new System.Windows.Forms.Panel();
			this.panelcontainer = new System.Windows.Forms.Panel();
			this.sneklogopanel = new System.Windows.Forms.Panel();
			this.sidepanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// sidepanel
			// 
			this.sidepanel.Controls.Add(this.panelcontainer);
			this.sidepanel.Controls.Add(this.sneklogopanel);
			this.sidepanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.sidepanel.Location = new System.Drawing.Point(0, 0);
			this.sidepanel.MaximumSize = new System.Drawing.Size(200, 0);
			this.sidepanel.MinimumSize = new System.Drawing.Size(200, 0);
			this.sidepanel.Name = "sidepanel";
			this.sidepanel.Size = new System.Drawing.Size(200, 561);
			this.sidepanel.TabIndex = 0;
			// 
			// panelcontainer
			// 
			this.panelcontainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelcontainer.Location = new System.Drawing.Point(0, 106);
			this.panelcontainer.Name = "panelcontainer";
			this.panelcontainer.Size = new System.Drawing.Size(200, 455);
			this.panelcontainer.TabIndex = 1;
			// 
			// sneklogopanel
			// 
			this.sneklogopanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.sneklogopanel.Location = new System.Drawing.Point(0, 0);
			this.sneklogopanel.Name = "sneklogopanel";
			this.sneklogopanel.Size = new System.Drawing.Size(200, 100);
			this.sneklogopanel.TabIndex = 0;
			// 
			// SnakeGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.sidepanel);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "SnakeGame";
			this.Text = "SnakeGame";
			this.sidepanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel sidepanel;
		private System.Windows.Forms.Panel panelcontainer;
		private System.Windows.Forms.Panel sneklogopanel;
	}
}