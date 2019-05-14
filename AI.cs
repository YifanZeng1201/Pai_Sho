/* Author: Yifan Zeng
 * Updated 5.6.2019
 */
 //Updated 5/14 : made non-intrusive changes for the sake of compatability
using Pai_Sho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pai_sho
{
    public class AI
    {

        static int MAX = 10000;
        static int MIN = -10000;

        public int Minimax(int depth, Treenode<int> root, bool isMaxPlayer, int alpha, int beta)
        {
            if (depth == 2)
            {
                return root.Value;
            }

            if (isMaxPlayer)
            {
                int best = MIN;
                for (int i=0; i<root.ChildrenCount; i++)
                {
                    int val = Minimax(depth + 1, root.GetChild(i), false, alpha, beta);
                    best = Math.Max(best, val);
                    alpha = Math.Max(best, alpha);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return best;
            }
            else
            {
                int best = MAX;
                for (int i=0; i<root.ChildrenCount; i++)
                {
                    int val = Minimax(depth + 1, root.GetChild(i), true, alpha, beta);
                    best = Math.Min(best, val);
                    beta = Math.Min(best, beta);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return best;
            }
        }

        // development in progress
        public Treenode<int> buildGameTree(Board board)
        {
            Tree<int> gameTree = new Tree<int>(0);
            List<Space> PossTile = board.occupied;
            List<Space> currentTiles = new List<Space>();
            List<Space> oppTiles = new List<Space>();

            foreach (Space s in PossTile)
            {
                //Tile t = s.getTile();
                if (s.getTile().owner == -1 && s.getTile().isFlower())
                {
                    currentTiles.Add(s);
                }
                if (s.getTile().owner == 1 && s.getTile().isFlower())
                {
                    oppTiles.Add(s);
                }
            }
            foreach (Space s1 in currentTiles)
            {
                Board cpy = board.copy();
                List<Space> moves = cpy.poss_moves(s1);
                foreach (Space m in moves)
                {

                    board.move_tile(s1.i,s1.j,m.i,m.j);  
                    int value = Eval.evaluation(cpy.getBoard());
                    Treenode<int> child1 = new Treenode<int>(value);
                    gameTree.Root.AddChild(child1);
                    foreach (Space s2 in oppTiles)
                    {
                        Board cpy2 = cpy.copy();
                        List<Space> oppMoves = cpy2.poss_moves(s2);
                        foreach (Space o in oppMoves)
                        {
                            board.move_tile(m.i, m.j, o.i, o.j);
                            int oppValue = Eval.evaluation(cpy2.getBoard());
                            Treenode<int> child2 = new Treenode<int>(oppValue);
                            child1.AddChild(child2);
                        }
                    }
                }
            }
            return gameTree.Root;
        }
    }
}
