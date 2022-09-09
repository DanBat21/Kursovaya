using System.Drawing;

namespace PlantsVsZombies
{
    internal static class ImageHelper // Класс для работы с изображениями игровых объектов
    {
        public static Image Grid = Image.FromFile("images/grid1.png"); // Игровое поле
        public static Image Castle = Image.FromFile("images/tower.png"); // Замок
        public static Image Thunderbolt = Image.FromFile("images/thunderbolt.png"); // Оборонное средство "Молния"

        public static Image Plant = Image.FromFile("images/plant.png"); // Оборонное средство "Растение"
        public static Image Plant2 = Image.FromFile("images/plant_2.png"); // Оборонное средство "Улучшенное Растение"
        public static Image PlantShoot = Image.FromFile("images/plant_shoot.png"); // Снаряд оборонного средства "Растение"
        public static Image PlantShoot2 = Image.FromFile("images/plant_shoot2.png"); // Снаряд оборонного средства "Улучшенное Растение"

        public static Image Drakon = Image.FromFile("images/drakon.png"); // Оборонное средство "Дракон"
        public static Image Drakon2 = Image.FromFile("images/drakon_2.png"); // Оборонное средство "Улучшенный Дракон"
        public static Image DrakonShoot = Image.FromFile("images/drakon_shoot.png"); // Снаряд оборонного средства "Дракон"
        public static Image DrakonShoot2 = Image.FromFile("images/drakon_shoot2.png"); // Снаряд оборонного средства "Улучшенный Дракон"

        public static Image Bomb = Image.FromFile("images/bomb.png"); // Оборонное средство "Бомба"
        public static Image Bomb2 = Image.FromFile("images/bomb_2.png"); // Оборонное средство "Улучшенная Бомба"

        public static Image Wall = Image.FromFile("images/wall.png"); // Оборонное средство "Стена"
        public static Image Wall2 = Image.FromFile("images/wall_2.png"); // Оборонное средство "Улучшенная Стена"

        public static Image ZombieDefault = Image.FromFile("images/zombie_default.png"); // Враг "Обычный Зомби"
        public static Image ZombieStrong = Image.FromFile("images/zombie_strong.png"); // Враг "Мощный Зомби"
        public static Image ZombieFunny = Image.FromFile("images/zombie_funny.png"); // Враг "Потешный Зомби"
        public static Image ZombieArmor = Image.FromFile("images/zombie_armor.png"); // Враг "Зомби в броне"
        public static Image ZombieHappy = Image.FromFile("images/zombie_happy.png"); // Враг "Удачный Зомби"

        public static Image ButtonPlay1 = Image.FromFile("images/Play1.png"); // Кнопка "Play" на форме Меню
        public static Image ButtonPlay2 = Image.FromFile("images/Play2.png"); // Кнопка "Play" при наведении курсора
        public static Image ButtonExit1 = Image.FromFile("images/Exit.png"); // Кнопка "Exit"
        public static Image ButtonExit2 = Image.FromFile("images/Exit1.png"); // Кнопка "Exit" при наведении курсора
        public static Image ButtonStart = Image.FromFile("images/Start.png"); // Кнопка "Start" 
        public static Image ButtonStop = Image.FromFile("images/Stop.png"); // Кнопка "Stop" 
        public static Image ButtonContinue = Image.FromFile("images/Playgame.png"); // Кнопка "Play" на форме игры
    }
}

