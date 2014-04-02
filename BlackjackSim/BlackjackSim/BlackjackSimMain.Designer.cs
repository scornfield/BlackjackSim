namespace BlackjackSim
{
    partial class BlackjackSimMain
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.txtNumInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumHands = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumDecks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClearStats = new System.Windows.Forms.Button();
            this.gridStats = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblNumDecks = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblNumHands = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblNumPlayers = new System.Windows.Forms.ToolStripLabel();
            this.statusHandCount = new System.Windows.Forms.ToolStripLabel();
            this.statusTimer = new System.Windows.Forms.ToolStripLabel();
            this.statusToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Losses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Busts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pushes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blackjacks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStats)).BeginInit();
            this.statusToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.Controls.Add(this.txtNumInterval);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.txtNumHands);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.txtNumDecks);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Location = new System.Drawing.Point(10, 60);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSettings.Size = new System.Drawing.Size(1114, 122);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // txtNumInterval
            // 
            this.txtNumInterval.Location = new System.Drawing.Point(776, 31);
            this.txtNumInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumInterval.Name = "txtNumInterval";
            this.txtNumInterval.Size = new System.Drawing.Size(148, 26);
            this.txtNumInterval.TabIndex = 5;
            this.txtNumInterval.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(627, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Update Interval:";
            // 
            // txtNumHands
            // 
            this.txtNumHands.Location = new System.Drawing.Point(468, 31);
            this.txtNumHands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumHands.Name = "txtNumHands";
            this.txtNumHands.Size = new System.Drawing.Size(148, 26);
            this.txtNumHands.TabIndex = 3;
            this.txtNumHands.Text = "10000";
            this.txtNumHands.TextChanged += new System.EventHandler(this.txtNumHands_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Hands:";
            // 
            // txtNumDecks
            // 
            this.txtNumDecks.Location = new System.Drawing.Point(159, 31);
            this.txtNumDecks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumDecks.Name = "txtNumDecks";
            this.txtNumDecks.Size = new System.Drawing.Size(148, 26);
            this.txtNumDecks.TabIndex = 1;
            this.txtNumDecks.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of Decks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cornfield\'s Blackjack Simulator";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(1012, 535);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(112, 35);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run Sim";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClearStats
            // 
            this.btnClearStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearStats.Location = new System.Drawing.Point(891, 535);
            this.btnClearStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearStats.Name = "btnClearStats";
            this.btnClearStats.Size = new System.Drawing.Size(112, 35);
            this.btnClearStats.TabIndex = 6;
            this.btnClearStats.Text = "Clear Stats";
            this.btnClearStats.UseVisualStyleBackColor = true;
            this.btnClearStats.Click += new System.EventHandler(this.btnClearStats_Click);
            // 
            // gridStats
            // 
            this.gridStats.AllowUserToAddRows = false;
            this.gridStats.AllowUserToDeleteRows = false;
            this.gridStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Chips,
            this.Wins,
            this.Losses,
            this.Busts,
            this.Pushes,
            this.Blackjacks});
            this.gridStats.Location = new System.Drawing.Point(10, 192);
            this.gridStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridStats.Name = "gridStats";
            this.gridStats.ReadOnly = true;
            this.gridStats.Size = new System.Drawing.Size(1114, 334);
            this.gridStats.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 34);
            this.lblStatus.Text = "Status Label";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(150, 34);
            this.statusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 34);
            this.toolStripLabel1.Text = "Decks:";
            // 
            // lblNumDecks
            // 
            this.lblNumDecks.Name = "lblNumDecks";
            this.lblNumDecks.Size = new System.Drawing.Size(22, 34);
            this.lblNumDecks.Text = "0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 34);
            this.toolStripLabel2.Text = "Hands:";
            // 
            // lblNumHands
            // 
            this.lblNumHands.Name = "lblNumHands";
            this.lblNumHands.Size = new System.Drawing.Size(22, 34);
            this.lblNumHands.Text = "0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(71, 34);
            this.toolStripLabel3.Text = "Players:";
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(22, 34);
            this.lblNumPlayers.Text = "0";
            // 
            // statusHandCount
            // 
            this.statusHandCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusHandCount.Name = "statusHandCount";
            this.statusHandCount.Size = new System.Drawing.Size(39, 34);
            this.statusHandCount.Text = "0/0";
            // 
            // statusTimer
            // 
            this.statusTimer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusTimer.Name = "statusTimer";
            this.statusTimer.Size = new System.Drawing.Size(46, 34);
            this.statusTimer.Text = "0:00";
            // 
            // statusToolStrip
            // 
            this.statusToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.statusProgressBar,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.lblNumDecks,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.lblNumHands,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.lblNumPlayers,
            this.toolStripSeparator5,
            this.statusHandCount,
            this.toolStripSeparator4,
            this.statusTimer});
            this.statusToolStrip.Location = new System.Drawing.Point(0, 577);
            this.statusToolStrip.Name = "statusToolStrip";
            this.statusToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.statusToolStrip.Size = new System.Drawing.Size(1143, 37);
            this.statusToolStrip.TabIndex = 5;
            this.statusToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Chips
            // 
            this.Chips.HeaderText = "Chips";
            this.Chips.Name = "Chips";
            this.Chips.ReadOnly = true;
            // 
            // Wins
            // 
            this.Wins.HeaderText = "Wins";
            this.Wins.Name = "Wins";
            this.Wins.ReadOnly = true;
            // 
            // Losses
            // 
            this.Losses.HeaderText = "Losses";
            this.Losses.Name = "Losses";
            this.Losses.ReadOnly = true;
            // 
            // Busts
            // 
            this.Busts.HeaderText = "Busts";
            this.Busts.Name = "Busts";
            this.Busts.ReadOnly = true;
            // 
            // Pushes
            // 
            this.Pushes.HeaderText = "Pushes";
            this.Pushes.Name = "Pushes";
            this.Pushes.ReadOnly = true;
            // 
            // Blackjacks
            // 
            this.Blackjacks.HeaderText = "Blackjacks";
            this.Blackjacks.Name = "Blackjacks";
            this.Blackjacks.ReadOnly = true;
            // 
            // BlackjackSimMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 614);
            this.Controls.Add(this.gridStats);
            this.Controls.Add(this.btnClearStats);
            this.Controls.Add(this.statusToolStrip);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BlackjackSimMain";
            this.Text = "Cornfield\'s Blackjack Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStats)).EndInit();
            this.statusToolStrip.ResumeLayout(false);
            this.statusToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.TextBox txtNumDecks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearStats;
        private System.Windows.Forms.DataGridView gridStats;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumInterval;
        private System.Windows.Forms.TextBox txtNumHands;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblNumDecks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lblNumHands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel lblNumPlayers;
        private System.Windows.Forms.ToolStripLabel statusHandCount;
        private System.Windows.Forms.ToolStripLabel statusTimer;
        private System.Windows.Forms.ToolStrip statusToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chips;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Losses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Busts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pushes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blackjacks;
    }
}

