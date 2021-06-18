namespace Draw3D
{
    partial class frmView
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
            this.pictGraph = new System.Windows.Forms.PictureBox();
            this.btnEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictGraph
            // 
            this.pictGraph.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictGraph.Location = new System.Drawing.Point(31, 27);
            this.pictGraph.Name = "pictGraph";
            this.pictGraph.Size = new System.Drawing.Size(232, 184);
            this.pictGraph.TabIndex = 0;
            this.pictGraph.TabStop = false;
            this.pictGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictMouseDown);
            this.pictGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictMouseMove);
            this.pictGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictGraphPaint);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(97, 235);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(87, 33);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 525);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.pictGraph);
            this.Name = "frmView";
            this.Text = "3D View";
            ((System.ComponentModel.ISupportInitialize)(this.pictGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictGraph;
        private System.Windows.Forms.Button btnEnd;
    }
}

