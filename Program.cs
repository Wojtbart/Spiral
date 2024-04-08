namespace Spirala
{
    class Program
    {
        public static void Main(string[] args)
        {
            int v = 5;
            int[,] myArray = new int[v, v];
            //zrob_spirale(v,myArray);

            GenerateSpiral(5);
        }

        private static void zrob_spiral(int v, int[,] myArray)
        {
            
            if (v % 2 == 0)  throw new Exception("Podano liczbę parzystą!");
            if (v == 1) Console.WriteLine(1);
            else
            {
                

                for (int i = 0; i < myArray.GetLength(0); i++)
                {
                   for (int j = 0; j < myArray.GetLength(1); j++)
                   {
                        myArray[0,i] = 1;
                        myArray[j,v-1] = 1;
                        myArray[v - 1, i] = 1;
                        myArray[j, 0] = 1;
                        //myArray[1, 0] = 0;

                    }
                }

                zrob_spiral(v - 2,myArray);
            }
            //WYPISYWANIE
            Console.WriteLine("2D Array filled with '#':");
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.Write(myArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] GenerateSpiral(int n)
        {
            int[,] spiral = new int[n, n];
            FillSpiral(spiral, 0, 0, n - 1, n - 1, 1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (spiral[i, j] == '\0')
                        Console.Write(" ");
                    else
                        Console.Write(spiral[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return spiral;
        }

        static void FillSpiral(int[,] spiral, int top, int left, int bottom, int right, int value)
        {
            if (top > bottom || left > right)
                return;

            for (int i = left; i <= right; i++)
                spiral[top, i] = value;
                value++;

            for (int i = top + 1; i <= bottom; i++)
                spiral[i, right] = value;
                value++;

            if (top != bottom)
            {
                for (int i = right - 1; i >= left; i--)
                    spiral[bottom, i] = value;
                    value++;
            }

            if (left != right)
            {
                for (int i = bottom - 1; i > top; i--)
                    spiral[i, left] = value;
                    value++;
            }

            FillSpiral(spiral, top + 1, left + 1, bottom - 1, right - 1, value);
        
       
            
           // return spiral;
        }

            
        
    }
}
