﻿/* Authors: Ishaan Thota and Andrew Crapitto
 * Updated: 5/04/2019
 */

// Changelog: 5/4/2019: Finished cleaning things up, changed array type of the board, changed from ArrayList to List<>, made Space and Tile seperate classes

using System;
using System.Collections.Generic;

namespace Pai_Sho
{
    public class Board
    {
        static string RED = "red";
        static string WHITE = "white";
        static string NEUT = "neutral";
        static string PORT = "port";


        static char ROCK = 'r';
        static char WHEEL = 'w';
        static char KNOTWEED = 'k';
        static char BOAT = 'b';
        static char LOTUS = 'l';
        static char ORCHID = 'o';

        static int HOST = 0;
        static int GUEST = 1;

        Space[][] game_board;
        //number of red tiles on the board
        int num_red_tiles;
        //number of white tiles one the board
        int num_white_tiles;

        List<Space> occupied = new List<Space>();

        //row one is at the very tope of the game board
        public Board()
        {
            game_board = new Space[19][];
            for (int i = 0; i < 19; i++) game_board[i] = new Space[19];

            for (int i = 0; i <= 18; i++)
            {
                game_board[0][i] = new Space();
                //null spaces
                if (i <= 4 || i >= 14) game_board[1][i] = new Space();
                if (i <= 3 || i >= 15) game_board[2][i] = new Space();
                if (i <= 2 || i >= 16) game_board[3][i] = new Space();
                if (i <= 1 || i >= 17) game_board[4][i] = new Space();
                if (i <= 0 || i >= 18) game_board[5][i] = new Space();
                if (i <= 0 || i >= 18) game_board[6][i] = new Space();
                if (i <= 0 || i >= 18) game_board[7][i] = new Space();
                if (i <= 0 || i >= 18) game_board[8][i] = new Space();
                if (i <= 0 || i >= 18) game_board[9][i] = new Space();
                if (i <= 0 || i >= 18) game_board[10][i] = new Space();
                if (i <= 0 || i >= 18) game_board[11][i] = new Space();
                if (i <= 0 || i >= 18) game_board[12][i] = new Space();
                if (i <= 0 || i >= 18) game_board[13][i] = new Space();
                if (i <= 1 || i >= 17) game_board[14][i] = new Space();
                if (i <= 2 || i >= 16) game_board[15][i] = new Space();
                if (i <= 3 || i >= 15) game_board[16][i] = new Space();
                if (i <= 4 || i >= 14) game_board[17][i] = new Space();
                game_board[18][i] = new Space();

                //neutral spaces
                if (i >= 5 && i <= 13 && i != 9) game_board[1][i] = new Space(NEUT);
                if (i >= 4 && i <= 14) game_board[2][i] = new Space(NEUT);
                if ((i >= 3 && i <= 8) || (i >= 10 && i <= 15)) game_board[3][i] = new Space(NEUT);
                if ((i >= 2 && i <= 7) || (i >= 11 && i <= 16)) game_board[4][i] = new Space(NEUT);
                if ((i >= 1 && i <= 6) || (i >= 12 && i <= 17)) game_board[5][i] = new Space(NEUT);
                if ((i >= 1 && i <= 5) || (i >= 13 && i <= 17)) game_board[6][i] = new Space(NEUT);
                if ((i >= 1 && i <= 4) || (i >= 14 && i <= 17)) game_board[7][i] = new Space(NEUT);
                if ((i >= 1 && i <= 3) || (i >= 15 && i <= 17)) game_board[8][i] = new Space(NEUT);
                if (i == 2 || i == 16) game_board[9][i] = new Space(NEUT);
                if ((i >= 1 && i <= 3) || (i >= 15 && i <= 17)) game_board[10][i] = new Space(NEUT);
                if ((i >= 1 && i <= 4) || (i >= 14 && i <= 17)) game_board[11][i] = new Space(NEUT);
                if ((i >= 1 && i <= 5) || (i >= 13 && i <= 17)) game_board[12][i] = new Space(NEUT);
                if ((i >= 1 && i <= 6) || (i >= 12 && i <= 17)) game_board[13][i] = new Space(NEUT);
                if ((i >= 2 && i <= 7) || (i >= 11 && i <= 16)) game_board[14][i] = new Space(NEUT);
                if ((i >= 3 && i <= 8) || (i >= 10 && i <= 15)) game_board[15][i] = new Space(NEUT);
                if (i >= 4 && i <= 14) game_board[16][i] = new Space(NEUT);
                if (i >= 5 && i <= 13 && i != 9) game_board[17][i] = new Space(NEUT);

                //red spaces
                if (i == 10) game_board[4][i] = new Space(RED);
                if (i >= 10 && i <= 11) game_board[5][i] = new Space(RED);
                if (i >= 10 && i <= 12) game_board[6][i] = new Space(RED);
                if (i >= 10 && i <= 13) game_board[7][i] = new Space(RED);
                if (i >= 10 && i <= 14) game_board[8][i] = new Space(RED);
                if (i <= 8 && i >= 4) game_board[10][i] = new Space(RED);
                if (i <= 8 && i >= 5) game_board[11][i] = new Space(RED);
                if (i <= 8 && i >= 6) game_board[12][i] = new Space(RED);
                if (i <= 8 && i >= 7) game_board[13][i] = new Space(RED);
                if (i == 8) game_board[14][i] = new Space(RED);

                //white spaces
                if (i == 10) game_board[14][i] = new Space(WHITE);
                if (i >= 10 && i <= 11) game_board[13][i] = new Space(WHITE);
                if (i >= 10 && i <= 12) game_board[12][i] = new Space(WHITE);
                if (i >= 10 && i <= 13) game_board[11][i] = new Space(WHITE);
                if (i >= 10 && i <= 14) game_board[10][i] = new Space(WHITE);
                if (i <= 8 && i >= 4) game_board[8][i] = new Space(WHITE);
                if (i <= 8 && i >= 5) game_board[7][i] = new Space(WHITE);
                if (i <= 8 && i >= 6) game_board[6][i] = new Space(WHITE);
                if (i <= 8 && i >= 7) game_board[5][i] = new Space(WHITE);
                if (i == 8) game_board[4][i] = new Space(WHITE);

            }

            //ports

            game_board[9][17] = new Space("port");
            game_board[9][1] = new Space("port");
            game_board[1][9] = new Space("port");
            game_board[17][9] = new Space("port");

        }

