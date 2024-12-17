using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class MainMenuController
	{
		private FormObserver mainObserver;
		private ControllerSwitchDel hangmanController;

		public void SetDelegates(FormObserver m, ControllerSwitchDel c) 
		{
			mainObserver = m;
			hangmanController = c;
		}

		public void MenuInput(GameChoice choice) 
		{
			switch (choice) 
			{
				case GameChoice.Hangman:
					hangmanController();
					break;
			}
		}

		public void BackToMain() 
		{
			mainObserver();
		}
	}
}
