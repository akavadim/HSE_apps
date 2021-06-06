namespace WinControllers
{
    partial class ColorBox
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decRadioButton = new System.Windows.Forms.RadioButton();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.blueNumberBox = new WinControllers.NumberFormatTextBox();
            this.greenNumberBox = new WinControllers.NumberFormatTextBox();
            this.redNumberBox = new WinControllers.NumberFormatTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Красный";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Зеленый";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Синий";
            // 
            // decRadioButton
            // 
            this.decRadioButton.AutoSize = true;
            this.decRadioButton.Checked = true;
            this.decRadioButton.Location = new System.Drawing.Point(6, 87);
            this.decRadioButton.Name = "decRadioButton";
            this.decRadioButton.Size = new System.Drawing.Size(54, 21);
            this.decRadioButton.TabIndex = 6;
            this.decRadioButton.TabStop = true;
            this.decRadioButton.Text = "Dec";
            this.decRadioButton.UseVisualStyleBackColor = true;
            this.decRadioButton.CheckedChanged += new System.EventHandler(this.decRadioButton_CheckedChanged);
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Location = new System.Drawing.Point(75, 87);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(53, 21);
            this.hexRadioButton.TabIndex = 7;
            this.hexRadioButton.Text = "Hex";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            this.hexRadioButton.CheckedChanged += new System.EventHandler(this.hexRadioButton_CheckedChanged);
            // 
            // blueNumberBox
            // 
            this.blueNumberBox.Location = new System.Drawing.Point(76, 59);
            this.blueNumberBox.MaxValue = 255;
            this.blueNumberBox.MinValue = 0;
            this.blueNumberBox.Name = "blueNumberBox";
            this.blueNumberBox.NumberFormat = WinControllers.NumberFormat.Dec;
            this.blueNumberBox.Size = new System.Drawing.Size(52, 22);
            this.blueNumberBox.TabIndex = 2;
            this.blueNumberBox.Text = "0";
            this.blueNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blueNumberBox.Value = 0;
            this.blueNumberBox.TextChanged += new System.EventHandler(this.numberBox_TextChanged);
            // 
            // greenNumberBox
            // 
            this.greenNumberBox.Location = new System.Drawing.Point(76, 31);
            this.greenNumberBox.MaxValue = 255;
            this.greenNumberBox.MinValue = 0;
            this.greenNumberBox.Name = "greenNumberBox";
            this.greenNumberBox.NumberFormat = WinControllers.NumberFormat.Dec;
            this.greenNumberBox.Size = new System.Drawing.Size(52, 22);
            this.greenNumberBox.TabIndex = 1;
            this.greenNumberBox.Text = "0";
            this.greenNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.greenNumberBox.Value = 0;
            this.greenNumberBox.TextChanged += new System.EventHandler(this.numberBox_TextChanged);
            // 
            // redNumberBox
            // 
            this.redNumberBox.Location = new System.Drawing.Point(76, 3);
            this.redNumberBox.MaxValue = 255;
            this.redNumberBox.MinValue = 0;
            this.redNumberBox.Name = "redNumberBox";
            this.redNumberBox.NumberFormat = WinControllers.NumberFormat.Dec;
            this.redNumberBox.Size = new System.Drawing.Size(52, 22);
            this.redNumberBox.TabIndex = 0;
            this.redNumberBox.Text = "0";
            this.redNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.redNumberBox.Value = 0;
            this.redNumberBox.TextChanged += new System.EventHandler(this.numberBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(134, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 105);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ColorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hexRadioButton);
            this.Controls.Add(this.decRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blueNumberBox);
            this.Controls.Add(this.greenNumberBox);
            this.Controls.Add(this.redNumberBox);
            this.Name = "ColorBox";
            this.Size = new System.Drawing.Size(242, 111);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumberFormatTextBox redNumberBox;
        private NumberFormatTextBox greenNumberBox;
        private NumberFormatTextBox blueNumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton decRadioButton;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
