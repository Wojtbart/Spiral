namespace Spiral
{
    class Program
    {
        static int[,] GenerateSpiral(int n)
        {
            if (n % 2 == 0 || n<=0) 
                throw new Exception("Podano niewłaściwą liczbę! To zabronione! Poprawne liczby to dodatnie liczby nieparzyste!");

            int[,] spiral = new int[n, n];
            int counter = 0;

            FillSpiral(spiral, 0, 0, n - 1, n - 1, 1, counter);

            //WYPISYWANIE WYNIKU
            Console.WriteLine("Rysuję spiralę!\n");
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

        static void FillSpiral(int[,] spiral, int top, int left, int bottom, int right, int value, int counter)
        {
            if (counter % 2 == 1) value = 0;
            else value = 1;

            if (top > bottom || left > right)
                return;

            for (int i = left; i <= right; i++)
            {
                spiral[top, i] = value;
            }

            for (int i = top + 1; i <= bottom; i++)
            {
                spiral[i, right] = value;
            }

            if (top != bottom)
            {
                for (int i = right - 1; i >= left; i--)
                {
                    spiral[bottom, i] = value;
                }

            }

            if (left != right)
            {
                for (int i = bottom - 1; i > top; i--)
                {
                    if (i == 1) continue;
                    if (i % 2 ==1 && left % 2 == 0 && i - left == 1 ) continue;
                    if(i == top + 1) value = 1;
                    
                    spiral[i, left] = value;
                }

            }
            counter++;

            FillSpiral(spiral, top + 1, left + 1, bottom - 1, right - 1, value, counter);
        }

        public static void Main(string[] args)
        {
            int v = 9;
            GenerateSpiral(v);
        }
    }
}