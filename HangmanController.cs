using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class HangmanController
	{
		private FormObserver hangmanObs;
		private ControllerSwitchDel cntrlDel;

		public void SetDelegates(FormObserver h, ControllerSwitchDel c)
		{
			hangmanObs = h;
			cntrlDel = c;
		}

		public void MenuInput(GameChoice choice)
		{
			switch (choice)
			{
				case GameChoice.Menu:
					cntrlDel();
					break;
			}
		}

		public void Start() 
		{
			hangmanObs();
		}
	}
}
