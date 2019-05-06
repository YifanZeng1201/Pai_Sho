using System;
using System.Collections;
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
            if (depth == 3)
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
        public Treenode<int> gameTree()
        {
            Tree<int> gameTree = new Tree<int>(0);
            return gameTree.Root;
        }
    }
}
