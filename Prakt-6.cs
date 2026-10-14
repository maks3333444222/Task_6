using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakt_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();

            // 1. Создать матрицу цитадели char[,] castle размером 7x7.

            char[,] castle = new char[7, 7];

            int rows = castle.GetLength(0);
            int cols = castle.GetLength(1);


            // 2. Построить по внешнему контуру стены #, а по 4 углам установить сторожевые башни T.

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == 6 ||
                        j == 0 || j == 6)
                    {
                        castle[i, j] = '#';
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            castle[0, 0] = 'T';
            castle[0, 6] = 'T';
            castle[6, 0] = 'T';
            castle[6, 6] = 'T';
            Console.ResetColor();

            // 3. В центре нижней стены [6, 3] установить ворота G, внутренний двор замостить ..


            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    castle[i, j] = '.';
                }
            }

            castle[6, 3] = 'G';


            // 4. Создать целочисленную матрицу гарнизона int[,] defendersCount (число стрелков на клетку).

            int[,] defendersCount = new int[rows, cols];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    defendersCount[x, y] = rnd.Next(1, 11);
                }
            }


            Console.WriteLine();
            Console.WriteLine("===================== Вывод карты замка =====================");
            Console.WriteLine();

            // 5,1. Вывод замка
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(castle[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("===================== Вывод карты гарнизона =====================");
            Console.WriteLine();


            // 5,2. Вывод карты гарнизона

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Console.Write($"{defendersCount[x, y] = rnd.Next(1, 11),2} ");
                }

                Console.WriteLine();
            }


            // 6. Рассчитать общее число защитников на северной стене (строка 0).

            int northdefenders = 0;

            for (int x = 0; x < rows; x++)
            {
                northdefenders += defendersCount[0, x];
            }
            Console.WriteLine($"Защитников на северной стороне: {northdefenders}");


            // 7. Найти участок крепостной стены с наименьшим числом бойцов гарнизона.

            int mindefenders = int.MaxValue;

            int minX = 0;
            int minY = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (castle[x, y] == '#' && defendersCount[x, y] < mindefenders)
                    {
                        mindefenders = defendersCount[x, y];
                    }
                }
            }

            Console.WriteLine($"Минимум защитников: {mindefenders}");
            Console.WriteLine($"Координаты стены: [{minX}, {minY}]");


            // 8. Подсчитать общее число башен T и ворот G на плане.

            int CountT = 0;
            int CountG = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (castle[x, y] == 'T')
                    {
                        CountT++;
                    }

                    else if (castle[x, y] == 'G')
                    {
                        CountG++;
                    }
                }
            }

            Console.WriteLine($"Количество T: {CountT}");
            Console.WriteLine($"Количество G: {CountG}");


            // 9. Запросить у коменданта координаты для переброски подкрепления (+5 бойцов в указанную клетку).

            Console.WriteLine();
            Console.WriteLine("===================== Подкрепление =====================");
            Console.WriteLine();

            Console.Write("Введите координату x: ");
            int choiseX = int.Parse(Console.ReadLine());

            Console.Write("Введите координату y: ");
            int choiseY = int.Parse(Console.ReadLine());

            if (choiseX >= 0 && choiseX < rows && choiseY >= 0 && choiseY < cols)
            {
                defendersCount[choiseX, choiseY] += 5;
                Console.WriteLine("Подкрепление отправлено");
                Console.WriteLine($"Теперь на клетке [{choiseX}, {choiseY}] теперь {defendersCount[choiseX, choiseY]} защитников");
            }

            else
            {
                Console.WriteLine("Ошибка!");
            }

            // 10. Проложить каменную дорогу через внутренний двор по главной диагонали из символов =.

            for (int x = 1; x < rows - 1; x++)
            {
                for (int y = 1; y < cols - 1; y++)
                {
                    if (x == y)
                    {
                        castle[x, y] = '=';
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("===================== Карта с каменной дорогой =====================");
            Console.WriteLine();

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Console.Write(castle[x, y] + " ");
                }

                Console.WriteLine();
            }


        }
    }
}