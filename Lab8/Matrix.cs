using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Matrix
    {
        private double[,] _Elements;
        private int _Rows;
        private int _Columns;
        public int Rows
        {
            get
            {
                return _Rows;
            }
            private set
            {
                _Rows = value;
            }
        }
        public int Columns
        {
            get
            {
                return _Columns;
            }
            private set
            {
                _Columns = value;
            }
        }
        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Columns)
                {
                    throw new IndexOutOfRangeException();
                }
                return _Elements[i, j];
            }
            private set
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Columns)
                {
                    throw new IndexOutOfRangeException();
                }
                _Elements[i, j] = value;
            }
        }
        //empty m x n
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _Elements = new double[rows, columns];
        }
        //matrix from 2d array
        public Matrix(double[,] elements)
        {
            _Elements = elements;
            Rows = elements.GetUpperBound(0) + 1;
            Columns = elements.GetUpperBound(1) + 1;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new ArgumentException("matrices must have the same dimensions");
            }
            var sum = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    sum[i, j] = a[i, j] + b[i, j];
                }
            }
            return sum;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new ArgumentException("matrices must have the same dimensions");
            }
            var difference = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    difference[i, j] = a[i, j] - b[i, j];
                }
            }
            return difference;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new ArgumentException("Multiplication of these matrices is not allowed");
            }
            var product = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    Vector va = a.GetRow(i);
                    Vector vb = b.GetColumn(j);
                     product[i, j] = va * vb;
                }
            }
            return product;
        }
       
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Matrix matrix = (Matrix)obj;
            if (Rows != matrix.Rows ||
                Columns != matrix.Columns)
            {
                return false;
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this[i,j] != matrix[i,j])
                    {
                        return false;
                    }
                }
            }
                return true;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !a.Equals(b);
        }
        private Vector GetRow(int rowIndex)
        {
            double[] row = new double[this.Columns];
            for(int j = 0; j < this.Columns; j++)
            {
                row[j] = this[rowIndex, j];
            }
            return new Vector(row);
        }
        private Vector GetColumn(int columnIndex)
        {
            double[] column = new double[this.Rows];
            for (int i = 0; i < this.Rows; i++)
            {
                column[i] = this[i, columnIndex];
            }
            return new Vector(column);
        }
        public override string ToString()
        {
            string matrixAsString = "";
            for(int i = 0; i < Rows; i++)
            {
                matrixAsString += "| ";
                for (int j = 0; j < Columns; j++)
                {
                    matrixAsString += $"{this[i, j]}\t";
                }
                matrixAsString += "|\n";
            }
            return matrixAsString;
        }
    }
}
