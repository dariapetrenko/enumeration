using System;
using System.Collections.Generic;

class Program
{
    [Flags]
    enum Disciplines
    {
        None = 0,
        // Дисципліни для бакалавра
        Programming = 1,
        Database = 2,
        Networking = 4,
        WebDevelopment = 8,

        // Дисципліни для магістра
        ArtificialIntelligence = 16,
        MachineLearning = 32,
        BigData = 64,
        DataMining = 128
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Прізвище автора програми: Петренко");

        Console.WriteLine("Перелік дисциплін для бакалавра:");
        List<Disciplines> bachelorDisciplines = GetBachelorDisciplines();
        foreach (Disciplines discipline in bachelorDisciplines)
        {
            Console.WriteLine($"{(int)discipline} - {GetDisciplineName(discipline)}");
        }

        Console.WriteLine("Перелік дисциплін для магістра:");
        List<Disciplines> masterDisciplines = GetMasterDisciplines();
        foreach (Disciplines discipline in masterDisciplines)
        {
            Console.WriteLine($"{(int)discipline} - {GetDisciplineName(discipline)}");
        }

        Console.WriteLine("Введіть номери дисциплін, які ви хочете вивчати (відокремлюйте номери комами):");
        string input = Console.ReadLine();

        List<Disciplines> selectedDisciplines = ParseDisciplines(input);

        Console.WriteLine("Ви вибрали наступні дисципліни:");

        Console.WriteLine("Дисципліни для бакалавра:");
        foreach (Disciplines discipline in selectedDisciplines)
        {
            if (bachelorDisciplines.Contains(discipline))
            {
                Console.WriteLine($"{(int)discipline} - {GetDisciplineName(discipline)}");
            }
        }

        Console.WriteLine("Дисципліни для магістра:");
        foreach (Disciplines discipline in selectedDisciplines)
        {
            if (masterDisciplines.Contains(discipline))
            {
                Console.WriteLine($"{(int)discipline} - {GetDisciplineName(discipline)}");
            }
        }

        Console.ReadLine();
    }

    static List<Disciplines> GetBachelorDisciplines()
    {
        return new List<Disciplines>
        {
            Disciplines.Programming,
            Disciplines.Database,
            Disciplines.Networking,
            Disciplines.WebDevelopment
        };
    }

    static List<Disciplines> GetMasterDisciplines()
    {
        return new List<Disciplines>
        {
            Disciplines.ArtificialIntelligence,
            Disciplines.MachineLearning,
            Disciplines.BigData,
            Disciplines.DataMining
        };
    }

    static List<Disciplines> ParseDisciplines(string input)
    {
        string[] disciplineNumbers = input.Split(',');
        List<Disciplines> selectedDisciplines = new List<Disciplines>();

        foreach (string number in disciplineNumbers)
        {
            if (Enum.TryParse(number.Trim(), out Disciplines discipline))
            {
                selectedDisciplines.Add(discipline);
            }
        }

        return selectedDisciplines;
    }

    static string GetDisciplineName(Disciplines discipline)
    {
        return discipline.ToString();
    }
}