using System.Collections.Generic;
using System.Drawing;

namespace PlantsVsZombies.Defend
{
    internal abstract class AbstractDefend  // Класс, описывающий любое оборонное средство
    {
        public abstract int OriginalPrice { get; } // Изначальная цена покупки

        public int Price { get; set; } // Изменяющаяся цена улучшения 

        public abstract int OriginalHealth { get;} // Здоровье при установке

        public int Health { get; set; } // Изменяющееся здоровье при взаимодействии с врагами

        public Point Location { get; set; } = new Point(0, 0); // Положение оборонного средства на игровом поле

        public abstract Image Image { get; } // Изображение средства обороны

        // Позиция каждого установленного оборонного средства
        public int Column { get; set; } // Столбец игрового поля 
        public int Row { get; set; } // Строка игрового поля

        public abstract AbstractShoot TypeShoot { get; } // Тип снаряда оборонного средства

        public List<AbstractShoot> Shoots { get; private set; } // Список снарядов оборонных средств

        public abstract int ShootInterval { get; } // Задержка между выстрелами

        public int ShootDelay { get; set; } // Задержка перед первым выстрелом после установки оборонного средства

        /// <summary>
        /// Метод инициализации любого оборонного средства
        /// </summary>
        public void Init() 
        {
            Shoots = new List<AbstractShoot>();
            Health = OriginalHealth;
        }
    }
}
