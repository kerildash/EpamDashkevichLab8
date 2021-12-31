using NUnit.Framework;
using Lab8;
using System;

namespace Lab8Tests
{
    public class MatrixTests
    {
        Matrix ma;
        Matrix mb;
        Matrix mc;
        Matrix md;

        [SetUp]
        public void Setup()
        {
            double[,] a =
            {
                {1, 2 },
                {3, 4 }
            };
            ma = new Matrix(a);
            double[,] b =
            {
                {1, 1 },
                {1, 1 }
            };
            mb = new Matrix(b);
            double[,] c =
            {
                {0, 0, 0 },
                {1, 1, 0 }
            };
            mc = new Matrix(c);
            double[,] d =
            {
                {0, 0, 0 },
                {1, 1, 0 },
                {1, 1, 0 }
            };
            md = new Matrix(d);
        }

        [Test]
        public void Adding_Of_Matrices_Returns_Correct_Matrix()
        {
            Matrix equal = new Matrix(new double[,]
            {
                {2, 3 },
                {4, 5 }
            });
            Matrix result = ma + mb;
            Assert.AreEqual(equal, result);
        }
        [Test]
        public void Subtracting_Of_Matrices_Returns_Correct_Matrix()
        {
            Matrix equal = new Matrix(new double[,]
            {
                {0, 1 },
                {2, 3 }
            });
            Matrix result = ma - mb;
            Assert.AreEqual(equal, result);
        }
        [Test]
        public void Multiplication_Of_Matrices_Returns_Correct_Matrix()
        {

            Matrix equal = new Matrix(new double[,]
            {
                {1, 1, 0 },
                {1, 1, 0 }
            });
            Matrix result = mb * mc;
            Assert.AreEqual(equal, result);
        }
        [Test]
        public void Addition_Of_Incorrect_Matrices_Throws()
        {
            Assert.Throws<ArgumentException>(() => (ma + md).GetType());
        }
        [Test]
        public void Subtraction_Of_Incorrect_Matrices_Throws()
        {
            Assert.Throws<ArgumentException>(() => (ma - md).GetType());
        }
        [Test]
        public void Multiplication_Of_Incorrect_Matrices_Throws()
        {
            Assert.Throws<ArgumentException>(() => (ma * md).GetType());
        }
        //==================
        [Test]
        public void Equals_Of_Equal_Matrices_Returns_True()
        {
            double[,] array =
            {
                {1, 2 },
                {3, 4 }
            };
            Matrix equal = new Matrix(array);
            Assert.AreEqual(true, ma.Equals(equal));
        }
        [Test]
        public void Equals_Of_Not_Equal_Matrices_Returns_False()
        {
            Assert.AreEqual(false, ma.Equals(mb));
        }
    }
}