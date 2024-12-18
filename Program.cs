namespace GameHub
{
	public delegate void InputHandler(GameChoice choice);
	public delegate void MainMenuFormObserver();
	public delegate void HangmanObserver(string word, string guess, char[] guessBank, bool correctWord, bool correctGuess, bool isStartup);
	public delegate void ConnectFourObserver(int rowPlaced, bool isWin, bool isPlayerOne);
	public delegate void PlaceConnectFour(int column);
	public delegate void ControllerSwitchDel();
	public delegate void HangmanGuess(char guess);
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			MainMenuController mainMenuCntrl = new MainMenuController();
			HangmanController hangmanCntrl = new HangmanController();
			ConnectFourController connectFourCntrl = new ConnectFourController();

			MainForm mainForm = new MainForm(mainMenuCntrl.MenuInput);
			HangmanForm hangmanForm = new HangmanForm(hangmanCntrl.MenuInput, hangmanCntrl.MadeGuess);
			ConnectFourForm connectFourForm = new ConnectFourForm(connectFourCntrl.MenuInput, connectFourCntrl.MakeMove);

			mainMenuCntrl.SetDelegates(mainForm.ShowForm, hangmanCntrl.Start, connectFourCntrl.Start);
			hangmanCntrl.SetDelegates(hangmanForm.UpdateView, mainMenuCntrl.BackToMain);
			connectFourCntrl.SetDelegates(connectFourForm.UpdateView, mainMenuCntrl.BackToMain);

			Application.Run(mainForm);
		}
	}
}