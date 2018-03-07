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
			this.gamepanel = new System.Windows.Forms.Panel();
			this.sidepanel = new System.Windows.Forms.Panel();
			this.sneklogopanel = new System.Windows.Forms.Panel();
			this.sidepanelcontainer = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.sidepanel.SuspendLayout();
			this.sneklogopanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// gamepanel
			// 
			this.gamepanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gamepanel.Location = new System.Drawing.Point(200, 0);
			this.gamepanel.Name = "gamepanel";
			this.gamepanel.Size = new System.Drawing.Size(584, 561);
			this.gamepanel.TabIndex = 1;
			// 
			// sidepanel
			// 
			this.sidepanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.sidepanel.Controls.Add(this.sidepanelcontainer);
			this.sidepanel.Controls.Add(this.sneklogopanel);
			this.sidepanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.sidepanel.Location = new System.Drawing.Point(0, 0);
			this.sidepanel.Name = "sidepanel";
			this.sidepanel.Size = new System.Drawing.Size(200, 561);
			this.sidepanel.TabIndex = 0;
			// 
			// sneklogopanel
			// 
			this.sneklogopanel.Controls.Add(this.label1);
			this.sneklogopanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.sneklogopanel.Location = new System.Drawing.Point(0, 0);
			this.sneklogopanel.Name = "sneklogopanel";
			this.sneklogopanel.Size = new System.Drawing.Size(200, 100);
			this.sneklogopanel.TabIndex = 0;
			// 
			// sidepanelcontainer
			// 
			this.sidepanelcontainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.sidepanelcontainer.Location = new System.Drawing.Point(0, 106);
			this.sidepanelcontainer.Name = "sidepanelcontainer";
			this.sidepanelcontainer.Size = new System.Drawing.Size(200, 455);
			this.sidepanelcontainer.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 100);
			this.label1.TabIndex = 0;
			this.label1.Text = "snek";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SnakeGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.gamepanel);
			this.Controls.Add(this.sidepanel);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "SnakeGame";
			this.Text = "SnakeGame";
			this.sidepanel.ResumeLayout(false);
			this.sneklogopanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel gamepanel;
		private System.Windows.Forms.Panel sidepanel;
		private System.Windows.Forms.Panel sidepanelcontainer;
		private System.Windows.Forms.Panel sneklogopanel;
		private System.Windows.Forms.Label label1;
	}
}