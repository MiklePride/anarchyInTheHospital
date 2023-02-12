using System;
using System.Collections.Generic;
using System.Linq;

namespace anarchyInTheHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            hospital.Start();
        }
    }
}

class Hospital
{
    private List<Patient> _patients = new List<Patient>();

    public Hospital()
    {
        _patients.Add(new Patient("Степанов Иван Викторович", 35, "Орви"));
        _patients.Add(new Patient("Вологодин Антон Виниаминович", 24, "Отит"));
        _patients.Add(new Patient("Карпов Евгений Николаевич", 15, "Ветрянка"));
        _patients.Add(new Patient("Гриднев Алексей Сергеевич", 30, "Грипп"));
        _patients.Add(new Patient("Казаков Дмитрий Викторович", 43, "Орви"));
        _patients.Add(new Patient("Пашутин Станислав Валереевич", 17, "Ветрянка"));
        _patients.Add(new Patient("Растров Гектор Аркадиевич", 64, "Склероз"));
        _patients.Add(new Patient("Лопушков Анатолий Михайлович", 71, "Орви"));
        _patients.Add(new Patient("Поспелов Руслан Артемович", 25, "Отит"));
        _patients.Add(new Patient("Алихандров Геннадий Александрович", 22, "Грипп"));
        _patients.Add(new Patient("Усманов Павел Артурович", 56, "Склероз"));
        _patients.Add(new Patient("Гончаров Рустам Евгениевич", 43, "Орви"));
        _patients.Add(new Patient("Лабба Александр Семенович", 19, "Ветрянка"));
        _patients.Add(new Patient("Козлов Семен Семёнович", 77, "Склероз"));
        _patients.Add(new Patient("Золкин Валерий Гайдарович", 90, "Склероз"));
    }

    public void Start()
    {
        const int CommandSortByName = 1;
        const int CommandSortByAge = 2;
        const int CommandShowPatientWithDiseas = 3;
        const int CommandExit = 4;

        bool isWork = true;

        while (isWork)
        {
            ShowPatients();

            Console.WriteLine($"Введите команту:\n" +
                $"{CommandSortByName} Cортировать пациентов по имени\n" +
                $"{CommandSortByAge} Cортировать пациентов по возрасту\n" +
                $"{CommandShowPatientWithDiseas} Показать пациентов по указаной болезни\n" +
                $"{CommandExit} Выход\n");

            int userInput = UserUtils.GetNumber();

            switch (userInput) 
            {
                case CommandSortByName:
                    SortPatientsByName();
                    break;
                case CommandSortByAge:
                    SortPatientsByAge();
                    break;
                case CommandShowPatientWithDiseas:
                    ShowPatientWithSpecifiedDisease();
                    break;
                case CommandExit:
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Такой команды нет.");
                    break;
            }
        }
    }

    private void ShowPatients()
    {
        foreach (var patient in _patients)
        {
            patient.ShowInfo();
        }
    }

    private void SortPatientsByName()
    {
        var sortPatients = _patients.OrderBy(patient => patient.FullName).ToList();

        _patients = sortPatients;

        Console.Clear();
    }

    private void SortPatientsByAge()
    {
        var sortPatients = _patients.OrderBy(patient => patient.Age).ToList();

        _patients = sortPatients;

        Console.Clear();
    }

    private void ShowPatientWithSpecifiedDisease()
    {
        Console.Write("Введите название болезни: ");

        string disease = Console.ReadLine();

        var selectedPatients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower());

        Console.Clear();

        if (selectedPatients.Count() == 0)
        {
            Console.WriteLine("Пациенты с таким заболеванием отсутствуют");
        }
        else
        {
            foreach (var patient in selectedPatients)
            {
                patient.ShowInfo();
            }
        }

        Console.ReadLine();
    }
}

class Patient
{
    public Patient(string fullName, int age, string disease)
    {
        FullName = fullName;
        Age = age;
        Disease = disease;
    }

    public string FullName { get; private set; }

    public int Age { get; private set; }

    public string Disease { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"ФИО: {FullName}\nВозраст: {Age}\nЗаболевание: {Disease}\n");
    }
}

static class UserUtils
{
    public static int GetNumber()
    {
        bool isNumberWork = true;
        int userNumber = 0;

        while (isNumberWork)
        {
            bool isNumber;
            string userInput = Console.ReadLine();

            if (isNumber = int.TryParse(userInput, out int number))
            {
                userNumber = number;
                isNumberWork = false;
            }
            else
            {
                Console.WriteLine($"Не правильный ввод данных!!!  Повторите попытку");
            }
        }

        return userNumber;
    }
}
