namespace GameHub
{
	public partial class MainForm : Form
	{
		private InputHandler inputHandler;

		/// <summary>
		/// Constructor for main form
		/// </summary>
		/// <param name="del">the inpout handler delegate method</param>
		public MainForm(InputHandler del)
		{
			InitializeComponent();
			inputHandler = del;
		}

		/// <summary>
		/// Handles the hangman button clicked event
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void hangmanBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.Hangman);
			Hide();
		}

		/// <summary>
		/// Method to show the form
		/// </summary>
		public void ShowForm()
		{
			Show();
		}

		/// <summary>
		/// Handles the multiplayer connect 4 button clicked event
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void mpConnectFourBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.TwoPlayerConnectFour);
			Hide();
		}

		/// <summary>
		/// Handles the single player connect 4 button clicked event
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void spConnectFourBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.SinglePlayerConnectFour);
			Hide();
		}
	}
}
