using System;
using CustomHashTable;
using NUnit.Framework;

namespace HashTable.Tests
{
    public partial class HashTableTest
    {
        [TestFixture]
        public class Set
        {
            [Test]
            public void ValueTypeDataOnExistingElement_AssignsNewValueAndCountOfElementsDoesNotChange(
                [Random(0, 19, 1)] int randomKey)
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var elementsCount = 20;
                for (var i = 0; i < elementsCount; i++)
                    hashTable.Add(i, i);

                var previousValue = hashTable[randomKey];

                //Act
                hashTable[randomKey] = 100;

                //Assert
                Assert.AreNotEqual(previousValue, hashTable[randomKey]);
                TestContext.Write(randomKey);
            }


            [Test]
            public void ValueTypeDataValueTypeDataOnNonExistentElement_ThrowsArgumentException()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var elementsCount = 20;
                for (var i = 0; i < elementsCount; i++)
                    hashTable.Add(i, i);

                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    //Act
                    hashTable[elementsCount * 3] = 1000;
                });
            }


            [Test]
            public void ReferenceTypeDataOnExistingElement_AssignsNewValueAndCountOfElementsDoesNotChange(
                [Random(0, 19, 1)] int randomKey)
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                var elementsCount = 20;
                for (var i = 0; i < elementsCount; i++)
                    hashTable.Add(i.ToString(), i.ToString());

                var previousValue = hashTable[randomKey.ToString()];

                //Act
                hashTable[randomKey.ToString()] = 100.ToString();

                //Assert
                Assert.AreNotEqual(previousValue, hashTable[randomKey.ToString()]);
                TestContext.Write(randomKey);
            }


            [Test]
            public void ReferenceTypeDataValueTypeDataOnNonExistentElement_ThrowsArgumentException()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var elementsCount = 20;
                for (var i = 0; i < elementsCount; i++)
                    hashTable.Add(i, i);

                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    //Act
                    hashTable[elementsCount * 3] = 1000;
                });
            }


            [Test]
            public void PassNullKey_ThrowsArgumentNullException()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();

                //Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Act
                    hashTable["some object"] = null;
                });
            }

            [Test]
            public void PassNullValue_ThrowsArgumentNullException()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();

                //Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Act
                    hashTable[null] = "some object";
                });
            }
        }
    }
}