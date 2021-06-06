namespace SelectPathApp
{
    partial class PathSelectAppp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSelectPath1 = new WinControllers.FileSelectPath();
            this.SuspendLayout();
            // 
            // fileSelectPath1
            // 
            this.fileSelectPath1.AutoSize = true;
            this.fileSelectPath1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileSelectPath1.FileName = "";
            this.fileSelectPath1.Location = new System.Drawing.Point(13, 9);
            this.fileSelectPath1.Margin = new System.Windows.Forms.Padding(4);
            this.fileSelectPath1.MinimumSize = new System.Drawing.Size(50, 0);
            this.fileSelectPath1.Name = "fileSelectPath1";
            this.fileSelectPath1.Size = new System.Drawing.Size(587, 33);
            this.fileSelectPath1.TabIndex = 0;
            // 
            // PathSelectAppp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 54);
            this.Controls.Add(this.fileSelectPath1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PathSelectAppp";
            this.Text = "FilePathSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinControllers.FileSelectPath fileSelectPath1;
    }
}

