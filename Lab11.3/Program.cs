using System;
using LibraryShipClass;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11._3
{
    // Поскольку нам необходимо работать с калссами базовый - производный, то нам необходимо определить их заранее.
    // Известно, что у класса Ship есть три наследника, поэтому мы выберем лишь один из них.
    // Пусть это будет класс SteamBoat (это не означает, что мы удаляем оставшиеся два класс наследника, мы просто не будем использовать из в этой программе
    class Program
    {
        public static Random random = new Random();
        public static TestCollecctions collections = new TestCollecctions();
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
                else if (option < 0 || option > 4)
                    Console.WriteLine("Ошибка! Такой опции нет");
            } while (!ok || option < 0 || option > 4);
            return option;
        }
        public static void QueueTesting(Ship ship, int position)
        {
            Console.WriteLine("//////////|||||\\\\\\\\\\");
            Stopwatch stopwatch1_1 = new Stopwatch();
            stopwatch1_1.Start();
            collections.QueueShip.Contains(collections.QueueShip.First());
            stopwatch1_1.Stop();
            Stopwatch stopwatch1_2 = new Stopwatch();
            stopwatch1_2.Start();
            collections.stringQueueShip.Contains(collections.stringQueueShip.First());
            stopwatch1_2.Stop();
            Console.WriteLine($"Метод Contains нашёл первый элемент для коллекции 1 с ключом <TKey> за {stopwatch1_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch1_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch2_1 = new Stopwatch();
            stopwatch2_1.Start();
            collections.QueueShip.Contains(collections.QueueShip.ElementAt(position));
            stopwatch2_1.Stop();
            Stopwatch stopwatch2_2 = new Stopwatch();
            stopwatch2_2.Start();
            collections.stringQueueShip.Contains(collections.stringQueueShip.ElementAt(position));
            stopwatch2_2.Stop();
            Console.WriteLine($"Метод Contains нашёл элемент в середине для коллекции 1 с ключом <TKey> за {stopwatch2_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch2_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch3_1 = new Stopwatch();
            stopwatch3_1.Start();
            collections.QueueShip.Contains(collections.QueueShip.ElementAt(collections.Size - 1));
            stopwatch3_1.Stop();
            Stopwatch stopwatch3_2 = new Stopwatch();
            stopwatch3_2.Start();
            collections.stringQueueShip.Contains(collections.stringQueueShip.ElementAt(collections.Size - 1));
            stopwatch3_2.Stop();
            Console.WriteLine($"Метод Contains нашёл последний элемент для коллекции 1 с ключом <TKey> за {stopwatch3_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch3_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch4_1 = new Stopwatch();
            stopwatch4_1.Start();
            collections.QueueShip.Contains(ship);
            stopwatch4_1.Stop();
            Stopwatch stopwatch4_2 = new Stopwatch();
            stopwatch4_2.Start();
            collections.stringQueueShip.Contains(ship.ToString());
            stopwatch4_2.Stop();
            Console.WriteLine($"Метод Contains, не найдя элемент, прошёл коллекцию 1 с ключом <TKey> за {stopwatch4_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch4_2.ElapsedTicks} тиков.");
            Console.WriteLine("\\\\\\\\\\|||||//////////");
        }
        public static void SortedDictionaryTestingTKey(Ship ship, int position)
        {
            Console.WriteLine("//////////|||||\\\\\\\\\\");
            Stopwatch stopwatch1_1 = new Stopwatch();
            stopwatch1_1.Start();
            collections.SortedDictionaryShip.ContainsKey(collections.SortedDictionaryShip.First().Key);
            stopwatch1_1.Stop();
            Stopwatch stopwatch1_2 = new Stopwatch();
            stopwatch1_2.Start();
            collections.stringSortedDictionaryShip.ContainsKey(collections.stringSortedDictionaryShip.First().Key);
            stopwatch1_2.Stop();
            Console.WriteLine($"Метод ContainsKey нашёл первый элемент для коллекции 2 с ключом <TKey> за {stopwatch1_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch1_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch2_1 = new Stopwatch();
            stopwatch2_1.Start();
            collections.SortedDictionaryShip.ContainsKey(collections.SortedDictionaryShip.ElementAt(position).Key);
            stopwatch2_1.Stop();
            Stopwatch stopwatch2_2 = new Stopwatch();
            stopwatch2_2.Start();
            collections.stringSortedDictionaryShip.ContainsKey(collections.stringSortedDictionaryShip.ElementAt(position).Key);
            stopwatch2_2.Stop();
            Console.WriteLine($"Метод ContainsKey нашёл элемент в середине для коллекции 2 с ключом <TKey> за {stopwatch2_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch2_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch3_1 = new Stopwatch();
            stopwatch3_1.Start();
            collections.SortedDictionaryShip.ContainsKey(collections.SortedDictionaryShip.ElementAt(collections.Size - 1).Key);
            stopwatch3_1.Stop();
            Stopwatch stopwatch3_2 = new Stopwatch();
            stopwatch3_2.Start();
            collections.stringSortedDictionaryShip.ContainsKey(collections.stringSortedDictionaryShip.ElementAt(collections.Size - 1).Key);
            stopwatch3_2.Stop();
            Console.WriteLine($"Метод ContainsKey нашёл последний элемент для коллекции 2 с ключом <TKey> за {stopwatch3_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch3_2.ElapsedTicks} тиков.");
            Stopwatch stopwatch4_1 = new Stopwatch();
            stopwatch4_1.Start();
            collections.SortedDictionaryShip.ContainsKey(ship);
            stopwatch4_1.Stop();
            Stopwatch stopwatch4_2 = new Stopwatch();
            stopwatch4_2.Start();
            collections.stringSortedDictionaryShip.ContainsKey(ship.ToString());
            stopwatch4_2.Stop();
            Console.WriteLine($"Метод ContainsKey, не найдя элемент, прошёл коллекцию 2 с ключом <TKey> за {stopwatch4_1.ElapsedTicks} тиков, а с ключом <string> за {stopwatch4_2.ElapsedTicks} тиков.");
            Console.WriteLine("\\\\\\\\\\|||||//////////");
        }
        public static void SortedDictionaryTestingTValue(SteamBoat ship, int position)
        {
            Console.WriteLine("//////////|||||\\\\\\\\\\");
            Stopwatch stopwatch1_1 = new Stopwatch();
            stopwatch1_1.Start();
            collections.SortedDictionaryShip.ContainsValue(collections.SortedDictionaryShip.First().Value);
            stopwatch1_1.Stop();
            Console.WriteLine($"Метод ContainsValue нашёл первый элемент для коллекции 2 со значением <TValue> за {stopwatch1_1.ElapsedTicks}  тиков.");
            Stopwatch stopwatch2_1 = new Stopwatch();
            stopwatch2_1.Start();
            collections.SortedDictionaryShip.ContainsValue(collections.SortedDictionaryShip.ElementAt(position).Value);
            stopwatch2_1.Stop();
            Console.WriteLine($"Метод ContainsValue нашёл элемент в середине для коллекции 2 со значением <TValue> за {stopwatch2_1.ElapsedTicks} тиков.");
            Stopwatch stopwatch3_1 = new Stopwatch();
            stopwatch3_1.Start();
            collections.SortedDictionaryShip.ContainsValue(collections.SortedDictionaryShip.ElementAt(collections.Size - 1).Value);
            stopwatch3_1.Stop();
            Console.WriteLine($"Метод Containsvalue нашёл последний элемент для коллекции 2 со значением <TValue> за {stopwatch3_1.ElapsedTicks} тиков.");
            Stopwatch stopwatch4_1 = new Stopwatch();
            stopwatch4_1.Start();
            collections.SortedDictionaryShip.ContainsValue(ship);
            stopwatch4_1.Stop();
            Console.WriteLine($"Метод ContainsValue, не найдя элемент, прошёл коллекцию 2 со значением <TValue> за {stopwatch4_1.ElapsedTicks} тиков.");
            Console.WriteLine("\\\\\\\\\\|||||//////////");
        }
        public static void TimeTesting()
        {
            int MiddleElement = random.Next(1, collections.Size - 1);
            SteamBoat OutofRangeElement = new SteamBoat("Лучезарный IV", random.Next(1950, 2020), random.Next(50, 140), random.Next(10, 100), "Архангельск", random.Next(800, 1600));
            Ship OutofRangeElementKey = OutofRangeElement.GetBaseShip;
            QueueTesting(OutofRangeElementKey, MiddleElement);
            SortedDictionaryTestingTKey(OutofRangeElementKey, MiddleElement);
            SortedDictionaryTestingTValue(OutofRangeElement, MiddleElement);
        }
        public static void ActionofMainFunction(int option)
        {
            switch (option)
            {
                case 1:
                    MakeCollection();
                    break;
                case 2:
                    collections.AddGeneratedItem();
                    break;
                case 3:
                    collections.RemoveItem();
                    break;
                case 4:
                    TimeTesting();
                    break;
                case 0:
                    Console.WriteLine("Пользователь завершил работу программы");
                    break;
            }
        }
        public static void MakeCollection()
        {
            int size = InputSize();
            collections = new TestCollecctions(size);
        }
        public static void MainFunction()
        {
            FirstofAll();
            MakeCollection();
            int option;
            do
            {
                MainFunctionOptions();
                option = InputOption();
                ActionofMainFunction(option);
            } while (option != 0);
        }
        public static void Main(string[] args)
        {
            MainFunction();
        }
        public static void FirstofAll()
        {
            Console.WriteLine("Для начала создадим коллекцию.");
            Console.WriteLine("Введите количество элементов коллекции");
        }
        public static void MainFunctionOptions()
        {
            Console.WriteLine("Возможные опции:");
            Console.WriteLine("1. Создать новую коллекцию;");
            Console.WriteLine("2. Добавить сгенерированный элемент в коллекцию;");
            Console.WriteLine("3. Удалить элементы из коллекции, учитывая правила Очереди (удаление самого первого элемента;");
            Console.WriteLine("4. Провести тестирование по нахождению элементов в коллекции сравнивая время;");
            Console.WriteLine("0. Завершить работу со Списком.");
        }
    }
}
