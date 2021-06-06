namespace WinFormApp
{
    partial class Form1
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
            this.numberTextBox1 = new WinControllers.NumberTextBox();
            this.SuspendLayout();
            // 
            // numberTextBox1
            // 
            this.numberTextBox1.ForeColor = System.Drawing.Color.Black;
            this.numberTextBox1.Location = new System.Drawing.Point(12, 12);
            this.numberTextBox1.Name = "numberTextBox1";
            this.numberTextBox1.Size = new System.Drawing.Size(322, 22);
            this.numberTextBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 46);
            this.Controls.Add(this.numberTextBox1);
            this.Name = "Form1";
            this.Text = "WinFormApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinControllers.NumberTextBox numberTextBox1;
    }
}

