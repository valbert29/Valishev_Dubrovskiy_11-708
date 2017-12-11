using System;
using System.Threading;

namespace ConsoleGame
{
    public class Egg
    {
        public static int X;
        public static int Y;

        public static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = 32;
            Console.BufferHeight = Console.WindowHeight = 22;
            Console.CursorVisible = false;
            GetStartPosition();
            int step;
            if (X == 0) step = 1;
            else step = -1;
            for (int i = 0; i < 10; i++)
            {
                Console.Write('O');
                Console.SetCursorPosition(X, Y);
                Thread.Sleep(500);
                Console.Write(' ');
                Console.SetCursorPosition(X + step, Y);
                X += step;
            }
            Console.ReadLine();
        }

        public static void GetStartPosition()
        {
            Random startCase = new Random();
            switch (startCase.Next(4))
            {
                case 0:
                    SetStartPosition(0, 0);
                    break;
                case 1:
                    SetStartPosition(0, 10);
                    break;
                case 2:
                    SetStartPosition(31, 0);
                    break;
                case 3:
                    SetStartPosition(31, 10);
                    break;
            }
        }

        public static void SetStartPosition(int x, int y)
        {
            X = x;
            Y = y;
            Console.SetCursorPosition(X, Y);
        }
    }
}