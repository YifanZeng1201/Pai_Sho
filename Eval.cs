using System;

namespace Pai_Sho
{

    class Eval
    {
        private int open_ports(Space[][] arr)
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

        private int piece_value(Space[][] arr)
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

        private int count_harmonies(Space[][] arr)
        {
            int sum = 0;
            for (int j = 0; j < 19; j++)
            {
                for (int i = 0; i < 19; i++)
                {
                    if (!arr[i][j].isEmpty())
                    {
                        for (int k = 0; k < 19; k++)
                        {
                            if (!arr[i][k].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[i][k].currentTile)) sum++;
                            }
                            if (!arr[k][j].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[k][j].currentTile)) sum++;
                            }
                        }
                    }
                }
            }
            return sum/2;
        }
        static void Main(string[] args)
        {
            ;
        }
    }
}
