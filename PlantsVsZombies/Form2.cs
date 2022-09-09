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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Действия, при нажатии на кнопку "Play"
        private void button1_Click(object sender, EventArgs e) 
        {
            Form1 Menu = new Form1();
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Hide();
            Menu.Show();
        }

        // Действия, при закрытии формы
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private static readonly Image image1 = ImageHelper.ButtonPlay1;
        private static readonly Image image2 = ImageHelper.ButtonPlay2;

        // Поведение кнопки "Play" при наведении курсором мыши 
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImage = image2;
            button1.BackColor = Color.Transparent;
        }

        // Поведение кнопки "Play" при снятия курсора мыши
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImage = image1;
            button1.BackColor = Color.Transparent;
        }

        // Действия, при нажатии на кнопку "Справка"
        private void button2_Click(object sender, EventArgs e) 
        {
            Form3 Ref = new Form3();
            this.Hide();
            Ref.Show();
        }

        // Действия, при нажатии на кнопку "О программе"
        private void button3_Click(object sender, EventArgs e) 
        {
            Form4 About = new Form4();
            this.Hide();
            About.Show();
        }
    }
}
