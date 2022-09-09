using PlantsVsZombies.Enemy;
using System.Collections.Generic;
using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal abstract class AbstractShoot // Класс, описывающий любой снаряд оборонного средства 
    {
        public abstract int Damage { get; } // Наносимый снарядом урон врагу

        public Point Location { get; set; } = new Point(0, 0); // Положение снаряда на игровом поле

        public abstract Image Image { get; } // Изображение снаряда

        public List<AbstractEnemy> HiitedEnemies { get; set; } = new List<AbstractEnemy>(); // Список врагов, которым наносится урон
    }
}
