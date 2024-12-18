using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub
{
	public class ConnectFourController
	{
		private const int ROWS = 6;
		private const int COLUMNS = 7;
		private int[,] board = new int[ROWS, COLUMNS]; //0 = empty, 1 = player 1, 2 = player 2
		private bool isPlayerOne = true;
		private ControllerSwitchDel cntrlDel;
		private ConnectFourObserver obs;

		public void SetDelegates(ConnectFourObserver cfo, ControllerSwitchDel c)
		{
			obs = cfo;
			cntrlDel = c;
		}

		/// <summary>
		/// Called on the first bootup of connect 4
		/// </summary>
		public void Start()
		{
			ResetValues();
			obs(-1, false, isPlayerOne);
		}

		/// <summary>
		/// Controls the inputs sent by the hangman form
		/// </summary>
		/// <param name="choice">The state of the game</param>
		public void MenuInput(GameChoice choice)
		{
			switch (choice)
			{
				case GameChoice.Menu:
					cntrlDel();
					break;
			}
		}

		public void MakeMove(int column) 
		{
			int rowPlaced = -1;
			int toPlace;
			bool isWin = false;
			if (isPlayerOne) toPlace = 1;
			else toPlace = 2;
			for (int i = ROWS-1; i >= 0; i--) 
			{
				if (board[i, column] == 0) 
				{
					board[i, column] = toPlace;
					rowPlaced = i;
					Debug.WriteLine($"Piece Placed at Row: {i} Column: {column}");
					isPlayerOne = !isPlayerOne;
					break;
				}
			}
			if (CheckForWin()) isWin = true;
			obs(rowPlaced, isWin, isPlayerOne);
		}

		/// <summary>
		/// Checks for a win
		/// </summary>
		/// <returns>whether or not the player won</returns>
		public bool CheckForWin() 
		{
			return false;
		}

		/// <summary>
		/// Reset variables for start of game
		/// </summary>
		public void ResetValues() 
		{
			isPlayerOne = true;
			for (int i = 0; i < ROWS; i++) 
			{
				for (int j = 0; j < COLUMNS; j++) 
				{
					board[i, j] = 0;
				}
			}
		}
	}
}
