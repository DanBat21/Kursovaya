using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantsVsZombies
{
    public partial class Form4 : Form
    {
        public Form4()
        {    
            InitializeComponent();
            
            // Выравнивание текста в текстовых окнах
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll();

            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.DeselectAll();
        }

        // Действия, при закрытии формы
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 Intro = new Form2();
            this.Hide();
            Intro.Show();
        }
    }
}
