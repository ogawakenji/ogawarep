namespace WcfSample01Client
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.TextBox();
            this.btnCallSerivceMethod = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "結果";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(36, 114);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(200, 22);
            this.lblResult.TabIndex = 1;
            // 
            // btnCallSerivceMethod
            // 
            this.btnCallSerivceMethod.Location = new System.Drawing.Point(28, 37);
            this.btnCallSerivceMethod.Name = "btnCallSerivceMethod";
            this.btnCallSerivceMethod.Size = new System.Drawing.Size(208, 31);
            this.btnCallSerivceMethod.TabIndex = 2;
            this.btnCallSerivceMethod.Text = "サービスメソッド呼び出し";
            this.btnCallSerivceMethod.UseVisualStyleBackColor = true;
            this.btnCallSerivceMethod.Click += new System.EventHandler(this.btnCallSerivceMethod_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(25, 169);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 15);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "C#版";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnCallSerivceMethod);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblResult;
        private System.Windows.Forms.Button btnCallSerivceMethod;
        private System.Windows.Forms.Label Label2;
    }
}

