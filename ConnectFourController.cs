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

		/// <summary>
		/// Makes a move by adding the piece to the board
		/// </summary>
		/// <param name="column">the column the piece is added to</param>
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

					isWin = CheckForWin();
					isPlayerOne = !isPlayerOne;
					break;
				}
			}

			obs(rowPlaced, isWin, isPlayerOne);
		}

		/// <summary>
		/// Checks for a win
		/// </summary>
		/// <returns>whether or not the player won</returns>
		public bool CheckForWin() 
		{
			int curPiece;
			if (isPlayerOne) curPiece = 1;
			else curPiece = 2;

			// Horizontal check
			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == curPiece && board[row, col + 1] == curPiece && board[row, col + 2] == curPiece && board[row, col + 3] == curPiece) return true;
				}
			}

			// Vertical check
			for (int col = 0; col < COLUMNS; col++)
			{
				for (int row = 0; row <= ROWS - 4; row++)
				{
					if (board[row, col] == curPiece && board[row + 1, col] == curPiece && board[row + 2, col] == curPiece && board[row + 3, col] == curPiece) return true;
				}
			}

			// Ascending diagonal check
			for (int row = 3; row < ROWS; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == curPiece && board[row - 1, col + 1] == curPiece && board[row - 2, col + 2] == curPiece && board[row - 3, col + 3] == curPiece) return true;
				}
			}

			// Descending diagonal check
			for (int row = 0; row <= ROWS - 4; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == curPiece && board[row + 1, col + 1] == curPiece && board[row + 2, col + 2] == curPiece && board[row + 3, col + 3] == curPiece) return true;
				}
			}
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
