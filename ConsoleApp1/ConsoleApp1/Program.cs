using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = 3;
            string[] names = new string[arrayLenght];
            names[0] = "Ivanov Ivan Ivanovich";
            names[1] = "Petrov Petr Petrovich";
            names[2] = "Vasiliev Vasiliy Vaslilevich";
            string[] positions = new string[arrayLenght];
            positions[0] = "Ceo";
            positions[1] = "Hr";
            positions[2] = "CTEO";
            string[] tempArray = { };
            string[] bufferArray = { };
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
                        AddNewWorker(bufferArray,ref arrayLenght,tempArray,ref names,ref positions);
                        break;
                    case 2:
                        ShowList(names, positions);
                        break;
                    case 3:
                        DeleteResume(ref arrayLenght,tempArray, ref names, ref positions);
                        break;
                    case 4:
                        SearchSoname(names);
                        break;
                    case 5:
                        isWorking = Exit(isWorking);
                        break;
                }
            }
        }

        static void AddNewWorker(string [] bufferArray,ref int arrayLenght, string [] tempArray,ref string [] names,ref string [] positions)
        {
            tempArray = names;
            bufferArray = positions;
            arrayLenght += 1;
            names = new string[arrayLenght];
            positions = new string[arrayLenght];

            for (int i = 0; i < tempArray.Length; i++)
            {
                names[i] = tempArray[i];
                positions[i] = bufferArray[i];
            }
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();
            names[arrayLenght - 1] = name;
            Console.WriteLine("Введите должность");
            string position = Console.ReadLine();
            positions[arrayLenght - 1] = position;
        }

        static void ShowList(string [] names, string [] positions)
        {

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + names[i] + " - " + positions[i]);
            }
            Console.WriteLine("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteResume(ref int arrayLenght,string[] tempArray, ref string[] names, ref string[] positions)
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
                arrayLenght -= 1;
                names = new string[arrayLenght];

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
                positions = new string[arrayLenght];

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

        static void SearchSoname(string[] names)
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

        static bool Exit(bool isWorking)
        {
            Console.WriteLine("Выход из программы");
            isWorking = false;
            return isWorking;
        }
    }
}