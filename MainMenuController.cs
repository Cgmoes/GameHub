using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class MainMenuController
	{
		private HangmanObserver hangmanObserver;
		private MainObserver mainObserver;

		public void SetDelegates(HangmanObserver h, MainObserver m) 
		{
			hangmanObserver = h;
			mainObserver = m;
		}

		public void MenuInput(GameChoice choice) 
		{
			switch (choice) 
			{
				case GameChoice.Hangman:
					hangmanObserver();
					break;
				case GameChoice.Menu:
					mainObserver();
					break;
			}
		}
	}
}
