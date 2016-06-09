using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[,] aa = new int[2, 2] { { 11, 2}, { 14, 5 } };
            int[,] aa1 = new int[2, 2] { { 31, 5 }, { 16, 5 } };
            int[,] aa2 = new int[2, 2] { { 25, 2 }, { 1, 2 } };
            martix m1 = new martix(2, 2,aa);
            martix m2 = new martix(2, 2, aa1);
            martix m3 = new martix(2, 2, aa2);
            m1.PrintMartix();
            Console.WriteLine();
            m2.PrintMartix();
            Console.WriteLine("============================");
            m3.PrintMartix();
            Console.WriteLine("============================");


            // (m1 * m2).PrintMartix();
            (martix.Pow(m3, 2)).PrintMartix();
            Console.ReadKey();
        }
    }
}
