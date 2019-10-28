using System;
using CustomCollection.Generic;
using NUnit.Framework;

namespace CircularLinkedListTest.LinkedListTest
{
    public partial class LinkedList
    {
        [TestFixture]
        public class Remove
        {
            [Test]
            public void CollectionWithElements_LengthDecrease()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1, 2, 3, 4};
                var expected = linkedList.Length;

                //Act              
                linkedList.Remove();
                var actual = linkedList.Length;

                //Assert
                Assert.AreEqual(expected - 1, actual);
            }


            [Test]
            public void CollectionWithOnlyOneElement_ReturnedNode()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1};

                //Act              
                var returnedNode = linkedList.Remove();

                //Assert
                Assert.NotNull(returnedNode);
            }


            [Test]
            public void EmptyCollection_ThrowsInvalidOperationException()
            {
                //Arrange
                var linkedList = new LinkedList<int>();

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    //Act
                    linkedList.Remove();
                });
            }
        }
    }
}