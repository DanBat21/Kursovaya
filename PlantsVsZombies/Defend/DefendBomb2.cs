using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendBomb2 : AbstractDefend // Класс, описывающий оборонное средство "Улучшенная Бомба"
    {
        public override int OriginalPrice => 50; // Цена улучшения 
        public override int OriginalHealth => 15; // Здоровье улучшенного оборонного средства
        public override Image Image => ImageHelper.Bomb2; // Изображение "Улучшенной Бомбы"
        public override AbstractShoot TypeShoot => null; // Тип снаряда (отсутсвует для улучшенной бомбы) 
        public override int ShootInterval => 0; // Интервал между выстрелами (отсутсвует для улучшенной бомбы)
    }
}
