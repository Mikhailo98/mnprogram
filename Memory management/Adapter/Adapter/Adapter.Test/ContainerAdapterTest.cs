using System.Collections.Generic;
using Epam.NetMentoring.Adapter;
using Moq;
using NUnit.Framework;

namespace Adapter.Test
{
    [TestFixture]
    public class ContainerAdapterTest
    {
        [Test]
        public void Items_PassCollectionInElements_VerifyIfGetElementsMethodIsCalledFromItems()
        {
            //Arrange
            var list = new List<int>() { 1, 2, 3, 4 };
            var printer = new Printer();
            var mock = new Mock<IElements<int>>();
            mock.Setup(p => p.GetElements()).Returns(list);


            //Act
            printer.Print(new ContainerAdapter<int>(mock.Object));


            //Assert
            mock.Verify(m => m.GetElements(), Times.Once);
        }

        
        [Test]
        public void Count_PassCollectionInElements_ReturnsProperCount()
        {
            //Arrange
            var list = new List<int>() { 1, 2, 3, 4 };
            var expectedCount = list.Count;

            var mock = new Mock<IElements<int>>();
            mock.Setup(p => p.GetElements()).Returns(list);
            

            //Act
            var adapter = new ContainerAdapter<int>(mock.Object);
            

            //Assert
            Assert.AreEqual(expectedCount, adapter.Count);
        }

        [Test]
        public void Items_PassCollectionInElements_ReturnsEquivalentCollection()
        {
            //Arrange
            var list = new List<int>() { 1, 2, 3, 4 };
            var mock = new Mock<IElements<int>>();
            mock.Setup(p => p.GetElements()).Returns(list);


            //Act
            var adapter = new ContainerAdapter<int>(mock.Object);


            //Assert
            CollectionAssert.AreEquivalent(list, adapter.Items);
        }

    }
}
