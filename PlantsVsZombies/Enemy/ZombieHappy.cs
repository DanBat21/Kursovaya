using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal class ZombieHappy : AbstractEnemy // Класс описывающий врага "Удачный Зомби"
    {
        public override int RewardMoney => 16; // Награда за уничтожение врага

        public override int OriginalHealth => 15; // Здоровье врага при генерации

        public override int Speed => 2; // Скорость передвижения врага

        public override int Damage => 4; // Наносимый врагом урон обороным средствам и замку

        public override Image Image => ImageHelper.ZombieHappy; // Изображение врага "Удачный Зомби"
    }
}
