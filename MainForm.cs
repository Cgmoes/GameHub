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

		private void conectFourBtn_Click(object sender, EventArgs e)
		{
			inputHandler(GameChoice.ConnectFour);
			Hide();
		}
	}
}
