/* Author: Andrew Crapitto
 * Updated: 5/13/2019
 */

 // Changelog: 5/13/2019: Made methods static for use in the minimax algorithm

using System;
    class Eval
    {
        static private int open_ports(Space[][] arr)
        {
            int sum = 0;
            if (arr[1][9].isEmpty())
            {
                sum++;
            }
            if (arr[17][9].isEmpty())
            {
                sum++;
            }
            if (arr[9][1].isEmpty())
            {
                sum++;
            }
            if (arr[9][17].isEmpty())
            {
                sum++;
            }
            return sum;
        }

        static private int piece_value(Space[][] arr)
        {
            int sum = 0;
            for (int j = 0; j < 19; j++)
            {
                for (int i = 0; i < 19; i++)
                {
                    if (!arr[i][j].isEmpty()) {
                        sum += arr[i][j].pieceVal();
                    }
                }
            }
            return sum;
        }

        static private int count_harmonies(Space[][] arr)
        {
            int sum = 0;
            bool blockedu = false, blockedd = false, blockedl = false, blockedr = false;

            for (int j = 0; j < 19; j++)
            {
                for (int i = 0; i < 19; i++)
                {
                    if (!arr[i][j].isEmpty())
                    {
                        for (int k = i; k < 19; k++)
                        {
                            if (!arr[i][k].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[i][k].currentTile) && !blockedu) sum++;
                                blockedu = true;
                            }
                        }
                        for (int k = i; k >= 0; k--)
                        {
                            if (!arr[i][k].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[i][k].currentTile) && !blockedd) sum++;
                                blockedd = true;
                            }
                        }
                        for (int h = j; h < 19; h ++)
                        {
                            if (!arr[h][j].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[h][j].currentTile) && !blockedr) sum++;
                                blockedr = true;
                            }
                        }
                        for (int h = j; h >= 0; h--)
                        {
                            if (!arr[i][h].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[i][h].currentTile) && !blockedl) sum++;
                                blockedl = true;
                            }
                        }
                    }
                }
            }
            return sum/2;
        }

        static private int count_junctions(Space[][] arr)
        {
            int sum = 0;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                if (!arr[i][j].isEmpty())
                {
                    if (arr[i][j].currentTile.isJunction()) sum++;
                }
            }
            }
            return sum;
        }

        // This is the main evaluation function to be used by the minimax algorithm
        // Call this function to get the score of a board state
        static public int evaluation(Space[][] board)
        {
            return count_harmonies(board) + count_junctions(board) + piece_value(board) + open_ports(board);
        }
    }
