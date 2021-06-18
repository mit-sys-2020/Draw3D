namespace Draw3D
{
    partial class frmTest
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.tabInput = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbBkCol1 = new System.Windows.Forms.ComboBox();
            this.txtAngXY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAngXZ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbBkCol2 = new System.Windows.Forms.ComboBox();
            this.cmbDir2 = new System.Windows.Forms.ComboBox();
            this.txtAng2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmbCur3 = new System.Windows.Forms.ComboBox();
            this.txtYLin3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtXLin3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.tabInput.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(137, 329);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 30);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "実行";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.tabPage1);
            this.tabInput.Controls.Add(this.tabPage2);
            this.tabInput.Controls.Add(this.tabPage3);
            this.tabInput.Location = new System.Drawing.Point(26, 59);
            this.tabInput.Name = "tabInput";
            this.tabInput.SelectedIndex = 0;
            this.tabInput.Size = new System.Drawing.Size(395, 236);
            this.tabInput.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbBkCol1);
            this.tabPage1.Controls.Add(this.txtAngXY);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtAngXZ);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(387, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "初期表示";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbBkCol1
            // 
            this.cmbBkCol1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBkCol1.FormattingEnabled = true;
            this.cmbBkCol1.Items.AddRange(new object[] {
            "黒",
            "赤",
            "青",
            "緑",
            "黄",
            "紫",
            "水",
            "白"});
            this.cmbBkCol1.Location = new System.Drawing.Point(241, 24);
            this.cmbBkCol1.Name = "cmbBkCol1";
            this.cmbBkCol1.Size = new System.Drawing.Size(71, 20);
            this.cmbBkCol1.TabIndex = 6;
            this.cmbBkCol1.SelectedIndexChanged += new System.EventHandler(this.cmbBkCol1SelChange);
            // 
            // txtAngXY
            // 
            this.txtAngXY.Location = new System.Drawing.Point(240, 96);
            this.txtAngXY.Name = "txtAngXY";
            this.txtAngXY.Size = new System.Drawing.Size(73, 19);
            this.txtAngXY.TabIndex = 5;
            this.txtAngXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "視点角度（経度方向ｘｙ角度）";
            // 
            // txtAngXZ
            // 
            this.txtAngXZ.Location = new System.Drawing.Point(240, 62);
            this.txtAngXZ.Name = "txtAngXZ";
            this.txtAngXZ.Size = new System.Drawing.Size(73, 19);
            this.txtAngXZ.TabIndex = 3;
            this.txtAngXZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "視点角度（緯度方向ｘｚ角度）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "背景色（0～7）";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbBkCol2);
            this.tabPage2.Controls.Add(this.cmbDir2);
            this.tabPage2.Controls.Add(this.txtAng2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(387, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "回転表示";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbBkCol2
            // 
            this.cmbBkCol2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBkCol2.FormattingEnabled = true;
            this.cmbBkCol2.Items.AddRange(new object[] {
            "黒",
            "赤",
            "青",
            "緑",
            "黄",
            "紫",
            "水",
            "白"});
            this.cmbBkCol2.Location = new System.Drawing.Point(238, 42);
            this.cmbBkCol2.Name = "cmbBkCol2";
            this.cmbBkCol2.Size = new System.Drawing.Size(71, 20);
            this.cmbBkCol2.TabIndex = 13;
            this.cmbBkCol2.SelectedIndexChanged += new System.EventHandler(this.cmbBkCol2SelChange);
            // 
            // cmbDir2
            // 
            this.cmbDir2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDir2.FormattingEnabled = true;
            this.cmbDir2.Items.AddRange(new object[] {
            "時計方向",
            "反時計方向"});
            this.cmbDir2.Location = new System.Drawing.Point(239, 82);
            this.cmbDir2.Name = "cmbDir2";
            this.cmbDir2.Size = new System.Drawing.Size(106, 20);
            this.cmbDir2.TabIndex = 12;
            // 
            // txtAng2
            // 
            this.txtAng2.Location = new System.Drawing.Point(238, 115);
            this.txtAng2.Name = "txtAng2";
            this.txtAng2.Size = new System.Drawing.Size(73, 19);
            this.txtAng2.TabIndex = 11;
            this.txtAng2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "回転角度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "回転方向";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "背景色（0～7）";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmbCur3);
            this.tabPage3.Controls.Add(this.txtYLin3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtXLin3);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(387, 210);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "位置指定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmbCur3
            // 
            this.cmbCur3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCur3.FormattingEnabled = true;
            this.cmbCur3.Items.AddRange(new object[] {
            "しない",
            "する"});
            this.cmbCur3.Location = new System.Drawing.Point(244, 117);
            this.cmbCur3.Name = "cmbCur3";
            this.cmbCur3.Size = new System.Drawing.Size(73, 20);
            this.cmbCur3.TabIndex = 18;
            // 
            // txtYLin3
            // 
            this.txtYLin3.Location = new System.Drawing.Point(244, 83);
            this.txtYLin3.Name = "txtYLin3";
            this.txtYLin3.Size = new System.Drawing.Size(73, 19);
            this.txtYLin3.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "カーソル垂線出力";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "変更するy線の番号（1～）";
            // 
            // txtXLin3
            // 
            this.txtXLin3.Location = new System.Drawing.Point(244, 49);
            this.txtXLin3.Name = "txtXLin3";
            this.txtXLin3.Size = new System.Drawing.Size(73, 19);
            this.txtXLin3.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "変更するｘ線の番号（1～）";
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(233, 329);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 30);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 385);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.tabInput);
            this.Controls.Add(this.btnGo);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.tabInput.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabControl tabInput;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtAngXZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAngXY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAng2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDir2;
        private System.Windows.Forms.TextBox txtYLin3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtXLin3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCur3;
        private System.Windows.Forms.ComboBox cmbBkCol1;
        private System.Windows.Forms.ComboBox cmbBkCol2;
        private System.Windows.Forms.Button btnEnd;
    }
}