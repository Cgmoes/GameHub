namespace GameHub
{
	public delegate void InputHandler(GameChoice choice);
	public delegate void MainMenuFormObserver();
	public delegate void HangmanObserver(string word, string guess, char[] guessBank, bool correctWord, bool correctGuess, bool isStartup);
	public delegate void ConnectFourObserver(int rowPlaced, bool isWin, bool isPlayerOne);
	public delegate void AiConnectFourObserver(int rowPlaced, int colPlaced, bool isWin, bool isPlayerOne);
	public delegate void PlaceConnectFour(int column);
	public delegate void ControllerSwitchDel();
	public delegate void HangmanGuess(char guess);
	public delegate void AiPlaceConnectFour();
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
			MPConnectFourController mpConnectFourCntrl = new MPConnectFourController();
			SPConnectFourController spConnectFourCntrl = new SPConnectFourController();

			MainForm mainForm = new MainForm(mainMenuCntrl.MenuInput);
			HangmanForm hangmanForm = new HangmanForm(hangmanCntrl.MenuInput, hangmanCntrl.MadeGuess);
			MPConnectFourForm mpConnectFourForm = new MPConnectFourForm(mpConnectFourCntrl.MenuInput, mpConnectFourCntrl.MakeMove);
			SPConnectFourForm spConnectFourForm = new SPConnectFourForm(spConnectFourCntrl.MenuInput, spConnectFourCntrl.MakeMove, spConnectFourCntrl.AiMove);

			mainMenuCntrl.SetDelegates(mainForm.ShowForm, hangmanCntrl.Start, mpConnectFourCntrl.Start, spConnectFourCntrl.Start);
			hangmanCntrl.SetDelegates(hangmanForm.UpdateView, mainMenuCntrl.BackToMain);
			mpConnectFourCntrl.SetDelegates(mpConnectFourForm.UpdateView, mainMenuCntrl.BackToMain);
			spConnectFourCntrl.SetDelegates(spConnectFourForm.UpdateView, mainMenuCntrl.BackToMain, spConnectFourForm.UpdateViewFromAi);

			Application.Run(mainForm);
		}
	}
}