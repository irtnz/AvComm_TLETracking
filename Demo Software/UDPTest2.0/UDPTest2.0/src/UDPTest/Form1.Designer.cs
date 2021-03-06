namespace UDPTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxLPort = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.logListView = new Common.LogListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnBoardcast = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnStatusStop = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnStatusStart = new System.Windows.Forms.Button();
			this.textBoxStatusInterval = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnSend = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.txtBox1 = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.groupBox2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "ACU IP Address:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "ACU Port:";
			// 
			// textBoxIP
			// 
			this.textBoxIP.Location = new System.Drawing.Point(98, 13);
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.Size = new System.Drawing.Size(100, 20);
			this.textBoxIP.TabIndex = 4;
			this.textBoxIP.Text = "192.168.1.100";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Location = new System.Drawing.Point(98, 39);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(100, 20);
			this.textBoxPort.TabIndex = 5;
			this.textBoxPort.Text = "6767";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBoxLPort);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBoxIP);
			this.groupBox2.Controls.Add(this.textBoxPort);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(207, 99);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Connection";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Local Port:";
			// 
			// textBoxLPort
			// 
			this.textBoxLPort.Location = new System.Drawing.Point(98, 65);
			this.textBoxLPort.Name = "textBoxLPort";
			this.textBoxLPort.Size = new System.Drawing.Size(100, 20);
			this.textBoxLPort.TabIndex = 7;
			this.textBoxLPort.Text = "6767";
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(12, 126);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(92, 23);
			this.btnQuery.TabIndex = 11;
			this.btnQuery.Text = "IP Query";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// logListView
			// 
			this.logListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.logListView.FullRowSelect = true;
			this.logListView.GridLines = true;
			this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.logListView.Location = new System.Drawing.Point(12, 172);
			this.logListView.MultiSelect = false;
			this.logListView.Name = "logListView";
			this.logListView.Size = new System.Drawing.Size(546, 344);
			this.logListView.TabIndex = 20;
			this.logListView.UseCompatibleStateImageBehavior = false;
			this.logListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "IP Address";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Data";
			this.columnHeader2.Width = 262;
			// 
			// btnBoardcast
			// 
			this.btnBoardcast.Location = new System.Drawing.Point(110, 126);
			this.btnBoardcast.Name = "btnBoardcast";
			this.btnBoardcast.Size = new System.Drawing.Size(100, 23);
			this.btnBoardcast.TabIndex = 0;
			this.btnBoardcast.Text = "Broadcast Query";
			this.btnBoardcast.UseVisualStyleBackColor = true;
			this.btnBoardcast.Click += new System.EventHandler(this.btnBoardcast_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBoxStatusInterval);
			this.tabPage2.Controls.Add(this.btnStatusStart);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.btnStatusStop);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(329, 128);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Auto Status";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnStatusStop
			// 
			this.btnStatusStop.Enabled = false;
			this.btnStatusStop.Location = new System.Drawing.Point(171, 6);
			this.btnStatusStop.Name = "btnStatusStop";
			this.btnStatusStop.Size = new System.Drawing.Size(57, 23);
			this.btnStatusStop.TabIndex = 0;
			this.btnStatusStop.Text = "Stop";
			this.btnStatusStop.UseVisualStyleBackColor = true;
			this.btnStatusStop.Click += new System.EventHandler(this.timer1_Stop);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Inverval:";
			// 
			// btnStatusStart
			// 
			this.btnStatusStart.Location = new System.Drawing.Point(108, 6);
			this.btnStatusStart.Name = "btnStatusStart";
			this.btnStatusStart.Size = new System.Drawing.Size(57, 23);
			this.btnStatusStart.TabIndex = 0;
			this.btnStatusStart.Text = "Start";
			this.btnStatusStart.UseVisualStyleBackColor = true;
			this.btnStatusStart.Click += new System.EventHandler(this.timer1_Start);
			// 
			// textBoxStatusInterval
			// 
			this.textBoxStatusInterval.Location = new System.Drawing.Point(60, 8);
			this.textBoxStatusInterval.Name = "textBoxStatusInterval";
			this.textBoxStatusInterval.Size = new System.Drawing.Size(42, 20);
			this.textBoxStatusInterval.TabIndex = 10;
			this.textBoxStatusInterval.Text = "1000";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtBox1);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.btnSend);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(329, 128);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Predefined";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(245, 10);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(64, 23);
			this.btnSend.TabIndex = 0;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(18, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(221, 21);
			this.comboBox1.TabIndex = 16;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// txtBox1
			// 
			this.txtBox1.Location = new System.Drawing.Point(18, 40);
			this.txtBox1.Name = "txtBox1";
			this.txtBox1.Size = new System.Drawing.Size(221, 20);
			this.txtBox1.TabIndex = 17;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(225, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(337, 154);
			this.tabControl1.TabIndex = 19;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.timer1_Stop);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 528);
			this.Controls.Add(this.btnBoardcast);
			this.Controls.Add(this.logListView);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UDPTest";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxLPort;
		private Common.LogListView logListView;
		private System.Windows.Forms.Button btnBoardcast;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBoxStatusInterval;
		private System.Windows.Forms.Button btnStatusStart;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnStatusStop;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox txtBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TabControl tabControl1;
	}
}