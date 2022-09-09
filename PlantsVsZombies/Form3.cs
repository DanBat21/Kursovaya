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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        // Действия, при закрытии формы
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 Intro = new Form2();
            this.Hide();
            Intro.Show();
        }   
    }
}
