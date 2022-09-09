using PlantsVsZombies.Defend;
using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal abstract class AbstractEnemy // Класс, описывающий любого врага
    {
        public int Health { get; set; } // Здоровье врага

        public abstract int RewardMoney { get; } // Награда за уничтожение врага

        public abstract int OriginalHealth { get; } // Здоровье врага при генерации 

        public abstract int Speed { get; } // Скорость врага

        public abstract int Damage { get; } // Наносимый врагом урон обороным средствам и замку

        public Point Location { get; set; } = new Point(0, 0); // Положение врага на игровом поле

        public abstract Image Image { get; } // Изображение врага

        public EnemyState State { get; set; } = EnemyState.Stay; // Установка врагу статуса "Стоять"

        public AbstractDefend DefendForAttack { get; set; } // Объект обороны, атакующийся врагом
    }

    public enum EnemyState // Перечисление для трех возможных статусов врагов во время игрового процесса
    {
        Stay,
        Walk,
        Attack
    }
}
