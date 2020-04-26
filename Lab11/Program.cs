using System;
using System.Collections.Generic;
using System.Collections;
using LibraryShipClass;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        public static string[] ShipName = { "Слава", "Паллада", "Чесма", "Диана", "Варяг", "Безбоязнь", "Цвет войны", "Лев", "Единорог", "Геркулес",  "Крепость", "Скорпион", "Флаг",
        "Гром", "Молния", "Громовая стрела", "Иван-город", "Кроншлот", "Шлиссельбург", "Санкт-Петербург", "Нарва", "Пернов", "Рига", "Выборг", "Полтава", "Ингерманланд", "Ревель", "Лесное", "Гангут",
        "Гавриил", "Михаил", "Уриил", "Салафаил", "Варахаил", "Ягудиил", "Михаил", "Иоанн Предтеча", "Мария Магдалина", "Св. Владимир", "Св. Павел", "Преображение Господне", "Св. Александр Невский",
        "Георгий Победоносец", "Св. Андрей Первозванный", "Св. Иоанн Богослов", "Новик", "Россия", "Громобой", "Рюрик", "Аскольд", "Олег", "Богатырь", "Баян", "Паллада",
        "Адмирал Ушаков", "Адмирал Лазарев", "Адмирал Нахимов", "Петр Великий", "Каганович", "Молотов", "Черненко", "Брежнев", "Слава", "Маршал Устинов", "Червона Украина" };
        public static string[] ShipNamePostfix = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
        public static string[] PortName = { "Азов", "Ейск", "Таганрог", "Санкт-Петербург", "Астрахань", "Мурманск", "Владивосток" };
        public static Stack shipsStack = new Stack();
        public static List<Ship> shipsList = new List<Ship>();
        public static Random random = new Random();
        public static Stack GenStackShipCollection(int size)
        {
            Stack shipStack = new Stack();
            for (int i = 0; i < size; i++)
            {
                int classofShip = random.Next(1, 4);
                switch (classofShip)
                {
                    case 1:
                        {
                            SteamBoat ship = new SteamBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipStack.Push(ship);
                            break;
                        }
                    case 2:
                        {
                            SailBoat ship = new SailBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipStack.Push(ship);
                            break;
                        }
                    case 3:
                        {
                            Corvette ship = new Corvette(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipStack.Push(ship);
                            break;
                        }
                }
            }
            return shipStack;
        }
        public static List<Ship> GenListShipCollection(int size)
        {
            List<Ship> shipList = new List<Ship>();
            for (int i = 0; i < size; i++)
            {
                int classofShip = random.Next(1, 4);
                switch (classofShip)
                {
                    case 1:
                        {
                            SteamBoat ship = new SteamBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipList.Add(ship);
                            break;
                        }
                    case 2:
                        {
                            SailBoat ship = new SailBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipList.Add(ship);
                            break;
                        }
                    case 3:
                        {
                            Corvette ship = new Corvette(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                            shipList.Add(ship);
                            break;
                        }
                }
            }
            return shipList;
        }
        public static int InputSize()
        {
            int size;
            bool ok;
            do
            {
                Console.Write("Размерность: ");
                ok = int.TryParse(Console.ReadLine(), out size);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип вводимых данных");
                else if (size < 0)
                    Console.WriteLine("Количество элементов не может быть отрицательным");
                else if (size == 0)
                    Console.WriteLine("Чтобы можно было хоть как - то работать с этой коллекцией введите хотя бы количество равное 1");
            } while (!ok);
            return size;
        }
        public static void MakeCollection2()
        {
            int size = InputSize();
            shipsList = GenListShipCollection(size);
        }
        public static void MakeCollection1()
        {
            int size = InputSize();
            shipsStack = GenStackShipCollection(size);
        }
        public static int InputOptionParts()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 0 || option > 6)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 0 || option > 6);
            return option;
        }
        public static int InputInquiryOption()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 1 || option > 3)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 1 || option > 3);
            return option;
        }
        public static int InputChangeCollecction2Option()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 1 || option > 3)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 1 || option > 3);
            return option;
        }
        public static int InputChangeCollecction1Option()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 1 || option > 2)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 1 || option > 2);
            return option;
        }
        public static int InputIndex()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Введите номер для удаленя: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 1 || option > shipsList.Count)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 1 || option > shipsList.Count);
            return option;
        }
        public static int InputOption()
        {
            bool ok;
            int option;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out option);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (option < 0 || option > 2)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 0 || option > 2);
            return option;
        }
        public static int ChooseType()
        {
            Console.WriteLine("Выберете цифру типа корабля, который вам нужен: ");
            Console.WriteLine("1. Пароход;");
            Console.WriteLine("2. Парусник;");
            Console.WriteLine("3. Корвет.");
            bool ok;
            int options;
            do
            {
                Console.Write("Опция: ");
                ok = int.TryParse(Console.ReadLine(), out options);
                if (!ok)
                    Console.WriteLine("Ошибка! Неверный тип для входных данных");
                else if (options < 1 || options > 3)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || options < 1 || options > 3);
            return options;
        }
        public static Ship CreateElement()
        {
            int classofShip = random.Next(1, 4);
            Ship ship = new Ship();
            switch (classofShip)
            {
                case 1:
                    {
                        ship = new SteamBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                        break;
                    }
                case 2:
                    {
                        ship = new SailBoat(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                        break;
                    }
                case 3:
                    {
                        ship = new Corvette(ShipName[random.Next(0, ShipName.Length)] + ShipNamePostfix[random.Next(0, ShipNamePostfix.Length)], random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), PortName[random.Next(0, PortName.Length)], random.Next(800, 1600));
                        break;
                    }
            }
            return ship;
        }
        public static void Changecollection2()
        {
            ChangeCollection2Options();
            int option;
            option = InputChangeCollecction2Option();
            switch (option)
            {
                case 1:
                    Ship FirstShip = CreateElement();
                    shipsList.Prepend(FirstShip);
                    Console.Write("Добавлен элемент в начало: ");
                    FirstShip.Show();
                    break;
                case 2:
                    Ship LastShip = CreateElement();
                    shipsList.Append(LastShip);
                    Console.Write("Добавлен элемент в конец: ");
                    LastShip.Show();
                    break;
                case 3:
                    if (shipsList.Count == 0)
                        Console.WriteLine("Список пуст");
                    else
                    {
                        int index = InputIndex();
                        Ship DeletedShip = shipsList[index];
                        shipsList.RemoveAt(index);
                        Console.Write("Удалён элемент: ");
                        DeletedShip.Show();
                    }
                    break;
            }
        }
        public static void Changecollection1()
        {
            ChangeCollection1Options();
            int option;
            option = InputChangeCollecction1Option();
            switch (option)
            {
                case 1:
                    Ship ship = CreateElement();
                    shipsStack.Push(ship);
                    Console.Write("Добавлен элемент: ");
                    ship.Show();
                    break;
                case 2:
                    if (shipsStack.Count == 0)
                        Console.WriteLine("Стэк пуст");
                    else
                    {
                        Ship DeletedShip = (Ship)shipsStack.Pop();
                        Console.Write("Удалён элемент: ");
                        DeletedShip.Show();
                    }
                    break;              
            }
        }
        public static string InputName()
        {
            Console.Write("Введите имя искомого корабля: ");
            return Console.ReadLine();
        }
        public static string InputPort()
        {
            Console.Write("Введите имя искомого порта: ");
            return Console.ReadLine();
        }
        public static void InquiriesCollection2()
        {
            CollectionInquiry();
            int option = InputInquiryOption();
            switch (option)
            {
                case 1:
                    int type = ChooseType();
                    int count = 0;
                    foreach (Ship ship in shipsList)
                    {
                        switch (type)
                        {
                            case 1:
                                if (ship is SteamBoat)
                                    count++;
                                break;
                            case 2:
                                if (ship is SailBoat)
                                    count++;
                                break;
                            case 3:
                                if (ship is Corvette)
                                    count++;
                                break;
                        }
                    }
                    Console.WriteLine($"В коллекции {count} элементов");
                    break;
                case 2:
                    int Type = ChooseType();
                    foreach (Ship ship in shipsList)
                    {
                        switch (Type)
                        {
                            case 1:
                                if (ship is SteamBoat)
                                    ship.Show();
                                break;
                            case 2:
                                if (ship is SailBoat)
                                    ship.Show();
                                break;
                            case 3:
                                if (ship is Corvette)
                                    ship.Show();
                                break;
                        }
                    }
                    break;
                case 3:
                    string port = InputPort();
                    bool ok = false;
                    foreach (Ship ship in shipsList)
                    {
                        if (ship.Port == port)
                        {
                            ship.Show();
                            ok = true;
                        }
                    }
                    if (!ok)
                        Console.WriteLine("В таком порту нет кораблей");
                    break;
            }
        }
        public static void InquiriesCollection1()
        {
            CollectionInquiry();
            int option = InputInquiryOption();
            switch (option)
            {
                case 1:
                    int type = ChooseType();
                    int count = 0;
                    foreach (Ship ship in shipsStack)
                    {
                        switch (type)
                        {
                            case 1:
                                if (ship is SteamBoat)
                                    count++;
                                break;
                            case 2:
                                if (ship is SailBoat)
                                    count++;
                                break;
                            case 3:
                                if (ship is Corvette)
                                    count++;
                                break;
                        }
                    }
                    Console.WriteLine($"В коллекции {count} элементов");
                    break;
                case 2:
                    int Type = ChooseType();
                    foreach (Ship ship in shipsStack)
                    {
                        switch (Type)
                        {
                            case 1:
                                if (ship is SteamBoat)
                                    ship.Show();
                                break;
                            case 2:
                                if (ship is SailBoat)
                                    ship.Show();
                                break;
                            case 3:
                                if (ship is Corvette)
                                    ship.Show();
                                break;
                        }
                    }
                    break;
                case 3:
                    string port = InputPort();
                    bool ok = false;
                    foreach (Ship ship in shipsStack)
                    {
                        if (ship.Port == port)
                        {
                            ship.Show();
                            ok = true;
                        }
                    }
                    if (!ok)
                        Console.WriteLine("В таком порту нет кораблей");
                    break;
            }
        }
        public static void StackSort()
        {
            Array cloneStack = shipsStack.ToArray();
            Array.Sort(cloneStack);
            Array.Reverse(cloneStack);
            shipsStack.Clear();
            foreach (Ship ship in cloneStack)
            {
                shipsStack.Push(ship);
            }
            string name = InputName();
            bool ok = false;
            int i = 1;
            foreach (Ship ship in shipsStack)
            {
                if (ship.Name == name)
                {
                    Console.WriteLine($"Элемент с именем {name} находится на позиции {i}");
                    ok = true;
                }
                i++;
            }
            if (!ok)
                Console.WriteLine("Такого элемента нет");
        }
        public static void ListSort()
        {
            shipsList.Sort();
            string name = InputName();
            bool ok = false;
            foreach (Ship ship in shipsList)
            {
                if (ship.Name == name)
                {
                    Console.WriteLine($"Элемент с именем {name} находится на позиции {shipsList.LastIndexOf(ship)}");
                    ok = true;
                }
            }
            if (!ok)
                Console.WriteLine("Такого элемента нет");
        }
        public static void ListClone()
        {
            List<Ship> cloneList = new List<Ship>();
            Console.WriteLine("Скопированный список:");
            for(int i = 0; i < shipsList.Count; i++)
            {
                cloneList.Add((Ship)shipsList[i].Clone()); 
                cloneList[i].Show();
            }
        }
        public static void StackClone()
        {
            Stack cloneStack = (Stack)shipsStack.Clone();
            Console.WriteLine("Скопированный стэк:");
            foreach (Ship ship in cloneStack)
            {
                ship.Show();
            }
        }
        public static void StackForEach()
        {
            DateTime oldtime = DateTime.Now;
            foreach (Ship ship in shipsStack)
            {
                ship.Show();
            }
            TimeSpan time = DateTime.Now - oldtime;
            Console.WriteLine($"Стэк прошли методом foreach за {time}");
        }
        public static void ListForEach()
        {
            DateTime oldtime = DateTime.Now;
            foreach (Ship ship in shipsList)
            {
                ship.Show();
            }
            TimeSpan time = DateTime.Now - oldtime;
            Console.WriteLine($"Список прошли методом foreach за {time}");
        }
        public static void ActionofMainFunction2(int option)
        {
            switch (option)
            {
                case 1:
                    MakeCollection2();
                    break;
                case 2:
                    Changecollection2();
                    break;
                case 3:
                    InquiriesCollection2();
                    break;
                case 4:
                    ListForEach();
                    break;
                case 5:
                    ListClone();
                    break;
                case 6:
                    ListSort();
                    break;
                case 0:
                    Console.WriteLine("Пользователь вышел из данной части программы");
                    break;
            }
        }
        public static void ActionofMainFunction1(int option)
        {
            switch (option)
            {
                case 1:
                    MakeCollection1();
                    break;
                case 2:
                    Changecollection1();
                    break;
                case 3:
                    InquiriesCollection1();
                    break;
                case 4:
                    StackForEach();
                    break;
                case 5:
                    StackClone();
                    break;
                case 6:
                    StackSort();
                    break;
                case 0:
                    Console.WriteLine("Пользователь вышел из данной части программы");
                    break;
            }
        }
        public static void ActionofMainFunction(int option)
        {
            switch (option)
            {
                case 1:
                    MainFunction1();
                    break;
                case 2:
                    MainFunction2();
                    break;
                case 0:
                    Console.WriteLine("Пользователь вышел из данной части программы");
                    break;
            }
        }
        public static void MainFunction2()
        {
            FirstofAll();
            MakeCollection2();
            int option;
            do
            {
                MainFunction2Options();
                option = InputOptionParts();
                ActionofMainFunction2(option);
            } while (option != 0);
        }
        public static void MainFunction1()
        {
            FirstofAll();
            MakeCollection1();
            int option;
            do
            {
                MainFunction1Options();
                option = InputOptionParts();
                ActionofMainFunction1(option);
            } while (option != 0);
        }
        public static void MainFunction()
        {
            int option;
            do
            {
                MainFunctionOptions();
                option = InputOption();
                ActionofMainFunction(option);
            } while (option != 0);
        }
        public static void FirstofAll()
        {
            Console.WriteLine("Для начала создадим коллекцию.");
            Console.WriteLine("Введите количество элементов коллекции");
        }
        public static void MainFunction1Options()
        {
            Console.WriteLine("Возможные опции");
            Console.WriteLine("1. Создать новую коллекцию;");
            Console.WriteLine("2. Функции, изменяющие коллекцию;");
            Console.WriteLine("3. Запросы для данной коллекции;");
            Console.WriteLine("4. Перебор элементов коллекции методом foreach");
            Console.WriteLine("5. Клонироваание коллекции");
            Console.WriteLine("6. Сортировка коллекции и поиск элемента");
            Console.WriteLine("0. Завершить работу со Стэком.");
        }
        public static void MainFunction2Options()
        {
            Console.WriteLine("Возможные опции");
            Console.WriteLine("1. Создать новую коллекцию;");
            Console.WriteLine("2. Функции, изменяющие коллекцию;");
            Console.WriteLine("3. Запросы для данной коллекции;");
            Console.WriteLine("4. Перебор элементов коллекции методом foreach");
            Console.WriteLine("5. Клонироваание коллекции");
            Console.WriteLine("6. Сортировка коллекции и поиск элемента");
            Console.WriteLine("0. Завершить работу со Списком.");
        }
        public static void MainFunctionOptions()
        {
            Console.WriteLine("Возможные опции");
            Console.WriteLine("1. Работа со Стэком;");
            Console.WriteLine("2. Работа со Списком;");
            Console.WriteLine("0. Завершить работу программы.");
        }
        public static void ChangeCollection1Options()
        {
            Console.WriteLine("Возможные опции");
            Console.WriteLine("1. Добавление элемента в Стэк;");
            Console.WriteLine("2. Удаление элемента из Стэка;");
        }
        public static void ChangeCollection2Options()
        {
            Console.WriteLine("Возможные опции");
            Console.WriteLine("1. Добавление элемента в начало списка;");
            Console.WriteLine("2. Добавление элемента в конец списка;");
            Console.WriteLine("3. Удаление элемента из списка;");
        }
        public static void CollectionInquiry()
        {
            Console.WriteLine("1. Количество кораблей указанного типа;");
            Console.WriteLine("2. Печать кораблей указанного типа;");
            Console.WriteLine("3. Печать кораблей в указанном порту.");
        }
        public static void Main(string[] args)
        {
            MainFunction();
        }
    }
}
