/* Authors: Ishaan Thota and Andrew Crapitto
 * Updated: 5/04/2019
 */

// Changelog: 5/4/2019: Finished cleaning things up, changed array type of the board, changed from ArrayList to List<>, made Space and Tile seperate classes
// Changelog: 5/12/2019: Fixed up some issues that I found in the initializer, created the Print function to print out the board to the console
// Changelog: 5/13/2019: Created the copy method that returns a copy of the current board state, add the move tile method as a variation on the place tile method
// Changelog: 5/14/2019

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

        public List<Space> occupied = new List<Space>();

        //row one is at the very tope of the game board
        public Board()
        {
            game_board = new Space[19][];
            for (int i = 0; i < 19; i++) game_board[i] = new Space[19];

            for (int i = 0; i < 19; i++)
            {
                game_board[0][i] = new Space(0, i);
                //null spaces
                if (i <= 4 || i >= 14) game_board[1][i] = new Space(1, i);
                if (i <= 3 || i >= 15) game_board[2][i] = new Space(2, i);
                if (i <= 2 || i >= 16) game_board[3][i] = new Space(3, i);
                if (i <= 1 || i >= 17) game_board[4][i] = new Space(4, i);
                if (i <= 0 || i >= 18) game_board[5][i] = new Space(5, i);
                if (i <= 0 || i >= 18) game_board[6][i] = new Space(6, i);
                if (i <= 0 || i >= 18) game_board[7][i] = new Space(7, i);
                if (i <= 0 || i >= 18) game_board[8][i] = new Space(8, i);
                if (i <= 0 || i >= 18) game_board[9][i] = new Space(9, i);
                if (i <= 0 || i >= 18) game_board[10][i] = new Space(10, i);
                if (i <= 0 || i >= 18) game_board[11][i] = new Space(11, i);
                if (i <= 0 || i >= 18) game_board[12][i] = new Space(12, i);
                if (i <= 0 || i >= 18) game_board[13][i] = new Space(13, i);
                if (i <= 1 || i >= 17) game_board[14][i] = new Space(14, i);
                if (i <= 2 || i >= 16) game_board[15][i] = new Space(15, i);
                if (i <= 3 || i >= 15) game_board[16][i] = new Space(16, i);
                if (i <= 4 || i >= 14) game_board[17][i] = new Space(17, i);
                game_board[18][i] = new Space(18, i);

                //neutral spaces
                if (i >= 5 && i <= 13 && i != 9) game_board[1][i] = new Space(NEUT, 1, i);
                if (i >= 4 && i <= 14) game_board[2][i] = new Space(NEUT, 2, i);
                if ((i >= 3 && i <= 9) || (i >= 10 && i <= 15)) game_board[3][i] = new Space(NEUT, 3, i);
                if ((i >= 2 && i <= 7) || i == 9 || (i >= 11 && i <= 16)) game_board[4][i] = new Space(NEUT, 4, i);
                if ((i >= 1 && i <= 6) || i == 9 || (i >= 12 && i <= 17)) game_board[5][i] = new Space(NEUT, 5, i);
                if ((i >= 1 && i <= 5) || i == 9 || (i >= 13 && i <= 17)) game_board[6][i] = new Space(NEUT, 6, i);
                if ((i >= 1 && i <= 4) || i == 9 || (i >= 14 && i <= 17)) game_board[7][i] = new Space(NEUT, 7, i);
                if ((i >= 1 && i <= 3) || i == 9 || (i >= 15 && i <= 17)) game_board[8][i] = new Space(NEUT, 8, i);
                if ((i >= 2 && i <= 17) || i == 9 || (i >= 15 && i <= 17)) game_board[9][i] = new Space(NEUT, 9, i);
                if (i == 2 || i == 16) game_board[9][i] = new Space(NEUT, 9, i);
                if ((i >= 1 && i <= 3) || i == 9 || (i >= 15 && i <= 17)) game_board[10][i] = new Space(NEUT, 10, i);
                if ((i >= 1 && i <= 4) || i == 9 || (i >= 14 && i <= 17)) game_board[11][i] = new Space(NEUT, 11, i);
                if ((i >= 1 && i <= 5) || i == 9 || (i >= 13 && i <= 17)) game_board[12][i] = new Space(NEUT, 12, i);
                if ((i >= 1 && i <= 6) || i == 9 || (i >= 12 && i <= 17)) game_board[13][i] = new Space(NEUT, 13, i);
                if ((i >= 2 && i <= 7) || i == 9 || (i >= 11 && i <= 16)) game_board[14][i] = new Space(NEUT, 14, i);
                if ((i >= 3 && i <= 8) || i == 9 || (i >= 10 && i <= 15)) game_board[15][i] = new Space(NEUT, 15, i);
                if (i >= 4 && i <= 14) game_board[16][i] = new Space(NEUT, 16, i);
                if (i >= 5 && i <= 13 && i != 9) game_board[17][i] = new Space(NEUT, 17, i);

                //red spaces
                if (i == 10) game_board[4][i] = new Space(RED, 4, i);
                if (i >= 10 && i <= 11) game_board[5][i] = new Space(RED, 5, i);
                if (i >= 10 && i <= 12) game_board[6][i] = new Space(RED, 6, i);
                if (i >= 10 && i <= 13) game_board[7][i] = new Space(RED, 7, i);
                if (i >= 10 && i <= 14) game_board[8][i] = new Space(RED, 8, i);
                if (i <= 8 && i >= 4) game_board[10][i] = new Space(RED, 10, i);
                if (i <= 8 && i >= 5) game_board[11][i] = new Space(RED, 11, i);
                if (i <= 8 && i >= 6) game_board[12][i] = new Space(RED, 12, i);
                if (i <= 8 && i >= 7) game_board[13][i] = new Space(RED, 13, i);
                if (i == 8) game_board[14][i] = new Space(RED, 14, i);

                //white spaces
                if (i == 10) game_board[14][i] = new Space(WHITE, 14, i);
                if (i >= 10 && i <= 11) game_board[13][i] = new Space(WHITE, 13, i);
                if (i >= 10 && i <= 12) game_board[12][i] = new Space(WHITE, 12, i);
                if (i >= 10 && i <= 13) game_board[11][i] = new Space(WHITE, 11, i);
                if (i >= 10 && i <= 14) game_board[10][i] = new Space(WHITE, 10, i);
                if (i <= 8 && i >= 4) game_board[8][i] = new Space(WHITE, 8, i);
                if (i <= 8 && i >= 5) game_board[7][i] = new Space(WHITE, 7, i);
                if (i <= 8 && i >= 6) game_board[6][i] = new Space(WHITE, 6, i);
                if (i <= 8 && i >= 7) game_board[5][i] = new Space(WHITE, 5, i);
                if (i == 8) game_board[4][i] = new Space(WHITE, 4, i);

            }

            //ports

            game_board[9][17] = new Space("port", 9, 17);
            game_board[9][1] = new Space("port", 9, 1);
            game_board[1][9] = new Space("port", 1, 9);
            game_board[17][9] = new Space("port", 17, 9);

        }

        public ref Space[][] getBoard() {
            return ref game_board;
        }

        public List<Space> poss_moves(Space space)
        {
            Tile tile = space.currentTile;
            List<Space> ans = new List<Space>();
            int speed = tile.mobility;
            // Ask: what is the point of posx and posy?
            int posx = space.j;
            int posy = space.i;
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

        public bool harmony(Tile t1, Tile t2) {
            if (t1.owner!=t2.owner) {
                return false;
            }
            if (t1.mobility == t2.mobility) {
                return false;
            } else {

                if (t1.mobility == 5) {

                    if ((t2.mobility==3 && t2.color!=t1.color) || (t2.mobility == 4 && t2.color == t1.color)) {
                        return true;
                    }

                } else if (t1.mobility == 4) {

                    if (t1.color==t2.color) {
                        return true;
                    }

                } else if (t1.mobility==3) {
                    if ((t2.mobility == 5 && t2.color != t1.color) || (t2.mobility == 4 && t2.color == t1.color)) {
                        return true;
                    }
                }
            }
            return false;
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

        public void move_tile(int i, int j, int di, int dj)
        {
            place_tile(di, dj, game_board[i][j].currentTile);
            game_board[i][j].emptyUp();

        }
        //TODOS kid of necessary for the full UI and winn condition function
        // builds the appropriate harmonies
        // if harmonies from different players overlap, their owner value is set to 2
        // otherwise, the owner value of the spaces in the harmony are set to that of the appropriate player
        public void build_harmonies(Space start) {
            int y = start.i;
            int x = start.j;

            // Checks up the y-axis
            for (int i = 0; i + y <= 17; i++)
            {
                Space s1 = game_board[y + i][x];
                if (!s1.isEmpty()){
                    // return to start tile while building the harmony
                    if (harmony(start.currentTile,s1.currentTile)) {
                        for (int k=0; i-k>=0;i++) {
                            if (game_board[y + i - k][x].owner == 2)
                            {
                                continue;
                            } // intended to set owner value to 2 if this space is already a part of a different harmony
                            else if (game_board[y + i - k][x].owner == (start.owner * -1))
                            {
                                game_board[y + i - k][x].owner = 2;
                            }
                            else {
                                game_board[y + i - k][x].owner = start.owner;
                            }
                        }
                    }
                    break;
                }
                else continue;
            }

            // Checks down the y-axis
            for (int i = 0; i - y >= 1; i++)
            {
                Space s1 = game_board[y - i][x];
                if (!s1.isEmpty())
                {
                    // return to start tile while building the harmony
                    if (harmony(start.currentTile, s1.currentTile))
                    {
                        for (int k = 0; i - k >= 0; i++)
                        {
                            if (game_board[(y - i) + k][x].owner == 2)
                            {
                                continue;
                            } // intended to set owner value to 2 if this space is already a part of a different player's harmony
                            else if (game_board[(y - i) + k][x].owner == (start.owner * -1))
                            {
                                game_board[(y - i) + k][x].owner = 2;
                            }
                            else
                            {
                                game_board[(y - i) + k][x].owner = start.owner;
                            }
                        }
                    }
                    break;
                }
                else continue;
            }

            // Checks down the x-axis
            for (int i = 0; i - x >= 1; i++)
            {
                Space s1 = game_board[y][x-1];
                if (!s1.isEmpty())
                {
                    // return to start tile while building the harmony
                    if (harmony(start.currentTile, s1.currentTile))
                    {
                        for (int k = 0; i - k >= 0; i++)
                        {
                            if (game_board[y][(x-i)+k].owner == 2)
                            {
                                continue;
                            } // intended to set owner value to 2 if this space is already a part of a different player's harmony
                            else if (game_board[y][(x - i) + k].owner == (start.owner * -1))
                            {
                                game_board[y][(x - i) + k].owner = 2;
                            }
                            else
                            {
                                game_board[y][(x - i) + k].owner = start.owner;
                            }
                        }
                    }
                    break;
                }
                
                else continue;
            }

            // Checks up the x-axis
            for (int i = 0; i + x <= 17; i++)
            {
                Space s1 = game_board[y][x - 1];
                if (!s1.isEmpty())
                {
                    // return to start tile while building the harmony
                    if (harmony(start.currentTile, s1.currentTile))
                    {
                        for (int k = 0; i - k >= 0; i++)
                        {
                            if (game_board[y][(x + i) - k].owner == 2)
                            {
                                continue;
                            } // intended to set owner value to 2 if this space is already a part of a different player's harmony
                            else if (game_board[y][(x + i) - k].owner == (start.owner * -1))
                            {
                                game_board[y][(x + i) - k].owner = 2;
                            }
                            else
                            {
                                game_board[y][(x + i) - k].owner = start.owner;
                            }
                        }
                    }
                    break;
                }
                else continue;
            }
        }


        

        public void remove_all_harmonies() {
            for (int i=0; i<19;i++) {
                for (int k=0; k<19;k++) {
                    if (game_board[i][k].isEmpty()) {
                        game_board[i][k].owner = 0;
                    }
                }
            }

        }

        public void build_all_harmonies() {
            foreach (Space sp in occupied) {
                this.build_harmonies(game_board[sp.i][sp.j]);
            }
        }

        public Board copy()
        {
            Board newB = new Board();
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    Space oldS = this.game_board[i][j];
                    Space newS = new Space(oldS.type, oldS.i, oldS.j);

                    Tile oldT = oldS.currentTile;
                    Tile newT = new Tile(oldT.mobility, oldT.owner, oldT.color, oldT.getID());
                    
                    newS.currentTile = newT;

                    newB.game_board[i][j] = newS;
                }
            }
            return newB;
        }

        public void print()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (game_board[i][j].isEmpty()) {
                        if (game_board[i][j].isNull())
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("N ");
                        }
                        else
                        {
                            if (game_board[i][j].type == RED)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("0 ");
                            }
                            if (game_board[i][j].type == WHITE)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("0 ");
                            }
                            if (game_board[i][j].type == NEUT)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("0 ");
                            }
                            if (game_board[i][j].type == PORT)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("P ");
                            }
                        }
                    }
                    else
                    {
                        if (game_board[i][j].owner == 1) Console.ForegroundColor = ConsoleColor.Blue;
                        else if (game_board[i][j].owner == -1) Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(game_board[i][j].pieceVal() + " ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public bool win_condition(int player_val)
        {

            bool[,] arry = new bool[19, 19];

            for (int i = 1; i <= 17; i++)
            {
                for (int f = 1; f <= 17; f++)
                {
                    arry[i, f] = false; ;
                }
            }
            return this.win_condition_helper(player_val, arry, 9, 9);

        }

        // a recursive function that essentially fills the board to check for any "leaks" that would indicate that the player has not won
        public bool win_condition_helper(int player_val, bool[,] visited, int y, int x)
        {
            bool north = true;
            bool south = true;
            bool east = true;
            bool west = true;

            //checks self aka basecase

            if (game_board[y][x] == null)
            {
                return false;
            }
            else if (game_board[y][x].owner == player_val || game_board[y][x].owner==2)
            {
                visited[y, x] = true;
                return true;
            }
            else {
                visited[y, x] = true;
            }

            //checks the north direction
            if (y - 1 >= 0 && !visited[y - 1, x])
            {
                north = this.win_condition_helper(player_val, visited, y - 1, x);
            }
            //checks the south direction
            if (y + 1 <= 18 && !visited[y + 1, x])
            {
                south = this.win_condition_helper(player_val, visited, y + 1, x);
            }
            //checks the east direction
            if (x + 1 <= 18 && !visited[y, x + 1])
            {
                east = this.win_condition_helper(player_val, visited, y, x + 1);
            }
            //checks the west direction
            if (x - 1 >= 0 && !visited[y, x - 1])
            {
                west = this.win_condition_helper(player_val, visited, y, x - 1);
            }

            return north && south && east && west;


        }

    }

}