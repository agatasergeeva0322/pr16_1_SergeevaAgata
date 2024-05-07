using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите название файла (подсказка: он называется 'file.txt'): ");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                string[] sentenses = File.ReadAllLines("file.txt");
                string searchWord = "";
                bool result = false;
                do
                {
                    Console.Write("Введите слово: ");
                    searchWord = Console.ReadLine();
                    //Проверка, что слово состоит искключительно из букв
                    result = searchWord.All(char.IsLetter);
                }
                while (result == false);
                
                if (result == true)
                {
                    //Определение количества нахождений слова с тексте
                    int count = sentenses.SelectMany(sentens => sentens.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries))
                        .Where(word => word.ToLower() == searchWord.ToLower())
                        .Count();
                    Console.WriteLine($"Ваше слово '{searchWord}' встречается в тексте {count} раз(-а)");
                }
                else Console.WriteLine("Вы неправильно ввели слово!!");
            }
            else Console.WriteLine("Файл с данными не найден!");

            Console.ReadKey();
        }
    }
}

