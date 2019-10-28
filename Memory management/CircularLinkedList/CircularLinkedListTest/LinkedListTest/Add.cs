using CustomCollection.Generic;
using NUnit.Framework;

namespace CircularLinkedListTest.LinkedListTest
{
    public partial class LinkedList
    {
        [TestFixture]
        public class Add
        {
            [Test]
            public void NumberIntoEmptyCollection_AddsNumberToEnd()
            {
                //Arrange
                LinkedList<int> linkedList = new LinkedList<int>();
                var expectedLength = linkedList.Length + 1;

                //Act
                linkedList.Add(12);
                var actualLength = linkedList.Length;

                //Assert
                Assert.AreEqual(expectedLength, actualLength);
            }

            [Test]
            public void NumberIntoCollectionWithElements_AddsNumberToEnd()
            {
                //Arrange
                LinkedList<int> linkedList = new LinkedList<int> { 1, 2, 3 };
                var lastNode = linkedList.Head.Previous;

                //Act
                linkedList.Add(5);
                var actualNode = linkedList.Head.Previous;

                //Assert
                Assert.AreNotEqual(lastNode, actualNode);
            }

            [Test]
            public void StringIntoEmptyCollection_AddsStringToEnd()
            {
                //Arrange
                LinkedList<string> linkedList = new LinkedList<string> { "1", "2", "3" };
                var lastNode = linkedList.Head.Previous;
                //Act
                linkedList.Add("test string");
                var actualNode = linkedList.Head.Previous;

                //Assert
                Assert.AreNotEqual(lastNode, actualNode);
            }

            [Test]
            public void CustomTestClassIntoCollectionWithElements_AddsCustomTestClassToEnd()
            {
                //Arrange
                LinkedList<CustomTestClass> linkedList = new LinkedList<CustomTestClass>()
                {
                    new CustomTestClass(){ID = 1 },
                    new CustomTestClass(){ID = 2 },
                    new CustomTestClass(){ID = 3 },
                };
                var lastNode = linkedList.Head.Previous;

                //Act
                linkedList.Add(new CustomTestClass() { ID = 4 });
                var actualNode = linkedList.Head.Previous;

                //Assert
                Assert.AreNotEqual(lastNode, actualNode);
            }
        }
    }
}
