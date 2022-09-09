using System.Drawing;

namespace PlantsVsZombies.Enemy
{
    internal class ZombieArmor : AbstractEnemy // Класс описывающий врага "Зомби в броне"
    {
        public override int RewardMoney => 30; // Награда за уничтожение врага

        public override int OriginalHealth => 30; // Здоровье врага при генерации

        public override int Speed => 2; // Скорость передвижения врага

        public override int Damage => 9; // Наносимый врагом урон обороным средствам и замку

        public override Image Image => ImageHelper.ZombieArmor; // Изображение врага "Зомби в броне"
    }
}
