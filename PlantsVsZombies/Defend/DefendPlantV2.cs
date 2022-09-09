using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendPlantV2 : AbstractDefend // Класс, описывающий оборонное средство "Улучшенное Растение"
    {
        public override int OriginalPrice => 70; // Цена улучшения
        public override int OriginalHealth => 70; // Здоровье улучшенного оборонного средства
        public override Image Image => ImageHelper.Plant2; // Изображение "Улучшенного Растения"
        public override AbstractShoot TypeShoot => new DefendPlantShoot2(); // Тип снаряда
        public override int ShootInterval => 55; // Интервал между выстрелами
    }

    internal class DefendPlantShoot2 : AbstractShoot // Класс, описывающий снаряд оборонного средства "Улучшенное Растение"
    {
        public override int Damage => 8; // Урон снаряда
        public override Image Image => ImageHelper.PlantShoot2; // Изображение снаряда
    }
}
