using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RetailEquity;
using RetailEquity.Factories;

namespace Tests
{
    public class FilterTestBase
    {
        protected IEnumerable<Trade> Trades = new List<Trade>
        {
            new Trade(10, TradeSubType.MyOption, TradeType.Future),
            new Trade(200, TradeSubType.NyOption, TradeType.Option),
            new Trade(75, TradeSubType.MyOption, TradeType.Option),
            new Trade(30, TradeSubType.NyOption, TradeType.Future),
            new Trade(100, TradeSubType.NyOption, TradeType.Future)
        };
    }

    [TestFixture]
    public class BofaFilterTest : FilterTestBase
    {
        [Test]
        public void Match_SendTradesCollection_ReturnsExpectedTrades()
        {
            //Arrange
            var expectedFilteredTrades = new List<Trade>
            {
                new Trade(200, TradeSubType.NyOption, TradeType.Option),
                new Trade(75, TradeSubType.MyOption, TradeType.Option),
                new Trade(100, TradeSubType.NyOption, TradeType.Future)
            };
            var bofaFilter = new Bank(new BofaFilterFactory());

            //Act 
            var filterTrades = bofaFilter.Trade(Trades).ToList();

            //Assert
            Assert.IsNotNull(bofaFilter);
            CollectionAssert.AreEquivalent(expectedFilteredTrades, filterTrades);
        }
    }

    [TestFixture]
    public class BarclaysFilterTest : FilterTestBase
    {
        [Test]
        public void Match_SendTradesCollection_ReturnsExpectedTrades()
        {
            //Arrange
            var expectedFilteredTrades = new List<Trade>
            {
                new Trade(200, TradeSubType.NyOption, TradeType.Option)
            };
            var barklaysBank = new BarclaysBank(new BarclaysFilterFactory());

            //Act 
            var filterTrades = barklaysBank.Trade(Trades).ToList();

            //Assert
            Assert.IsNotNull(barklaysBank);
            CollectionAssert.AreEquivalent(expectedFilteredTrades, filterTrades);
        }
    }

    [TestFixture]
    public class ConnacordFilterTest : FilterTestBase
    {
        [Test]
        public void Match_SendTradesCollection_ReturnsExpectedTrades()
        {
            //Arrange
            var expectedFilteredTrades = new List<Trade>
            {
                new Trade(30, TradeSubType.NyOption, TradeType.Future)
            };
            var connacordBank = new ConnacordBank(new ConnacordFilterFactory());

            //Act 
            var filterTrades = connacordBank.Trade(Trades).ToList();

            //Assert
            Assert.IsNotNull(connacordBank);
            CollectionAssert.AreEquivalent(expectedFilteredTrades, filterTrades);
        }
    }
}