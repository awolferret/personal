using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Ivanov Ivan Ivanovich" , "Petrov Petr Petrovich", "Vasiliev Vasiliy Vaslilevich"};
            string[] positions = {"Ceo", "Hr", "Cteo"};
            string[] tempArray = {" "};
            bool isWorking = true;

            while (isWorking == true)
            {
                Console.WriteLine("1. Добавить нового сотрудника");
                Console.WriteLine("2. Посмотреть все досье");
                Console.WriteLine("3. Удалить выбранное досье");
                Console.WriteLine("4. Поиск по фамилии");
                Console.WriteLine("5. Выход из программы");
                Console.WriteLine("Введите команду");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        addNewWorker(tempArray,ref names,ref positions);
                        break;
                    case 2:
                        getList(names, positions);
                        break;
                    case 3:
                        cvDelete(tempArray, ref names, ref positions);
                        break;
                    case 4:
                        sonameSearch(names);
                        break;
                    case 5:
                        isWorking = exit(isWorking);
                        break;
                }
            }
        }
        static void addNewWorker(string [] tempArray,ref string [] names,ref string [] positions)
        {
            tempArray = names;
            names = new string[names.Length + 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                names[i] = tempArray[i];
            }
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();
            names[names.Length - 1] = name;
            tempArray = positions;
            positions = new string[positions.Length + 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                positions[i] = tempArray[i];
            }
            Console.WriteLine("Введите должность");
            string position = Console.ReadLine();
            positions[positions.Length - 1] = position;
            Console.Clear();
        }
        static void getList(string [] names, string [] positions)
        {

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + names[i] + " - " + positions[i]);
            }
            Console.WriteLine("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static void cvDelete(string[] tempArray, ref string[] names, ref string[] positions)
        {
            Console.WriteLine("Какое досье вы хотите удалить?");
            int userChooise = Convert.ToInt32(Console.ReadLine());

            if (userChooise < names.Length)
            {
                names[userChooise - 1] = " ";

                for (int i = userChooise; i < names.Length; i++)
                {
                    names[i - 1] = names[i];
                }
                tempArray = names;
                names = new string[names.Length - 1];

                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = tempArray[i];
                }
                positions[userChooise - 1] = " ";

                for (int i = userChooise; i < positions.Length; i++)
                {
                    positions[i - 1] = positions[i];
                }
                tempArray = positions;
                positions = new string[positions.Length - 1];

                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = tempArray[i];
                }
                Console.Clear();
            }
            else 
            {
                Console.WriteLine("Такого досье нет");
            }
        }
        static void sonameSearch(string[] names)
        {
            Console.WriteLine("Введите искомую фамилию");
            string soname = Console.ReadLine();

            for (int i = 0; i < names.Length; i++)
            {
                string[] words = names[i].Split(' ');

                for (int j = 0; j < names.Length; j++)
                {
                    if (soname.ToLower() == words[j].ToLower())
                    {
                        Console.WriteLine(words[j]);
                        Console.WriteLine(words[j + 1]);
                        Console.WriteLine(words[j + 2]);
                    }
                }
            }
        }
        static bool exit(bool isWorking)
        {
            Console.WriteLine("Выход из программы");
            isWorking = false;
            return isWorking;
        }
    }
}