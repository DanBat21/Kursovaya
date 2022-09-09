using PlantsVsZombies.Defend;
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
    public partial class Form1 : Form
    {
        private GameManager gameManager;
        private Graphics graphics;
        private Random random = new Random();

        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = pf.CreateGraphics();   
        }

        // Действия, при нажатии на кнопку "Start"
        private void button1_Click(object sender, EventArgs e) 
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            button2.Enabled = true;

            gameManager = new GameManager(); 

            // Описание событий из класса "GameManager"
            gameManager.GameOver += () => MessageBox.Show($"Вы проиграли! Количество очков = {label8.Text}"); 
            gameManager.CastleHealthChanged += health => lblCastleHealth.Text = health.ToString();
            gameManager.MoneyChanged += money => lblMoney.Text = money.ToString();
            gameManager.PointsChanged += points => label8.Text = points.ToString();
            gameManager.CastlePriceChanged += m => label10.Text = "цена: " + m;
           
            gameManager.Start(); // Вызов метода старта игры
            gameManager.SpawnEnemy(); // Вызов метода генерации врагов

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;

            button2.BackgroundImage = image3;
            timer1.Start();
        }

        private void pf_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameManager == null)
                return;
            // Отрисовка игрового поля на панели
            gameManager.HandleMouseClick(e.X, e.Y);
            if (button2.BackgroundImage == image4)
            {
                var background = ImageHelper.Grid; // Установка фона игрового поля
                using (Bitmap bufl = new Bitmap(pf.Width, pf.Height))
                {
                    using (Graphics g = Graphics.FromImage(bufl))
                    {
                        g.DrawImage(background, 0, 0);
                        gameManager.GameStep(g);
                        graphics.DrawImageUnscaled(bufl, 0, 0);
                    }
                }
            }
        }

        // Привязка к преключателю оборонного средства "Растение"
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Plant;
            }
        }

        // Привязка к преключателю оборонного средства "Стена"
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Wall;
            }
        }

        // Запуск таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            var background = ImageHelper.Grid;
            using (Bitmap bufl = new Bitmap(pf.Width, pf.Height))
            {
                using (Graphics g = Graphics.FromImage(bufl))
                {
                    g.DrawImage(background, 0, 0);
                    gameManager.GameStep(g);
                    graphics.DrawImageUnscaled(bufl, 0, 0);
                }
            }

            if (random.NextDouble() > 0.997)
            {
                gameManager.DelaySpawnEnemies--;
            }
        }

        // Привязка к преключателю действия "Очистить"
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Remove;
            }
        }

        // Привязка к преключателю действия "Улучшить"
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Upgrade;
            }
        }

        // Привязка к преключателю оборонного средства "Дракон"
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Drakon;
            }
        }

        // Привязка к преключателю оборонного средства "Бомба"
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Bomb;
            }
        }

        // Привязка к преключателю оборонного средства "Молния"
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (gameManager != null)
            {
                gameManager.DefendChoose = DefendEnum.Thunderbolt;
                radioButton7.Checked = false;
            }
        }

        private static readonly Image image3 = ImageHelper.ButtonStop;
        private static readonly Image image4 = ImageHelper.ButtonContinue;

        // Действия, при нажатии на кнопку "Stop/Play"
        private void button2_Click(object sender, EventArgs e)
        {
            if (gameManager == null)
            {
                return;
            }

            if (button2.BackgroundImage == image3)
            {
                timer1.Stop();
                button2.BackgroundImage = image4;
            }
            else
            {
                timer1.Start();
                button2.BackgroundImage = image3;
            }
        }

        // Ограничение для значения надписи, содержащей данные о здоровье замка
        private void lblCastleHealth_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblCastleHealth.Text) < 0)
            {
                lblCastleHealth.Text = "0";
            }
        }

        // Действия, при закрытии формы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Действия, при нажатии на кнопку "Exit"
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Intro = new Form2();
            this.Hide();
            Intro.Show();
        }

        private static readonly Image image1 = ImageHelper.ButtonExit1;
        private static readonly Image image2 = ImageHelper.ButtonExit2;

        // Поведение кнопки "Exit" при наведении курсором мыши 
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImage = image2;
            button3.BackColor = Color.Transparent;
        }

        // Поведение кнопки "Exit" при снятия курсора мыши 
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImage = image1;
            button3.BackColor = Color.Transparent;
        }   
    }
}
