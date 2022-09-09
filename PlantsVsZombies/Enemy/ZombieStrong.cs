using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal class ZombieStrong : AbstractEnemy // Класс описывающий врага "Мощный Зомби"
    {
        public override int RewardMoney => 25; // Награда за уничтожение врага

        public override int OriginalHealth => 22; // Здоровье врага при генерации

        public override int Speed => 2; // Скорость передвижения врага

        public override int Damage => 7; // Наносимый врагом урон обороным средствам и замку

        public override Image Image => ImageHelper.ZombieStrong; // Изображение врага "Мощный Зомби"
    }
}
