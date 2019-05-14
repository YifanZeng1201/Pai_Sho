/* Author: Yifan Zeng
 * Updated 5.6.2019
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paisho
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
            List<Tile> currentTiles = new List<Tile>();
            List<Tile> oppTiles = new List<Tile>();
            foreach (Space s in PossTile)
            {
                Tile t = s.getTile();
                if (t.owner == -1 && t.isFlower())
                {
                    currentTiles.Add(t);
                }
                if (t.owner == 1 && t.isFlower())
                {
                    oppTiles.Add(t);
                }
            }
            foreach (Tile t1 in currentTiles)
            {
                //Board cpy= board.copy
                List<Space> moves = cpy.poss_moves(t1);
                foreach (Space m in moves)
                {

                    m.setTile(t1);
                    int value = Eval.evaluation(cpy);
                    Treenode<int> child1 = new Treenode<int>(value);
                    gameTree.Root.AddChild(child1);
                    foreach (Tile t2 in oppTiles)
                    {
                        // Board cpy2= cpy.copy
                        List<Space> oppMoves = cpy2.poss_move(t2);
                        foreach (Space o in oppMoves)
                        {
                            o.setTile(t2);
                            int oppValue = Eval.evaluation(cpy2);
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
