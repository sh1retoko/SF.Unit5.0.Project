using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Popito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string lastName, int Age, bool hasPet, int countPets, string[] namePets, string[] favColor, int countColor) Anketa;

            // User
            Console.Write("Введите свое имя: ");
            Anketa.Name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            Anketa.lastName = Console.ReadLine();

            string age;
            int intage;

            do
            {
                Console.Write("Введите ваш возраст: ");
                age = Console.ReadLine();

            } while (CheckNum(age, out intage));

            Anketa.Age = intage;

            // Pets
            Console.Write("У вас есть домашние животные? Да / Нет: ");
            string pet = Console.ReadLine();

            Anketa.countPets = 0;

            string countPet;
            int intPet;

            if (pet == "Да")
            {
                Anketa.hasPet = true;

                do
                {
                    Console.Write("Сколько у вас домашних животных: ");
                    countPet = Console.ReadLine();

                } while (CheckNum(countPet, out intPet));

                Anketa.countPets = intPet;

                var result = new string[intPet];

                Console.WriteLine("Введите клички ваших животных: ");

                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(i + 1 + " ");
                    result[i] = Console.ReadLine();
                }

                Anketa.namePets = result;

            }
            else
            {
                Anketa.hasPet = false;
                Anketa.namePets = null;
            }

            // Color
            string color;
            int intColor;
            do
            {
                Console.Write("Сколько у вас любимых цветов: ");
                color = Console.ReadLine();

            } while (CheckNum(color, out intColor));

            Anketa.countColor = intColor;
          
            var ColorName = new string[intColor];

            for (int i = 0; i < ColorName.Length; i++)
            {
                Console.Write(i + 1 + " ");
                ColorName[i] = Console.ReadLine();
            }

            Anketa.favColor = ColorName;

            UserAnketa(Anketa.Name, Anketa.lastName, Anketa.Age, Anketa.hasPet, Anketa.countPets, Anketa.namePets, Anketa.favColor);

        }
        // Проверка на числа
        // Создали метод и задали ему параметры 
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            corrnumber = 0;
            return true;
        }

        // Вывод данных пользователя
        static void UserAnketa(string userName, string userLastName, int userAge, bool userHasPets, int userCountPets, string[] userNamePets, string[] userFavColor)
        {
            Console.WriteLine();
            Console.WriteLine(userName);
            Console.WriteLine(userLastName);
            Console.WriteLine(userAge);

            if (userHasPets)
            {
                Console.WriteLine($"У вас {userCountPets} животных ");
                Console.WriteLine($"Клички ваших животных: ");

                for (int i = 0; i < userNamePets.Length; i++)
                {
                    Console.Write(i + 1 + " ");
                    Console.WriteLine(userNamePets[i]);
                }
            }
            else
            {
                Console.WriteLine("У каждого должен быть кот!!!");
            }
            Console.WriteLine("Ваши любимые цвета: ");
            for (int i = 0; i < userFavColor.Length; i++)
            {
                Console.Write(i + 1 + " ");
                Console.WriteLine(userFavColor[i]);
            }
        }

    }
}
