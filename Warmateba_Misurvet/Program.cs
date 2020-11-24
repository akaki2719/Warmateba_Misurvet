using System;
using System.Threading;

namespace Warmateba_Misurvet
{
    class Snake
    {
        int height = 50;
        int width = 70;

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;
       
        ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random random = new Random();
        Snake()
        {
            X[0] = 1;
            Y[0] = 1;
            Console.CursorVisible = false;
            fruitX = random.Next(2, (width - 2));
            fruitY = random.Next(2, (height - 2));
        }
        public void WriteBoard()
        {
        Console.Clear();
        for (int i = 1; i <= (width + 1); i++)
        {
            Console.SetCursorPosition(i, 1);
            Console.Write("-");
        }
        for (int i = 1; i <= (width + 1); i++)
        {
            Console.SetCursorPosition(i, (height + 2));
            Console.Write("-");
        }
        for (int i = 1; i <= (width + 1); i++)
        {
            Console.SetCursorPosition(1, i);
            Console.Write("|");
        }
        for (int i = 1; i <= (width + 1); i++)
        {
            Console.SetCursorPosition((width + 2), i);
            Console.Write("|");
        }
    }
       public void Input()
        {
            if (Console.KeyAvailable)
            {
                KeyInfo = Console.ReadKey(true);
                key = KeyInfo.KeyChar;
            }
        }
        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("0");
        }
        public void Azri()
        {
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++;
                    fruitX = random.Next(2, (width - 2));
                    fruitY = random.Next(2, (height - 2));
                }
            }
            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (key)
            {
                case 'a':
                    Y[0]--;
                    break;
                case 'b':
                    Y[0]++;
                    break;
                case 'c':
                    X[0]++;
                    break;
                case 'd':
                    X[0]--;
                    break;
            }
            for (int i = 0; i <= (parts - 1); i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
       static void Main(string[] args)
       {
           Snake snake = new Snake();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Azri();
            }   
       }
  }
}
