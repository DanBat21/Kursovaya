using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal class DefendPlant : AbstractDefend // Класс, описывающий оборонное средство "Растение"
    {
        public override int OriginalPrice => 85; // Цена установки на игровое поле 
        public override int OriginalHealth => 50; // Здоровье при установке
        public override Image Image => ImageHelper.Plant; // Изображение "Растения"
        public override AbstractShoot TypeShoot => new DefendPlantShoot(); // Тип снаряда 
        public override int ShootInterval => 60; // Интервал между выстрелами
    }

    internal class DefendPlantShoot : AbstractShoot // Класс, описывающий снаряд оборонного средства "Растение"
    {
        public override int Damage => 6; // Урон снаряда
        public override Image Image => ImageHelper.PlantShoot; // Изображение снаряда
    }
}
