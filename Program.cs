namespace GameHub
{
	public delegate void InputHandler(GameChoice choice);
	public delegate void HangmanObserver();
	public delegate void MainObserver();
	public delegate void ControllerHandler(GameChoice choice);
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
			MainForm main = new MainForm(mainMenuCntrl.MenuInput);
			HangmanForm hangman = new HangmanForm(mainMenuCntrl.MenuInput);
			mainMenuCntrl.SetDelegates(hangman.UpdateView, main.ShowForm);

			Application.Run(main);
		}
	}
}