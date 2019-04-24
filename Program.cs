using System;

namespace Pai_Sho
{

    class Program
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

        private int harmonies(Space[][] arr)
        {
            int sum = 0;
            for (int j = 0; j < 19; j++)
            {
                for (int i = 0; i < 19; i++)
                {
                    if (!arr[i][j].isEmpty())
                    {
                        // Check for harmonies
                        ;
                    }
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            ;
        }
    }
}
