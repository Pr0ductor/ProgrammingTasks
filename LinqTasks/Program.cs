using System;
using System.Collections.Generic;
using System.Linq;

public class FitnessRecord
{
    public int Duration { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int ClientCode { get; set; }
}

public class Applicant
{
    public string Surname { get; set; }
    public int AdmissionYear { get; set; }
    public int SchoolNumber { get; set; }
}

public class Debtor
{
    public string LastName { get; set; }
    public double DebtAmount { get; set; }
    public int FlatNumber { get; set; }

    public Debtor(string lastName, double debtAmount, int flatNumber)
    {
        LastName = lastName;
        DebtAmount = debtAmount;
        FlatNumber = flatNumber;
    }
}

public class GasStation
{
    public int PricePerLiter { get; set; }
    public int GasType { get; set; }
    public string Street { get; set; }
    public string Company { get; set; }

    public GasStation(int pricePerLiter, int gasType, string street, string company)
    {
        PricePerLiter = pricePerLiter;
        GasType = gasType;
        Street = street;
        Company = company;
    }
}

class Student
{
    public int MathScore { get; set; }
    public int RussianScore { get; set; }
    public int InformaticsScore { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string SchoolNumber { get; set; }

    public int TotalScore => MathScore + RussianScore + InformaticsScore;
}


class StudentGrade
{
    public int ClassNumber { get; set; }
    public string Subject { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public int Grade { get; set; }
}

public class Program
{
    public static void Main()
    {
        // №7
        int K = 123; // код клиента

        List<FitnessRecord> fitnessRecords = new List<FitnessRecord>()
        {
            new FitnessRecord { Duration = 1, Year = 2021, Month = 1, ClientCode = 123 },
            new FitnessRecord { Duration = 2, Year = 2021, Month = 2, ClientCode = 123 },
            new FitnessRecord { Duration = 3, Year = 2021, Month = 3, ClientCode = 123 },
            new FitnessRecord { Duration = 4, Year = 2022, Month = 1, ClientCode = 123 },
            new FitnessRecord { Duration = 5, Year = 2022, Month = 2, ClientCode = 123 },
            new FitnessRecord { Duration = 6, Year = 2022, Month = 3, ClientCode = 123 },
            new FitnessRecord { Duration = 7, Year = 2023, Month = 1, ClientCode = 123 },
            new FitnessRecord { Duration = 8, Year = 2023, Month = 2, ClientCode = 123 },
            new FitnessRecord { Duration = 9, Year = 2023, Month = 3, ClientCode = 123 },
            new FitnessRecord { Duration = 10, Year = 2023, Month = 4, ClientCode = 123 },
            new FitnessRecord { Duration = 10, Year = 2023, Month = 4, ClientCode = 100 },
        };

        var result1 = fitnessRecords
            .Where(record => record.ClientCode == K)
            .GroupBy(record => record.Year)
            .OrderByDescending(group => group.Key) //сортировка от новых годов к старым
            .Select(group => group.OrderBy(record => record.Month).First()) //сортировка от первого к последнему месяцу по количеству посещаемости
            .Select(record => $"{record.Year} {record.Month} {record.Duration}");

        foreach (var item in result1)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-----------------");
        
        // №19
        List<Applicant> applicants = new List<Applicant>()
        {
            new Applicant { Surname = "Smith", AdmissionYear = 2021, SchoolNumber = 1 },
            new Applicant { Surname = "Jones", AdmissionYear = 2022, SchoolNumber = 2 },
            new Applicant { Surname = "Johnson", AdmissionYear = 2020, SchoolNumber = 1 },
            new Applicant { Surname = "Brown", AdmissionYear = 2021, SchoolNumber = 2 },
            new Applicant { Surname = "Davis", AdmissionYear = 2022, SchoolNumber = 1 },
            // Добавьте остальных абитуриентов
        };

        var result2 = applicants
            .GroupBy(applicant => applicant.SchoolNumber) //группирую абитуриентов по номеру школы
            .OrderBy(group => group.Key) //сортирует группы абитуриентов в порядке номера школы
            .Select(group => new
            {
                SchoolNumber = group.Key,
                TotalApplicants = group.Count(),
                FirstApplicantSurname = group.First().Surname
            }); // находит номер школы, количество абитуриентов и первого абитуриента

        foreach (var item in result2)
        {
            Console.WriteLine($"{item.SchoolNumber} {item.TotalApplicants} {item.FirstApplicantSurname}");
        }

        Console.WriteLine("-------------");
        
        //25
        
        static void L25(List<Debtor> debtors)
        {
            var max = debtors
                .GroupBy(d => d.FlatNumber / 4) // группировка по номеру подъезда
                .Select(group => new
                {
                    EntranceNumber = group.Key,
                    TotalDebt = group.Sum(d => d.DebtAmount)
                }) // вычисление общей задолжности
                .OrderByDescending(group => group.TotalDebt) // сортировка по общей задолжности (убывание)
                .First(); //выбрасываем первое значение

            Console.WriteLine("Номер подъезда: " + max.EntranceNumber);
            Console.WriteLine("Суммарная задолженность: " + max.TotalDebt.ToString("N2"));
        }
    
        List<Debtor> debtors = new List<Debtor>
        {
            new Debtor("Иванов", 1000.50, 1),
            new Debtor("Петров", 500.75, 2),
            new Debtor("Сидоров", 200.25, 3),
            new Debtor("Козлов", 1500.80, 4),
            new Debtor("Смирнов", 750.40, 5),
            new Debtor("Васильев", 300.60, 6),
            new Debtor("Попов", 450.90, 7),
            new Debtor("Андреев", 1200.30, 8),
            new Debtor("Алексеев", 800.20, 9),
            new Debtor("Соловьев", 650.10, 10),
        };

        L25(debtors);

        Console.WriteLine("--------------");
        
        
        
        //31
        
        List<Debtor> debtors1 = new List<Debtor>
        {
            new Debtor("Иванов", 1500.25, 101),
            new Debtor("Петров", 2000.50, 102),
            new Debtor("Сидорова", 1800.75, 103),
            new Debtor("Козлов", 2200.00, 104),
            new Debtor("Смирнов", 1900.45, 105),
            new Debtor("Кузнецов", 2100.60, 106),
            new Debtor("Николаев", 1700.30, 107),
            new Debtor("Ковалев", 2300.90, 108),
            new Debtor("Зайцев", 1950.80, 109),
            new Debtor("Борисова", 1850.70, 110),
            new Debtor("Григорьев", 2400.20, 111),
            new Debtor("Алексеев", 1750.35, 112),
            new Debtor("Павлов", 2050.55, 113),
            new Debtor("Семенов", 2250.70, 114),
            new Debtor("Федорова", 2150.40, 115),
            new Debtor("Морозов", 1950.85, 116)
        };

        debtors.GroupBy(d => d.FlatNumber / 4)
            .Select(group => new
            {
                Podjezd = group.Key + 1,
                TopDebtors = group.OrderByDescending(d => d.DebtAmount).Take(3)
            })
            .ToList()
            .ForEach(group =>
            {
                Console.WriteLine($"Подъезд {group.Podjezd}");

                group.TopDebtors.ToList().ForEach(debtor =>
                {
                    Console.WriteLine(
                        $"{debtor.DebtAmount:F2} руб., квартира {debtor.FlatNumber}, {debtor.LastName}");
                });
            });

        Console.WriteLine("------------------");
        
        //43
        int M = 95; // Заданная марка бензина

        List<GasStation> gasStations = new List<GasStation>
        {
            new GasStation(420, 92, "Central St.", "Shell"),
            new GasStation(410, 95, "Oak Ave.", "Exxon"),
            new GasStation(430, 95, "Maple St.", "Exxon"),
            new GasStation(440, 98, "Main St.", "BP"),
            new GasStation(425, 95, "Elm St.", "BP")
        };

        var result = gasStations
            .GroupBy(g => g.Company)
            .Select(g =>
            {
                int minPrice = g.Any(gas => gas.GasType == M) ? g.Where(gas => gas.GasType == M).Min(gas => gas.PricePerLiter) : -1;
                int maxPrice = g.Any(gas => gas.GasType == M) ? g.Where(gas => gas.GasType == M).Max(gas => gas.PricePerLiter) : -1;
                int priceRange = maxPrice != -1 ? maxPrice - minPrice : -1;

                return new { Company = g.Key, PriceRange = priceRange };
            })
            .OrderByDescending(g => g.PriceRange)
            .ThenBy(g => g.Company);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.PriceRange} {item.Company}");
        }


