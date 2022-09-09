using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsVsZombies.Defend
{
    internal class DefendCastle : AbstractDefend // Класс, описывающий оборонное средство "Замок"
    {
        public override int OriginalPrice => 20; // Цена улучшения здоровья замка
        public override int OriginalHealth => 800; // Здоровье замка при запуске игры
        public override Image Image => ImageHelper.Castle; // Изображение замка

        public override AbstractShoot TypeShoot => null; // Тип снаряда (отсутсвует для замка) 
        public override int ShootInterval => 0; // Интервал между выстрелами (отсутсвует для замка)

        /// <summary>
        /// Метод установки картинки замка на игровом поле
        /// </summary>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, 5, 0, 160, 500); 
        }
    }
}
