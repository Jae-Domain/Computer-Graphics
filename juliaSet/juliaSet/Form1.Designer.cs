namespace juliaSet
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textC0 = new System.Windows.Forms.TextBox();
            this.textC1 = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.labelc0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textUser1 = new System.Windows.Forms.TextBox();
            this.textUser2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.randomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(119, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1000, 800);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play Default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textC0
            // 
            this.textC0.Location = new System.Drawing.Point(13, 42);
            this.textC0.Name = "textC0";
            this.textC0.Size = new System.Drawing.Size(100, 20);
            this.textC0.TabIndex = 2;
            this.textC0.Text = "Current C1: ";
            // 
            // textC1
            // 
            this.textC1.Location = new System.Drawing.Point(13, 69);
            this.textC1.Name = "textC1";
            this.textC1.Size = new System.Drawing.Size(100, 20);
            this.textC1.TabIndex = 3;
            this.textC1.Text = "Current C2:";
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(13, 143);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(75, 23);
            this.inputButton.TabIndex = 4;
            this.inputButton.Text = "Input Values";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // labelc0
            // 
            this.labelc0.AutoSize = true;
            this.labelc0.Location = new System.Drawing.Point(32, 169);
            this.labelc0.Name = "labelc0";
            this.labelc0.Size = new System.Drawing.Size(44, 13);
            this.labelc0.TabIndex = 5;
            this.labelc0.Text = "User c1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "User c2";
            // 
            // textUser1
            // 
            this.textUser1.Location = new System.Drawing.Point(13, 237);
            this.textUser1.Name = "textUser1";
            this.textUser1.Size = new System.Drawing.Size(100, 20);
            this.textUser1.TabIndex = 7;
            // 
            // textUser2
            // 
            this.textUser2.Location = new System.Drawing.Point(12, 185);
            this.textUser2.Name = "textUser2";
            this.textUser2.Size = new System.Drawing.Size(100, 20);
            this.textUser2.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Iterative Coloring";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(13, 294);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(75, 23);
            this.randomButton.TabIndex = 10;
            this.randomButton.Text = "CHAOS";
            this.randomButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 862);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textUser2);
            this.Controls.Add(this.textUser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelc0);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.textC1);
            this.Controls.Add(this.textC0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textC0;
        private System.Windows.Forms.TextBox textC1;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Label labelc0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUser1;
        private System.Windows.Forms.TextBox textUser2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button randomButton;
    }
}