        Console.WriteLine("---------------");
        
        //55
        // Создание списка учащихся с данными
        List<Student> students = new List<Student>
        {
            new Student { LastName = "Иванов", Initials = "И.И.", SchoolNumber = "123", MathScore = 70, RussianScore = 80, InformaticsScore = 60 },
            new Student { LastName = "Петров", Initials = "П.П.", SchoolNumber = "456", MathScore = 55, RussianScore = 65, InformaticsScore = 70 },
            new Student { LastName = "Сидоров", Initials = "С.С.", SchoolNumber = "789", MathScore = 80, RussianScore = 75, InformaticsScore = 85 }
        };
        
        var selectedStudents = students.Where(s =>
                s.MathScore >= 50 && s.RussianScore >= 50 && s.InformaticsScore >= 50)
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.Initials);

        // Выводим результаты
        if (selectedStudents.Any())
        {
            foreach (var student in selectedStudents)
            {
                Console.WriteLine($"{student.LastName} {student.Initials}, {student.SchoolNumber}, " +
                                  $"Суммарный балл ЕГЭ: {student.TotalScore}");
            }
        }
        else
        {
            Console.WriteLine("Требуемые учащиеся не найдены");
        }


        Console.WriteLine("--------------------");
        //67
        
        // Создание списка учащихся с оценками
        List<StudentGrade> studentGrades = new List<StudentGrade>
        {
            new StudentGrade { ClassNumber = 10, Subject = "Алгебра", LastName = "Иванов", Initials = "И.И.", Grade = 4 },
            new StudentGrade { ClassNumber = 10, Subject = "Геометрия", LastName = "Иванов", Initials = "И.И.", Grade = 5 },
            new StudentGrade { ClassNumber = 10, Subject = "Информатика", LastName = "Иванов", Initials = "И.И.", Grade = 2 },
            new StudentGrade { ClassNumber = 11, Subject = "Алгебра", LastName = "Петров", Initials = "П.П.", Grade = 3 },
            new StudentGrade { ClassNumber = 11, Subject = "Геометрия", LastName = "Петров", Initials = "П.П.", Grade = 2 },
            new StudentGrade { ClassNumber = 11, Subject = "Информатика", LastName = "Петров", Initials = "П.П.", Grade = 5 },
            new StudentGrade { ClassNumber = 11, Subject = "Информатика", LastName = "Коля", Initials = "К.К.", Grade = 2 },
            new StudentGrade { ClassNumber = 11, Subject = "Информатика", LastName = "Коля", Initials = "К.К.", Grade = 2 }
        };

        var result5 = studentGrades
            .Where(student => student.Grade == 2)
            .GroupBy(student => new { student.ClassNumber, student.LastName, student.Initials })
            .OrderByDescending(group => group.Key.ClassNumber)
            .ThenBy(group => group.Key.LastName)
            .ThenBy(group => group.Key.Initials)
            .Select(group => $"{group.Key.ClassNumber} {group.Key.LastName} {group.Key.Initials} {group.Count()}");

        if (result5.Any())
        {
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("Требуемые учащиеся не найдены");
        }



    }
}