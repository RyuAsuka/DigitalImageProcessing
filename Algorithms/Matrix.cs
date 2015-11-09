using System;

namespace DIP.Algorithms
{
    /// <summary>
    /// 矩阵类
    /// </summary>
    public class Matrix
    {
        int[,] mat;
        int rows;
        int columns;

        /// <summary>
        /// 根据指定的行数和列数构造矩阵
        /// </summary>
        /// <param name="rows">矩阵的行数</param>
        /// <param name="columns">矩阵的列数</param>
        public Matrix(int rows, int columns)
        {
            mat = new int[rows, columns];
            this.rows = rows;
            this.columns = columns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    mat[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 获得矩阵的行数
        /// </summary>
        public int Rows
        {
            get { return rows; }
        }

        /// <summary>
        /// 获得矩阵的列数
        /// </summary>
        public int Columns
        {
            get { return columns; }
        }

        /// <summary>
        /// 获得矩阵的某一行的全部元素
        /// </summary>
        /// <param name="rowNum">行数</param>
        /// <returns>该行的全部元素组成的数组</returns>
        public int[] GetRow(int rowNum)
        {
            int[] retVal = new int[columns];
            for (int i = 0; i < columns; i++)
            {
                retVal[i] = mat[rowNum, i];
            }

            return retVal;
        }

        /// <summary>
        /// 获得矩阵某一列的全部元素
        /// </summary>
        /// <param name="colNum">列数</param>
        /// <returns>该列的全部元素组成的数组</returns>
        public int[] GetColumn(int colNum)
        {
            int[] retVal = new int[rows];
            for (int j = 0; j < rows; j++)
            {
                retVal[j] = mat[j, colNum];
            }

            return retVal;
        }

        /// <summary>
        /// 获得矩阵在相应位置的值
        /// </summary>
        /// <param name="x">该值所在的横坐标</param>
        /// <param name="y">该值所在的纵坐标</param>
        /// <returns>该点的矩阵值</returns>
        [Obsolete]
        public int GetValue(int x, int y)
        {
            return mat[x, y];
        }

        /// <summary>
        /// 设置矩阵在相应位置的值
        /// </summary>
        /// <param name="x">该值所在的横坐标</param>
        /// <param name="y">该值所在的纵坐标</param>
        /// <param name="value">要设置的矩阵值。</param>
        [Obsolete]
        public void SetValue(int x, int y, int value)
        {
            mat[x, y] = value;
        }

        /// <summary>
        /// 获得或设置矩阵在相应位置的值
        /// </summary>
        /// <param name="x">该值所在的横坐标</param>
        /// <param name="y">该值所在的纵坐标</param>
        /// <returns>该点的矩阵值</returns>
        public int this[int x, int y]
        {
            get
            {
                return mat[x, y];
            }
            set
            {
                mat[x, y] = value;
            }
        }
    }
}
