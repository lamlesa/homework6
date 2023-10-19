using System;
using System.Threading;

namespace homework6
{
    public class Drugs
    {
        private static bool choice = false;
        private ushort price;
        private byte dose;
        public bool Choice
        {
            get { return choice; }
            set { choice = value; }
        }
        public ushort Price
        {
            get { return price; }
            set { price = value; }
        }
        public byte Dose
        {
            get { return dose; }
            set { dose = value; }
        }
        public void MakeChoice()
        {
            Console.WriteLine("из-за тёмного угла показалась рука с перстнем и протянула вам пакетик с неопознанным содержимым, ваши действия?\n1: с локтя\n2: робко, но взять");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.D1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ кафе \"Элефант\" вошёл Штирлиц.\r\n- Это Штирлиц, сейчас будет драка, - сказал один из посетителей. Штирлиц выпил чашечку кофе и вышел.\r\n- Нет, это не Штирлиц, - возразил второй посетитель.\r\n- Нет, Штирлиц! - и тут началась драка.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nэто действие будет иметь последствия ....");
                choice = true;
            }
        }
        public void MakeChoiceAgain()
        {
            Console.WriteLine("");
            Console.WriteLine("вы пришли домой и выбираете, что делать с наркотиками .");
            Console.WriteLine("1: употребить\n2: выбросить");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.D1)
            {
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("вы решили употребить наркотики.");
                if (choice == true)
                {
                    Console.WriteLine("теперь вы Леонардо Ди Каприо в <<дневниках баскеболиста>> ....");
                }
                else
                {
                    Console.WriteLine("добрая фея дала вам подзатыльник и напомнила, что у вас ничего нет, ведь вы отказались от предложенных нарКОТИКОВ");
                }
            }
            else
            {
                Console.WriteLine("вы решили выкинуть накротики.");
                if (choice == true)
                {
                    Console.WriteLine("давай!! ДАВАААЙ УРААА ДАВААЙ ДААААВАААЙ");
                }
                else
                {
                    Console.WriteLine("вы большие умнички, ведь не поддаетесь на провокации !!");
                }
            }
        }
        public virtual void Use() 
        {
            Console.WriteLine("");
            Console.WriteLine("*вы решили употребить наркотики*");
            Console.WriteLine("вы опять убегаете от реальности .");
        }
    }
    class Psychedelics : Drugs
    {
        public Psychedelics(ushort price)
        {
            Price = price;
        }
        public Psychedelics(ushort price, byte dose)
        {
            Price = price;
            Dose = dose;
        }
        public void Feelings()
        {
            Console.WriteLine("Человек в состоянии наркотического опьянения перестает испытывать душевную и\r\nфизическую боль, появляется ощущение легкости, комфорта, происходит потеря\r\nконтроля над собой и утрата чувства реальности. ");
            if (Choice == true)
            {
                Console.WriteLine("но это ненадолго ....");
            }
        }
        private string[] laws = { "Статья 228", "Статья 228.1", "Статья 228.2", "Статья 228.4", "Статьи 229-233" };
        public string[] Laws
        {
            get { return laws; }
        }
        public void PrintLaws()
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("незаконное приобретение,\nперевозка,\nхранение,\nизготовление и переработка для употребления в личных целях веществ\nявляются нарушением следующих статей УК РФ:");
            foreach(string law in laws)
            {
                Console.WriteLine(law);
            }
            if (Choice == false)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("но вам это не грозит <3");
            }
            Console.ResetColor();
        }
    }
    class Stimulants : Drugs
    {
        private static ushort overdose = 30;
        public Stimulants(byte dose)
        {
            Dose = dose;
        }
        private static string[] consequences = { "бредовые состояния", "слуховые галлюцинации", "зрительные галлюцинации", "тремор", "нарушение сна", "аритмия"};
        public void PrintConcequences()
        {
            Console.WriteLine("");
            Console.WriteLine("последствия употребления стимуляторов:");
            Console.BackgroundColor = ConsoleColor.White;
            foreach (string consequence in consequences)
            {
                Console.WriteLine(consequence);
            }
            if (Choice == false)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("но вы можете об этом не беспокоиться !!");
            }
            Console.ResetColor();
        }
        public void DeathCheck()
        {
            Console.WriteLine();
            Console.WriteLine("проверка на передоз...");
            if (Dose > overdose)
            {
                Console.WriteLine("как называется место на кладбище, где сидит сторож ? живой уголок :))))");
            }
            else
            {
                Console.WriteLine("вы остались живы, но такими темпами... в общем тихонечко");
            }
        }
    }
    public abstract class Sedatives : Drugs
    {
        public override void Use()
        {
            Console.WriteLine("");
            Console.WriteLine("вы решили употребить седативное вещество .");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("К седативным (т.е. успокаивающим) наркотикам относят опиатные наркотики и снотворные барбитуратной группы .");
            Thread.Sleep(5000);
            Console.ResetColor();
        }
    }
    public class Opioids : Sedatives
    {
        public Opioids(byte dose)
        {
            Dose = dose;
        }
        public Opioids(byte dose, ushort price)
        {
            Dose = dose;
            Price = price;
        }
        private string[] composition = { "бензольное кольцо", "азот", "этильный или пропильный «мостик»" };
        public string[] Composition
        {
            get { return composition; }
        }
        public void ExplainComposition()
        {
            Console.WriteLine("");
            Console.WriteLine("преимущетвенный химический состав седативов:");
            foreach(string component in Composition)
            {
                Console.WriteLine(component);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Psychedelics LSD = new Psychedelics(1500, 15);
            Psychedelics ketamine = new Psychedelics(5320);
            Opioids heroin = new Opioids(10);
            LSD.MakeChoice();
            bool flag = false;
            byte dose = 0;
            byte k = 0;
            do
            {
                if (k != 0)
                {
                    Console.WriteLine("а употребление сказывается на вашей мозговой деятельности ....");
                }
                Console.Write("введите дозу амфетамина: ");
                flag = byte.TryParse(Console.ReadLine(), out dose);
                k++;
            } while (!flag);
            Stimulants amphetamine = new Stimulants(dose);
            amphetamine.DeathCheck();
            amphetamine.PrintConcequences();
            heroin.Use();
            heroin.ExplainComposition();
            ketamine.Use();
            ketamine.PrintLaws();
        }
    }
}