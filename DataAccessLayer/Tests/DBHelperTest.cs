using NUnit.Framework;
using System.Data.Common;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DBHelperTest
    {
        private DBHelper _dbHelper;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _dbHelper = DBHelper.Instance;
            _dbHelper.Init("JudoKataTournamentDb");
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
            
            DbConnection dbConnection = _dbHelper.CreateConnection();
            Assert.IsNotNull(dbConnection, "DbHelper.CreateConnection() returns a null reference!");
        }
    }
}
