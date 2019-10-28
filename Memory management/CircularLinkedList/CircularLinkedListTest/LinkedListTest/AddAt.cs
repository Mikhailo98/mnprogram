using CustomCollection.Generic;
using NUnit.Framework;

namespace CircularLinkedListTest.LinkedListTest
{
    public partial class LinkedList
    {
        [TestFixture]
        public class AddAt
        {
            [Test]
            public void CustomTestClassAtEndPosition_AddsClass()
            {
                //Arrange
                var linkedList = new LinkedList<CustomTestClass>
                {
                    new CustomTestClass {ID = 1},
                    new CustomTestClass {ID = 2},
                    new CustomTestClass {ID = 3},
                    new CustomTestClass {ID = 4}
                };
                var lastNode = linkedList.Head.Previous;

                //Act
                linkedList.AddAt(4, new CustomTestClass {ID = 5});
                var actualLastNode = linkedList.Head.Previous;
                
                //Assert
                Assert.AreNotEqual(lastNode, actualLastNode);
            }


            [Test]
            public void CustomTestClassAtTheFirstPosition_HeadChanges()
            {
                //Arrange
                var linkedList = new LinkedList<CustomTestClass>
                {
                    new CustomTestClass {ID = 1},
                    new CustomTestClass {ID = 2},
                    new CustomTestClass {ID = 3}
                };
                var head = linkedList.Head;

                //Act
                linkedList.AddAt(0, new CustomTestClass {ID = 5});
                var actualHead = linkedList.Head;

                //Assert
                Assert.AreNotEqual(head, actualHead);
            }


            [Test]
            public void CustomTestClassBetweenOtherElements_LengthIncreases()
            {
                //Arrange
                var linkedList = new LinkedList<CustomTestClass>
                {
                    new CustomTestClass {ID = 1},
                    new CustomTestClass {ID = 2},
                    new CustomTestClass {ID = 3}
                };
                var expectedLength = linkedList.Length + 1;

                //Act
                linkedList.AddAt(3, new CustomTestClass {ID = 5});
                var actualLength = linkedList.Length;

                //Assert
                Assert.AreEqual(expectedLength, actualLength);
            }


            [Test]
            public void NumberAtEndPosition_PreviousNodeOfHeadChanges()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3};
                var prevNode = linkedList.Head.Previous;

                //Act
                linkedList.AddAt(4, 4);
                var actualNode = linkedList.Head.Previous;

                //Assert
                Assert.AreNotEqual(prevNode, actualNode);
            }


            [Test]
            public void NumberAtTheFirstPosition_AddsNumber()
            {
                //Arrange
                var linkedList = new LinkedList<int> {0, 1, 2, 3, 4};
                var headBefore = linkedList.Head;

                //Act
                linkedList.AddAt(0, 5);
                var actualHead = linkedList.Head;

                //Assert
                Assert.AreNotEqual(headBefore, actualHead);
            }


            [Test]
            public void NumberBetweenOtherElements_AddsNumber()
            {
                //Arrange
                var linkedList = new LinkedList<int> {1, 2, 3, 4};
                var expectedLength = linkedList.Length + 1;

                //Act
                linkedList.AddAt(3, 5);
                var actualLength = linkedList.Length;

                //Assert
                Assert.AreEqual(expectedLength, actualLength);
            }
        }
    }
}