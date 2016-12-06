using System.Drawing;

namespace MainApplication
{
	partial class MainForm
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
			this.DataButton = new System.Windows.Forms.Button();
			this.SendButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.AccountLabel0 = new System.Windows.Forms.Label();
			this.AccountLabel1 = new System.Windows.Forms.Label();
			this.ProgressBar0 = new System.Windows.Forms.ProgressBar();
			this.ResultLabel0 = new System.Windows.Forms.Label();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar2 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar3 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar4 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar5 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar6 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar7 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar8 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar9 = new System.Windows.Forms.ProgressBar();
			this.AccountLabel2 = new System.Windows.Forms.Label();
			this.AccountLabel3 = new System.Windows.Forms.Label();
			this.AccountLabel4 = new System.Windows.Forms.Label();
			this.AccountLabel5 = new System.Windows.Forms.Label();
			this.AccountLabel6 = new System.Windows.Forms.Label();
			this.AccountLabel7 = new System.Windows.Forms.Label();
			this.AccountLabel8 = new System.Windows.Forms.Label();
			this.ResultLabel1 = new System.Windows.Forms.Label();
			this.AccountLabel9 = new System.Windows.Forms.Label();
			this.ResultLabel2 = new System.Windows.Forms.Label();
			this.ResultLabel3 = new System.Windows.Forms.Label();
			this.ResultLabel4 = new System.Windows.Forms.Label();
			this.ResultLabel5 = new System.Windows.Forms.Label();
			this.ResultLabel6 = new System.Windows.Forms.Label();
			this.ResultLabel7 = new System.Windows.Forms.Label();
			this.ResultLabel8 = new System.Windows.Forms.Label();
			this.ResultLabel9 = new System.Windows.Forms.Label();
			this.TotalsLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// DataButton
			// 
			this.DataButton.Location = new System.Drawing.Point(18, 15);
			this.DataButton.Name = "DataButton";
			this.DataButton.Size = new System.Drawing.Size(75, 23);
			this.DataButton.TabIndex = 0;
			this.DataButton.Text = "Load Data";
			this.DataButton.UseVisualStyleBackColor = true;
			this.DataButton.Click += new System.EventHandler(this.DataButton_Click);
			// 
			// SendButton
			// 
			this.SendButton.Enabled = false;
			this.SendButton.Location = new System.Drawing.Point(213, 15);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(75, 23);
			this.SendButton.TabIndex = 1;
			this.SendButton.Text = "Send Data";
			this.SendButton.UseVisualStyleBackColor = true;
			this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(348, 15);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 23);
			this.ExitButton.TabIndex = 2;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StatusLabel.Location = new System.Drawing.Point(18, 333);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(64, 13);
			this.StatusLabel.TabIndex = 3;
			this.StatusLabel.Text = "STATUS :";
			// 
			// AccountLabel0
			// 
			this.AccountLabel0.AutoSize = true;
			this.AccountLabel0.Location = new System.Drawing.Point(18, 58);
			this.AccountLabel0.Name = "AccountLabel0";
			this.AccountLabel0.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel0.TabIndex = 4;
			this.AccountLabel0.Text = "A/c end in 0";
			// 
			// AccountLabel1
			// 
			this.AccountLabel1.AutoSize = true;
			this.AccountLabel1.Location = new System.Drawing.Point(18, 84);
			this.AccountLabel1.Name = "AccountLabel1";
			this.AccountLabel1.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel1.TabIndex = 5;
			this.AccountLabel1.Text = "A/c end in 1";
			// 
			// ProgressBar0
			// 
			this.ProgressBar0.Location = new System.Drawing.Point(88, 51);
			this.ProgressBar0.Name = "ProgressBar0";
			this.ProgressBar0.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar0.TabIndex = 6;
			// 
			// ResultLabel0
			// 
			this.ResultLabel0.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ResultLabel0.Location = new System.Drawing.Point(298, 58);
			this.ResultLabel0.Name = "ResultLabel0";
			this.ResultLabel0.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel0.TabIndex = 7;
			this.ResultLabel0.Text = "987654 / 987654 [100%]";
			this.ResultLabel0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Location = new System.Drawing.Point(88, 77);
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar1.TabIndex = 8;
			// 
			// ProgressBar2
			// 
			this.ProgressBar2.Location = new System.Drawing.Point(88, 103);
			this.ProgressBar2.Name = "ProgressBar2";
			this.ProgressBar2.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar2.TabIndex = 9;
			// 
			// ProgressBar3
			// 
			this.ProgressBar3.Location = new System.Drawing.Point(88, 129);
			this.ProgressBar3.Name = "ProgressBar3";
			this.ProgressBar3.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar3.TabIndex = 10;
			// 
			// ProgressBar4
			// 
			this.ProgressBar4.Location = new System.Drawing.Point(88, 155);
			this.ProgressBar4.Name = "ProgressBar4";
			this.ProgressBar4.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar4.TabIndex = 11;
			// 
			// ProgressBar5
			// 
			this.ProgressBar5.Location = new System.Drawing.Point(88, 198);
			this.ProgressBar5.Name = "ProgressBar5";
			this.ProgressBar5.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar5.TabIndex = 12;
			// 
			// ProgressBar6
			// 
			this.ProgressBar6.Location = new System.Drawing.Point(88, 224);
			this.ProgressBar6.Name = "ProgressBar6";
			this.ProgressBar6.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar6.TabIndex = 13;
			// 
			// ProgressBar7
			// 
			this.ProgressBar7.Location = new System.Drawing.Point(88, 250);
			this.ProgressBar7.Name = "ProgressBar7";
			this.ProgressBar7.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar7.TabIndex = 14;
			// 
			// ProgressBar8
			// 
			this.ProgressBar8.Location = new System.Drawing.Point(88, 276);
			this.ProgressBar8.Name = "ProgressBar8";
			this.ProgressBar8.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar8.TabIndex = 15;
			// 
			// ProgressBar9
			// 
			this.ProgressBar9.Location = new System.Drawing.Point(88, 302);
			this.ProgressBar9.Name = "ProgressBar9";
			this.ProgressBar9.Size = new System.Drawing.Size(200, 20);
			this.ProgressBar9.TabIndex = 16;
			// 
			// AccountLabel2
			// 
			this.AccountLabel2.AutoSize = true;
			this.AccountLabel2.Location = new System.Drawing.Point(18, 110);
			this.AccountLabel2.Name = "AccountLabel2";
			this.AccountLabel2.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel2.TabIndex = 17;
			this.AccountLabel2.Text = "A/c end in 2";
			// 
			// AccountLabel3
			// 
			this.AccountLabel3.AutoSize = true;
			this.AccountLabel3.Location = new System.Drawing.Point(18, 136);
			this.AccountLabel3.Name = "AccountLabel3";
			this.AccountLabel3.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel3.TabIndex = 18;
			this.AccountLabel3.Text = "A/c end in 3";
			// 
			// AccountLabel4
			// 
			this.AccountLabel4.AutoSize = true;
			this.AccountLabel4.Location = new System.Drawing.Point(18, 162);
			this.AccountLabel4.Name = "AccountLabel4";
			this.AccountLabel4.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel4.TabIndex = 19;
			this.AccountLabel4.Text = "A/c end in 4";
			// 
			// AccountLabel5
			// 
			this.AccountLabel5.AutoSize = true;
			this.AccountLabel5.Location = new System.Drawing.Point(18, 205);
			this.AccountLabel5.Name = "AccountLabel5";
			this.AccountLabel5.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel5.TabIndex = 20;
			this.AccountLabel5.Text = "A/c end in 5";
			// 
			// AccountLabel6
			// 
			this.AccountLabel6.AutoSize = true;
			this.AccountLabel6.Location = new System.Drawing.Point(18, 231);
			this.AccountLabel6.Name = "AccountLabel6";
			this.AccountLabel6.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel6.TabIndex = 21;
			this.AccountLabel6.Text = "A/c end in 6";
			// 
			// AccountLabel7
			// 
			this.AccountLabel7.AutoSize = true;
			this.AccountLabel7.Location = new System.Drawing.Point(18, 257);
			this.AccountLabel7.Name = "AccountLabel7";
			this.AccountLabel7.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel7.TabIndex = 22;
			this.AccountLabel7.Text = "A/c end in 7";
			// 
			// AccountLabel8
			// 
			this.AccountLabel8.AutoSize = true;
			this.AccountLabel8.Location = new System.Drawing.Point(18, 283);
			this.AccountLabel8.Name = "AccountLabel8";
			this.AccountLabel8.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel8.TabIndex = 23;
			this.AccountLabel8.Text = "A/c end in 8";
			// 
			// ResultLabel1
			// 
			this.ResultLabel1.Location = new System.Drawing.Point(298, 84);
			this.ResultLabel1.Name = "ResultLabel1";
			this.ResultLabel1.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel1.TabIndex = 24;
			this.ResultLabel1.Text = "987654 / 987654 [100%]";
			// 
			// AccountLabel9
			// 
			this.AccountLabel9.AutoSize = true;
			this.AccountLabel9.Location = new System.Drawing.Point(18, 309);
			this.AccountLabel9.Name = "AccountLabel9";
			this.AccountLabel9.Size = new System.Drawing.Size(66, 13);
			this.AccountLabel9.TabIndex = 25;
			this.AccountLabel9.Text = "A/c end in 9";
			// 
			// ResultLabel2
			// 
			this.ResultLabel2.Location = new System.Drawing.Point(298, 110);
			this.ResultLabel2.Name = "ResultLabel2";
			this.ResultLabel2.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel2.TabIndex = 26;
			this.ResultLabel2.Text = "987654 / 987654 [100%]";
			this.ResultLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel3
			// 
			this.ResultLabel3.Location = new System.Drawing.Point(298, 136);
			this.ResultLabel3.Name = "ResultLabel3";
			this.ResultLabel3.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel3.TabIndex = 27;
			this.ResultLabel3.Text = "987654 / 987654 [100%]";
			this.ResultLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel4
			// 
			this.ResultLabel4.Location = new System.Drawing.Point(298, 162);
			this.ResultLabel4.Name = "ResultLabel4";
			this.ResultLabel4.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel4.TabIndex = 28;
			this.ResultLabel4.Text = "987654 / 987654 [100%]";
			this.ResultLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel5
			// 
			this.ResultLabel5.Location = new System.Drawing.Point(298, 205);
			this.ResultLabel5.Name = "ResultLabel5";
			this.ResultLabel5.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel5.TabIndex = 29;
			this.ResultLabel5.Text = "987654 / 987654 [100%]";
			this.ResultLabel5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel6
			// 
			this.ResultLabel6.Location = new System.Drawing.Point(298, 231);
			this.ResultLabel6.Name = "ResultLabel6";
			this.ResultLabel6.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel6.TabIndex = 30;
			this.ResultLabel6.Text = "987654 / 987654 [100%]";
			this.ResultLabel6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel7
			// 
			this.ResultLabel7.Location = new System.Drawing.Point(298, 257);
			this.ResultLabel7.Name = "ResultLabel7";
			this.ResultLabel7.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel7.TabIndex = 31;
			this.ResultLabel7.Text = "987654 / 987654 [100%]";
			this.ResultLabel7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel8
			// 
			this.ResultLabel8.Location = new System.Drawing.Point(298, 283);
			this.ResultLabel8.Name = "ResultLabel8";
			this.ResultLabel8.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel8.TabIndex = 32;
			this.ResultLabel8.Text = "987654 / 987654 [100%]";
			this.ResultLabel8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ResultLabel9
			// 
			this.ResultLabel9.Location = new System.Drawing.Point(298, 309);
			this.ResultLabel9.Name = "ResultLabel9";
			this.ResultLabel9.Size = new System.Drawing.Size(125, 13);
			this.ResultLabel9.TabIndex = 33;
			this.ResultLabel9.Text = "987654 / 987654 [100%]";
			this.ResultLabel9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TotalsLabel
			// 
			this.TotalsLabel.AutoSize = true;
			this.TotalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalsLabel.Location = new System.Drawing.Point(298, 333);
			this.TotalsLabel.Name = "TotalsLabel";
			this.TotalsLabel.Size = new System.Drawing.Size(72, 13);
			this.TotalsLabel.TabIndex = 34;
			this.TotalsLabel.Text = "RESULTS :";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 355);
			this.Controls.Add(this.TotalsLabel);
			this.Controls.Add(this.ResultLabel9);
			this.Controls.Add(this.ResultLabel8);
			this.Controls.Add(this.ResultLabel7);
			this.Controls.Add(this.ResultLabel6);
			this.Controls.Add(this.ResultLabel5);
			this.Controls.Add(this.ResultLabel4);
			this.Controls.Add(this.ResultLabel3);
			this.Controls.Add(this.ResultLabel2);
			this.Controls.Add(this.AccountLabel9);
			this.Controls.Add(this.ResultLabel1);
			this.Controls.Add(this.AccountLabel8);
			this.Controls.Add(this.AccountLabel7);
			this.Controls.Add(this.AccountLabel6);
			this.Controls.Add(this.AccountLabel5);
			this.Controls.Add(this.AccountLabel4);
			this.Controls.Add(this.AccountLabel3);
			this.Controls.Add(this.AccountLabel2);
			this.Controls.Add(this.ProgressBar9);
			this.Controls.Add(this.ProgressBar8);
			this.Controls.Add(this.ProgressBar7);
			this.Controls.Add(this.ProgressBar6);
			this.Controls.Add(this.ProgressBar5);
			this.Controls.Add(this.ProgressBar4);
			this.Controls.Add(this.ProgressBar3);
			this.Controls.Add(this.ProgressBar2);
			this.Controls.Add(this.ProgressBar1);
			this.Controls.Add(this.ResultLabel0);
			this.Controls.Add(this.ProgressBar0);
			this.Controls.Add(this.AccountLabel1);
			this.Controls.Add(this.AccountLabel0);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.DataButton);
			this.Name = "MainForm";
			this.Text = "Push Notifications";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button DataButton;
		private System.Windows.Forms.Button SendButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Label AccountLabel0;
		private System.Windows.Forms.Label AccountLabel1;
		private System.Windows.Forms.ProgressBar ProgressBar0;
		private System.Windows.Forms.Label ResultLabel0;
		private System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.ProgressBar ProgressBar2;
		private System.Windows.Forms.ProgressBar ProgressBar3;
		private System.Windows.Forms.ProgressBar ProgressBar4;
		private System.Windows.Forms.ProgressBar ProgressBar5;
		private System.Windows.Forms.ProgressBar ProgressBar6;
		private System.Windows.Forms.ProgressBar ProgressBar7;
		private System.Windows.Forms.ProgressBar ProgressBar8;
		private System.Windows.Forms.ProgressBar ProgressBar9;
		private System.Windows.Forms.Label AccountLabel2;
		private System.Windows.Forms.Label AccountLabel3;
		private System.Windows.Forms.Label AccountLabel4;
		private System.Windows.Forms.Label AccountLabel5;
		private System.Windows.Forms.Label AccountLabel6;
		private System.Windows.Forms.Label AccountLabel7;
		private System.Windows.Forms.Label AccountLabel8;
		private System.Windows.Forms.Label ResultLabel1;
		private System.Windows.Forms.Label AccountLabel9;
		private System.Windows.Forms.Label ResultLabel2;
		private System.Windows.Forms.Label ResultLabel3;
		private System.Windows.Forms.Label ResultLabel4;
		private System.Windows.Forms.Label ResultLabel5;
		private System.Windows.Forms.Label ResultLabel6;
		private System.Windows.Forms.Label ResultLabel7;
		private System.Windows.Forms.Label ResultLabel8;
		private System.Windows.Forms.Label ResultLabel9;
		private System.Windows.Forms.Label TotalsLabel;
	}
}

