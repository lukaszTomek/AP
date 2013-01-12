
namespace Wizualizacja
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.newPlaneBut = new System.Windows.Forms.Button();
            this.connectBut = new System.Windows.Forms.Button();
            this.newSuitcaseBut = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 680);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 654);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Airport\'s preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(972, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // newPlaneBut
            // 
            this.newPlaneBut.Location = new System.Drawing.Point(204, 12);
            this.newPlaneBut.Name = "newPlaneBut";
            this.newPlaneBut.Size = new System.Drawing.Size(90, 25);
            this.newPlaneBut.TabIndex = 3;
            this.newPlaneBut.Text = "Add new plane";
            this.newPlaneBut.UseVisualStyleBackColor = true;
            this.newPlaneBut.Click += new System.EventHandler(this.newPlaneBut_Click);
            // 
            // connectBut
            // 
            this.connectBut.Location = new System.Drawing.Point(12, 12);
            this.connectBut.Name = "connectBut";
            this.connectBut.Size = new System.Drawing.Size(90, 25);
            this.connectBut.TabIndex = 1;
            this.connectBut.Text = "Connect";
            this.connectBut.UseVisualStyleBackColor = true;
            this.connectBut.Click += new System.EventHandler(this.connectBut_Click);
            // 
            // newSuitcaseBut
            // 
            this.newSuitcaseBut.Location = new System.Drawing.Point(108, 12);
            this.newSuitcaseBut.Name = "newSuitcaseBut";
            this.newSuitcaseBut.Size = new System.Drawing.Size(90, 25);
            this.newSuitcaseBut.TabIndex = 2;
            this.newSuitcaseBut.Text = "Add a suitcase";
            this.newSuitcaseBut.UseVisualStyleBackColor = true;
            this.newSuitcaseBut.Click += new System.EventHandler(this.newSuitcaseBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.newPlaneBut);
            this.Controls.Add(this.connectBut);
            this.Controls.Add(this.newSuitcaseBut);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Wizualizacja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button newPlaneBut;
        private System.Windows.Forms.Button connectBut;
        private System.Windows.Forms.Button newSuitcaseBut;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

