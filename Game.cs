//Project name: Module 4 Exercise 1
//Project purpose: Handle Game Funcitonality
//Created by: Jacob McMahon

using System;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{

    //.Net does not have a BadMoveException so you must define a custom exception class
    class BadMoveException : Exception
    {
        public BadMoveException()
        {
        }

        public BadMoveException(string message)
            : base(message)
        {
        }

        public BadMoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    internal class Game
    {
        char[,] grid = new char[3, 3];
        public Game()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    grid[x, y] = '.';
                }
            }
        }


        public void Print()
        {
            Console.Clear();

            Console.WriteLine("Key");
            int cell = 0;
            for (int y = 0; y < 3; y++)
            {
                if (y >= 1) Console.WriteLine("---+---+---");
                for (int x = 0; x < 3; x++)
                {
                    if (x >= 1) Console.Write("|");
                    Console.Write($" {cell++} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int y = 0; y < 3; y++)
            {
                if (y >= 1) Console.WriteLine("---+---+---");
                for (int x = 0; x < 3; x++)
                {
                    if (x >= 1) Console.Write("|");
                    Console.Write($" {grid[x, y]} ");
                }
                Console.WriteLine();
            }

        }

        internal void Move(int position, char player)
        {
            //TBD: This function needs validation - Done
            //1. Position needs to be in the range 0..9 - if not throw an ArgumentException
            //2. The grid cell needs to be unoccupied - if not throw a BadMoveException
            //    .Net does not have a BadMoveException so you must define a custom exception class


            if (position < 0 || position > 9)
            {
                throw new ArgumentException("Postion out of range");
            }
            if (grid[position % 3, (position / 3)] != '.')
            {
                throw new BadMoveException("Error:Bad Move!!");
            }

            grid[position % 3, (position / 3)] = player;
        }

        public bool Ended() //Check if game should end
        {
            //TBD: Determine the 'end' condition - Done
            bool result = false;
            bool allDotsCovered = true;
            int all_o = 'O' + 'O' + 'O';
            int all_x = 'X' + 'X' + 'X';

            for (int i = 0; i < 3; i++)
            {
                int coloumn_total = 0;
                int row_total = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == '.')
                    {
                        allDotsCovered = false;
                    }

                    coloumn_total += grid[i, j];
                    row_total += grid[j, i];

                }

                if (coloumn_total == all_o || coloumn_total == all_x)
                {
                    result = true;
                    break;
                }

                if (row_total == all_o || row_total == all_x)
                {
                    result = true;
                    break;
                }
            }

            int right_diag = grid[2, 0] + grid[1, 1] + grid[0, 2];
            int left_diag = grid[0, 0] + grid[1, 1] + grid[2, 2];


            if (left_diag == all_o || left_diag == all_x)
            {
                result = true;
            }

            if (right_diag == all_o || right_diag == all_x)
            {
                result = true;
            }

            if (allDotsCovered)
            {
                result = true;
            }

            return result;
        }

    }
}