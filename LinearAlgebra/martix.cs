using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    public class martix
    {
        //定义行数
        private int row;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        //定义列数
        private int col;
        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        //定义矩阵元素，用一个二维数组
        private int[,] a;
        public int[,] A
        {
            get { return a; }
            set { a = value; }
        }

        //第一个构造函数,创建时赋值
        public martix(int row, int col, int[,] aa)
        {
            this.Row = row;
            this.Col = col;
            a = aa;
        }

        //第一个构造函数，创建时不赋值，但是创建后建议赋予0
        public martix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.A = new int[this.Row, this.Col];
        }

        /// <summary>
        /// 将整个矩阵的元素打印出来
        /// </summary>
        /// <param name="m">要打印的矩阵对象</param>
        public void PrintMartix()
        {
            for (int _row = 0; _row < Row; _row++)
            {
                for (int _col = 0; _col < Col; _col++)
                {
                    Console.Write(A[_row, _col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 返回当前对象的一个零矩阵
        /// </summary>
        /// <returns>修改当前对象，使之成为一个零矩阵</returns>
        public martix ReturnZeroMartix()
        {
            for (int i = 1; i < this.Row; i++)
            {
                for (int j = 1; j < this.Col; j++)
                {
                    this.A[i, j] = 0;
                }
            }
            return this;
        }

        /// <summary>
        /// 返回当前对象的一个单元矩阵 //行数与列数必须相等！
        /// </summary>
        /// <returns>修改当前对象，使之成为一个单元矩阵</returns>
        public martix ReturnUnitMartix()
        {
            if (this.Row != this.Col)
            {
                Console.WriteLine("The row must equal to the col");
            }
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    if (i == j)
                    {
                        this.A[i, j] = 1;
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 返回当前对象的一个转置矩阵
        /// </summary>
        /// <returns></returns>
        public martix ReturnTransposeMartix()
        {
            martix result = new martix(this.Col, this.Row);
            result.ReturnZeroMartix();
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    result.A[j, i] = this.A[i, j];
                }
            }
            return result;
        }

        //第一个重载+号运算符，使之计算两个矩阵加法
        public static martix operator +(martix m1, martix m2)
        {
            martix result = m1;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] += m2.A[i, j];
                }
            }
            return result;
        }
        //第二个重载+号运算符，使之计算矩阵和整数加法
        public static martix operator +(int m1, martix m2)
        {
            martix result = m2;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] +=m1;
                }
            }
            return result;
        }
        //第二个重载+号运算符，使之计算整数和整数加法
        public static martix operator +(martix m1, int m2)
        {
            martix result = m1;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] += m2;
                }
            }
            return result;
        }

        //重载-号晕算法，同+号
        public static martix operator -(martix m1, martix m2)
        {
            martix result = m1;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] -= m2.A[i, j];
                }
            }
            return result;
        }
        //same
        public static martix operator -(int m1, martix m2)
        {
            martix result = m2;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] -= m1;
                }
            }
            return result;
        }
        //same
        public static martix operator -(martix m1, int m2)
        {
            martix result = m1;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] -= m2;
                }
            }
            return result;
        }
        
        //重载*号晕算法，第一个矩阵的列必须与第二个矩阵的行相等才可以计算
        public static martix operator *(martix m1, martix m2)
        {
            if (m1.Col != m2.Row)
            {
                Console.WriteLine("Wrong");
            }
            martix result = new martix(m1.Row, m2.Col);
            result.ReturnZeroMartix();

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    int sum = 0;
                     for (int _j = 0; _j < m1.Col; _j++)
                        {
                            sum += m1.A[i, _j] * m2.A[_j,j];
                        }
                    
                    result.A[i, j] = sum;
                }
            }
            return result;
        }
        public static martix operator *(int m1, martix m2)
        {
           
            martix result = m2;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] *= m1;
                }
            }
            return result;
        }
        public static martix operator *(martix m1, int m2)
        {
            martix result = m1;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    result.A[i, j] -= m2;
                }
            }
            return result;
        }
        /// <summary>
        /// 矩阵的幂运算
        /// </summary>
        /// <param name="m1">第一个参数是一个矩阵</param>
        /// <param name="level">第二个参数是数量级</param>
        /// <returns></returns>
        public static martix Pow(martix m1, int level)
        {
            martix result = new martix(m1.Row, m1.Col);
            result.ReturnZeroMartix();
            result = result + 1;
            for (int i = 0; i < level; i++)
            {
                result *= m1;
            }
            return result;
        }

        


    }


}
