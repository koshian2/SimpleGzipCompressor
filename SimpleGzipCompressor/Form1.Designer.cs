namespace SimpleGzipCompressor
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_process = new System.Windows.Forms.Button();
            this.label_progress = new System.Windows.Forms.Label();
            this.checkBox_delete = new System.Windows.Forms.CheckBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_removeext = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_process
            // 
            this.button_process.AllowDrop = true;
            this.button_process.Location = new System.Drawing.Point(50, 50);
            this.button_process.Name = "button_process";
            this.button_process.Size = new System.Drawing.Size(180, 120);
            this.button_process.TabIndex = 0;
            this.button_process.Text = "ファイル または ディレクトリを\r\nドラッグ＆ドロップでgzipに圧縮";
            this.button_process.UseVisualStyleBackColor = true;
            this.button_process.DragDrop += new System.Windows.Forms.DragEventHandler(this.button_process_DragDrop);
            this.button_process.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_process_DragEnter);
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(10, 200);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(29, 12);
            this.label_progress.TabIndex = 1;
            this.label_progress.Text = "進捗";
            // 
            // checkBox_delete
            // 
            this.checkBox_delete.AutoSize = true;
            this.checkBox_delete.Location = new System.Drawing.Point(10, 230);
            this.checkBox_delete.Name = "checkBox_delete";
            this.checkBox_delete.Size = new System.Drawing.Size(206, 16);
            this.checkBox_delete.TabIndex = 2;
            this.checkBox_delete.Text = "圧縮が完了したら元ファイルを消去する";
            this.checkBox_delete.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(170, 200);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "キャンセル";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_removeext
            // 
            this.checkBox_removeext.AutoSize = true;
            this.checkBox_removeext.Checked = true;
            this.checkBox_removeext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_removeext.Location = new System.Drawing.Point(10, 252);
            this.checkBox_removeext.Name = "checkBox_removeext";
            this.checkBox_removeext.Size = new System.Drawing.Size(112, 16);
            this.checkBox_removeext.TabIndex = 4;
            this.checkBox_removeext.Text = "拡張子を消去する";
            this.checkBox_removeext.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 273);
            this.Controls.Add(this.checkBox_removeext);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.checkBox_delete);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.button_process);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SimpleGzipCompressor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_process;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.CheckBox checkBox_delete;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_removeext;
    }
}

