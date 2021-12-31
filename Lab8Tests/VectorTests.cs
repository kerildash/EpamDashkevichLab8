using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8;
using NUnit.Framework;

namespace Lab8Tests
{
    class VectorTests
    {
        Vector v1 = new Vector(new double[] { 1, 2, 3 });
        Vector v2 = new Vector(new double[] { 1, 1, 1 });
        Vector v3 = new Vector(new double[] { 1, 1 });
        [Test]
        public void Vector_By_Vector_Multiplication_Returns_Correct_Scalar()
        {
            double result = v1 * v2;
            double equal = 6;
            Assert.AreEqual(equal, result);
        }
        [Test]
        public void Multiplication_Of_Vectors_Of_Different_Dimensions_Throws()
        {
            Assert.Throws<ArgumentException>(() => (v1 * v3).GetType());
        }
        [Test]
        public void Equals_Of_Same_Vectors_Returns_True()
        {
            Vector same = new Vector(new double[] { 1, 2, 3 });
            bool isEqual = v1.Equals(same);
            Assert.AreEqual(true, isEqual);
        }
        [Test]
        public void Equals_Of_Different_Vectors_Returns_false()
        {
            bool isEqual = v1.Equals(v3);
            Assert.AreEqual(false, isEqual);
        }

    }
}
