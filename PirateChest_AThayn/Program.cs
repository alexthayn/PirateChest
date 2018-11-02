using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateChest_AThayn
{
    public class Program
    {
        public static int[,] pond;
        public static int a;
        public static int b;
        public static int m;
        public static int n;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter test input: ");

            //Get input dimensions
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());

            pond = new int[m, n];

            //Get pond depths
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    pond[i, j] = Convert.ToInt32(Console.ReadLine());

            int result = MaxSizeOfPirateChest();
            Console.Write(result);
            Console.ReadKey();
        }
            

        public static int MaxSizeOfPirateChest()
        {
            int maxDepth = pond.Cast<int>().Max();

            int volumeOfPond = GetVolumeOfPond();
            int volumeWithChest = volumeOfPond;
            int maxSize = 0;

            //Check each layer for max size of chest starting at bottom of pond
            for(int i = maxDepth; i > 0; i--)
            {
                int[,] currentLayer = GetLayerValues(i);
                int maxArea = FindMaxSizeOfChestInLayer(currentLayer);
                int chestVolume = maxArea;
                int chestHeight = 1;
                int waterHeight = 0 + chestVolume/(m*n);
                int topOfChest = -i + chestHeight;

                //Increase size of the chest until it can't fit underwater anymore
                do
                {
                    chestHeight++;
                    topOfChest = waterHeight - i + chestHeight;
                    waterHeight += waterHeight + chestVolume / (m * n);
                }
                while (topOfChest < waterHeight);
                maxSize = (chestHeight - 1) * maxArea;
            }
            
            return maxSize;
        }

        private static int GetVolumeOfPond()
        {
            int volume = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    volume += pond[i, j];
            return volume;
        }

        public static int[,] GetLayerValues(int depth)
        {
            int[,] layer = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    layer[i, j] = pond[i, j] >= depth ? 0 : 1;
            return layer;
        }

        public static int FindMaxSizeOfChestInLayer(int[,] layer)
        {
            int[] temp = new int[n];
            MaximumHistogram mh = new MaximumHistogram();
            int areaBounds = m * n;
            int maxArea = 0;
            int area = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (layer[i, j] == 0)
                    {
                        temp[j] = 0;
                    }
                    else
                    {
                        temp[j] += layer[i,j];
                    }
                    area = mh.maxHistogram(temp, a,b);
                    if (area > maxArea)
                    {
                        if (area > areaBounds)
                            maxArea = areaBounds;
                        maxArea = area;
                    }
                }
            }
            return maxArea;
        }
        
    }
}
