using System;

namespace lab7
{
    public enum AccountTypes
    {
        Current,
        Savings
    }
    public class Building
    {
        private static ushort number = CreateBuildingNumber();
        private double height;
        private byte storeys;
        private uint apartments;
        private byte entrances;
        static private ushort CreateBuildingNumber()
        {
            Random n = new Random(0);
            bool flag = false;
            do
            {
                flag = ushort.TryParse(Convert.ToString(n.Next()), out number);
            } while (!flag);
            return (number);
        }
        public void CreateNewBuildingNumber()
        {
            Building.number += 1;
        }
        public ushort Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        public byte Storeys
        {
            get { return storeys; }
            set { storeys = value; }
        }
        public uint Apartments
        {
            get { return apartments; }
            set { apartments = value; }
        }
        public byte Entrances
        {
            get { return entrances  ; }
            set { entrances = value; }
        }
        public void CalculateTheHeightOfTheStorey(double height, byte storeys)
        {
            double storey_height = height / Convert.ToDouble(storeys);
            Console.WriteLine($"Высота одного этажа: {storey_height}");
        }
        public void CalculateTheNumberOfApartmentsInTheEntrance(uint apartments, byte entrances)
        {
            double entrance_volume = Convert.ToDouble(apartments) / Convert.ToDouble(entrances);
            if (entrance_volume % 1 == 0)
            {
                Console.WriteLine($"Квартир в одном подъезде: {entrance_volume}");
            }
            else
            {
                throw new ArgumentException("Что-то не так с входными данными.");
            }            
        }
        public void CalculateTheNumberOfApartmentsPerStorey(uint apartments, byte storeys)
        {
            double storey_volume = Convert.ToDouble(apartments) / Convert.ToDouble(storeys);
            if (storey_volume % 1 == 0)
            {
                Console.WriteLine($"Квартир на одном этаже: {storey_volume}");
            }
            else
            {
                throw new ArgumentException("Что-то не так с входными данными.");
            }            
        }
        public void Print()
        {
            Console.WriteLine($"Номер здания: {number}\nВысота: {height}\nКоличество квартир: {apartments}\nПодъездов: {entrances}\nЭтажей: {storeys}");
        }
    }
    public class BankAccount
    {
        static private ulong number = CreateAccountNumber();
        private double balance;
        private AccountTypes type;
        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public AccountTypes Type
        {
            get { return type; }
            set { type = value; }
        }
        static private ulong CreateAccountNumber()
        {
            Random n = new Random(0);
            bool flag = false;
            do
            {
                flag = ulong.TryParse(Convert.ToString(n.Next()), out number);
            } while (!flag);
            return (number);
        }
        public void CreateNewAccountNumber()
        {
            BankAccount.number += 1;
        }
        public void WithdrawMoney(double sum)
        {
            if (sum > balance)
            {
                throw new ArgumentOutOfRangeException("У вас нет таких денег.");
            }
            else
            {
                balance -= sum;
            }
        }
        public void PutMoney(double sum)
        {
            balance += sum;
        }
        public void Print()
        {
            Console.WriteLine($"Номер счёта: {number}\nБаланс: {balance}\nТип счёта: {type}");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная 7:");
            Console.WriteLine("( после каждого ввода стоит нажимать Enter )");
            double balance = 0, sum = 0;
            bool flag = false;
            byte type = 0;
            BankAccount account = new BankAccount();
            account.CreateNewAccountNumber();
            do
            {
                Console.Write("Сколько денег находится на счету? ");
                flag = double.TryParse(Console.ReadLine(), out balance);
            } while (!flag);
            account.Balance = balance;
            Console.WriteLine("( 1 - текущий, 2 - сберегательный )");
            do
            {
                Console.Write("Какой тип счёта? ");
                flag = byte.TryParse(Console.ReadLine(), out type);
                if ((type != 1) && (type != 2))
                {
                    flag = false;
                }
            } while (!flag);
            if (type == 1)
            {
                account.Type = AccountTypes.Current;
            }
            else
            {
                account.Type = AccountTypes.Savings;
            }
            do
            {
                Console.Write("Сколько денег вы бы хотели снять со счёта? ");
                flag = double.TryParse(Console.ReadLine(), out sum);
            } while (!flag);
            try
            {
                account.WithdrawMoney(sum);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            do
            {
                Console.Write("Сколько денег вы бы хотели положить на счёт? ");
                flag = double.TryParse(Console.ReadLine(), out sum);
            } while (!flag);
            account.PutMoney(sum);
            account.Print();

            Building building1 = new Building();
            building1.CreateNewBuildingNumber();
            building1.Height = 90.74;
            building1.Storeys = 5;
            building1.Apartments = 75;
            building1.Entrances = 4;
            building1.Print();
            building1.CalculateTheHeightOfTheStorey(building1.Height, building1.Storeys);
            try
            {
                building1.CalculateTheNumberOfApartmentsInTheEntrance(building1.Apartments, building1.Entrances);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"(в подъезде) Ошибка: {ex.Message}");
            }
            try
            {
                building1.CalculateTheNumberOfApartmentsPerStorey(building1.Apartments, building1.Storeys);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"(на этаже) Ошибка: {ex.Message}");
            }


            // посмотреть изменения уникального номера .
            Building building2 = new Building();
            building2.CreateNewBuildingNumber();
            building2.Print();
        }
    }
}