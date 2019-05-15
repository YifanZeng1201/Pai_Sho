/* Author: Yifan Zeng
 * Updated 5.6.2019
 */
//Updated 5/14 : made non-intrusive changes for the sake of compatability

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AI
{

    static int MAX = 10000;
    static int MIN = -10000;

    static public int Minimax(int depth, Treenode<int> root, bool isMaxPlayer, int alpha, int beta)
    {
        if (depth == 2)
        {
            return root.Value;
        }

        if (isMaxPlayer)
        {
            int best = MIN;
            for (int i = 0; i < root.ChildrenCount; i++)
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
            for (int i = 0; i < root.ChildrenCount; i++)
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


    static public Treenode<int> buildGameTree(Board board)
    {
        int init = Eval.evaluation(board.game_board);
        Tree<int> gameTree = new Tree<int>(init);
        List<Space> currentTiles = new List<Space>();
        List<Space> oppTiles = new List<Space>();

        foreach (Space s in board.occupied)
        {
            if (s.getTile().owner == -1 && s.getTile().isFlower())
            {
                currentTiles.Add(s);
            }
            if (s.getTile().owner == 1 && s.getTile().isFlower())
            {
                oppTiles.Add(s);
            }
        }
        foreach (Tile t1 in board.ai)
        {
            if (board.game_board[9][17].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(9, 17, t1);
                int value = Eval.evaluation(cpy.game_board);
                Treenode<int> child1 = new Treenode<int>(value);
                gameTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
            }
            if (board.game_board[9][1].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(9, 1, t1);
                int value = Eval.evaluation(cpy.game_board);
                Treenode<int> child1 = new Treenode<int>(value);
                gameTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
            }
            if (board.game_board[1][9].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(1, 9, t1);
                int value = Eval.evaluation(cpy.game_board);
                Treenode<int> child1 = new Treenode<int>(value);
                gameTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }

            }
            if (board.game_board[17][9].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(17, 9, t1);
                int value = Eval.evaluation(cpy.game_board);
                Treenode<int> child1 = new Treenode<int>(value);
                gameTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
            }

        }
        foreach (Space s1 in currentTiles)
        {

            List<Space> moves = board.poss_moves(s1);
            foreach (Space m in moves)
            {
                Board cpy = board.copy2();
                cpy.move_tile(s1.i, s1.j, m.i, m.j);
                int value = Eval.evaluation(cpy.game_board);
                Treenode<int> child1 = new Treenode<int>(value);
                gameTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        int oppValue = Eval.evaluation(cpy2.game_board);
                        Treenode<int> child2 = new Treenode<int>(oppValue);
                        child1.AddChild(child2);
                    }
                }
            }
        }
        return gameTree.Root;
    }

    static public Treenode<Board> buildBoardTree(Board board)
    {
        Tree<Board> boardTree = new Tree<Board>(board);
        List<Space> currentTiles = new List<Space>();
        List<Space> oppTiles = new List<Space>();
        foreach (Space s in board.occupied)
        {
            if (s.getTile().owner == -1 && s.getTile().isFlower())
            {
                currentTiles.Add(s);
            }
            if (s.getTile().owner == 1 && s.getTile().isFlower())
            {
                oppTiles.Add(s);
            }
        }

        foreach (Tile t1 in board.ai)
        {

            if (board.game_board[9][17].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(9, 17, t1);
                cpy.ai.Remove(t1);
                Treenode<Board> child1 = new Treenode<Board>(cpy);
                boardTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {

                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
            }
            if (board.game_board[9][1].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(9, 1, t1);
                cpy.ai.Remove(t1);
                Treenode<Board> child1 = new Treenode<Board>(cpy);
                boardTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {
                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
            }
            if (board.game_board[1][9].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(1, 9, t1);
                cpy.ai.Remove(t1);
                Treenode<Board> child1 = new Treenode<Board>(cpy);
                boardTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {
                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }

            }
            if (board.game_board[17][9].isEmpty())
            {
                Board cpy = board.copy2();
                cpy.place_tile(17, 9, t1);
                cpy.ai.Remove(t1);
                Treenode<Board> child1 = new Treenode<Board>(cpy);
                boardTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {
                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }

                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
            }

        }
        foreach (Space s1 in currentTiles)
        {

            List<Space> moves = board.poss_moves(s1);
            foreach (Space m in moves)
            {
                Board cpy = board.copy2();
                cpy.move_tile(s1.i, s1.j, m.i, m.j);
                Treenode<Board> child1 = new Treenode<Board>(cpy);
                boardTree.Root.AddChild(child1);
                foreach (Tile t2 in board.player)
                {
                    if (cpy.game_board[9][17].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 17, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[9][1].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(9, 1, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[1][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(1, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                    if (cpy.game_board[17][9].isEmpty())
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.place_tile(17, 9, t2);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }

                }
                foreach (Space s2 in oppTiles)
                {

                    List<Space> oppMoves = cpy.poss_moves(s2);
                    foreach (Space o in oppMoves)
                    {
                        Board cpy2 = cpy.copy2();
                        cpy2.move_tile(s2.i, s2.j, o.i, o.j);
                        Treenode<Board> child2 = new Treenode<Board>(cpy2);
                        child1.AddChild(child2);
                    }
                }
            }
        }
        return boardTree.Root;
    }

    static public Board makeMove(int value, Treenode<int> gameTree, Treenode<Board> boardTree)
    {
        int index = -1;
        for (int i = 0; i < gameTree.ChildrenCount; i++)
        {
            Treenode<int> choice = gameTree.GetChild(i);
            for (int j = 0; j < choice.ChildrenCount; j++)
            {
                int result = choice.GetChild(j).Value;
                if (result == value)
                {
                    index = i;
                    break;
                }
            }
            if (index == i)
            {
                break;
            }
        }
        Board move = boardTree.GetChild(index).Value;
        return move;
    }

}