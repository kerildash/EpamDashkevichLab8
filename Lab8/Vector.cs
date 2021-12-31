using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Vector
    {
        private double[] _Entries;
        private int _Length;
        public int Length
        {
            get
            {
                return _Length;
            }
        }
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return _Entries[index];
            }
            set
            {
                if (index < 0 || index > Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _Entries[index] = value;
            }
        }

        public Vector(double[] v)
        {
            if (v.Length < 0)
            {
                throw new ArgumentException();
            }
            _Entries = v;
            _Length = v.Length;
        }

        public static double operator *(Vector a, Vector b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("vectors has not the same dimension");
            }
            double prod = 0;
            for (int i = 0; i < a.Length; i++)
            {
                prod += a[i] * b[i];
            }
            return prod;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Vector vector = (Vector)obj;
            if (vector.Length != this.Length)
            {
                return false;
            }
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != vector[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
