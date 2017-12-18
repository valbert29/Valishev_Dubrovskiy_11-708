using System;
using System.Threading;

namespace WolfCatchEggs
{
    class Egg
    {
        public static char[][] lines = new char[][] { new char[6], new char[6], new char[6], new char[6] };

        public static void Initialize()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 6; j++)
                    lines[i][j] = ' ';
        }

        public static void RunEgg(char[][] lines)
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                lines[random.Next(4)][0] = 'O';
                Print(lines);
                foreach (char[] e in lines)
                    for (int j = 5; j >= 0; j--)
                        if (e[j] == 'O')
                        {
                            e[j] = ' ';
                            if (j != 5) e[j + 1] = 'O';
                        }
                Thread.Sleep(1000);
            }
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
                    x = 29;
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
    }
}