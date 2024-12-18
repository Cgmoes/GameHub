using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class MainMenuController
	{
		private MainMenuFormObserver mainObserver;
		private ControllerSwitchDel hangmanController;
		private ControllerSwitchDel connectFourController;

		public void SetDelegates(MainMenuFormObserver m, ControllerSwitchDel h, ControllerSwitchDel cf) 
		{
			mainObserver = m;
			hangmanController = h;
			connectFourController = cf;
		}

		/// <summary>
		/// Controls the menu inputs from the main menu
		/// </summary>
		/// <param name="choice">The game that was selected</param>
		public void MenuInput(GameChoice choice) 
		{
			switch (choice) 
			{
				case GameChoice.Hangman:
					hangmanController();
					break;
				case GameChoice.ConnectFour:
					connectFourController();
					break;
			}
		}

		/// <summary>
		/// Switches forms back to the main form
		/// </summary>
		public void BackToMain() 
		{
			mainObserver();
		}
	}
}
