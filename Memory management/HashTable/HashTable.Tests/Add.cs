using System;
using CustomHashTable;
using NUnit.Framework;

namespace HashTable.Tests
{
    public partial class HashTableTest
    {
        [TestFixture]
        public class Add
        {
            [Test]
            public void ValueTypeDataRandomCountOfTimes_AddsAllElementsAndCountEqualsToRandomValue(
                [Random(0, 20, 1)] int random)
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var expectedCount = random;

                //Act
                for (var i = 0; i < random; i++)
                    hashTable.Add(i, i);

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
                TestContext.Write($"Random value was {random}");
            }

            [Test]
            public void ReferenceTypeDataRandomCountOfTimes_AddsAllElementsAndCountEqualsToRandomValue(
                [Random(0, 20, 1)] int random)
            {
                //Arrange
                IHashTable<int, string> hashTable = new HashTable<int, string>();
                var expectedCount = random;

                //Act
                for (var i = 0; i < random; i++)
                    hashTable.Add(i, i.ToString());

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
                TestContext.Write($"Random value was {random}");
            }


            [Test]
            public void ValueTypeDataWithIntegerKeyInEmptyHashTable_AddsOnceAndCountChanges()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                var expectedCount = 1;
                //Act
                hashTable.Add(1, 1);

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
            }

            [Test]
            public void ReferenceTypeDataWithIntegerKeyInEmptyHashTable_AddsOnceAndCountChanges()
            {
                //Arrange
                IHashTable<int, string> hashTable = new HashTable<int, string>();
                var expectedCount = 1;
                //Act
                hashTable.Add(1, 1.ToString());

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
            }

            [Test]
            public void ValueTypeDataValueWithIntegerKeyInHashTableWith2Elements_AddsOnceAndCountChanges()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);
                hashTable.Add(2, 2);
                var expectedCount = hashTable.Count + 1;

                //Act
                hashTable.Add(3, 3);

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
            }


            [Test]
            public void ValueTypeDataValueWithSameIntegerKeyInHashTable_ThrowsArgumentException()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Assert
                Assert.Throws<DuplicateKeyException<int>>(() =>
                {
                    //Act
                    hashTable.Add(1, 1);
                });
            }


            [Test]
            public void ReferenceTypeDataValueWithSameStringKeyInHashTable_ThrowsArgumentException()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "some object");

                //Assert
                Assert.Throws<DuplicateKeyException<string>>(() =>
                {
                    //Act
                    hashTable.Add("1", "some object");
                });
            }


            [Test]
            public void ReferenceTypeDataWithStringKeyInHashTableWith2Elements_AddsOnceAndCountChanges()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "1");
                hashTable.Add("2", "2");
                var expectedCount = hashTable.Count + 1;

                //Act
                hashTable.Add("3", "3");

                //Assert
                Assert.AreEqual(expectedCount, hashTable.Count);
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
                    hashTable.Add(null, "some object");
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
                    hashTable.Add("some key", null);
                });
            }
        }
    }
}