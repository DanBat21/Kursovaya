using PlantsVsZombies.Defend;
using PlantsVsZombies.Enemy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantsVsZombies
{
    internal class GameManager
    {
        private Random random = new Random();

        private List<AbstractDefend> defendTools = new List<AbstractDefend>(); // Список всех оборонных средств

        private List<AbstractEnemy> Enemies = new List<AbstractEnemy>(); // Список всех врагов на игровом поле

        private int FieldWidth = 1185; // Параметр ширины основного поля

        private int FieldHeight = 590; // Параметр высоты основного поля

        private AbstractDefend[,] defendGrid; // Двумерный массив, содержащий установленные на поле игры средства обороны

        private int TimeForNextEnemy; // Время генерации следующего врага
        public int DelaySpawnEnemies = 90; // Задержка между генерируемыми врагами

        public static int CountColumns = 7; // Количество горизонтальных ячеек игрового поля
        public static int CountRows = 3; // Количество вертикальных ячеек игрового поля

        public bool IsGameOver { get; private set; } = false; // Логическая переменная, символизирующая конец игры 
        public DefendCastle Castle { get; private set; } // Объект замка

        public DefendEnum? DefendChoose { get; set; } = null; // Переменная, определяющая выбранное для установки оборонное средство

        public int CurrentHealth { get; set; } = 800; // Здоровье замка на старте игры
        public int CurrentMoney { get; set; } = 400; // Количество денег на старте игры

        public int CurrentPoints { get; set; } = 0; // Количество очков на старте игры

        public event Action GameOver; // Событие, которое вызывается при проигрыше
        public event Action<int> CastleHealthChanged; // Событие, которое вызывается при изменении здоровья замка
        public event Action<int> CastlePriceChanged; // Событие, которое вызывается при изменении цены улучшения замка
        public event Action<int> MoneyChanged; // Событие, которое вызывается при изменении количества денег игрока
        public event Action<int> PointsChanged; // Событие, которое вызывается при изменении количества очков игрока

        public static int GameFieldHeight => 475; // Высота игрового поля

        public static int CastleEndX = 145; // Линия появления замка на игровом поле
        public static int GameFieldEndX = 815; // Линия появления врагов на игровом поле

        public static int GameFieldWidth = 850; // Ширина игрового поля

        public static int CellWidth = GameFieldWidth / CountColumns; // Количество пикселей, которых занимает одна ячейка игрового поля в ширину
        public static int CellHeight = GameFieldHeight / CountRows; // Количество пикселей, которых занимает одна ячейка игрового поля в высоту

        /// <summary>
        /// Метод, запускающий игровой процесс 
        /// </summary>
        public void Start()    
        {
            defendGrid = new AbstractDefend[CountColumns, CountRows]; // Инициализация двумерного массива, определяющего ячейки игрового поля
            TimeForNextEnemy = DelaySpawnEnemies; // Промежуток времени между каждым генерируемым врагом

            Castle = new DefendCastle(); // Инициализация объекта замка
            Castle.Init(); // Вызов метода, инициализирующего здоровье замка
            Castle.Price = Castle.OriginalPrice; // Инициализация переменной, обозначающей здоровье замка

            defendTools.Add(Castle); // Добавление замка в список оборонных средств
            
            defendGrid[0, 0] = Castle; // Ячейки, занимаемые замком в двумерном массиве ячеек
            defendGrid[0, 1] = Castle; // Ячейки, занимаемые замком в двумерном массиве ячеек
            defendGrid[0, 2] = Castle; // Ячейки, занимаемые замком в двумерном массиве ячеек

            CastleHealthChanged(CurrentHealth); // Изменение текущего здоровья
            MoneyChanged(CurrentMoney); // Изменение текущего количества денег
            PointsChanged(CurrentPoints); // Изменение текущего количества очков
            CastlePriceChanged(Castle.Price); // Изменение цены улучшения замка
        }

        /// <summary>
        /// Метод, запускающий процесс генерации врагов 
        /// </summary>
        public void SpawnEnemy()
        {
            var enemy = GenerateEnemy(); // Создание экземпляра и вызов для него метода определяющего тип генерируемого врага
            enemy.Health = enemy.OriginalHealth; // Присвоение здоровью генерируемого врага изначального значения

            const int offestX = 285; // Конечная точка, до которой враг осуществляет движение

            var line = random.Next(CountRows); // Случайный выбор одной строки из трех возможных для генерации на ней врага 

            // Нахождение центра ячеек каждой линии, для генерации там врагов
            var y = ((FieldHeight) / CountRows) * line - 10;
            if (line == CountRows - 2)
            {
                y -= 30;
            }
            if (line == CountRows - 1)
            {
                y -= 80;
            }

            enemy.Location = new Point(FieldWidth - offestX, y); // Начальная точка генерации врага

            enemy.State = EnemyState.Walk; // Изменение статуса врага на "Идти"

            Enemies.Add(enemy); // Добавление генерируемого врага в список врагов
        }

        /// <summary>
        /// Метод, определяющий тип генерируемого врага случайным образом 
        /// </summary>
        private AbstractEnemy GenerateEnemy()
        {
            var typeEnemy = random.Next(5);
            switch (typeEnemy)
            {
                case 0: return new ZombieCommon();
                case 1: return new ZombieFunny();
                case 2: return new ZombieHappy();
                case 3: return new ZombieStrong();
                case 4: return new ZombieArmor();
                default: return null;
            }
        }

        /// <summary>
        /// Метод, который срабатывает при запуске таймера
        /// </summary>
        public void GameStep(Graphics graphics)
        {
            if (IsGameOver)
            {
                return;
            }

            Castle.Draw(graphics); // Вызов метода, располагающего картинку замка по заданным координатам 

            // Генерация врагов на игровом поле
            TimeForNextEnemy--; 
            if (random.NextDouble() >= 0.92 && TimeForNextEnemy <= 0)
            {
                SpawnEnemy();
                TimeForNextEnemy = DelaySpawnEnemies;
            }

            // Активация способности оборонного средства "Молния", при достаточном количестве денег
            if (DefendChoose == DefendEnum.Thunderbolt)
            {
                if (CurrentMoney >= 80)
                {
                    ActivateThunderBolt(graphics);
                    CurrentMoney -= 80;
                    MoneyChanged(CurrentMoney);
                }
                DefendChoose = null;
            }

            // Если здоровье врага на игровом поле становится равно 0, добавлять игроку деньги и очки за его уничтожение
            Enemies.RemoveAll(x =>
            {
                if (x.Health < 0)
                {
                    // Ограничение на начисляемое игроку количество игровых денег
                    if (CurrentMoney <= 300)
                    {
                        CurrentMoney += x.RewardMoney;
                        MoneyChanged(CurrentMoney);
                    }
                    
                    CurrentPoints += x.RewardMoney / 2;
                    PointsChanged(CurrentPoints);

                    // Увеличение количества генерируемых врагов при наборе игроком 150 очков
                    if (CurrentPoints > 150)
                    {
                        DelaySpawnEnemies -= 8;
                        TimeForNextEnemy = 5;

                        if (CurrentPoints > 800)
                        {
                            DelaySpawnEnemies -= 15;
                            TimeForNextEnemy = 1; 
                        }
                    }
                    
                    return true;
                }
                return false;
            });

            
            foreach (var defend in defendTools)
            {
                // Если здоровье замка не равно 0, игровой процесс продолжается
                if (defend is DefendCastle)
                {
                    continue;
                }

                // Каждый "тик" таймера, заново отрисовывается игровая площадь
                var offsetX = defend.Column >= 5 ? 10 : 25;
                graphics.DrawImage(defend.Image, defend.Location.X + offsetX, defend.Location.Y + 20, 100, 100);

                if (defend.TypeShoot != null)
                {
                    // Если запущен алгоритм выстрела, отрисовка и генерация снарядов
                    if (defend.ShootDelay <= 0)
                    {
                        var shoot = defend.TypeShoot;
                        shoot.Location = new Point(defend.Location.X + 50, defend.Location.Y);

                        var rect = new Rectangle(shoot.Location, new Size(GameFieldWidth, 50));
                        var shootedZombie = Enemies.FirstOrDefault(x =>
                            Rectangle.Intersect(new Rectangle(x.Location, new Size(100, 100)), rect).X != 0);

                        // Если на игровом поле присутвует враг, запускается алгоритм выстрела
                        if (shootedZombie != null)
                        {
                            defend.Shoots?.Add(shoot);
                            defend.ShootDelay = defend.ShootInterval;
                        }
                    }
                    else
                    {
                        defend.ShootDelay--;
                    }

                    AbstractShoot shootForDelete = null;  // Переменная, в которую записывается снаряд, который надо удалить
                    
                    // Определение снарядов, которые должны исчезнуть при столкновении с врагом или при достижении конца поля
                    foreach (var shoot in (defend.Shoots ?? Enumerable.Empty<AbstractShoot>()))
                    {
                        var newX = shoot.Location.X + 5;
                        shoot.Location = new Point(newX, defend.Location.Y);

                        graphics.DrawImage(defend.TypeShoot.Image, newX + offsetX, defend.Location.Y + 20, 50, 50);

                        var rect = new Rectangle(shoot.Location, new Size(50, 50));

                        var shootedZombie = Enemies.FirstOrDefault(x =>
                            Rectangle.Intersect(new Rectangle(x.Location, new Size(100, 100)), rect).X != 0);
                        
                        // Если снаряд сталкивается с врагом
                        if (shootedZombie != null)
                        {
                            // Если снаряд пущен оборонным средством "Дракон" или "Улучшенный Дракон",
                            // удаление не происходит, так как эти снаряды должны быть "сквозными"
                            if (shoot is DefendDrakonShoot || shoot is DefendDrakonShoot2)
                            {
                                // Снаряд помечается на удаление при достижении им конца игрового поля
                                if (shoot.Location.X > GameFieldEndX)
                                {
                                    shootForDelete = shoot;
                                }
                            }
                            // Если снаряд, сталкивающийся с врагом, относится к остальным оборонным средствам
                            else
                            {
                                shootForDelete = shoot; // Снаряд помечается на удаление
                            }

                            // При попадании снаряда в врага, враг помечается, как "поражаемый" 
                            if (!shoot.HiitedEnemies.Any(x => x == shootedZombie))
                            {
                                shoot.HiitedEnemies.Add(shootedZombie);
                                shootedZombie.Health -= shoot.Damage;
                            }
                        }
                    }
                    
                    // Снаряд, помеченный на удаление, удаляется с поля игры
                    if (shootForDelete != null)
                    {
                        defend.Shoots.Remove(shootForDelete);
                    }
                }
            }

            // Когда статус врага - "Идти", враг перемещается по игровому полю с определенной скоростью
            foreach (var zombie in Enemies.Where(x => x.State == EnemyState.Walk))
            {
                var newX = zombie.Location.X - zombie.Speed;
                zombie.Location = new Point(newX, zombie.Location.Y);
            }

            // Когда статус врага - "Атаковать", враг наносит урон оборонному средству или замку
            foreach (var zombie in Enemies.Where(x => x.State == EnemyState.Attack))
            {
                zombie.DefendForAttack.Health -= zombie.Damage; // Враг наносит урон оборонному средству

                if (zombie.DefendForAttack is DefendCastle)
                {
                    CastleHealthChanged(zombie.DefendForAttack.Health); // Враг наносит урон замку
                }
            }

            // При генерации врагов, их картинкам задается определенный размер 
            foreach (var enemy in Enemies)
            {
                var width = 150;
                var height = 150;
                if (enemy is ZombieCommon)
                {
                    width = 90;
                    height = 150;
                }
                graphics.DrawImage(enemy.Image, enemy.Location.X, enemy.Location.Y, width, height);

                var column = (int)Math.Ceiling((double)(enemy.Location.X - CastleEndX) / CellWidth);
                var row = (int)Math.Ceiling((double)enemy.Location.Y / CellHeight);

                // Если положение врага и оборонного средства на игровом поле совпадают, то враг наносит урон оборонному средству
                if (column < CountColumns && column >= 0
                    && row < CountRows && row >= 0
                    && defendGrid[column, row] != null)
                {
                    enemy.DefendForAttack = defendGrid[column, row];
                    enemy.State = EnemyState.Attack;
                }
            }

            
            var destroyedDefend = defendTools.Where(x => x.Health <= 0);           
            foreach (var destroyed in destroyedDefend)
            {
                // Когда здоровье оборонного средства достигает 0, оно удаляется
                if (destroyed.Health <= 0)
                {
                    defendGrid[destroyed.Column, destroyed.Row] = null;

                    var zombies = Enemies.Where(x => x.DefendForAttack == destroyed);

                    // Когда враг уничтожает оборонное средство, статус врага меняется на "Идти"
                    foreach (var zombie in zombies)
                    {
                        zombie.DefendForAttack = null;
                        zombie.State = EnemyState.Walk;

                        // Если враг уничтожил бомбу, то с ее уничтожением, враг получает урон
                        if (destroyed is DefendBomb)
                        {
                            zombie.Health -= 15;
                        }
                        if (destroyed is DefendBomb2)
                        {
                            zombie.Health -= 20;
                        }
                    }
                }
            }
            defendTools.RemoveAll(x => x.Health <= 0); // Оборонное средство, здоровье которого равно 0, удаляется с игрового поля     
            
            // Если здоровье замка опускается до 0, игра проиграна
            if (!defendTools.Any(x => x is DefendCastle))
            {
                IsGameOver = true;
                GameOver();
            }
        }

        /// <summary>
        /// Метод, который возвращает координаты x,y места, куда кликнули мышкой 
        /// </summary>
        public void HandleMouseClick(int x, int y)
        {
            // Определяется строка и столбец, куда кликнули мышкой
            var column = (int)Math.Ceiling((double)(x - CastleEndX)/ CellWidth);
            var row = (int)Math.Ceiling((double)y / CellHeight) - 1;

            // Если кликнули в области, где нельзя производить взаимодействие с игровым полем, ничего не происходит
            if (column < 0 || column >= CountColumns
                || row < 0 || row >= CountRows)
            {
                return;
            }

            // Если кликнули в ячейку игрового поля, где размещено оборонное средство
            if (DefendChoose != null)
            {
                var columnStartX = column * CellWidth;
                var rowStartY = row * CellHeight;

                // Если выбрано действие "Очистить"
                if (DefendChoose.Value == DefendEnum.Remove)
                {
                    // Если кликнули в области, где размещен замок, то ничего не происходит
                    if (column == 0)
                    {
                        return;
                    }

                    var defendForRemove = defendGrid[column, row]; // Оборонное средство помечается на удаление
                    defendTools.Remove(defendForRemove); // Оборонное средство удаляется
                    defendGrid[column, row] = null; // Данные оборонного средства удаляются из массива, содержащего оборонные средства, расположенные на игровом поле 

                    // Для врага, который наносил урон удаленному средству обороны
                    foreach (var zombie in Enemies.Where(z => z.DefendForAttack == defendForRemove))
                    {
                        zombie.DefendForAttack = null; // Удаленный объект больше не помечен для врага атакуемым
                        zombie.State = EnemyState.Walk; // Статус врага меняется на "Идти"

                        // Если удаляемое оборонное средство - бомба, наносится урон атаковавшему ее врагу
                        if (defendForRemove is DefendBomb)
                        {
                            zombie.Health -= 15; 
                        }
                        if (defendForRemove is DefendBomb2)
                        {
                            zombie.Health -= 20;
                        }
                    }

                    return;
                }

                // Если выбрано действие "Улучшить"
                if (DefendChoose.Value == DefendEnum.Upgrade)
                {
                    var defendForUpgrade = defendGrid[column, row]; // Оборонное средство помечается на улучшение
                    if (defendForUpgrade == null)
                    {
                        return;
                    }

                    var upgrade = GetObjectForUpgrade(defendForUpgrade); 
                    var cost = upgrade?.OriginalPrice; // Цена улучшения сравнивается с текущим количеством денег игрока
                    if (upgrade == null)
                    {
                        return;
                    }
                    // Если текущего количества денег не хватает для улучшения, ничего не происходит
                    if (upgrade.OriginalPrice > CurrentMoney)
                    {
                        return;
                    }
                    else
                    {
                        // Если объектом для улучшения выбран замок
                        if (upgrade is DefendCastle)
                        {
                            // Если текущего количества денег не хватает для улучшения, ничего не происходит
                            if (Castle.Price > CurrentMoney)
                            {
                                return;
                            }

                            // Здоровье и цена на следующее улучшение замка увеличиваются
                            Castle.Health += 100; 
                            cost = Castle.Price;
                            Castle.Price = (int)(Castle.Price * 1.5); 
                            CastleHealthChanged(Castle.Health);
                            CastlePriceChanged(Castle.Price);
                        }
                    }

                    // Замена обычной версии оборонного средства на его улучшенную версию на игровом поле
                    upgrade.Init();
                    upgrade.Location = defendForUpgrade.Location;
                    upgrade.Row = defendForUpgrade.Row;
                    upgrade.Column = defendForUpgrade.Column;

                    // Удаление информации о замененной версии оборонного средства
                    defendForUpgrade.Shoots.RemoveAll(shoot => true);
                    defendTools.Remove(defendForUpgrade);
                    defendTools.Add(upgrade);

                    // Вычет требуемого для улучшения количества денег из текущего количества 
                    CurrentMoney -= cost.Value;
                    MoneyChanged(CurrentMoney);

                    defendGrid[column, row] = upgrade; // Внесение информации об улучшенном оборонном средстве в массив оборонных средств, размещенных на игровом поле
                    return;
                }
                
                // Если пытаться поставить оборонное средство на уже установленное, ничего не происходит
                if (defendGrid[column, row] != null)
                {
                    return;
                }

                // Создание переменной и запись в нее оборонного средства для установки
                var defend = GetObjectForDefend(DefendChoose.Value);

                // Если текущего количества денег не хватает для установки, ничего не происходит
                if (defend.OriginalPrice > CurrentMoney)
                {
                    return;
                }

                // Добавление на игровое поле установленного оборонного средства
                defend.Init();
                defend.Location = new Point(columnStartX, rowStartY);
                defend.Row = row;
                defend.Column = column;
                defend.ShootDelay = defend.ShootInterval / 2;

                // Вычет требуемого для улучшения количества денег из текущего количества 
                CurrentMoney -= defend.OriginalPrice;
                MoneyChanged(CurrentMoney);

                // Внесение информации об установленном оборонном средстве в массив оборонных средстве в массив оборонных средств, размещенных на игровом поле
                defendGrid[column, row] = defend; 
                defendTools.Add(defend);
            }
        }

        /// <summary>
        /// Метод, который активирует способность оборонного средства "Молния"
        /// </summary>
        public void ActivateThunderBolt(Graphics graphics)
        {
            // Если текущего количества денег не хватает для использования, ничего не происходит
            if (CurrentMoney < 80)
            {
                return;
            }

            // Выбор ближайшего к замку врага для уничтожения
            var zombie = Enemies.OrderBy(x => x.Location.X).FirstOrDefault();
            if (zombie != null)
            {
                zombie.Health -= 500; // Уничтожение врага
                graphics.DrawImage(ImageHelper.Thunderbolt, zombie.Location);
            }
        }

        /// <summary>
        /// Метод выбора объекта оборонного средства
        /// </summary>
        private AbstractDefend GetObjectForDefend(DefendEnum defend)
        {
            switch (defend)
            {
                case DefendEnum.Wall:
                    return new DefendWall();
                case DefendEnum.Plant:
                    return new DefendPlant();
                case DefendEnum.Drakon:
                    return new DefendDrakon();
                case DefendEnum.Bomb:
                    return new DefendBomb();
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Метод выбора объекта улучшенного оборонного средства
        /// </summary>
        private AbstractDefend GetObjectForUpgrade(AbstractDefend defend)
        {
            if (defend is DefendCastle)
                return new DefendCastle();
            if (defend is DefendPlant)
                return new DefendPlantV2();
            if (defend is DefendDrakon)
                return new DefendDrakonV2();
            if (defend is DefendBomb)
                return new DefendBomb2();
            if (defend is DefendWall)
                return new DefendWallV2();

            return null;
        }
    }
}
