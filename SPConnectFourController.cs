using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameHub
{
	public class SPConnectFourController
	{
		private const int ROWS = 6;
		private const int COLUMNS = 7;
		private int[,] board = new int[ROWS, COLUMNS]; //0 = empty, 1 = player 1, 2 = ai
		private bool isPlayerOne = true;
		private ControllerSwitchDel cntrlDel;
		private ConnectFourObserver obs;
		private AiConnectFourObserver obsAi;

		public void SetDelegates(ConnectFourObserver cfo, ControllerSwitchDel c, AiConnectFourObserver ai)
		{
			obs = cfo;
			cntrlDel = c;
			obsAi = ai;
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

		/// <summary>
		/// Checks for a win
		/// </summary>
		/// <returns>whether or not the player won</returns>
		public bool CheckForWin(int player)
		{

			// Horizontal check
			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == player && board[row, col + 1] == player && board[row, col + 2] == player && board[row, col + 3] == player) return true;
				}
			}
			// Vertical check
			for (int col = 0; col < COLUMNS; col++)
			{
				for (int row = 0; row <= ROWS - 4; row++)
				{
					if (board[row, col] == player && board[row + 1, col] == player && board[row + 2, col] == player && board[row + 3, col] == player) return true;
				}
			}
			// Ascending diagonal check
			for (int row = 3; row < ROWS; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == player && board[row - 1, col + 1] == player && board[row - 2, col + 2] == player && board[row - 3, col + 3] == player) return true;
				}
			}
			// Descending diagonal check
			for (int row = 0; row <= ROWS - 4; row++)
			{
				for (int col = 0; col <= COLUMNS - 4; col++)
				{
					if (board[row, col] == player && board[row + 1, col + 1] == player && board[row + 2, col + 2] == player && board[row + 3, col + 3] == player) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Makes a move by adding the piece to the board
		/// </summary>
		/// <param name="column">the column the piece is added to</param>
		public void MakeMove(int column)
		{
			lock (this)
			{
				int rowPlaced = -1;
				bool isWin = PlayerMove(column);
			}
		}

		/// <summary>
		/// Handles action if the player placed a piece
		/// </summary>
		/// <param name="column">the column the piece was placed</param>
		/// <returns></returns>
		public bool PlayerMove(int column)
		{
			lock (this)
			{
				int rowPlaced = -1;
				bool isWin = false;
				for (int i = ROWS - 1; i >= 0; i--)
				{
					if (board[i, column] == 0)
					{
						board[i, column] = 1;
						rowPlaced = i;

						isWin = CheckForWin(1);
						isPlayerOne = !isPlayerOne;
						break;
					}
				}
				obs(rowPlaced, isWin, true);
				return isWin;
			}
		}

		#region Ai Methods
		public void AiMove()
		{
			lock (this)
			{
				bool isWin = false;

				(int bestScore, int bestColumn) = Minimax(board, 3, int.MinValue, int.MaxValue, true);

				if (bestColumn != -1)
				{
					int row = GetNextValidRow(board, bestColumn);
					board[row, bestColumn] = 2;
					isWin = CheckForWin(2);
					isPlayerOne = !isPlayerOne;
					obsAi(row, bestColumn, isWin, true);
				}
			}
		}

		private int GetNextValidRow(int[,] board, int column)
		{
			for (int row = ROWS - 1; row >= 0; row--)
			{
				if (board[row, column] == 0) return row;
			}
			return -1;
		}

		private int EvaluateLine(int playerCount, int opponentCount)
		{
			if (playerCount == 4) return 1000; // AI wins
			if (opponentCount == 4) return -1000; // Opponent wins

			// Favor 3-in-a-row (with one empty spot)
			if (playerCount == 3 && opponentCount == 0) return 100; // AI advantage
			if (opponentCount == 3 && playerCount == 0) return -100; // Opponent advantage

			// Favor 2-in-a-row (with two empty spots)
			if (playerCount == 2 && opponentCount == 0) return 100; // AI advantage
			if (opponentCount == 2 && playerCount == 0) return -100; // Opponent advantage

			return 0; // Neutral
		}

		private int EvaluateBoard(int[,] board)
		{
			int score = 0;

			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col < COLUMNS; col++)
				{
					if (board[row, col] == 0) continue;

					// Horizontal evaluation
					if (col <= COLUMNS - 4)
					{
						int playerCount = 0, opponentCount = 0;
						for (int i = 0; i < 4; i++)
						{
							if (board[row, col + i] == 1) opponentCount++;
							else if (board[row, col + i] == 2) playerCount++;
						}
						score += EvaluateLine(playerCount, opponentCount);
					}

					// Vertical evaluation
					if (row <= ROWS - 4)
					{
						int playerCount = 0, opponentCount = 0;
						for (int i = 0; i < 4; i++)
						{
							if (board[row + i, col] == 1) opponentCount++;
							else if (board[row + i, col] == 2) playerCount++;
						}
						score += EvaluateLine(playerCount, opponentCount);
					}

					// Ascending diagonal evaluation
					if (row >= 3 && col <= COLUMNS - 4)
					{
						int playerCount = 0, opponentCount = 0;
						for (int i = 0; i < 4; i++)
						{
							if (board[row - i, col + i] == 1) opponentCount++;
							else if (board[row - i, col + i] == 2) playerCount++;
						}
						score += EvaluateLine(playerCount, opponentCount);
					}

					// Descending diagonal evaluation
					if (row <= ROWS - 4 && col <= COLUMNS - 4)
					{
						int playerCount = 0, opponentCount = 0;
						for (int i = 0; i < 4; i++)
						{
							if (board[row + i, col + i] == 1) opponentCount++;
							else if (board[row + i, col + i] == 2) playerCount++;
						}
						score += EvaluateLine(playerCount, opponentCount);
					}
				}
			}
			return score;
		}

		private (int, int) Minimax(int[,] board, int depth, int alpha, int beta, bool isMaximizingPlayer)
		{
			if (depth == 0 || CheckForWin(1) || CheckForWin(2)) return (EvaluateBoard(board), -1);

			int bestCol = -1;

			if (isMaximizingPlayer)
			{
				int bestScore = int.MinValue;

				for (int col = 0; col < COLUMNS; col++)
				{
					if (board[0, col] == 0)
					{
						int row = GetNextValidRow(board, col);
						board[row, col] = 2;

						int score = Minimax(board, depth - 1, alpha, beta, false).Item1;

						board[row, col] = 0;

						if (score > bestScore)
						{
							bestScore = score;
							bestCol = col;
						}

						alpha = Math.Max(alpha, bestScore);
						if (beta <= alpha) break;
					}
				}
				return (bestScore, bestCol);
			}
			else
			{
				int bestScore = int.MaxValue;

				for (int col = 0; col < COLUMNS; col++)
				{
					if (board[0, col] == 0)
					{
						int row = GetNextValidRow(board, col);
						board[row, col] = 1;

						int score = Minimax(board, depth - 1, alpha, beta, true).Item1;

						board[row, col] = 0;

						if (score < bestScore)
						{
							bestScore = score;
							bestCol = col;
						}

						beta = Math.Min(beta, bestScore);
						if (beta <= alpha) break;
					}
				}
				return (bestScore, bestCol);
			}
		}
		#endregion
	}
}
