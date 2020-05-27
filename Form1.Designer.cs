namespace bo_macro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.currentStatus = new System.Windows.Forms.Label();
            this.select_stage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.min_oil_val = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drop_ship_val = new System.Windows.Forms.TextBox();
            this.min_oil_checkBox = new System.Windows.Forms.CheckBox();
            this.drop_ship_checkBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // currentStatus
            // 
            this.currentStatus.AutoSize = true;
            this.currentStatus.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.currentStatus.Location = new System.Drawing.Point(12, 13);
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(133, 31);
            this.currentStatus.TabIndex = 7;
            this.currentStatus.Text = "연결 실패!";
            // 
            // select_stage
            // 
            this.select_stage.BackColor = System.Drawing.Color.DimGray;
            this.select_stage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_stage.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.select_stage.ForeColor = System.Drawing.Color.White;
            this.select_stage.FormattingEnabled = true;
            this.select_stage.Items.AddRange(new object[] {
            "1-1",
            "1-2",
            "1-3",
            "1-4",
            "2-1",
            "2-2",
            "2-3",
            "2-4",
            "3-1",
            "3-2",
            "3-3",
            "3-4",
            "4-1",
            "4-2",
            "4-3",
            "4-4",
            "5-1",
            "5-2",
            "5-3",
            "5-4",
            "custom",
            "custom2"});
            this.select_stage.Location = new System.Drawing.Point(151, 24);
            this.select_stage.Name = "select_stage";
            this.select_stage.Size = new System.Drawing.Size(121, 22);
            this.select_stage.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(151, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "해역선택";
            // 
            // min_oil_val
            // 
            this.min_oil_val.BackColor = System.Drawing.Color.DimGray;
            this.min_oil_val.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.min_oil_val.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.min_oil_val.ForeColor = System.Drawing.Color.White;
            this.min_oil_val.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.min_oil_val.Location = new System.Drawing.Point(151, 65);
            this.min_oil_val.Name = "min_oil_val";
            this.min_oil_val.Size = new System.Drawing.Size(97, 19);
            this.min_oil_val.TabIndex = 10;
            this.min_oil_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.min_oil_val_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(151, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "최저연료";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(151, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "드랍함횟수";
            // 
            // drop_ship_val
            // 
            this.drop_ship_val.BackColor = System.Drawing.Color.DimGray;
            this.drop_ship_val.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drop_ship_val.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.drop_ship_val.ForeColor = System.Drawing.Color.White;
            this.drop_ship_val.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.drop_ship_val.Location = new System.Drawing.Point(151, 104);
            this.drop_ship_val.Name = "drop_ship_val";
            this.drop_ship_val.Size = new System.Drawing.Size(97, 19);
            this.drop_ship_val.TabIndex = 13;
            this.drop_ship_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.drop_ship_val_KeyPress);
            // 
            // min_oil_checkBox
            // 
            this.min_oil_checkBox.AutoSize = true;
            this.min_oil_checkBox.Location = new System.Drawing.Point(254, 68);
            this.min_oil_checkBox.Name = "min_oil_checkBox";
            this.min_oil_checkBox.Size = new System.Drawing.Size(15, 14);
            this.min_oil_checkBox.TabIndex = 14;
            this.min_oil_checkBox.UseVisualStyleBackColor = true;
            this.min_oil_checkBox.CheckedChanged += new System.EventHandler(this.min_oil_checkBox_CheckedChanged);
            // 
            // drop_ship_checkBox
            // 
            this.drop_ship_checkBox.AutoSize = true;
            this.drop_ship_checkBox.Location = new System.Drawing.Point(254, 107);
            this.drop_ship_checkBox.Name = "drop_ship_checkBox";
            this.drop_ship_checkBox.Size = new System.Drawing.Size(15, 14);
            this.drop_ship_checkBox.TabIndex = 15;
            this.drop_ship_checkBox.UseVisualStyleBackColor = true;
            this.drop_ship_checkBox.CheckedChanged += new System.EventHandler(this.drop_ship_checkBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(182, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "시작,종료:<F5>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "도움말:<F1>";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.drop_ship_checkBox);
            this.Controls.Add(this.min_oil_checkBox);
            this.Controls.Add(this.drop_ship_val);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.min_oil_val);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_stage);
            this.Controls.Add(this.currentStatus);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bo_macro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label currentStatus;
        private System.Windows.Forms.ComboBox select_stage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox min_oil_val;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox drop_ship_val;
        private System.Windows.Forms.CheckBox min_oil_checkBox;
        private System.Windows.Forms.CheckBox drop_ship_checkBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

