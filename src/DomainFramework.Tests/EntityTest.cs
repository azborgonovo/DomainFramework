using DomainFramework.Tests.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainFramework.Tests
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void SameIdentityProduceEqualsTrueTest()
        {
            //Arrange
            var entityLeft = new FakeEntity();
            var entityRight = new FakeEntity();

            entityLeft.SetIdentity(1);
            entityRight.SetIdentity(1);

            //Act
            bool resultOnEquals = entityLeft.Equals(entityRight);
            bool resultOnOperator = entityLeft == entityRight;

            //Assert
            Assert.IsTrue(resultOnEquals);
            Assert.IsTrue(resultOnOperator);

        }
        [TestMethod]
        public void DiferentIdProduceEqualsFalseTest()
        {
            //Arrange
            var entityLeft = new FakeEntity();
            var entityRight = new FakeEntity();

            entityLeft.SetIdentity(1);
            entityRight.SetIdentity(2);


            //Act
            bool resultOnEquals = entityLeft.Equals(entityRight);
            bool resultOnOperator = entityLeft == entityRight;

            //Assert
            Assert.IsFalse(resultOnEquals);
            Assert.IsFalse(resultOnOperator);

        }
        [TestMethod]
        public void CompareUsingEqualsOperatorsAndNullOperandsTest()
        {
            //Arrange
            FakeEntity entityLeft = null;
            FakeEntity entityRight = new FakeEntity();

            entityRight.SetIdentity(1);

            //Act
            //if (!(entityLeft == (Entity)null))//this perform ==(left,right)
            //    Assert.Fail();

            //if (!(entityRight != (Entity)null))//this perform !=(left,right)
            //    Assert.Fail();

            entityRight = null;

            //Act
            if (!(entityLeft == entityRight))//this perform ==(left,right)
                Assert.Fail();

            if (entityLeft != entityRight)//this perform !=(left,right)
                Assert.Fail();


        }
        [TestMethod]
        public void CompareTheSameReferenceReturnTrueTest()
        {
            //Arrange
            var entityLeft = new FakeEntity();
            FakeEntity entityRight = entityLeft;


            //Act
            if (!entityLeft.Equals(entityRight))
                Assert.Fail();

            if (!(entityLeft == entityRight))
                Assert.Fail();

        }
        [TestMethod]
        public void CompareWhenLeftIsNullAndRightIsNullReturnFalseTest()
        {
            //Arrange

            FakeEntity entityLeft = null;
            var entityRight = new FakeEntity();

            entityRight.SetIdentity(1);

            //Act
            //if (!(entityLeft == (Entity)null))//this perform ==(left,right)
            //    Assert.Fail();

            //if (!(entityRight != (Entity)null))//this perform !=(left,right)
            //    Assert.Fail();
        }

        [TestMethod]
        public void SetIdentitySetANonTransientEntity()
        {
            //Arrange
            var entity = new FakeEntity();

            //Act
            entity.SetIdentity(1);

            //Assert
            Assert.IsFalse(entity.IsTransient());
        }

        [TestMethod]
        public void ChangeIdentitySetNewIdentity()
        {
            //Arrange
            var entity = new FakeEntity();
            entity.SetIdentity(1);

            //act
            int expected = entity.Id;
            entity.SetIdentity(2);

            //assert
            Assert.AreNotEqual(expected, entity.Id);
        }
    }
}
