using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIP.Algorithms;

namespace UnitTest
{
    [TestClass]
    public class ComplexTest
    {
        [TestMethod]
        public void AddTest()
        {
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(2, 2);

            Complex result = c1 + c2;
            Assert.AreEqual(new Complex(3, 3), result);
        }

        [TestMethod]
        public void SubTest()
        {
            Complex c1 = new Complex(3, 3);
            Complex c2 = new Complex(2, 1);

            Complex result = c1 - c2;
            Assert.AreEqual(new Complex(1, 2), result);
        }

        [TestMethod]
        public void MulTest1()
        {
            Complex c1 = new Complex(3, 3);
            Complex c2 = new Complex(2, 1);

            Complex result = c1 * c2;
            Assert.AreEqual(new Complex(3, 9), result);
        }

        [TestMethod]
        public void MulTest2()
        {
            Complex c1 = new Complex(0, 1);
            Complex c2 = new Complex(0, 1);

            Complex result = c1 * c2;
            Assert.AreEqual(new Complex(-1, 0), result);
        }

        [TestMethod]
        public void EqualTest()
        {
            Complex c1 = new Complex(3, 3);
            Complex c2 = new Complex(3, 3);

            bool result = c1 == c2;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotEqualTest1()
        {
            Complex c1 = new Complex(3, 3);
            Complex c2 = new Complex(1, 3);

            bool result = c1 != c2;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotEqualTest2()
        {
            Complex c1 = new Complex(3, 3);
            Complex c2 = new Complex(3, 1);

            bool result = c1 != c2;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotEqualTest3()
        {
            Complex c1 = new Complex(2, 1);
            Complex c2 = new Complex(1, 2);

            bool result = c1 != c2;
            Assert.AreEqual(true, result);
        }
    }
}
