
namespace Spirala
{
    class Program
    {
        public static void Main(string[] args)
        {
            int v = 7;
            GenerateSpiral(v);
        }

        static int[,] GenerateSpiral(int n)
        {
            int[,] spiral = new int[n, n];
            int counter =0;
            FillSpiral(spiral, 0, 0, n - 1, n - 1, 1, counter);
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
            if (counter % 2 == 0) value = 1;
            else value = 0;
            if (top > bottom || left > right)
                return;

            for (int i = left; i <= right; i++)
                spiral[top, i] = value;
               // value++;

            for (int i = top + 1; i <= bottom; i++)
                spiral[i, right] = value;
               // value++;

            if (top != bottom)
            {
                for (int i = right - 1; i >= left; i--)
                    spiral[bottom, i] = value;
                   // value++;
            }

            if (left != right)
            {
                for (int i = bottom - 1; i > top; i--)
                {
                    if (i == top + 1) continue;
                    spiral[i, left] = value;
                    //value++;
                }
            }
            counter++;
            FillSpiral(spiral, top + 1, left + 1, bottom - 1, right - 1, value, counter);
        }
    }
}
