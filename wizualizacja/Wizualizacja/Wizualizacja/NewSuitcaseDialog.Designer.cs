namespace Wizualizacja
{
    partial class NewSuitcaseDialog
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noneRadio = new System.Windows.Forms.RadioButton();
            this.explosivesRadio = new System.Windows.Forms.RadioButton();
            this.drugsRadio = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "etykieta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target plane";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noneRadio);
            this.groupBox1.Controls.Add(this.explosivesRadio);
            this.groupBox1.Controls.Add(this.drugsRadio);
            this.groupBox1.Location = new System.Drawing.Point(16, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 77);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dangerous content";
            // 
            // noneRadio
            // 
            this.noneRadio.AutoSize = true;
            this.noneRadio.Location = new System.Drawing.Point(6, 42);
            this.noneRadio.Name = "noneRadio";
            this.noneRadio.Size = new System.Drawing.Size(51, 17);
            this.noneRadio.TabIndex = 2;
            this.noneRadio.TabStop = true;
            this.noneRadio.Text = "None";
            this.noneRadio.UseVisualStyleBackColor = true;
            this.noneRadio.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // explosivesRadio
            // 
            this.explosivesRadio.AutoSize = true;
            this.explosivesRadio.Location = new System.Drawing.Point(97, 19);
            this.explosivesRadio.Name = "explosivesRadio";
            this.explosivesRadio.Size = new System.Drawing.Size(75, 17);
            this.explosivesRadio.TabIndex = 1;
            this.explosivesRadio.TabStop = true;
            this.explosivesRadio.Text = "Explosives";
            this.explosivesRadio.UseVisualStyleBackColor = true;
            this.explosivesRadio.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // drugsRadio
            // 
            this.drugsRadio.AutoSize = true;
            this.drugsRadio.Location = new System.Drawing.Point(6, 19);
            this.drugsRadio.Name = "drugsRadio";
            this.drugsRadio.Size = new System.Drawing.Size(53, 17);
            this.drugsRadio.TabIndex = 0;
            this.drugsRadio.TabStop = true;
            this.drugsRadio.Text = "Drugs";
            this.drugsRadio.UseVisualStyleBackColor = true;
            this.drugsRadio.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 120);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Weight";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewSuitcaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "NewSuitcaseDialog";
            this.Text = "Adding new suitcase";
            this.Load += new System.EventHandler(this.NewSuitcaseDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton explosivesRadio;
        private System.Windows.Forms.RadioButton drugsRadio;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton noneRadio;
        private System.Windows.Forms.Button button2;
    }
}