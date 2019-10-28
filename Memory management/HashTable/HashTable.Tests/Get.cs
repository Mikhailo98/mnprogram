using System;
using CustomHashTable;
using NUnit.Framework;

namespace HashTable.Tests
{
    public partial class HashTableTest
    {
        [TestFixture]
        public class Get
        {
            [Test]
            public void ValueTypeDataInCollectionWithoutElements_ThrowArgumentException()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var key = 1;

                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    //Act
                    var actualResult = hashTable[key];
                });
            }


            [Test]
            public void ValueTypeDataOnExistingElement_ReturnValueSameAsWithTryGetMethod()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                int key = 1, initialValue = 1;
                hashTable.Add(key, initialValue);

                //Act
                var actualResult = hashTable[key];
                hashTable.TryGet(key, out var expectedResult);

                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }


            [Test]
            public void ValueTypeDataOnNonExistentElement_ThrowArgumentException()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                int elementsCount = 20, key = elementsCount * 2;
                for (var i = 0; i < elementsCount; i++)
                    hashTable.Add(i, i);

                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    //Act
                    var actualResult = hashTable[key];
                });
            }
        }
    }
}