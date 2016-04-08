using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainFramework.Tests.Classes;

namespace DomainFramework.Tests
{
    [TestClass]
    public class ValueObjectTest
    {
        //Symmetry: For two references, a and b, a.equals(b) if and only if b.equals(a)
        //Reflexivity: For all non-null references, a.equals(a)
        //Transitivity: If a.equals(b) and b.equals(c), then a.equals(c)

        // https://msdn.microsoft.com/en-CA/library/ms173147(v=vs.80).aspx
        //x.Equals(x) returns true.
        //x.Equals(y) returns the same value as y.Equals(x).
        //if (x.Equals(y) && y.Equals(z)) returns true, then x.Equals(z) returns true.
        //Successive invocations of x.Equals(y) return the same value as long as the objects referenced by x and y are not modified.
        //x.Equals(null) returns false.
        
        [TestMethod]
        public void EqualityOperator_BothNulls_TrueReturned()
        {
            FakeValueObject left = null;
            FakeValueObject right = null;

            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void EqualityOperator_LeftNull_FalseReturned()
        {
            FakeValueObject left = null;
            var right = new FakeValueObject("A");

            Assert.IsFalse(left == right);
        }

        [TestMethod]
        public void EqualityOperator_RightNull_FalseReturned()
        {
            var left = new FakeValueObject("A");
            FakeValueObject right = null;

            Assert.IsFalse(left == right);
        }

        [TestMethod]
        public void EqualityOperator_NotEqual_FalseReturned()
        {
            var left = new FakeValueObject("B");
            var right = new FakeValueObject("A");

            Assert.IsFalse(left == right);
        }

        [TestMethod]
        public void EqualityOperator_Equal_TrueReturned()
        {
            var left = new FakeValueObject("A");
            var right = new FakeValueObject("A");

            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void InequalityOperator_BothNulls_FalseReturned()
        {
            FakeValueObject left = null;
            FakeValueObject right = null;
            Assert.IsFalse(left != right);
        }

        [TestMethod]
        public void InequalityOperator_LeftNull_TrueReturned()
        {
            FakeValueObject left = null;
            var right = new FakeValueObject("A");
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void InequalityOperator_RightNull_TrueReturned()
        {
            var left = new FakeValueObject("A");
            FakeValueObject right = null;
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void InequalityOperator_NotEqual_TrueReturned()
        {
            var left = new FakeValueObject("B");
            var right = new FakeValueObject("A");
            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void InequalityOperator_Equal_FalseReturned()
        {
            var left = new FakeValueObject("A");
            var right = new FakeValueObject("A");
            Assert.IsFalse(left != right);
        }

        [TestMethod]
        public void GetHashCode_SingleValue_ThisValueHashCodeReturned()
        {
            string singleValue = "abcd";
            var obj = new FakeValueObject(singleValue);

            Assert.AreEqual(singleValue.GetHashCode(), obj.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_NullValue_ZeroReturned()
        {
            var obj = new FakeValueObject(new object[] { null });

            Assert.AreEqual(0, obj.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_TwoValues_XorOfHashCodesReturned()
        {
            string firstValue = "abcd";
            int secodValue = 15;
            FakeValueObject obj = new FakeValueObject(firstValue, secodValue);

            Assert.AreEqual(firstValue.GetHashCode() ^ secodValue.GetHashCode(), obj.GetHashCode());
        }
    }
}
