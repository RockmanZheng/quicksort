using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quicksort_non_recursive_test
{
    class Program
    {
        /// <summary>
        /// 分割函数，将数组分割成 p 左边比 pivot 小，右边比 pivot 大
        /// </summary>
        /// <param name="A">数组</param>
        /// <param name="lo">要排序的数组段起始下标</param>
        /// <param name="hi">要排序的数组段终止下标</param>
        /// <returns>返回 pivot 的下标 p</returns>
        static int partition(int[] A, int lo, int hi)
        {
            int i = lo - 1;
            int j = hi + 1;
            int pivot = A[lo];
            while (true)
            {
                do
                {
                    i++;
                } while (A[i] < pivot);
                do
                {
                    j--;
                } while (A[j] > pivot);
                if (i >= j)
                {
                    return j;
                }
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
        }

        static void quicksort(int[] A)
        {
            //int[] newA = new int[A.Length];
            //Array.Copy(A, newA, A.Length);
            Stack<int> lo = new Stack<int>();
            Stack<int> hi = new Stack<int>();
            lo.Push(0);
            hi.Push(A.Length - 1);
            while (lo.Count > 0 && hi.Count > 0)
            {
                int templo = lo.Pop();
                int temphi = hi.Pop();
                // 如果 lo 下标已经到达甚至超过 hi 下标，说明这组已经不用排序了
                if (templo >= temphi)
                {
                    continue;
                }
                int p = partition(A, templo, temphi);
                lo.Push(templo);
                hi.Push(p);
                lo.Push(p + 1);
                hi.Push(temphi);
            }
            //return newA;
        }

        static void foo(int[] A)
        {
            int temp = A[0];
            A[0] = A[1];
            A[1] = temp;
        }

        static void Main(string[] args)
        {
            //int[] A = new int[2] { 1, 2 };
            //foo(A);
            //Console.WriteLine(A[0]);
            //Console.WriteLine(A[1]);
            //Console.ReadKey();

            int[] A = new int[5] { 3, 5, 1, 2, 4 };
            quicksort(A);
            for(int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i]);
            }
            Console.ReadKey();
        }
    }
}
