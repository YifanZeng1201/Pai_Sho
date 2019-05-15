using System;
using System.Collections.Generic;

namespace Pai_Sho
{
    public class Game
    {

        static void plant(Board board, List<Tile> tiles)
        {
            string input;
            if (!board.game_board[9][1].isEmpty() && !board.game_board[9][17].isEmpty() && !board.game_board[1][9].isEmpty() && !board.game_board[17][9].isEmpty())
            {
                Console.WriteLine("Sorry, there are no open Gates to plant in!");
                choice:
                Console.Write("Would you like to [plant] or [move] a piece? ");
                input = Console.ReadLine();
                if (input.ToLower() == "move")
                {
                    move(board, tiles);
                    return;
                }
                else if (input.ToLower() == "plant") plant(board, tiles);
                else {
                    Console.WriteLine("Invalid choice");
                    goto choice;
                }

                if (tiles.Count == 0)
                {
                    Console.WriteLine("Sorry, you have no tiles left to plant!");
                    goto choice;
                }


            }
            Console.Write("Please choose from the ");
            if (board.game_board[9][1].isEmpty()) Console.Write("[left]");
            if (board.game_board[9][17].isEmpty()) Console.Write("[right]");
            if (board.game_board[1][9].isEmpty()) Console.Write("[top]");
            if (board.game_board[17][9].isEmpty()) Console.Write("[bottom]");
            Console.Write("gates to plant in: ");
            input = Console.ReadLine();
        }

        static void move(Board board, List<Tile> tiles)
        {
            List<Tile> player = new List<Tile>();
            foreach (Space spot in board.occupied)
            {
                if (spot.owner == 1)
                {
                    player.Add(spot.currentTile);
                }
            }
            userget:
            Console.Write("Please select a piece by [i,j] coordinates: [");
            for (int i = 0; i < player.Count; i++)
            {
                if (i < player.Count - 1) Console.Write(player[i].color + player[i].mobility + "(" + player[i].i + "," + player[i].j + "),");
                else Console.Write(player[i].color + player[i].mobility + "(" + player[i].i + "," + player[i].j + ")]: ");
            }
            string input = Console.ReadLine();
            foreach (Tile piece in player)
            {
                if (input == (piece.i + "," + piece.j))
                {
                    List<Space> moves = board.poss_moves(piece);
                    if (moves.Count == 0)
                    {
                        Console.WriteLine("Sorry, this piece has no possible moves!");
                        choice:
                        Console.Write("Would you like to [plant] or [move] a piece? ");
                        input = Console.ReadLine();
                        if (input.ToLower() == "move") move(board, tiles);
                        else if (input.ToLower() == "plant")
                        {
                            plant(board, tiles);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                            goto choice;
                        }
                    }
                    movechoice:
                    Console.Write("Make an [i,j] selection of where to move: ");
                    input = Console.ReadLine();
                    if (!input.Contains(","))
                    {
                        Console.WriteLine("Invalid choice");
                        goto movechoice;
                    }
                    string[] substrings = input.Split(',');
                    int i, j;
                    bool goodI = int.TryParse(substrings[0], out i);
                    bool goodJ = int.TryParse(substrings[1], out j);

                    if (!goodI || !goodJ)
                    {
                        Console.WriteLine("Invalid input");
                        goto movechoice;
                    }

                    if (substrings.Length > 2)
                    {
                        Console.WriteLine("Invalid input");
                        goto movechoice;
                    }

                    foreach (Space spot in moves)
                    {
                        if (i == spot.i && j == spot.j)
                        {
                            board.move_tile(piece.i, piece.j, i, j);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Illegal move!");
                            goto movechoice;
                        }
                    }
                    break;
                }
                else if (player.IndexOf(piece) == player.Count - 1 && input != ("(" + piece.i + "," + piece.j + ")"))
                {
                    Console.WriteLine("Invalid selection.");
                    goto userget;
                }
            }
        }

        static void Main()
        {
            int playerturn = -1;
            bool harmonyFormed = false;
            string temp = null;
            Board board = new Board();
            int turn = 0;
            bool win = false;

            List<Tile> player = new List<Tile>();
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    player.Add(new Tile(i, 1, "R"));
                }
            }
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    player.Add(new Tile(i, 1, "W"));
                }
            }

            while (!win)
            {
                if (!harmonyFormed) playerturn *= -1;

                if (turn == 0) Console.WriteLine("Welcome to PaiSho!");
                Console.WriteLine("Turn #" + turn + ":");
                board.print();
                Console.ForegroundColor = ConsoleColor.White;
                if (turn == 0)
                {
                    userget:
                    Console.Write("Please choose from [R3, R4, R5, W3, W4, W5] to plant: ");
                    string input = Console.ReadLine();
                        temp = input.ToLower();
                        if (input.ToLower() == "r3") board.place_tile(17, 9, new Tile(3, 1, "R"));
                        else if (input.ToLower() == "r4") board.place_tile(17, 9, new Tile(4, 1, "R"));
                        else if (input.ToLower() == "r5") board.place_tile(17, 9, new Tile(5, 1, "R"));
                        else if (input.ToLower() == "w3") board.place_tile(17, 9, new Tile(3, 1, "W"));
                        else if (input.ToLower() == "w4") board.place_tile(17, 9, new Tile(4, 1, "W"));
                        else if (input.ToLower() == "w5") board.place_tile(17, 9, new Tile(5, 1, "W"));
                        else
                        {
                            Console.WriteLine("Please enter a valid selection.");
                            goto userget;
                        }
                    player.RemoveAt(0);
                }
                else if (turn == 1)
                {
                    if (temp == "r3") board.place_tile(1, 9, new Tile(3, -1, "R"));
                    else if (temp == "r4") board.place_tile(1, 9, new Tile(4, -1, "R"));
                    else if (temp == "r5") board.place_tile(1, 9, new Tile(5, -1, "R"));
                    else if (temp == "w3") board.place_tile(1, 9, new Tile(3, -1, "W"));
                    else if (temp == "w4") board.place_tile(1, 9, new Tile(4, -1, "W"));
                    else if (temp == "w5") board.place_tile(1, 9, new Tile(5, -1, "W"));
                    Console.Write("It's your opponent's turn, hit [enter] to continue... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        ;
                    }
                }
                else if (playerturn == 1)
                {
                    choice:
                    Console.Write("Would you like to [plant] or [move] a piece? ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "move") move(board, player);
                    else if (input.ToLower() == "plant") plant(board, player);
                    else
                    {
                        Console.WriteLine("Invalid choice");
                        goto choice;
                    }
                }
                else
                {
                    Console.Write("It's your opponent's turn, hit [enter] to continue... ");
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        ;
                    }
                }
                turn++;
                Console.Clear();
            }

            board.print();
            if (playerturn == 1) Console.WriteLine("Congratulations, you've won!");
            else Console.WriteLine("Sorry, you lose!");

        }
    }
    
}