        public List<Space> poss_moves(Tile tile, int x, int y)
        {
            List<Space> ans = new List<Space>();
            int speed = tile.mobility;
            // Ask: what is the point of posx and posy?
            int posx = x;
            int posy = y;
            for (int i = posx - speed; i <= posx + speed; i++)
            {
                for (int r = posy - speed; r <= posx + speed; r++)
                {
                    if (r >= 1 && r <= 17 && i >= 1 && i <= 17 && !game_board[r][i].isNull())
                    {
                        if (Math.Abs(posx - i) + Math.Abs(posy - r) <= speed && 
                                    (game_board[r][i].type == NEUT || game_board[r][i].type == tile.color))
                        {

                            if (game_board[r][i].isEmpty())
                            {
                                if (!clash_pos(tile, r, i))
                                {
                                    ans.Add(game_board[r][i]);
                                }


                            }
                            else if (clash(tile, game_board[r][i].getTile()))
                            {
                                ans.Add(game_board[r][i]);
                            }

                        }
                    }
                }
            }
                    return ans;
        }

        // t1 should be the tile known to be a flower
        public bool clash(Tile t1, Tile t2)
        {
            if (t2.isFlower() && t1.mobility == t2.mobility && t1.color != t2.color)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO fix this code to adapt for the new spaces and tiles classes
        // t1 is the tile that is being moved, and t2 is the tile that is bing moved to
        // Ask: What is the point of this code as a whole?
        public bool clash_pos(Tile t1, int y, int x)
        {

            // Checks up the x-axis
            for (int i = 0; i + x <= 17; i++)
            {
                Space s1 = game_board[y][x + i];
                if (!s1.isEmpty() && clash(t1, s1.getTile()))
                {
                    return true;
                }
                // Ask: Why do we have a break statement here? I changed this to a continue
                else continue;

            }

            // Checks down the x-axis
            for (int i = -1; i + x >= 1; i--)
            {
                Space s1 = game_board[y][x + i];
                if (!s1.isEmpty() && clash(t1, s1.getTile())) return true;
                // Ask: Why do we have a break statement here? I changed this to a continue
                else continue;

            }

            // Checks up the y-axis
            for (int i = 1; i + y <= 17; i++)
            {
                Space s1 = game_board[y + i][x];
                if (!s1.isEmpty() && clash(t1, s1.getTile())) return true;
                else continue;
            }

            // Checks down the y-axis
            for (int i = -1; i + y >= 1; i--)
            {
                Space s1 = game_board[y + i][x];
                if (!s1.isEmpty() && clash(t1, s1.getTile())) return true;
                // Ask: Why do we have a break statement here? I changed the break to a continue
                else continue;
            }

            return false;


        }

        public void place_tile(int i, int j, Tile piece)
        {
            game_board[i][j].setTile(piece);
            occupied.Add(game_board[i][j]);
        }

    }

}