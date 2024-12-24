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
		private ControllerSwitchDel mpConnectFourController;
		private ControllerSwitchDel spConnectFourController;

		/// <summary>
		/// Sets the delegates of the main menu controller
		/// </summary>
		/// <param name="m">the observer method for main form</param>
		/// <param name="h">the controller for hangman</param>
		/// <param name="mcf">the controller for multiplayer connect 4</param>
		/// <param name="spcf">the controller for singleplayer connect 4</param>
		public void SetDelegates(MainMenuFormObserver m, ControllerSwitchDel h, ControllerSwitchDel mcf, ControllerSwitchDel spcf) 
		{
			mainObserver = m;
			hangmanController = h;
			mpConnectFourController = mcf;
			spConnectFourController = spcf;
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
				case GameChoice.TwoPlayerConnectFour:
					mpConnectFourController();
					break;
				case GameChoice.SinglePlayerConnectFour:
					spConnectFourController();
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
