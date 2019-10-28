using CustomCollection.Generic;
using NUnit.Framework;

namespace CircularLinkedListTest.LinkedListTest
{
    public partial class LinkedList
    {
        [TestFixture]
        public class RemoveAt
        {
            [Test]
            public void CollectionWithOnlyOneElement_HeadIsNull()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1};

                //Act              
                linkedList.RemoveAt(0);
                var actualHead = linkedList.Head;

                //Assert
                Assert.IsNull(actualHead);
            }


            [Test]
            public void PassIndexBiggerThanNumericCollectionLength_RemovesElement()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3};

                //Act
                var actual = linkedList.RemoveAt(5);

                //Assert
                Assert.NotNull(actual);
            }


            [Test]
            public void PassIndexEqualToLength_RemovesFirstNodeAndHeadChanges()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3};

                //Act
                var actual = linkedList.RemoveAt(linkedList.Length);
                var newHead = linkedList.Head;

                //Assert
                Assert.AreNotEqual(newHead, actual);
            }


            [Test]
            public void ValidIndexInCollectionWithElements_LengthDecrease()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1, 2, 3, 4};
                var expected = linkedList.Length;

                //Act              
                linkedList.RemoveAt(2);
                var actual = linkedList.Length;

                //Assert
                Assert.AreEqual(expected - 1, actual);
            }
        }
    }
}