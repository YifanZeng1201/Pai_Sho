using System;
using System.Collections.Generic;

namespace Pai_Sho
{
    public class Game
    {

        static int MAX = 10000;
        static int MIN = -10000;

        static void plant(Board board)
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
                    move(board);
                    return;
                }
                else if (input.ToLower() == "plant") plant(board);
                else
                {
                    Console.WriteLine("Invalid choice");
                    goto choice;
                }
            }

            if (board.player.Count == 0)
            {
                Console.WriteLine("Sorry, you have no tiles left to plant!");
                choice:
                Console.Write("Would you like to [plant] or [move] a piece? ");
                input = Console.ReadLine();
                if (input.ToLower() == "move")
                {
                    move(board);
                    return;
                }
                else if (input.ToLower() == "plant") plant(board);
                else
                {
                    Console.WriteLine("Invalid choice");
                    goto choice;
                }
            }

            userget:
            Console.Write("Please choose from [");
            for (int i = 0; i < board.player.Count; i++)
            {
                if (i != board.player.Count - 1)
                {
                    Console.Write(board.player[i].color + board.player[i].mobility + ", ");
                }
                else
                {
                    Console.Write(board.player[i].color + board.player[i].mobility + "] to plant: ");
                }
            }

            input = Console.ReadLine();
            Tile newT = null;
            for (int i = 0; i < board.player.Count; i++)
            {
                if (input.ToLower() == ("" + board.player[i].color.ToLower() + board.player[i].mobility))
                {
                    newT = board.player[i];
                    board.player.RemoveAt(i);
                    break;
                }
                else if (i == board.player.Count - 1 && input.ToLower() != ("" + board.player[i].color.ToLower() + board.player[i].mobility))
                {
                    Console.WriteLine("Invalid selection");
                    goto userget;
                }
            }

            userget2:
            Console.Write("Please choose from the");
            if (board.game_board[9][1].isEmpty()) Console.Write(" [left]");
            if (board.game_board[9][17].isEmpty()) Console.Write(" [right]");
            if (board.game_board[1][9].isEmpty()) Console.Write(" [top]");
            if (board.game_board[17][9].isEmpty()) Console.Write(" [bottom]");
            Console.Write(" gates to plant in: ");
            input = Console.ReadLine();

            if (input.ToLower() == "left" && board.game_board[9][1].isEmpty()) board.place_tile(9, 1, newT);
            else if (input.ToLower() == "left" && !board.game_board[9][1].isEmpty())
            {
                Console.WriteLine("That gate is occupied!");
                goto userget2;
            }
            else if (input.ToLower() == "right" && board.game_board[9][17].isEmpty()) board.place_tile(9, 17, newT);
            else if (input.ToLower() == "left" && !board.game_board[9][17].isEmpty())
            {
                Console.WriteLine("That gate is occupied!");
                goto userget2;
            }
            else if (input.ToLower() == "top" && board.game_board[1][9].isEmpty()) board.place_tile(1, 9, newT);
            else if (input.ToLower() == "top" && !board.game_board[1][9].isEmpty())
            {
                Console.WriteLine("That gate is occupied!");
                goto userget2;
            }
            else if (input.ToLower() == "bottom" && board.game_board[17][9].isEmpty()) board.place_tile(17, 9, newT);
            else if (input.ToLower() == "bottom" && !board.game_board[17][9].isEmpty())
            {
                Console.WriteLine("That gate is occupied!");
                goto userget2;
            }
            else
            {
                Console.WriteLine("Invalid selection");
                goto userget2;
            }

        }

        static void move(Board board)
        {
            List<Tile> player = new List<Tile>();
            string input;
            foreach (Space spot in board.occupied)
            {
                if (spot.owner == 1)
                {
                    player.Add(spot.currentTile);
                }
            }

            if (player.Count == 0)
            {
                Console.WriteLine("You have no moveable pieces!");
                choice:
                Console.Write("Would you like to [plant] or [move] a piece? ");
                input = Console.ReadLine();
                if (input.ToLower() == "move") move(board);
                else if (input.ToLower() == "plant")
                {
                    plant(board);
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    goto choice;
                }

            }

            userget:
            Console.Write("Please select a piece by [i,j] coordinates: [");
            for (int i = 0; i < player.Count; i++)
            {
                if (i < player.Count - 1) Console.Write(player[i].color + player[i].mobility + "(" + player[i].i + "," + player[i].j + "),");
                else Console.Write(player[i].color + player[i].mobility + "(" + player[i].i + "," + player[i].j + ")]: ");
            }
            input = Console.ReadLine();
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
                        if (input.ToLower() == "move") move(board);
                        else if (input.ToLower() == "plant")
                        {
                            plant(board);
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
                        else if (moves.IndexOf(spot) == moves.Count - 1 && !(i == spot.i && j == spot.j))
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
            bool win2 = false;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board.player.Add(new Tile(i, 1, "R"));
                    board.ai.Add(new Tile(i, -1, "R"));
                }
            }
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board.player.Add(new Tile(i, 1, "W"));
                    board.ai.Add(new Tile(i, -1, "W"));
                }
            }
            while (win == false)
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
                    if (input.ToLower() == "r3")
                    {
                        board.place_tile(17, 9, new Tile(3, 1, "R"));
                        board.player.RemoveAt(0);
                        board.ai.RemoveAt(0);
                    }
                    else if (input.ToLower() == "r4")
                    {
                        board.place_tile(17, 9, new Tile(4, 1, "R"));
                        board.player.RemoveAt(3);
                        board.ai.RemoveAt(3);
                    }
                    else if (input.ToLower() == "r5")
                    {
                        board.place_tile(17, 9, new Tile(5, 1, "R"));
                        board.player.RemoveAt(6);
                        board.ai.RemoveAt(6);
                    }
                    else if (input.ToLower() == "w3")
                    {
                        board.place_tile(17, 9, new Tile(3, 1, "W"));
                        board.player.RemoveAt(9);
                        board.ai.RemoveAt(9);
                    }
                    else if (input.ToLower() == "w4")
                    {
                        board.place_tile(17, 9, new Tile(4, 1, "W"));
                        board.player.RemoveAt(12);
                        board.ai.RemoveAt(12);
                    }
                    else if (input.ToLower() == "w5")
                    {
                        board.place_tile(17, 9, new Tile(5, 1, "W"));
                        board.player.RemoveAt(15);
                        board.ai.RemoveAt(15);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid selection.");
                        goto userget;
                    }
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
                    if (input.ToLower() == "move") move(board);
                    else if (input.ToLower() == "plant") plant(board);
                    else
                    {
                        Console.WriteLine("Invalid choice");
                        goto choice;
                    }
                }
                else
                {
                    Console.Write("It's your opponent's turn, hit [enter] to continue... ");
                    Treenode<int> gameTree = AI.buildGameTree(board);
                    Treenode<Board> boardTree = AI.buildBoardTree(board);
                    int val = AI.Minimax(0, gameTree, true, MIN, MAX);
                    board = AI.makeMove(val, gameTree, boardTree);
                    while (Console.ReadKey().Key != ConsoleKey.Enter)
                    {
                        ;
                    }
                }
                turn++;
                Console.Clear();
                //win = board.win_condition(1);
                //win2 = board.win_condition(-1);
            }

            board.print();
            Console.ForegroundColor = ConsoleColor.White;
            if (win) Console.WriteLine("Congratulations, you've won!");
            else if (win2) Console.WriteLine("Sorry, you lose!");

        }
    }

}