namespace mandelbrot
{
    partial class Mandelbrot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.iterativeCheck = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.userBox1 = new System.Windows.Forms.TextBox();
            this.userBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userBox3 = new System.Windows.Forms.TextBox();
            this.userBox4 = new System.Windows.Forms.TextBox();
            this.coordinateBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zoomScale = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.defaultButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScale)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(139, 13);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1000, 800);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            // 
            // iterativeCheck
            // 
            this.iterativeCheck.AutoSize = true;
            this.iterativeCheck.Location = new System.Drawing.Point(12, 54);
            this.iterativeCheck.Name = "iterativeCheck";
            this.iterativeCheck.Size = new System.Drawing.Size(105, 17);
            this.iterativeCheck.TabIndex = 1;
            this.iterativeCheck.Text = "Iterative Coloring";
            this.iterativeCheck.UseVisualStyleBackColor = true;
            this.iterativeCheck.CheckedChanged += new System.EventHandler(this.iterativeCheck_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.startButton.Location = new System.Drawing.Point(29, 25);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Generate";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // userBox1
            // 
            this.userBox1.Location = new System.Drawing.Point(46, 133);
            this.userBox1.Name = "userBox1";
            this.userBox1.Size = new System.Drawing.Size(51, 20);
            this.userBox1.TabIndex = 3;
            this.userBox1.Text = "-2";
            // 
            // userBox2
            // 
            this.userBox2.Location = new System.Drawing.Point(46, 159);
            this.userBox2.Name = "userBox2";
            this.userBox2.Size = new System.Drawing.Size(51, 20);
            this.userBox2.TabIndex = 4;
            this.userBox2.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(9, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Coordinate Range:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(9, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "XMin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(6, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "XMax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(9, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "YMin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(6, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "YMax";
            // 
            // userBox3
            // 
            this.userBox3.Location = new System.Drawing.Point(46, 189);
            this.userBox3.Name = "userBox3";
            this.userBox3.Size = new System.Drawing.Size(51, 20);
            this.userBox3.TabIndex = 10;
            this.userBox3.Text = "-2";
            // 
            // userBox4
            // 
            this.userBox4.Location = new System.Drawing.Point(46, 213);
            this.userBox4.Name = "userBox4";
            this.userBox4.Size = new System.Drawing.Size(51, 20);
            this.userBox4.TabIndex = 11;
            this.userBox4.Text = "2";
            // 
            // coordinateBox
            // 
            this.coordinateBox.Location = new System.Drawing.Point(9, 285);
            this.coordinateBox.Name = "coordinateBox";
            this.coordinateBox.Size = new System.Drawing.Size(108, 20);
            this.coordinateBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Zoom Coordinates";
            // 
            // zoomScale
            // 
            this.zoomScale.Location = new System.Drawing.Point(9, 336);
            this.zoomScale.Minimum = 1;
            this.zoomScale.Name = "zoomScale";
            this.zoomScale.Size = new System.Drawing.Size(108, 45);
            this.zoomScale.TabIndex = 14;
            this.zoomScale.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Scale";
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(29, 468);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(75, 23);
            this.defaultButton.TabIndex = 16;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1162, 837);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.zoomScale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.coordinateBox);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.userBox4);
            this.Controls.Add(this.userBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userBox2);
            this.Controls.Add(this.userBox1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.iterativeCheck);
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot";
            this.Load += new System.EventHandler(this.Mandelbrot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox iterativeCheck;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox userBox1;
        private System.Windows.Forms.TextBox userBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userBox3;
        private System.Windows.Forms.TextBox userBox4;
        private System.Windows.Forms.TextBox coordinateBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar zoomScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button defaultButton;
    }
}

