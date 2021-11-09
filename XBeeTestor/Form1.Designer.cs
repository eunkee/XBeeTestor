namespace XBeeTestor
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PanelLog = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PanelLog
            // 
            this.PanelLog.Location = new System.Drawing.Point(1, 137);
            this.PanelLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelLog.Name = "PanelLog";
            this.PanelLog.Size = new System.Drawing.Size(600, 300);
            this.PanelLog.TabIndex = 4;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.buttonStart.Location = new System.Drawing.Point(373, 79);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 40);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.buttonStop.Location = new System.Drawing.Point(488, 79);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 40);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // textBoxData
            // 
            this.textBoxData.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.textBoxData.Location = new System.Drawing.Point(12, 82);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(330, 34);
            this.textBoxData.TabIndex = 7;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxPort.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(12, 24);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(142, 36);
            this.comboBoxPort.TabIndex = 8;
            this.comboBoxPort.DropDown += new System.EventHandler(this.ComboBoxPort_DropDown);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.buttonOpen.Location = new System.Drawing.Point(178, 24);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 40);
            this.buttonOpen.TabIndex = 9;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.buttonClose.Location = new System.Drawing.Point(303, 24);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 40);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 437);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.PanelLog);
            this.Name = "Form1";
            this.Text = "Xbee Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelLog;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

