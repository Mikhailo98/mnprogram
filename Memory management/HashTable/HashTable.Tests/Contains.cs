using CustomHashTable;
using NUnit.Framework;

namespace HashTable.Tests
{
    public partial class HashTableTest
    {
        [TestFixture]
        public class Contains
        {
            [Test]
            public void ValueTypeDataInEmptyHashTable_ReturnsFalse()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Act
                var actualResult = hashTable.Contains(3);

                //Assert
                Assert.IsFalse(actualResult);
            }


            [Test]
            public void ValueTypeDataInHashTableWith100Elements_ReturnsTrue(
                [Random(0, 100, 1)] int randomKey)
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                for (var i = 0; i < 100; i++)
                    hashTable.Add(i, i);

                //Act
                var actualResult = hashTable.Contains(randomKey);

                //Assert
                Assert.IsTrue(actualResult);
                TestContext.Write(randomKey);
            }


            [Test]
            public void ValueTypeDataWhichDoesNotExistInHashTable_ReturnsFalse()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Act
                var actualResult = hashTable.Contains(3);

                //Assert
                Assert.IsFalse(actualResult);
            }


            [Test]
            public void ValueTypeDataWithRandomKeyWhichExistsInHashTable_ReturnsTrue(
                [Random(0, 20, 1)] int value)
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(value, value);

                //Act
                var actualResult = hashTable.Contains(value);

                //Assert
                Assert.IsTrue(actualResult);
                TestContext.Write(value);
            }


            [Test]
            public void ReferenceTypeDataInEmptyHashTable_ReturnsFalse()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "some value");

                //Act
                var actualResult = hashTable.Contains("8");

                //Assert
                Assert.IsFalse(actualResult);
            }


            [Test]
            public void ReferenceTypeDataWhichDoesNotExistInHashTable_ReturnsFalse()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "12");

                //Act
                var actualResult = hashTable.Contains("unexisting key");

                //Assert
                Assert.IsFalse(actualResult);
            }


            [Test]
            public void ReferenceTypeDataWithRandomKeyWhichExistsInHashTable_ReturnsTrue()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("existing key", "some value");

                //Act
                var actualResult = hashTable.Contains("existing key");

                //Assert
                Assert.IsTrue(actualResult);
            }
        }
    }
}