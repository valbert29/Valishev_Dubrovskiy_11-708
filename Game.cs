using System;
using System.Threading;

namespace WolfCatchEggs
{
    //Работа просто Валишева Альберта
    public class Game
    {
        public static int WolfX = 0;
        public static int WolfY = 0;
        public static int Lives;
        public static int WolfPosition;
        public static int Points;

        static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = 38;
            Console.BufferHeight = Console.WindowHeight = 15;
            Console.CursorVisible = false;
            Console.Write("Управление Q, E, A, D\n" +
                          "Press S to Begin");
            while(true)
                if (Console.ReadKey(true).Key == ConsoleKey.S) GameProcess();
        }

        public static void GameProcess()
        {
            Points = 0;
            Lives = 3;
            Console.Clear();
            Console.Write(@"                                     " + "\n" +
                          @"                                     " + "\n" +
                          @" Q \_                            _/ E" + "\n" +
                          @"     \_                        _/    " + "\n" +
                          @"       \_                    _/      " + "\n" +
                          @"         \_                _/        " + "\n" +
                          @" A \_            ____            _/ D" + "\n" +
                          @"     \_       \_|""  ""|_/       _/    " + "\n" +
                          @"       \_       | __ |       _/      " + "\n" +
                          @"         \_   _/|____|\_   _/        " + "\n" +
                          @"                |/  \|               " + "\n" +
                          @"                |    |               " + "\n" +
                          @" Points - 0     |    |     Lives - 3 " + "\n");
            Thread WolfMove = new Thread(GetWolfPosition);
            WolfMove.Start();
            Move(ConsoleKey.Q);
            EggLines.Initialize();
            EggLines.RunEgg(EggLines.Lines);
            WolfMove.Abort();
            Console.SetCursorPosition(1, 13);
            if (Lives == 0) Console.Write("Game Over(");
            else Console.Write("Congratulations)");
            Console.WriteLine("\n Press S to retry");
            while (true)
                if (Console.ReadKey(true).Key == ConsoleKey.S) GameProcess();
        }

        static void GetWolfPosition()
        {
            while (true)
                Move(Console.ReadKey(true).Key);
        }

        public static void Move(ConsoleKey position)
        {
            Console.SetCursorPosition(WolfX, WolfY);
            Console.Write("   ");
            switch (position)
            {
                case ConsoleKey.Q:
                    WolfX = 11;
                    WolfY = 6;
                    WolfPosition = 0;
                    break;
                case ConsoleKey.E:
                    WolfX = 24;
                    WolfY = 6;
                    WolfPosition = 1;
                    break;
                case ConsoleKey.A:
                    WolfX = 11;
                    WolfY = 10;
                    WolfPosition = 2;
                    break;
                case ConsoleKey.D:
                    WolfX = 24;
                    WolfY = 10;
                    WolfPosition = 3;
                    break;
            }
            Console.SetCursorPosition(WolfX, WolfY);
            Console.Write(@"\_/");
        }
    }
}