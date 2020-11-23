namespace interactiveObj3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.objectBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.xBox = new System.Windows.Forms.TrackBar();
            this.zBox = new System.Windows.Forms.TrackBar();
            this.yBox = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.radius2Box = new System.Windows.Forms.TextBox();
            this.radius2Label = new System.Windows.Forms.Label();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.radius3Box = new System.Windows.Forms.TextBox();
            this.radius3Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(203, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(500, 500);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Z - Coordinate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X - Coordinate";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(773, 70);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 6;
            this.button.Text = "RENDER!";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Designate the coordinate to place\r\nyour object on the XZ plane.";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(721, 41);
            this.progress.Maximum = 500;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(176, 23);
            this.progress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(718, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rendering Progress";
            // 
            // objectBox
            // 
            this.objectBox.FormattingEnabled = true;
            this.objectBox.Items.AddRange(new object[] {
            "Sphere",
            "Ellipsoid"});
            this.objectBox.Location = new System.Drawing.Point(721, 183);
            this.objectBox.Name = "objectBox";
            this.objectBox.Size = new System.Drawing.Size(163, 21);
            this.objectBox.TabIndex = 10;
            this.objectBox.SelectedIndexChanged += new System.EventHandler(this.objectBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Designate Shape";
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(16, 95);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(143, 45);
            this.xBox.TabIndex = 12;
            this.xBox.Value = 5;
            // 
            // zBox
            // 
            this.zBox.Location = new System.Drawing.Point(16, 159);
            this.zBox.Maximum = 50;
            this.zBox.Name = "zBox";
            this.zBox.Size = new System.Drawing.Size(143, 45);
            this.zBox.TabIndex = 13;
            this.zBox.Value = 10;
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(15, 235);
            this.yBox.Maximum = 5;
            this.yBox.Minimum = 1;
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(143, 45);
            this.yBox.TabIndex = 14;
            this.yBox.Value = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y - Coordinate";
            // 
            // radius2Box
            // 
            this.radius2Box.Location = new System.Drawing.Point(721, 263);
            this.radius2Box.Name = "radius2Box";
            this.radius2Box.Size = new System.Drawing.Size(100, 20);
            this.radius2Box.TabIndex = 16;
            this.radius2Box.Text = "1";
            this.radius2Box.Visible = false;
            // 
            // radius2Label
            // 
            this.radius2Label.AutoSize = true;
            this.radius2Label.Location = new System.Drawing.Point(718, 247);
            this.radius2Label.Name = "radius2Label";
            this.radius2Label.Size = new System.Drawing.Size(49, 13);
            this.radius2Label.TabIndex = 18;
            this.radius2Label.Text = "Radius 2";
            this.radius2Label.Visible = false;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(718, 207);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(40, 13);
            this.radiusLabel.TabIndex = 20;
            this.radiusLabel.Text = "Radius";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point(721, 224);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(100, 20);
            this.radiusBox.TabIndex = 21;
            this.radiusBox.Text = "1";
            // 
            // radius3Box
            // 
            this.radius3Box.Location = new System.Drawing.Point(721, 302);
            this.radius3Box.Name = "radius3Box";
            this.radius3Box.Size = new System.Drawing.Size(100, 20);
            this.radius3Box.TabIndex = 22;
            this.radius3Box.Text = "1";
            this.radius3Box.Visible = false;
            // 
            // radius3Label
            // 
            this.radius3Label.AutoSize = true;
            this.radius3Label.Location = new System.Drawing.Point(718, 286);
            this.radius3Label.Name = "radius3Label";
            this.radius3Label.Size = new System.Drawing.Size(49, 13);
            this.radius3Label.TabIndex = 23;
            this.radius3Label.Text = "Radius 3";
            this.radius3Label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 524);
            this.Controls.Add(this.radius3Label);
            this.Controls.Add(this.radius3Box);
            this.Controls.Add(this.radiusBox);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.radius2Label);
            this.Controls.Add(this.radius2Box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.zBox);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.objectBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox objectBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar xBox;
        private System.Windows.Forms.TrackBar zBox;
        private System.Windows.Forms.TrackBar yBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox radius2Box;
        private System.Windows.Forms.Label radius2Label;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.TextBox radius3Box;
        private System.Windows.Forms.Label radius3Label;
    }
}

