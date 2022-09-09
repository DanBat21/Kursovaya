using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendBomb : AbstractDefend // Класс, описывающий оборонное средство "Бомба"
    {
        public override int OriginalPrice => 70; // Цена установки на игровое поле
        public override int OriginalHealth => 10; // Здоровье при установке на игровое поле
        public override Image Image => ImageHelper.Bomb; // Изображение "Бомбы"
        public override AbstractShoot TypeShoot => null; // Тип снаряда (отсутсвует для отсутствует для оборонного средства "Бомба")
        public override int ShootInterval => 0; // Интервал между выстрелами (отсутсвует для отсутствует для оборонного средства "Бомба")
    }
}
