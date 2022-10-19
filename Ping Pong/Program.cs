using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ping_Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //field size
            const int fieldLength = 50, fieldWigth = 15;
            const char fieldTile = '#';
            string line=string.Concat(Enumerable.Repeat(fieldTile, fieldLength));
            const int racketLength = fieldWigth / 4;
            const char racketTile = '|';
            //racket
            int leftRacketHeight = 0;
            int rightRacketHeight = 0;
            //boll 
            int ballX = fieldLength / 2;
            int ballY = fieldWigth / 2;
            const char ballTile = 'O';
            //movement
            bool isBallGoingDown = true;
            bool isBallGoingRight = true;
            //score counter
            int leftPlayerPoints = 0;
            int rightPlayerPoint = 0;
            //score
            int scoreBoardX = fieldLength / 2 - 2;
            int scoreBoardY = fieldWigth+3;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);
                Console.SetCursorPosition(0,fieldWigth);
                Console.WriteLine(line);

                for (int i = 0; i < racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1+leftRacketHeight);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1+rightRacketHeight);
                    Console.WriteLine(racketTile);
                }

                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(ballTile);
                    Thread.Sleep(100);

                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(' ');

                    if (isBallGoingDown)
                    {
                        ballY++;
                    }
                    else
                    {
                        ballY--;
                    }
                    if (isBallGoingRight)
                    {
                        ballX++;
                    }
                    else
                    {
                        ballX--;
                    }
                    if (ballY == 1||ballY==fieldWigth-1)
                    {
                        isBallGoingDown = !isBallGoingDown;
                    }

                    if (ballX == 1)
                    {
                        if (ballY >= leftRacketHeight + 1 && ballY <= leftRacketHeight + racketLength)
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else
                        {
                            rightPlayerPoint++;
                            ballY = fieldWigth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                            Console.WriteLine($"{leftPlayerPoints}|{rightPlayerPoint}");
                            if (rightPlayerPoint == 10)
                            {
                                goto outer;
                            }
                        }
                    }
                    if (ballX == fieldLength-2)
                    {
                        if (ballY >= rightRacketHeight + 1 && ballY <= rightRacketHeight + racketLength)
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else
                        {
                            leftPlayerPoints++;
                            ballY = fieldWigth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreBoardX, scoreBoardY);
                            Console.WriteLine($"{leftPlayerPoints}|{rightPlayerPoint}");
                            if (leftPlayerPoints == 10)
                            {
                                goto outer;
                            }
                        }
                    }
                }
                //prople the racket
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rightRacketHeight > 0)
                        {
                            rightRacketHeight--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (rightRacketHeight <fieldWigth-racketLength-1)
                        {
                            rightRacketHeight++;
                        }
                        break;
                    case ConsoleKey.W:
                        if (leftRacketHeight > 0)
                        {
                            leftRacketHeight--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (leftRacketHeight <fieldWigth-racketLength-1)
                        {
                            leftRacketHeight++;
                        }
                        break;
                }
                for (int i = 1; i < fieldWigth; i++)
                {
                    Console.SetCursorPosition(0, i );
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(fieldLength - 1, i );
                    Console.WriteLine(" ");
                }
            }
            //finish 
        outer:;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            if (rightPlayerPoint == 10)
            {
                Console.WriteLine("Right Player won!");
            }
            else
            {
                Console.WriteLine("Left Player won!");
            }
        }
    }
}
