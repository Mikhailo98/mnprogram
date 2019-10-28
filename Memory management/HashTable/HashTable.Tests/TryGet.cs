using CustomHashTable;
using NUnit.Framework;

namespace HashTable.Tests
{
    public partial class HashTableTest
    {
        [TestFixture]
        public class TryGet
        {
            [Test]
            public void ValueTypeDataExistedInCollectionWith100elements_ReturnsTrueAndValue(
                [Random(0, 100, 1)] int randomKey)
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                for (var i = 0; i < 100; i++)
                    hashTable.Add(i, i);

                //Act
                var actualBooleanResult = hashTable.TryGet(randomKey, out var returnedValue);

                //Assert
                Assert.IsTrue(actualBooleanResult);
                Assert.NotZero(returnedValue);
                TestContext.Write(randomKey);
            }


            [Test]
            public void ValueTypeDataInEmptyCollection_ReturnsFalseAndZero()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Act
                var actualBooleanResult = hashTable.TryGet(2, out var returnedValue);

                //Assert
                Assert.IsFalse(actualBooleanResult);
                Assert.Zero(returnedValue);
            }


            [Test]
            public void ValueTypeDataWhichDoesNoTExistsInCollection_ReturnsFalseAndZero()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Act
                var actualBooleanResult = hashTable.TryGet(2, out var returnedValue);

                //Assert
                Assert.IsFalse(actualBooleanResult);
                Assert.Zero(returnedValue);
            }


            [Test]
            public void ValueTypeDataWhichExistsInCollection_ReturnsTrueAndObject()
            {
                //Arrange
                IHashTable<int, int> hashTable = new HashTable<int, int>();
                hashTable.Add(1, 1);

                //Act
                var actualBooleanResult = hashTable.TryGet(1, out var returnedValue);

                //Assert
                Assert.IsTrue(actualBooleanResult);
                Assert.IsNotNull(returnedValue);
            }


            [Test]
            public void ReferenceTypeDataExistedInCollectionWith100elements_ReturnsTrueAndValue(
               [Random(0, 100, 1)] int randomKey)
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                for (var i = 0; i < 100; i++)
                    hashTable.Add(i.ToString(), i.ToString());

                //Act
                var actualBooleanResult = hashTable.TryGet(randomKey.ToString(), out var returnedValue);

                //Assert
                Assert.IsTrue(actualBooleanResult);
                Assert.NotNull(returnedValue);
                TestContext.Write(randomKey);
            }


            [Test]
            public void ReferenceTypeDataInEmptyCollection_ReturnsFalseAndNull()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "1");

                //Act
                var actualBooleanResult = hashTable.TryGet("2", out var returnedValue);

                //Assert
                Assert.IsFalse(actualBooleanResult);
                Assert.Null(returnedValue);
            }


            [Test]
            public void ReferenceTypeDataWhichDoesNoTExistsInCollection_ReturnsFalseAndNull()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "1");

                //Act
                var actualBooleanResult = hashTable.TryGet("2", out var returnedValue);

                //Assert
                Assert.IsFalse(actualBooleanResult);
                Assert.Null(returnedValue);
            }


            [Test]
            public void ReferenceTypeDataWhichExistsInCollection_ReturnsTrueAndObject()
            {
                //Arrange
                IHashTable<string, string> hashTable = new HashTable<string, string>();
                hashTable.Add("1", "1");

                //Act
                var actualBooleanResult = hashTable.TryGet("1", out var returnedValue);

                //Assert
                Assert.IsTrue(actualBooleanResult);
                Assert.IsNotNull(returnedValue);
            }
        }
    }
}