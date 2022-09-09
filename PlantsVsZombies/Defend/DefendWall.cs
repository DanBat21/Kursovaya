using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendWall : AbstractDefend // Класс, описывающий оборонное средство "Стена"
    {
        public override int OriginalPrice => 50; // Цена установки на игровое поле 
        public override int OriginalHealth => 500; // Здоровье при установке
        public override Image Image => ImageHelper.Wall; // Изображение "Стены"
        public override AbstractShoot TypeShoot => null; // Тип снаряда (отсутствует для оборонного средства "Стена")
        public override int ShootInterval => 0; // Интервал между выстрелами (отсутствует для оборонного средства "Стена")
    }
}
