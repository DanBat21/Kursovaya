using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendDrakon : AbstractDefend // Класс, описывающий оборонное средство "Дракон"
    {
        public override int OriginalPrice => 100; // Цена установки на игровое поле 
        public override int OriginalHealth => 60; // Здоровье при установке
        public override Image Image => ImageHelper.Drakon; // Изображение "Дракона"
        public override AbstractShoot TypeShoot => new DefendDrakonShoot(); // Тип снаряда 
        public override int ShootInterval => 75; // Интервал между выстрелами
    }

    internal class DefendDrakonShoot : AbstractShoot // Класс, описывающий снаряд оборонного средства "Дракон"
    {
        public override int Damage => 7; // Урон снаряда
        public override Image Image => ImageHelper.DrakonShoot; // Изображение снаряда
    }
}
