using NUnit.Framework;
using System.IO;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DataSetPersistorTest
    {
        DataSetPersistor _persistor;
        TestDataSet _testDataSet;

        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {

            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\CreateTestTables.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }

            _testDataSet = new TestDataSet();
            
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DropTestTables.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
        }
        
        [SetUp]
        public void Setup()
        {
            //Insert Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\InsertTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
            _persistor = new DataSetPersistor(_testDataSet);
        }

        [TearDown]
        public void TearDown()
        {
            //Delete Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DeleteTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
        }

        [Test]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void FillDataSetTest()
        {

            _persistor.Fill();
            
            Assert.AreEqual(4,_testDataSet.MasterTable.Rows.Count);
            Assert.AreEqual(6,_testDataSet.DetailsTable.Rows.Count);
        }

        [Test]
        public void DeleteRecordTest()
        {
            _persistor.Fill();

            
            foreach(TestDataSet.DetailsTableRow row in _testDataSet.DetailsTable.Select("IdMasterTable = 4"))
            {
                row.Delete();
            }

            _testDataSet.MasterTable.Select("Id=4")[0].Delete();


            _persistor.Update();

            Assert.AreEqual(3,_testDataSet.MasterTable.Rows.Count);
            Assert.AreEqual(3,_testDataSet.DetailsTable.Rows.Count);
        }
    }
}
