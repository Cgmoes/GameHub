﻿using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHub
{
	public partial class SPConnectFourForm : Form
	{
		public InputHandler handler;
		public PlaceConnectFour placePiece;
		public AiPlaceConnectFour aiPlace;
		private int columnClicked;
		private bool isAi;
		int tempCol = -1;

		/// <summary>
		/// Constructor for the form
		/// </summary>
		/// <param name="i">the input handler method</param>
		/// <param name="p">the player place piece method in controller</param>
		/// <param name="ai">the ai place piece method in controller</param>
		public SPConnectFourForm(InputHandler i, PlaceConnectFour p, AiPlaceConnectFour ai)
		{
			InitializeComponent();
			handler = i;
			placePiece = p;
			aiPlace = ai;
		}

		/// <summary>
		/// Updates the view after the player makes a move
		/// </summary>
		/// <param name="rowPlaced">the row the piece was placed in</param>
		/// <param name="isWin">if it is a winning move</param>
		/// <param name="player">the player</param>
		public void UpdateView(int rowPlaced, bool isWin, bool player)
		{
			isAi = !player;
			ClearTempPiece(tempCol);
			DrawPiece(rowPlaced, columnClicked, false);

			if (isWin)
			{
				if (isAi) MessageBox.Show($"Yellow Wins!\nPress OK to go back to Main Menu");
				else MessageBox.Show($"Red Wins!\nPress OK to go back to Main Menu");
				Hide();
				handler(GameChoice.Menu);
			}
			else Show();
		}

		/// <summary>
		/// Updates the view after the ai makes a move
		/// </summary>
		/// <param name="rowPlaced">the row the piece was placed in</param>
		/// <param name="colPlaced">the column it was placed in</param>
		/// <param name="isWin">if it is a winning move</param>
		/// <param name="player">the player</param>
		public void UpdateViewFromAi(int rowPlaced, int colPlaced, bool isWin, bool player)
		{
			isAi = player;
			DrawPiece(rowPlaced, colPlaced, false);

			if (isWin)
			{
				if (isAi) MessageBox.Show($"Yellow Wins!\nPress OK to go back to Main Menu");
				else MessageBox.Show($"Red Wins!\nPress OK to go back to Main Menu");
				Hide();
				handler(GameChoice.Menu);
			}
			else Show();
		}

		/// <summary>
		/// Clears the temporary piece drawing from the form
		/// </summary>
		/// <param name="col">the column the piece was in</param>
		private void ClearTempPiece(int col)
		{
			using (Graphics g = CreateGraphics()) //Draws the temporary piece to show where it is being placed
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				// Calculate the position of the circle
				int x = (col * cellWidth + (cellWidth - Math.Min(cellWidth, cellHeight)) / 2) + (cellWidth * 2) - 8;
				int y = cellHeight + (cellHeight - Math.Min(cellWidth, cellHeight)) / 2;

				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits
				Color c = this.BackColor;
				SolidBrush brush = new SolidBrush(c);
				g.FillEllipse(brush, x, 40, diameter, diameter);
			}
		}

		/// <summary>
		/// Handles event if back button is clicked
		/// </summary>
		/// <param name="sender">the object signaling the event</param>
		/// <param name="e">information about the event</param>
		private void backBtn_Click(object sender, EventArgs e)
		{
			Hide();
			handler(GameChoice.Menu);
		}

		/// <summary>
		/// Handles event if drop piece button is clicked
		/// </summary>
		/// <param name="sender">the object signaling the event</param>
		/// <param name="e">information about the event</param>
		private async void dropPieceBtn_Click(object sender, EventArgs e)
		{
			placePiece(columnClicked);
			await Task.Delay(1000);
			aiPlace();
		}

		/// <summary>
		/// Handles event if the table is being painted
		/// </summary>
		/// <param name="sender">the object signaling the event</param>
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

		/// <summary>
		/// Handles event if the table is clicked
		/// </summary>
		/// <param name="sender">the object signaling the event</param>
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
				int x = (column * cellWidth + cellWidth / 10) + 5; // Offset for padding
				int y = (row * cellHeight + cellHeight / 10) + 3;

				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits

				if (!isTempPlaced)
				{
					if (!isAi) g.FillEllipse(Brushes.Red, x, y - 1, diameter, diameter);
					else g.FillEllipse(Brushes.Yellow, x, y - 1, diameter, diameter);
				}
			}
			using (Graphics g = CreateGraphics()) //Draws the temporary piece to show where it is being placed
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				// Calculate the position of the circle
				int x = (column * cellWidth + (cellWidth - Math.Min(cellWidth, cellHeight)) / 2) + (cellWidth * 2)-8;
				int y = row * cellHeight + (cellHeight - Math.Min(cellWidth, cellHeight)) / 2;

				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits

				if (isTempPlaced) 
				{
					g.FillEllipse(Brushes.Pink, x, 40, diameter, diameter);
				}
			}
		}
	}
}
