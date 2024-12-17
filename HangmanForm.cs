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
	public partial class HangmanForm : Form
	{
		public InputHandler handler;
		public HangmanForm(InputHandler h)
		{
			InitializeComponent();
			handler = h;
		}

		public void UpdateView()
		{
			Show();
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			Hide();
			handler(GameChoice.Menu);
		}
	}
}
