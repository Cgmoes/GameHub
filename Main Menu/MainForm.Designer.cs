namespace GameHub
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			hangmanBtn = new Button();
			welcomeLabel = new Label();
			choicesLabel = new Label();
			mpConnectFourBtn = new Button();
			spConnectFourBtn = new Button();
			SuspendLayout();
			// 
			// hangmanBtn
			// 
			hangmanBtn.ForeColor = SystemColors.InfoText;
			hangmanBtn.Location = new Point(54, 214);
			hangmanBtn.Name = "hangmanBtn";
			hangmanBtn.Size = new Size(124, 23);
			hangmanBtn.TabIndex = 0;
			hangmanBtn.Text = "Hangman";
			hangmanBtn.UseVisualStyleBackColor = true;
			hangmanBtn.Click += hangmanBtn_Click;
			// 
			// welcomeLabel
			// 
			welcomeLabel.AutoSize = true;
			welcomeLabel.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			welcomeLabel.ForeColor = SystemColors.InfoText;
			welcomeLabel.Location = new Point(159, 9);
			welcomeLabel.Name = "welcomeLabel";
			welcomeLabel.Size = new Size(416, 50);
			welcomeLabel.TabIndex = 1;
			welcomeLabel.Text = "Welcome To Game Hub";
			// 
			// choicesLabel
			// 
			choicesLabel.AutoSize = true;
			choicesLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			choicesLabel.ForeColor = SystemColors.InfoText;
			choicesLabel.Location = new Point(44, 181);
			choicesLabel.Name = "choicesLabel";
			choicesLabel.Size = new Size(148, 30);
			choicesLabel.TabIndex = 2;
			choicesLabel.Text = "Game Choices";
			// 
			// mpConnectFourBtn
			// 
			mpConnectFourBtn.ForeColor = SystemColors.InfoText;
			mpConnectFourBtn.Location = new Point(54, 243);
			mpConnectFourBtn.Name = "mpConnectFourBtn";
			mpConnectFourBtn.Size = new Size(124, 23);
			mpConnectFourBtn.TabIndex = 3;
			mpConnectFourBtn.Text = "2 Player Connect 4";
			mpConnectFourBtn.UseVisualStyleBackColor = true;
			mpConnectFourBtn.Click += mpConnectFourBtn_Click;
			// 
			// spConnectFourBtn
			// 
			spConnectFourBtn.ForeColor = SystemColors.InfoText;
			spConnectFourBtn.Location = new Point(54, 272);
			spConnectFourBtn.Name = "spConnectFourBtn";
			spConnectFourBtn.Size = new Size(124, 23);
			spConnectFourBtn.TabIndex = 4;
			spConnectFourBtn.Text = "1 Player Connect 4";
			spConnectFourBtn.UseVisualStyleBackColor = true;
			spConnectFourBtn.Click += spConnectFourBtn_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Info;
			ClientSize = new Size(800, 450);
			Controls.Add(spConnectFourBtn);
			Controls.Add(mpConnectFourBtn);
			Controls.Add(choicesLabel);
			Controls.Add(welcomeLabel);
			Controls.Add(hangmanBtn);
			ForeColor = SystemColors.ControlDarkDark;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MainForm";
			Text = "Main Menu";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button hangmanBtn;
		private Label welcomeLabel;
		private Label choicesLabel;
		private Button mpConnectFourBtn;
		private Button spConnectFourBtn;
	}
}
