using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHub
{
	public partial class ConnectFourForm : Form
	{
		public InputHandler handler;
		public PlaceConnectFour placePiece;
		private int columnClicked;
		private bool isPlayerOne;

		public ConnectFourForm(InputHandler i, PlaceConnectFour p)
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

		public void UpdateView(int rowPlaced, bool isWin, bool player)
		{
			isPlayerOne = player;

			if (isPlayerOne) turnLabel.Text = "Turn:\nPlayer 1";
			else turnLabel.Text = "Turn:\nPlayer 2";

			DrawPiece(rowPlaced, columnClicked, false);
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
			DrawPiece(rowClicked, columnClicked, true);
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

		private void DrawPiece(int row, int column, bool isTempPlaced) 
		{
			using (Graphics g = boardTablePanel.CreateGraphics())
			{
				int cellWidth = boardTablePanel.Width / boardTablePanel.ColumnCount;
				int cellHeight = boardTablePanel.Height / boardTablePanel.RowCount;

				// Calculate the position of the circle
				int x = columnClicked * cellWidth + cellWidth / 10; // Offset for padding
				int y = row * cellHeight + cellHeight / 10;

				int diameter = Math.Min(cellWidth, cellHeight) - 2 * (cellWidth / 10); // Ensure circle fits

				if (!isTempPlaced)
				{
					if (isPlayerOne) g.FillEllipse(Brushes.Red, x, y, diameter, diameter);
					else g.FillEllipse(Brushes.Yellow, x, y, diameter, diameter);
				}
			}
		}
	}
}
