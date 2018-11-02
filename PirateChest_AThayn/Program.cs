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

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter test input: ");

            //Get input dimensions
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());

            pond = new int[m, n];

            //Get pond depths
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    pond[i, j] = Convert.ToInt32(Console.ReadLine());

            int result = MaxSizeOfPirateChest(a, b, m, n);
            Console.Write(result);
        }
            

        public static int MaxSizeOfPirateChest(int a, int b, int m, int n)
        {
            int maxDepth = pond.Cast<int>().Max();

            int volumeOfPond = GetVolumeOfPond(m,n);
            
            int maxSize = 0;

            //Check each layer for max size of chest starting at bottom of pond
            for(int i = maxDepth; i > 0; i--)
            {
                int[,] currentLayer = GetLayerValues(i, m, n);
                int maxWidth = 0;
                int maxLength =0;
            }
            
            return maxSize;
        }

        private static int GetVolumeOfPond(int m, int n)
        {
            int volume = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    volume += pond[i, j];
            return volume;
        }

        public static int[,] GetLayerValues(int depth, int m, int n)
        {
            int[,] layer = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    layer[i, j] = pond[i, j] >= depth ? 0 : 1;
            return layer;
        }

        public int FindMaxSizeOfChestInLayer(int[,] layer, int m, int n)
        {
            int[] temp = new int[m];
            MaximumHistogram mh = new MaximumHistogram();
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
                    area = mh.maxHistogram(temp);
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }
            return maxArea;
        }
        
    }
}
