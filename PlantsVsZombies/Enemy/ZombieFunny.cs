using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal class ZombieFunny : AbstractEnemy // Класс описывающий врага "Потешный Зомби"
    {
        public override int RewardMoney => 7; // Награда за уничтожение врага

        public override int OriginalHealth => 7; // Здоровье врага при генерации

        public override int Speed => 3; // Скорость передвижения врага

        public override int Damage => 1; // Наносимый врагом урон обороным средствам и замку

        public override Image Image => ImageHelper.ZombieFunny; // Изображение врага "Потешный Зомби"
    }
}
