using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendWallV2 : AbstractDefend // Класс, описывающий оборонное средство "Улучшенная Стена"
    {
        public override int OriginalPrice => 70; // Цена улучшения
        public override int OriginalHealth => 800; // Здоровье улучшенного оборонного средства
        public override Image Image => ImageHelper.Wall2; // Изображение "Улучшенной Стены"
        public override AbstractShoot TypeShoot => null; // Тип снаряда (отсутствует для оборонного средства "Улучшенная Стена")
        public override int ShootInterval => 0; // Интервал между выстрелами (отсутствует для оборонного средства "Улучшенная Стена")
    }
}
