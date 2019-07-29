namespace ECG_reader
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
            this.button1 = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picMeshWithModelLines = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picCurve = new System.Windows.Forms.PictureBox();
            this.picCalculatedCurve = new System.Windows.Forms.PictureBox();
            this.picCalculatedCurveWithMesh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeshWithModelLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalculatedCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalculatedCurveWithMesh)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(25, 74);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(763, 364);
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // picMeshWithModelLines
            // 
            this.picMeshWithModelLines.Location = new System.Drawing.Point(25, 445);
            this.picMeshWithModelLines.Name = "picMeshWithModelLines";
            this.picMeshWithModelLines.Size = new System.Drawing.Size(763, 375);
            this.picMeshWithModelLines.TabIndex = 2;
            this.picMeshWithModelLines.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(794, 445);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(69, 375);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // trackBarX
            // 
            this.trackBarX.Enabled = false;
            this.trackBarX.Location = new System.Drawing.Point(249, 841);
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(375, 69);
            this.trackBarX.TabIndex = 4;
            this.trackBarX.Scroll += new System.EventHandler(this.TrackBarX_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(790, 841);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 841);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // picCurve
            // 
            this.picCurve.Location = new System.Drawing.Point(886, 74);
            this.picCurve.Name = "picCurve";
            this.picCurve.Size = new System.Drawing.Size(763, 364);
            this.picCurve.TabIndex = 7;
            this.picCurve.TabStop = false;
            // 
            // picCalculatedCurve
            // 
            this.picCalculatedCurve.Location = new System.Drawing.Point(886, 456);
            this.picCalculatedCurve.Name = "picCalculatedCurve";
            this.picCalculatedCurve.Size = new System.Drawing.Size(763, 364);
            this.picCalculatedCurve.TabIndex = 8;
            this.picCalculatedCurve.TabStop = false;
            // 
            // picCalculatedCurveWithMesh
            // 
            this.picCalculatedCurveWithMesh.Location = new System.Drawing.Point(1670, 74);
            this.picCalculatedCurveWithMesh.Name = "picCalculatedCurveWithMesh";
            this.picCalculatedCurveWithMesh.Size = new System.Drawing.Size(763, 364);
            this.picCalculatedCurveWithMesh.TabIndex = 9;
            this.picCalculatedCurveWithMesh.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2493, 983);
            this.Controls.Add(this.picCalculatedCurveWithMesh);
            this.Controls.Add(this.picCalculatedCurve);
            this.Controls.Add(this.picCurve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.picMeshWithModelLines);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeshWithModelLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalculatedCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalculatedCurveWithMesh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picMeshWithModelLines;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picCurve;
        private System.Windows.Forms.PictureBox picCalculatedCurve;
        private System.Windows.Forms.PictureBox picCalculatedCurveWithMesh;
    }
}

