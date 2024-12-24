namespace GameHub
{
	public partial class MainForm : Form
	{
		private InputHandler inputHandler;
		public MainForm(InputHandler del)
		{
			InitializeComponent();
			inputHandler = del;
		}

		private void hangmanBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.Hangman);
			Hide();
		}

		public void ShowForm()
		{
			Show();
		}

		private void mpConnectFourBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.TwoPlayerConnectFour);
			Hide();
		}

		private void spConnectFourBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.SinglePlayerConnectFour);
			Hide();
		}
	}
}
