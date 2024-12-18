using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GameHub
{
	public partial class HangmanForm : Form
	{
		public InputHandler handler;
		public HangmanGuess guessHandler;
		private static string CORRECT_WORD;
		private string guessedWord;
		private int lives;

		/// <summary>
		/// Constructor for form
		/// </summary>
		/// <param name="h">Method in the controller for a button click</param>
		/// <param name="g">method for making a guess</param>
		public HangmanForm(InputHandler h, HangmanGuess g)
		{
			InitializeComponent();
			handler = h;
			guessHandler = g;
			lives = 6;
		}

		/// <summary>
		/// Updates the view based on the action
		/// </summary>
		/// <param name="word">the correct word</param>
		/// <param name="guess">the currently guessed word</param>
		/// <param name="bank">the letters already guesssed</param>
		/// <param name="correctWord">If your guessed word is correct</param>
		/// <param name="correctLetter">If the letter is correct</param>
		/// <param name="isStartup">If the form is just starting up</param>
		public void UpdateView(string word, string guess, char[] bank, bool correctWord, bool correctLetter, bool isStartup)
		{
			if (isStartup)
			{
				lives = 6;
				Show();
			}
			if (!correctLetter) lives--;
			CheckForLives();
			livesLabel.Text = "Lives: " + lives;
			DrawCharacter();
			if (guess.Equals("ALREADY GUESSED"))
			{
				MessageBox.Show("Character already guessed");
				guessTextBox.Clear();
			}
			else
			{
				guessTextBox.Clear();
				CORRECT_WORD = word;
				prevGuessesLabel.Text = new string(bank.OrderBy(c => c).ToArray());
				correctWordLabel.Text = guess.ToUpper();
				if (correctWord)
				{
					MessageBox.Show("You Win!\nThe Word was " + CORRECT_WORD);
					handler(GameChoice.Menu);
					Hide();
				}
			}
		}

		/// <summary>
		/// Handles action for back button clicked
		/// </summary>
		/// <param name="sender">The object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void backBtn_Click(object sender, EventArgs e)
		{
			Hide();
			handler(GameChoice.Menu);
		}

		/// <summary>
		/// Handles action for guess button clicked
		/// </summary>
		/// <param name="sender">The object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void makeGuessBtn_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(guessTextBox.Text) && char.IsLetter(guessTextBox.Text[0]))
			{
				guessHandler(guessTextBox.Text[0]);
			}
			else
			{
				MessageBox.Show("Please enter a character a to z");
			}
		}

		/// <summary>
		/// Checks if the user has lives
		/// </summary>
		private void CheckForLives() 
		{
			if (lives == 0) 
			{
				MessageBox.Show("You Lost...\nThe Word Was " + CORRECT_WORD);
				Hide();
				handler(GameChoice.Menu);
			}
		}

		/// <summary>
		/// Draws the hangman picture based on how
		/// many lives you have left
		/// </summary>
		private void DrawCharacter()
		{
			using (Graphics g = CreateGraphics())
			{
				Pen pen = new Pen(Color.Black);
				int x = 300; // X position on the form
				int y = 100; // Y position on the form

				if (lives < 6)
				{
					int diameter = 50;
					g.DrawEllipse(pen, x, y, diameter, diameter);
				}
				if (lives < 5)
				{
					int bodyX = x + 50 / 2;
					int bodyStartY = y + 50;
					int bodyEndY = bodyStartY + 75;
					g.DrawLine(pen, bodyX, bodyStartY, bodyX, bodyEndY);
				}
				if (lives < 4)
				{
					int legStartX = (x + 50 / 2);
					int legStartY = (y + 125);
					int legEndY = legStartY + 50;
					int legEndX = legStartX - 20;
					g.DrawLine(pen, legStartX, legStartY, legEndX, legEndY);
				}
				if (lives < 3)
				{
					int legStartX = (x + 50 / 2);
					int legStartY = (y + 125);
					int legEndY = legStartY + 50;
					int legEndX = legStartX + 20;
					g.DrawLine(pen, legStartX, legStartY, legEndX, legEndY);
				}
				if (lives < 2)
				{
					int armStartX = (x + 50 / 2);
					int armY = (y + 75);
					int armEndX = armStartX - 20;
					g.DrawLine(pen, armStartX, armY, armEndX, armY);
				}
				if (lives < 1)
				{
					int armStartX = (x + 50 / 2);
					int armY = (y + 75);
					int armEndX = armStartX + 20;
					g.DrawLine(pen, armStartX, armY, armEndX, armY);
				}
			}
		}

		/// <summary>
		/// Handles action for drawing on startup
		/// </summary>
		/// <param name="sender">The object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void HangmanForm_Paint(object sender, PaintEventArgs e)
		{
			using (Graphics g = CreateGraphics())
			{
				Pen pen = new Pen(Color.Black);
				int x = 300; // X position on the form
				int y = 100; // Y position on the form

				// Draw the base of the hangman
				g.DrawLine(new Pen(Color.Black, 5), x - 50, y + 200, x, y + 200); //base
				g.DrawLine(pen, x - 25, y - 25, x - 25, y + 200); // Vertical post
				g.DrawLine(pen, x - 25, y - 25, x + 25, y - 25); // Horizontal bar
				g.DrawLine(pen, x + 25, y - 25, x + 25, y); // Rope

				if (lives < 6)
				{
					int diameter = 50;
					g.DrawEllipse(pen, x, y, diameter, diameter);
				}
				if (lives < 5)
				{
					int bodyX = x + 50 / 2;
					int bodyStartY = y + 50;
					int bodyEndY = bodyStartY + 75;
					g.DrawLine(pen, bodyX, bodyStartY, bodyX, bodyEndY);
				}
				if (lives < 4)
				{
					int legStartX = (x + 50 / 2);
					int legStartY = (y + 125);
					int legEndY = legStartY + 50;
					int legEndX = legStartX - 20;
					g.DrawLine(pen, legStartX, legStartY, legEndX, legEndY);
				}
				if (lives < 3)
				{
					int legStartX = (x + 50 / 2);
					int legStartY = (y + 125);
					int legEndY = legStartY + 50;
					int legEndX = legStartX + 20;
					g.DrawLine(pen, legStartX, legStartY, legEndX, legEndY);
				}
				if (lives < 2)
				{
					int armStartX = (x + 50 / 2);
					int armY = (y + 75);
					int armEndX = armStartX - 20;
					g.DrawLine(pen, armStartX, armY, armEndX, armY);
				}
				if (lives < 1)
				{
					int armStartX = (x + 50 / 2);
					int armY = (y + 75);
					int armEndX = armStartX + 20;
					g.DrawLine(pen, armStartX, armY, armEndX, armY);
				}
			}
		}
	}
}
