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
                            if (!arr[i][k].isEmpty())
                            {
                                if (arr[i][j].currentTile.inHarmony(arr[i][k].currentTile) && !blockedl) sum++;
                                blockedl = true;
                            }
                        }
                    }
                }
            }
            return sum/2;
        }

        private int count_junctions(Space[][] arr)
        {
            int sum = 0;
            return sum;
        }

        static void Main(string[] args)
        {
            ;
        }
    }
}
