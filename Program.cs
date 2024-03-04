using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public partial class SnakeGame
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int width = 50;
            int height = 25;
            Board(width, height);

            bool item = false;

            int itemX = rd.Next(2, width);
            int itemY = rd.Next(2, height);
            
            int middleX = (width / 2) + 1;
            int middleY = (height / 2) + 1;

            Console.SetCursorPosition(middleX, middleY);
            Console.Write('0');
            int currentX = middleX;
            int currentY = middleY;
            int score = 0;
            
            while (true)
            {
                ShowScore(score, height);

                if (!item)
                {
                    do
                    {
                        itemX = rd.Next(2, width);
                        itemY = rd.Next(2, height);
                    }while(itemX != currentX && itemY != currentY);
                    item = true;
                }
                Item(itemX, itemY);
                Snake(currentX, currentY, true);

                if(currentX == itemX && currentY == itemY)
                {
                    score++;
                    item = false;
                }

                bool die = false;
                ConsoleKeyInfo userKey = Console.ReadKey();
                Console.SetCursorPosition(currentX, currentY);
                Console.Write(" ");
                switch (userKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentY > 2)
                        {
                            Snake(currentX, currentY, false);
                            currentY--;
                        }
                        else
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentY < height)
                        {
                            Snake(currentX, currentY, false);
                            currentY++;
                        }
                        else
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentX > 2)
                        {
                            Snake(currentX, currentY, false);
                            currentX--;
                        }
                        else
                        {
                            die = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentY < width)
                        {
                            Snake(currentX, currentY, false);
                            currentX++;
                        }
                        else
                        {
                            die = true;
                        }
                        break;
                }
                Console.SetCursorPosition(currentX, currentY);
                Console.Write("0");
                

                if (die)
                {
                    if (GameOver(height))
                    {
                        break;
                    }
                    else
                    {
                        Board(width, height);
                        middleX = (int)(width / 2);
                        middleY = (int)(height / 2);
                        score = 0;
                        item = false;
                    }
                }
            }
            
            
            
        }

        static void Board(int Width, int Height)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Height += 1;
            Width += 1;
            for (int i = 0; i < Height; i++)
            {
                if (i == 0 || i == Height - 1)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write(" ");
                    }

                }
                else
                {
                    Console.SetCursorPosition(1, i + 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(Width, i + 1);
                    Console.Write(" ");
                }
            }
        }

        static void Item(int x, int y)
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("0");
        }

        static void Snake(int x, int y, bool alive)
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            if (alive)
            {
                Console.WriteLine("o");
            }
            else
            {
                Console.WriteLine(" ");
            }
        }

        static void ShowScore(int score, int height)
        {
            Console.SetCursorPosition(1, height + 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"Score: {score}");

        }

        static bool GameOver(int height)
        {
            Console.SetCursorPosition(1, height + 2);
            Console.Write("Game Over! - Continue?(Y/N): ");
            char yn = (char)(Console.Read());
            while (Console.In.Peek() != -1) Console.In.Read();
            bool wantToContinue = (yn == 'n' || yn == 'N');
            return wantToContinue;
        }
    }
}
