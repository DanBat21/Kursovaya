using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal class ZombieCommon : AbstractEnemy // Класс описывающий врага "Обычный Зомби"
    {
        public override int RewardMoney => 10; // Награда за уничтожение врага

        public override int OriginalHealth => 10; // Здоровье врага при генерации

        public override int Speed => 3; // Скорость передвижения врага

        public override int Damage => 2; // Наносимый врагом урон обороным средствам и замку

        public override Image Image => ImageHelper.ZombieDefault; // Изображение врага "Обычный Зомби"
    }
}
