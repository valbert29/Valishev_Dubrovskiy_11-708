using System;
using System.Threading;

namespace WolfCatchEggs
{
    //Работа Дубровского Егора
    class EggLines
    {
        public static char[][] Lines = new char[][] { new char[6], new char[6], new char[6], new char[6] };

        public static void Initialize()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 6; j++)
                    Lines[i][j] = ' ';
        }

        public static void RunEgg(char[][] lines)
        {
            Random random = new Random();
            int k = 0;
            while (Game.Lives > 0 && Game.Points < 1000)
            {
                if (k % 2 == 0) lines[random.Next(4)][0] = 'O';
                Print(lines);
                for (int i = 0; i < 4; i++)
                    for (int j = 5; j >= 0; j--)
                        if (lines[i][j] == 'O')
                        {
                            lines[i][j] = ' ';
                            if (j != 5) lines[i][j + 1] = 'O';
                            else
                            {
                                ChangeResult(Game.WolfPosition, i);
                                PrintPoints();
                            }
                        }
                if (Game.Points <= 150) Thread.Sleep(1200 - (Game.Points * 6));
                else Thread.Sleep(300);
                k++;
            }
        }

        public static void ChangeResult(int wolfPosition, int lineNumber)
        {
            if (lineNumber == wolfPosition) Game.Points++;
            else Game.Lives--;
        }

        public static void Print(char[][] lines)
        {
            for (int i = 0; i < 4; i++)
            {
                int x;
                int y;
                int n;
                if (i % 2 == 0)
                {
                    x = 0;
                    n = 2;
                }
                else
                {
                    x = 31;
                    n = -2;
                }
                if (i < 2) y = 1;
                else y = 5;
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(x + (n * j) + 3, y + j);
                    Console.Write(lines[i][j]);
                }
            }
        }

        public static void PrintPoints()
        {
            Console.SetCursorPosition(10, 12);
            Console.Write(Game.Points);
            Console.SetCursorPosition(35, 12);
            Console.Write(Game.Lives);
        }
    }
}