using System;
using System.Threading;

namespace WolfCatchEggs
{
    public class Game
    {
        public static int WolfX = 0;
        public static int WolfY = 0;

        static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = 34;
            Console.BufferHeight = Console.WindowHeight = 14;
            Console.CursorVisible = false;
            Console.Write(@"                                 " + "\n" +
                          @"                                 " + "\n" +
                          @"   \_                          _/" + "\n" +
                          @"     \_                      _/  " + "\n" +
                          @"       \_                  _/    " + "\n" +
                          @"         \_              _/      " + "\n" +
                          @"   \_                          _/" + "\n" +
                          @"     \_                      _/  " + "\n" +
                          @"       \_                  _/    " + "\n" +
                          @"         \_              _/      " + "\n" +
                          @"                                 " + "\n" +
                          @"                                 " + "\n" +
                          @"                                 " + "\n");
            GameProcess();
        }

        public static void GameProcess()
        {
            Thread WolfMove = new Thread(GetWolfPosition);
            WolfMove.Start();
            Egg.Initialize();
            Egg.RunEgg(Egg.lines);
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
                    WolfX = 10;
                    WolfY = 8;
                    break;
                case ConsoleKey.W:
                    WolfX = 20;
                    WolfY = 8;
                    break;
                case ConsoleKey.A:
                    WolfX = 10;
                    WolfY = 10;
                    break;
                case ConsoleKey.S:
                    WolfX = 20;
                    WolfY = 10;
                    break;
            }
            Console.SetCursorPosition(WolfX, WolfY);
            Console.Write(@"\_/");
        }
    }
}