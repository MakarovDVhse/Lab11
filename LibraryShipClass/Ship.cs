using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryShipClass
{
    public abstract class IExecutable
    {
        protected string name;
        protected string port;
        public abstract void Show();
    }
    public class Ship : IExecutable, IComparable, ICloneable
    {
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }       
        public string Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }       
        public Ship()
        {
            name = "";           
            port = "";
        }
        public Ship(string n, string p)
        {
            name = n;            
            port = p;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корабль '{name}'. Принадлежит порту {port}");
            Console.ResetColor();
        }
        public Ship ShallowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Ship("Клон" + this.name, this.port);
        }
        public int CompareTo(object obj)
        {
            Ship ship = (Ship)obj;
            if (String.Compare(this.Name, ship.Name) > 0)
                return 1;
            else if (String.Compare(this.Name, ship.Name) < 0)
                return -1;
            else
                return 0;
        }
        public override string ToString()
        {
            return this.Name.ToString() + " " + this.Port.ToString();
        }
    }
    public class SteamBoat : Ship, IComparable, ICloneable
    {
        protected string ClassofShip = "Пароход";
        protected int creationYear;
        protected int shipLength;
        protected int numberofPersonnel;
        protected int displacement;
        public SteamBoat() : base ()
        {
            creationYear = 0;
            shipLength = 1;
            numberofPersonnel = 1;
            displacement = 1;
        }
        public SteamBoat(string n, int cy, int sl, int nop, string p, int d) : base (n, p)
        {
            creationYear = cy;
            shipLength = sl;
            numberofPersonnel = nop;
            displacement = d;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корабль '{name}', класса {ClassofShip}, созданный в {creationYear} году, имеет водоизмещение в {displacement} т., длину {shipLength} м. и состав из {numberofPersonnel} человек. Принадлежит порту {port}");
            Console.ResetColor();
        }
        public Ship GetBaseShip
        {
            get
            {
                return new Ship(this.name, this.port);
            }
        }
    }
    public class SailBoat : Ship, IComparable, ICloneable
    {
        protected string ClassofShip = "Парусник";
        protected int creationYear;
        protected int shipLength;
        protected int numberofPersonnel;
        protected int displacement;
        public SailBoat() : base()
        {
            creationYear = 0;
            shipLength = 1;
            numberofPersonnel = 1;
            displacement = 1;
        }
        public SailBoat(string n, int cy, int sl, int nop, string p, int d) : base (n, p)
        {
            creationYear = cy;
            shipLength = sl;
            numberofPersonnel = nop;
            displacement = d;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корабль '{name}', класса {ClassofShip}, созданный в {creationYear} году, имеет водоизмещение в {displacement} т., длину {shipLength} м. и состав из {numberofPersonnel} человек. Принадлежит порту {port}");
            Console.ResetColor();
        }
        public Ship GetBaseShip
        {
            get
            {
                return new Ship(this.name, this.port);
            }
        }
    }
    public class Corvette : Ship, IComparable, ICloneable
    {
        protected string ClassofShip = "Корвет";
        protected int creationYear;
        protected int shipLength;
        protected int numberofPersonnel;
        protected int displacement;
        public Corvette()
        {
            creationYear = 0;
            shipLength = 1;
            numberofPersonnel = 1;
            displacement = 1;
        }
        public Corvette(string n, int cy, int sl, int nop, string p, int d) : base (n, p)
        {
            creationYear = cy;
            shipLength = sl;
            numberofPersonnel = nop;
            displacement = d;
        }
        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Корабль '{name}', класса {ClassofShip}, созданный в {creationYear} году, имеет водоизмещение в {displacement} т., длину {shipLength} м. и состав из {numberofPersonnel} человек. Принадлежит порту {port}");
            Console.ResetColor();
        }
        public Ship GetBaseShip
        {
            get
            {
                return new Ship(this.name, this.port);
            }
        }
    }
    public class SortByName : IComparer<object>
    {
        int IComparer<object>.Compare(object obj1, object obj2)
        {
            Ship ship1 = (Ship)obj1;
            Ship ship2 = (Ship)obj2;
            return String.Compare(ship1.Name, ship2.Name);
        }
    }
}

