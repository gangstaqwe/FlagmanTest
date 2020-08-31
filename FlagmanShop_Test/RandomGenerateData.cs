using System;
using System.Collections.Generic;
using System.Text;

namespace FlagmanShop_Test
{
    public class RandomDataGenerate
    {

        public static string GenerateRandomString(int size, bool lowerCase = true) // генерирую стрингу
        {
            StringBuilder stringbuilder = new StringBuilder();
            Random random = new Random();

            char a;

            for (int i = 0; i < size; i++)
            {
                a = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringbuilder.Append(a);
            }
            if (lowerCase)
                return stringbuilder.ToString().ToLower();

            return stringbuilder.ToString();
        }



        public static string GenerateRandomEmail(string NameDomen, int size = 10) // генерирую емаил
        {
            string RandomEmail = GenerateRandomString(size) + NameDomen;
            return RandomEmail;
        }

        public static string GenerateRandomData(int size) // генерирую рандомные данные
        {
            int[] array = new int[size];
            Random random = new Random();
            string data = "";

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(33, 65);
                data += (char)array[i];
            }
            return data;
        }

        public static string GenerateRandomPassword(int size) // возвращает рандомный пароль
        {
            string randomPassword = GenerateRandomData(size);
            return randomPassword;
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }
        public static string GeneratePhoneNumber(string countryCode, int country)
        {
            var random = new Random();
            int[] array = new int[country];
            string phoneNumber = "";

            for (int i = 0; i < array.Length; i++)

            {
                array[i] = random.Next(33, 125);
                phoneNumber += array[i];
            }
            phoneNumber = countryCode + phoneNumber;
            return phoneNumber;
        }

        public static string GenerateRandowNumberWithDiapazon() // возвращаю число диапазона от 1 до 9
        {
            Random x = new Random();
            return x.Next(1, 9).ToString();
        }

        public static string RandomName() // выбираю имя из масива
        {
            string[] mas = new string[] { "Коля", "Оля", "Паша", "Дмитрий", "Андрей" };
            Random rand = new Random();
            int i = rand.Next(0, mas.Length);
            return mas[i];
        }

    }
}