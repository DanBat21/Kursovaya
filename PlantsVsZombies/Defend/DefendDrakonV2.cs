using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendDrakonV2 : AbstractDefend // Класс, описывающий оборонное средство "Улучшенный Дракон"
    {
        public override int OriginalPrice => 85; // Цена улучшения
        public override int OriginalHealth => 80; // Здоровье улучшенного оборонного средства
        public override Image Image => ImageHelper.Drakon2; // Изображение "Улучшенного Дракона"
        public override AbstractShoot TypeShoot => new DefendDrakonShoot2(); // Тип снаряда
        public override int ShootInterval => 70; // Интервал между выстрелами
    }

    internal class DefendDrakonShoot2 : AbstractShoot // Класс, описывающий снаряд оборонного средства "Улучшенный Дракон"
    {
        public override int Damage => 8; // Урон снаряда
        public override Image Image => ImageHelper.DrakonShoot2; // Изображение снаряда
    }
}
