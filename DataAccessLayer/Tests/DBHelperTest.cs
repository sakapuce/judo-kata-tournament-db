using NUnit.Framework;
using System.Data.Common;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DBHelperTest
    {

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
        }
        
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestCreateConnection()
        {
            
            DbConnection dbConnection = DbHelper.CreateConnection();
            Assert.IsNotNull(dbConnection, "DbHelper.CreateConnection() returns a null reference!");
        }
    }
}
