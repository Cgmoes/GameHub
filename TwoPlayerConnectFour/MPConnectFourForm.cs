using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHub
{
	public partial class MPConnectFourForm : Form
	{
		public InputHandler handler;
		public PlaceConnectFour placePiece;
		private int columnClicked;
		private bool isPlayerOne;
		int tempCol = -1;

		/// <summary>
		/// Constructor for the form
		/// </summary>
		/// <param name="i">method in controller to handle inputs</param>
		/// <param name="p">method in controller to handle if a piece is placed</param>
		public MPConnectFourForm(InputHandler i, PlaceConnectFour p)
		{
			InitializeComponent();
			handler = i;
			placePiece = p;
		}

		/// <summary>
		/// Handles if the back button is clicked
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void backBtn_Click(object sender, EventArgs e)
		{
			Hide();
			handler(GameChoice.Menu);
		}

		/// <summary>
		/// Updates the form after a move is made
		/// </summary>
		/// <param name="rowPlaced">the row the piece was placed in</param>
		/// <param name="isWin">if it is a winning move</param>
		/// <param name="player">the player</param>
		public void UpdateView(int rowPlaced, bool isWin, bool player)
		{
			isPlayerOne = player;

			ClearTempPiece(tempCol);
			DrawPiece(rowPlaced, columnClicked, false);
			if (isWin)
			{
				if (isPlayerOne) MessageBox.Show($"Red Wins!\nPress OK to go back to Main Menu");
				else MessageBox.Show($"Yellow Wins!\nPress OK to go back to Main Menu");
				Hide();
				handler(GameChoice.Menu);
			}
			if (isPlayerOne) turnLabel.Text = "Turn:\nYellow";
			else turnLabel.Text = "Turn:\nRed";

			Show();
		}

		/// <summary>
		/// Handles if the board is clicked
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void boardTablePanel_Click(object sender, EventArgs e)
		{
			Point mousePos = boardTablePanel.PointToClient(Cursor.Position);
			int columnWidth = boardTablePanel.Width / 7;
			int rowWidth = boardTablePanel.Height / 6;
			columnClicked = mousePos.X / columnWidth;
			int rowClicked = mousePos.Y / rowWidth;

			if (tempCol != -1) ClearTempPiece(tempCol);

			tempCol = columnClicked;
			DrawPiece(rowClicked, columnClicked, true);
		}

		/// <summary>
		/// Clears the temporary piece off the form
		/// </summary>
		/// <param name="col">the column the piece was in</param>
		private void ClearTempPiece(int col)
		{
			using (Graphics g = boardTablePanel.CreateGraphics())
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				// Calculate the position of the rectangle to clear
				int x = (col * cellWidth + cellWidth / 10) + 5; // Offset for padding
				int y = (cellHeight / 10) + 2;
				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits
				Color c = this.BackColor;
				SolidBrush brush = new SolidBrush(c);
				// Clear the cell by drawing a rectangle matching the board background
				g.FillEllipse(brush, x, y, diameter, diameter);
			}
		}

		/// <summary>
		/// Handles if the drop piece button is clicked
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void dropPieceBtn_Click(object sender, EventArgs e)
		{
			placePiece(columnClicked);
		}

		/// <summary>
		/// Draws a piece on the board
		/// </summary>
		/// <param name="row">the row to be placed in</param>
		/// <param name="column">the column to be placed in</param>
		/// <param name="isTempPlaced">if the piece is meant to be placed</param>
		private void DrawPiece(int row, int column, bool isTempPlaced)
		{
			using (Graphics g = boardTablePanel.CreateGraphics())
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				// Calculate the position of the circle
				int x = (columnClicked * cellWidth + cellWidth / 10) + 5; // Offset for padding
				int y = (row * cellHeight + cellHeight / 10) + 3;

				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits

				if (!isTempPlaced)
				{
					if (isPlayerOne) g.FillEllipse(Brushes.Red, x, y-1, diameter, diameter);
					else g.FillEllipse(Brushes.Yellow, x, y-1, diameter, diameter);
				}
				else
				{
					if (isPlayerOne) g.FillEllipse(Brushes.LightGoldenrodYellow, x, 7, diameter, diameter);
					else g.FillEllipse(Brushes.Pink, x, 7, diameter, diameter);
				}
			}
		}

		/// <summary>
		/// Draws the holes in the board on startup
		/// </summary>
		/// <param name="sender">object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void boardTablePanel_Paint(object sender, PaintEventArgs e)
		{
			using (Graphics g = boardTablePanel.CreateGraphics())
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				for (int row = 0; row < boardTablePanel.RowCount; row++)
				{
					for (int col = 0; col < boardTablePanel.ColumnCount; col++)
					{
						// Calculate the position of the circle
						int x = (col * cellWidth + cellWidth / 10) + 5; // Offset for padding
						int y = (row * cellHeight + cellHeight / 10) + 2;
						int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits
						Color c = this.BackColor;
						SolidBrush brush = new SolidBrush(c);
						g.FillEllipse(brush, x, y, diameter, diameter);
					}
				}
			}
		}
	}
}
