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
                        AddNewWorker(ref arrayLenght,ref names,ref positions);
                        break;
                    case 2:
                        ShowList(names, positions);
                        break;
                    case 3:
                        DeleteResume(ref arrayLenght,ref names, ref positions);
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

        static void AddNewWorker(ref int arrayLenght, ref string [] names,ref string [] positions)
        {
            IncreaseArray(ref arrayLenght, ref names, ref positions);
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

        static void DeleteResume(ref int arrayLenght, ref string[] names, ref string[] positions)
        {
            string[] tempArray = { };
            string[] bufferArray = { };
            Console.WriteLine("Какое досье вы хотите удалить?");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if (userChoice <= names.Length)
            {
                DecreaseArray( userChoice, bufferArray, ref arrayLenght, tempArray, ref names, ref positions);
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

        static void IncreaseArray( ref int arrayLenght, ref string[] names, ref string[] positions)
        {
            string[] tempArray = { };
            string[] bufferArray = { };
            tempArray = names;
            bufferArray = positions;
            arrayLenght += 1;
            names = new string[arrayLenght];
            positions = new string[arrayLenght];

            for (int i = 0; i < tempArray.Length; i++)
            {
                names[i] = tempArray[i];
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                positions[i] = bufferArray[i];
            }

        }

        static void DecreaseArray(int userChoice, string[] bufferArray, ref int arrayLenght, string[] tempArray, ref string[] names, ref string[] positions)
        {
            names[userChoice - 1] = " ";
            positions[userChoice - 1] = " ";

            for (int i = userChoice; i < names.Length; i++)
            {
                names[i - 1] = names[i];
            }
            for (int i = userChoice; i < positions.Length; i++)
            {
                positions[i - 1] = positions[i];
            }
            tempArray = names;
            bufferArray = positions;
            arrayLenght -= 1;
            names = new string[arrayLenght];
            positions = new string[arrayLenght];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = tempArray[i];

            }
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = bufferArray[i];
            }
            Console.Clear();
        }
    }
}