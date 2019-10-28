using System;
using CustomCollection.Generic;
using NUnit.Framework;

namespace CircularLinkedListTest.LinkedListTest
{
    public partial class LinkedList
    {
        [TestFixture]
        private class ElementAt
        {
            [Test]
            public void OfEmptyNumericCollection_ThrowsInvalidOperationException()
            {
                //Arrange
                var linkedList = new LinkedList<int>();

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    //Act
                    linkedList.ElementAt(0);
                });
            }


            [Test]
            public void PassIndexBiggerThanNumericCollectionLength_ReturnsElement()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3};

                //Act
                var actual = linkedList.ElementAt(5);

                //Assert
                Assert.NotNull(actual);
            }


            [Test]
            public void PassIndexEqualToLength_ReturnsFirstElement()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3};
                var firstElement = linkedList.Head.Value;

                //Act
                var actual = linkedList.ElementAt(linkedList.Length);

                //Assert
                Assert.AreEqual(firstElement, actual);
            }


            [Test]
            public void PassValidIndexOfNumericCollection_ReturnsElementByIndex()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1, 2, 3, 4};

                //Act
                var actual = linkedList.ElementAt(2);

                //Assert
                Assert.NotNull(actual);
            }
        }
    }
}