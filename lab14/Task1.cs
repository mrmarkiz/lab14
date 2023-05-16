using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab14
{
    internal class Task1
    {
        public static void Run()
        {
            int choice;
            using (Film film = new Film())
            {
                do
                {
                    Console.WriteLine("Enter what to do(1 - init new film, 2 - show current film, 3 - clear current film, 0 - leave):");
                    int.TryParse(Console.ReadLine(), out choice);                    
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Init Film:");
                            film.Init();
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Film info:\n" + film);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine($"Error collapsed: {e.Message}");
                            }
                            break;
                        case 3:
                            film.Dispose();
                            break;
                    }
                    Console.WriteLine();
                } while (choice != 0);
            }
        }
    }

    internal class Film : IDisposable
    {
        public StringBuilder Name { get; set; }
        public StringBuilder Studio { get; set; }
        public StringBuilder Jenre { get; set; }
        public Nullable<double> DurationHours { get; set; }
        public Nullable<int> CreationYear { get; set; }

        public Film(string name, string studio, string jenre, double durationHours, int creationYear)
        {
            Name = new StringBuilder(name);
            Studio = new StringBuilder(studio);
            Jenre = new StringBuilder(jenre);
            DurationHours = durationHours;            
            CreationYear = creationYear;
        }        

        public Film() : this(string.Empty, string.Empty, string.Empty, 0, 0)
        { }

        public void Init()
        {
            Console.Write("Enter film name: ");
            Name = new StringBuilder(Console.ReadLine());
            Console.Write("Enter film studio: ");
            Studio = new StringBuilder(Console.ReadLine());
            Console.Write("Enter film jenre: ");
            Jenre = new StringBuilder(Console.ReadLine());
            Console.Write("Enter film duration(hours): ");
            double.TryParse(Console.ReadLine(), out double dur);
            DurationHours = dur;
            Console.Write("Enter film creation year: ");
            int.TryParse(Console.ReadLine(), out int cre);
            CreationYear = cre;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Film studio: {Studio}\n" +
                $"Jenre: {Jenre}\n" +
                $"Duration(hours): {Math.Round((decimal)DurationHours, 1)}\n" +
                $"Creation year: {CreationYear}";
        }

        public void Dispose()
        {
            Name = null;
            Studio = null;
            Jenre = null;
            DurationHours = null;
            CreationYear = null;
            Console.WriteLine("Memory for film was cleared");
        }
    }
}
