using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShipClass
{
    public class TestCollecctions
    {
        public static string[] ShipName = { "Слава", "Паллада", "Чесма", "Диана", "Варяг", "Безбоязнь", "Цвет войны", "Лев", "Единорог", "Геркулес",  "Крепость", "Скорпион", "Флаг",
        "Гром", "Молния", "Громовая стрела", "Иван-город", "Кроншлот", "Шлиссельбург", "Санкт-Петербург", "Нарва", "Пернов", "Рига", "Выборг", "Полтава", "Ингерманланд", "Ревель", "Лесное", "Гангут",
        "Гавриил", "Михаил", "Уриил", "Салафаил", "Варахаил", "Ягудиил", "Михаил", "Иоанн Предтеча", "Мария Магдалина", "Св. Владимир", "Св. Павел", "Преображение Господне", "Св. Александр Невский",
        "Георгий Победоносец", "Св. Андрей Первозванный", "Св. Иоанн Богослов", "Новик", "Россия", "Громобой", "Рюрик", "Аскольд", "Олег", "Богатырь", "Баян", "Паллада",
        "Адмирал Ушаков", "Адмирал Лазарев", "Адмирал Нахимов", "Петр Великий", "Каганович", "Молотов", "Черненко", "Брежнев", "Слава", "Маршал Устинов", "Червона Украина" };
        public static string[] ShipNamePostfix = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV" };
        public static string[] PortName = { "Азов", "Ейск", "Таганрог", "Санкт-Петербург", "Астрахань", "Мурманск", "Владивосток" };
        public static Random random = new Random();
        public Queue<Ship> queueShip;
        public Queue<string> stringQueueShip;
        public SortedDictionary<Ship, SteamBoat> sortedDictionaryShip;
        public SortedDictionary<string, SteamBoat> stringSortedDictionaryShip;
        public int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public Queue<Ship> QueueShip
        {
            get
            {
                return queueShip;
            }
            set
            {
                queueShip = value;
            }
        }
        public Queue<string> StringQueueShip
        {
            get
            {
                return stringQueueShip;
            }
            set
            {
                stringQueueShip = value;
            }
        }
        public SortedDictionary<Ship, SteamBoat> SortedDictionaryShip
        {
            get
            {
                return sortedDictionaryShip;
            }
            set
            {
                sortedDictionaryShip = value;
            }
        }
        public SortedDictionary<string, SteamBoat> StringSortedDictionaryShip
        {
            get
            {
                return stringSortedDictionaryShip;
            }
            set
            {
                stringSortedDictionaryShip = value;
            }
        }
        public TestCollecctions()
        {
            this.Size = 0;
            this.QueueShip = new Queue<Ship>();
            this.StringQueueShip = new Queue<string>();
            this.SortedDictionaryShip = new SortedDictionary<Ship, SteamBoat>();
            this.StringSortedDictionaryShip = new SortedDictionary<string, SteamBoat>();
        }
        public TestCollecctions(int s)
        {
            Size = s;
            GenerateEverething();
        }
        public void GenerateEverething()
        {
            this.QueueShip = new Queue<Ship>();
            this.StringQueueShip = new Queue<string>();
            this.SortedDictionaryShip = new SortedDictionary<Ship, SteamBoat>();
            this.StringSortedDictionaryShip = new SortedDictionary<string, SteamBoat>();
            for (int i = 0; i<Size; i++)
            {
                bool ok = false;
                do
                {
                    SteamBoat steamBoat = new SteamBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                    if (!(this.SortedDictionaryShip.ContainsKey(steamBoat.GetBaseShip)))
                    {
                        this.SortedDictionaryShip.Add(steamBoat.GetBaseShip, steamBoat);
                        this.QueueShip.Enqueue(steamBoat.GetBaseShip);
                        this.StringSortedDictionaryShip.Add(steamBoat.GetBaseShip.ToString(), steamBoat);
                        this.StringQueueShip.Enqueue(steamBoat.GetBaseShip.ToString());
                        ok = true;
                    }
                } while (!ok);
            }
        }
        public void AddGeneratedItem()
        {
            this.Size += 1;
            bool ok = false;
            do
            {
                SteamBoat steamBoat = new SteamBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                if (!(this.SortedDictionaryShip.ContainsKey(steamBoat.GetBaseShip)))
                {
                    this.SortedDictionaryShip.Add(steamBoat.GetBaseShip, steamBoat);
                    this.QueueShip.Enqueue(steamBoat.GetBaseShip);
                    this.StringSortedDictionaryShip.Add(steamBoat.GetBaseShip.ToString(), steamBoat);
                    this.StringQueueShip.Enqueue(steamBoat.GetBaseShip.ToString());
                    ok = true;
                }
            } while (!ok);
        }
        // данный метод удаляет элемент лишь из начала коллекции, это вызвано специфическим огрничением очереди FIFO
        public void RemoveItem()
        {
            if (this.Size!=0)
            {
                this.SortedDictionaryShip.Remove(SortedDictionaryShip.First().Key);
                this.QueueShip.Dequeue();
                this.StringSortedDictionaryShip.Remove(stringSortedDictionaryShip.First().Key);
                this.StringQueueShip.Dequeue();
                this.Size -= 1;
            }
            else
            {
                Console.WriteLine("Коллекция пуста, поэтому из неё нельзя удалить элемент.");
            }
        }
    }
}
