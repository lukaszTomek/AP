using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wizualizacja
{
    public partial class NewPlaneDialog : Form
    {
        int time;
        public int getTime()
        {
            return time;
        }
        public NewPlaneDialog()
        {
            InitializeComponent();
        }

        private void NewSuitcaseDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //nazwa samolotu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (textBox1.Text != ""))
            {
                Console.WriteLine("UWAGA SAMOLOOOOOOOOT");
                Console.WriteLine(textBox2.Text);
                time = Convert.ToInt32(textBox2.Text);
                Console.WriteLine("POSZEDŁ SAMOLOT");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Tou have to fill all the fields");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //czas odlotu

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
