using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    internal class Task2
    {
        public static void Run()
        {
            int choice;
            using (Performance performance = new Performance())
            {
                do
                {
                    Console.WriteLine("Enter what to do(1 - init new performance, 2 - show current performance, 3 - clear current performance, 0 - leave):");
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Init Film:");
                            performance.Init();
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Performance info:\n" + performance);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error collapsed: {e.Message}");
                            }
                            break;
                        case 3:
                            performance.Dispose();
                            break;
                    }
                    Console.WriteLine();
                } while (choice != 0);
            }
        }
    }

    internal class Performance : IDisposable
    {
        public StringBuilder Name { get; set; }
        public StringBuilder Theatre { get; set; }
        public StringBuilder Jenre { get; set; }
        public Nullable<double> DurationHours { get; set; }
        public List<Actor> Actors { get; set; }

        public Performance(string name, string theatre, string jenre, double durationHours, List<Actor> actors)
        {
            Name = new StringBuilder(name);
            Theatre = new StringBuilder(theatre);
            Jenre = new StringBuilder(jenre);
            DurationHours = durationHours;
            Actors = actors;
        }

        public Performance() : this(string.Empty, string.Empty, string.Empty, 0, new List<Actor>())
        { }

        public void Init()
        {
            Console.Write("Enter performance name: ");
            Name = new StringBuilder(Console.ReadLine());
            Console.Write("Enter theatre name: ");
            Theatre = new StringBuilder(Console.ReadLine());
            Console.Write("Enter performance jenre: ");
            Jenre = new StringBuilder(Console.ReadLine());
            Console.Write("Enter performance duration(hours): ");
            double.TryParse(Console.ReadLine(), out double dur);
            DurationHours = dur;
            List<Actor> actors = new List<Actor>();
            Console.WriteLine("Enter performance actors(press Enter to stop):");
            string name, role;
            do
            {
                Console.Write("Enter actor's name: ");
                name = Console.ReadLine();
                if (name == string.Empty)
                    break;
                Console.Write("Enter actor's role: ");
                role = Console.ReadLine();
                if (role == string.Empty)
                    break;
                actors.Add(new Actor(name, role));

            } while (true);
            Actors = actors;
        }

        public override string ToString()
        {
            string result = $"Name: {Name}\n" +
                $"Theatre: {Theatre}\n" +
                $"Jenre: {Jenre}\n" +
                $"Duration(hours): {Math.Round((decimal)DurationHours, 1)}\n" +
                $"Actors' list:\n";
            foreach (Actor actor in Actors)
                result += actor + "\n";
            return result;
        }

        public void Dispose()
        {
            Name = null;
            Theatre = null;
            Jenre = null;
            DurationHours = null;
            Actors = null;
            Console.WriteLine("Memory for peformance was cleared");
        }
    }

    internal class Actor
    {
        public StringBuilder Name { get; set; }
        public StringBuilder Role { get; set; }

        public Actor(string name, string role)
        {
            Name = new StringBuilder(name);
            Role = new StringBuilder(role);
        }

        public override string ToString()
        {
            return $"Name: {Name} | Role: {Role}";
        }
    }
}