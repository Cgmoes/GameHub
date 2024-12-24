namespace GameHub
{
	partial class HangmanForm
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
			backBtn = new Button();
			guessTextBox = new TextBox();
			makeGuessBtn = new Button();
			correctWordLabel = new Label();
			label1 = new Label();
			prevGuessesLabel = new Label();
			livesLabel = new Label();
			SuspendLayout();
			// 
			// backBtn
			// 
			backBtn.Location = new Point(12, 415);
			backBtn.Name = "backBtn";
			backBtn.Size = new Size(89, 23);
			backBtn.TabIndex = 0;
			backBtn.Text = "Back To Menu";
			backBtn.UseVisualStyleBackColor = true;
			backBtn.Click += backBtn_Click;
			// 
			// guessTextBox
			// 
			guessTextBox.CharacterCasing = CharacterCasing.Lower;
			guessTextBox.Location = new Point(303, 344);
			guessTextBox.MaxLength = 1;
			guessTextBox.Name = "guessTextBox";
			guessTextBox.PlaceholderText = "Type Char";
			guessTextBox.Size = new Size(61, 23);
			guessTextBox.TabIndex = 1;
			// 
			// makeGuessBtn
			// 
			makeGuessBtn.Location = new Point(370, 343);
			makeGuessBtn.Name = "makeGuessBtn";
			makeGuessBtn.Size = new Size(91, 23);
			makeGuessBtn.TabIndex = 2;
			makeGuessBtn.Text = "Make Guess";
			makeGuessBtn.UseVisualStyleBackColor = true;
			makeGuessBtn.Click += makeGuessBtn_Click;
			// 
			// correctWordLabel
			// 
			correctWordLabel.AutoSize = true;
			correctWordLabel.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			correctWordLabel.Location = new Point(482, 197);
			correctWordLabel.Name = "correctWordLabel";
			correctWordLabel.Size = new Size(115, 50);
			correctWordLabel.TabIndex = 3;
			correctWordLabel.Text = "Word";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(12, 20);
			label1.Name = "label1";
			label1.Size = new Size(193, 32);
			label1.TabIndex = 4;
			label1.Text = "Guessed Letters:";
			// 
			// prevGuessesLabel
			// 
			prevGuessesLabel.AutoSize = true;
			prevGuessesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			prevGuessesLabel.Location = new Point(12, 63);
			prevGuessesLabel.Name = "prevGuessesLabel";
			prevGuessesLabel.Size = new Size(131, 21);
			prevGuessesLabel.TabIndex = 5;
			prevGuessesLabel.Text = "Previous Guesses";
			// 
			// livesLabel
			// 
			livesLabel.AutoSize = true;
			livesLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			livesLabel.Location = new Point(274, 22);
			livesLabel.Name = "livesLabel";
			livesLabel.Size = new Size(64, 30);
			livesLabel.TabIndex = 6;
			livesLabel.Text = "Lives:";
			// 
			// HangmanForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(livesLabel);
			Controls.Add(prevGuessesLabel);
			Controls.Add(label1);
			Controls.Add(correctWordLabel);
			Controls.Add(makeGuessBtn);
			Controls.Add(guessTextBox);
			Controls.Add(backBtn);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "HangmanForm";
			Text = "HangmanForm";
			Paint += HangmanForm_Paint;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button backBtn;
		private TextBox guessTextBox;
		private Button makeGuessBtn;
		private Label correctWordLabel;
		private Label label1;
		private Label prevGuessesLabel;
		private Label livesLabel;
	}
}