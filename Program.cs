namespace GameHub
{
	public delegate void InputHandler(GameChoice choice);
	public delegate void FormObserver();
	public delegate void HangmanObserver(string word, string guess, char[] guessBank, bool correctWord, bool correctGuess, bool isStartup);
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
			MainForm main = new MainForm(mainMenuCntrl.MenuInput);
			HangmanForm hangman = new HangmanForm(hangmanCntrl.MenuInput, hangmanCntrl.MadeGuess);
			mainMenuCntrl.SetDelegates(main.ShowForm, hangmanCntrl.Start);
			hangmanCntrl.SetDelegates(hangman.UpdateView, mainMenuCntrl.BackToMain);

			Application.Run(main);
		}
	}
}