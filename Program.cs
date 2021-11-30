//Project name: Module 4 Exercise 1
//Project purpose: Handle game start and exit   
//Created by: Jacob McMahon

using System;

namespace TicTacToe
{
    class Program

    {
        static void Main()
        {
            var game = new Game();
            var player = 'X';
            while (!game.Ended())
            {
                game.Print();
                //Get an integer position
                Console.Write("Enter your move:");
                string input;
                int position;
                do
                {
                    input = Console.ReadLine();

                } while (!int.TryParse(input, out position));

                //TBD: Handle the Exceptions:
                //1. Once you have implemented exceptions in game.Move() you must catch the ones you expect to see here
                //and handle them with suitable error messages
                try
                {
                    game.Move(position, player);
                }
                catch (ArgumentException err)
                {
                    System.Diagnostics.Debug.Write(err.Message);
                    // This is wrong.
                    throw err;
                }
                catch (Exception err) //2. Also handle any unexpected exceptions with an "Unknown Error" message. Work out a way to test that code!
                {
                    System.Diagnostics.Debug.Write("Unknown Error");
                    throw err;
                }

                //Switch players
                player = (player == 'X') ? 'O' : 'X';
            }
            game.Print();
        }
    }
}
