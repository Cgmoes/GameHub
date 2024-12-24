using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		public SPConnectFourForm(InputHandler i, PlaceConnectFour p, AiPlaceConnectFour ai)
		{
			InitializeComponent();
			handler = i;
			placePiece = p;
			aiPlace = ai;
		}

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

		private void backBtn_Click(object sender, EventArgs e)
		{
			Hide();
			handler(GameChoice.Menu);
		}

		private async void dropPieceBtn_Click(object sender, EventArgs e)
		{
			placePiece(columnClicked);
			await Task.Delay(1000);
			aiPlace();
		}

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
				else g.FillEllipse(Brushes.Pink, x, 7, diameter, diameter);
			}
		}
	}
}
