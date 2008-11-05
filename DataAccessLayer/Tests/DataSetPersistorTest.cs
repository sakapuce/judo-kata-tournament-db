using NUnit.Framework;
using System.IO;
using NUnit.Framework.SyntaxHelpers;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DataSetPersistorTest
    {
        private DataSetPersistor _persistor;
        private TestDataSet _testDataSet;

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
            _testDataSet.Clear();
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
        public void InsertRecordTest()
        {
            _persistor.Fill();
            
            //add 1 new master record
            TestDataSet.MasterTableRow masterTableRow = _testDataSet.MasterTable.NewMasterTableRow();
            masterTableRow.Name = "Record_5";
            _testDataSet.MasterTable.Rows.Add(masterTableRow);

            //add 2 new details records
            TestDataSet.DetailsTableRow detailsTableRow = _testDataSet.DetailsTable.NewDetailsTableRow();
            detailsTableRow.IdMasterTable = masterTableRow.Id;
            detailsTableRow.Details = "Details 1 for Record_5";
            _testDataSet.DetailsTable.Rows.Add(detailsTableRow);

            detailsTableRow = _testDataSet.DetailsTable.NewDetailsTableRow();
            detailsTableRow.IdMasterTable = masterTableRow.Id;
            detailsTableRow.Details = "Details 2 for Record_5";
            _testDataSet.DetailsTable.Rows.Add(detailsTableRow);

            _persistor.Update();

            Assert.That(_testDataSet.MasterTable.Rows.Count, Is.EqualTo(5));
            Assert.That(_testDataSet.DetailsTable.Rows.Count,Is.EqualTo(8));
        }

        [Test]
        public void DeleteRecordTest()
        {
            _persistor.Fill();

            _testDataSet.MasterTable.Select("Id=4")[0].Delete();

            _persistor.Update();

            Assert.AreEqual(3,_testDataSet.MasterTable.Rows.Count);
            Assert.AreEqual(3,_testDataSet.DetailsTable.Rows.Count);
        }
    }
}
