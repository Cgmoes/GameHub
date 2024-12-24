namespace GameHub
{
	partial class SPConnectFourForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			boardTablePanel = new TableLayoutPanel();
			dropPieceBtn = new Button();
			backBtn = new Button();
			titleLabel = new Label();
			SuspendLayout();
			// 
			// boardTablePanel
			// 
			boardTablePanel.BackColor = SystemColors.ActiveCaption;
			boardTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			boardTablePanel.ColumnCount = 7;
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
			boardTablePanel.Location = new Point(132, 90);
			boardTablePanel.Name = "boardTablePanel";
			boardTablePanel.RowCount = 6;
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
			boardTablePanel.Size = new Size(505, 333);
			boardTablePanel.TabIndex = 4;
			boardTablePanel.Click += boardTablePanel_Click;
			boardTablePanel.Paint += boardTablePanel_Paint;
			// 
			// dropPieceBtn
			// 
			dropPieceBtn.Location = new Point(664, 205);
			dropPieceBtn.Name = "dropPieceBtn";
			dropPieceBtn.Size = new Size(75, 23);
			dropPieceBtn.TabIndex = 5;
			dropPieceBtn.Text = "Drop Piece";
			dropPieceBtn.UseVisualStyleBackColor = true;
			dropPieceBtn.Click += dropPieceBtn_Click;
			// 
			// backBtn
			// 
			backBtn.Location = new Point(12, 415);
			backBtn.Name = "backBtn";
			backBtn.Size = new Size(89, 23);
			backBtn.TabIndex = 6;
			backBtn.Text = "Back To Menu";
			backBtn.UseVisualStyleBackColor = true;
			backBtn.Click += backBtn_Click;
			// 
			// titleLabel
			// 
			titleLabel.AutoSize = true;
			titleLabel.Font = new Font("Segoe UI Variable Small Semibol", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			titleLabel.Location = new Point(271, -9);
			titleLabel.Name = "titleLabel";
			titleLabel.Size = new Size(196, 49);
			titleLabel.TabIndex = 3;
			titleLabel.Text = "Connect 4";
			// 
			// SPConnectFourForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveBorder;
			ClientSize = new Size(800, 450);
			Controls.Add(titleLabel);
			Controls.Add(backBtn);
			Controls.Add(dropPieceBtn);
			Controls.Add(boardTablePanel);
			Name = "SPConnectFourForm";
			Text = "SPConnectFourForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TableLayoutPanel boardTablePanel;
		private Button dropPieceBtn;
		private Button backBtn;
		private Label titleLabel;
	}
}