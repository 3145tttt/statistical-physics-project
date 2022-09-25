namespace statphys
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label_mean = new System.Windows.Forms.Label();
            this.label_var = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.numericUpDownMean = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVar = new System.Windows.Forms.NumericUpDown();
            this.label_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "get new sample";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 165);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "x = 0 delta = 0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(650, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Тест";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_numeric_methods_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(650, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Вывод";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 302);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "start loop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_start_timer_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(363, 380);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_mean
            // 
            this.label_mean.AutoSize = true;
            this.label_mean.Location = new System.Drawing.Point(37, 224);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(57, 15);
            this.label_mean.TabIndex = 7;
            this.label_mean.Text = "Mean = 0";
            // 
            // label_var
            // 
            this.label_var.AutoSize = true;
            this.label_var.Location = new System.Drawing.Point(37, 265);
            this.label_var.Name = "label_var";
            this.label_var.Size = new System.Drawing.Size(71, 15);
            this.label_var.TabIndex = 8;
            this.label_var.Text = "Variance = 0";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(363, 341);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "stoop loop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_stop_timer_Click);
            // 
            // numericUpDownMean
            // 
            this.numericUpDownMean.DecimalPlaces = 1;
            this.numericUpDownMean.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMean.Location = new System.Drawing.Point(37, 341);
            this.numericUpDownMean.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownMean.Name = "numericUpDownMean";
            this.numericUpDownMean.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownMean.TabIndex = 10;
            this.numericUpDownMean.ThousandsSeparator = true;
            this.numericUpDownMean.ValueChanged += new System.EventHandler(this.numericUpDownMean_ValueChanged);
            // 
            // numericUpDownVar
            // 
            this.numericUpDownVar.Location = new System.Drawing.Point(37, 380);
            this.numericUpDownVar.Name = "numericUpDownVar";
            this.numericUpDownVar.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownVar.TabIndex = 11;
            this.numericUpDownVar.ValueChanged += new System.EventHandler(this.numericUpDownVar_ValueChanged);
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Location = new System.Drawing.Point(37, 302);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(60, 15);
            this.label_count.TabIndex = 12;
            this.label_count.Text = "Count = 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.numericUpDownVar);
            this.Controls.Add(this.numericUpDownMean);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label_var);
            this.Controls.Add(this.label_mean);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "statphys";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label_mean;
        private Label label_var;
        private Button button6;
        private NumericUpDown numericUpDownMean;
        private NumericUpDown numericUpDownVar;
        private Label label_count;
    }
}