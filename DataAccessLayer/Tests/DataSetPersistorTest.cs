using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DataSetPersistorTest
    {
        DataSetPersistor _persistor;
        TestDataSet _testDataSet;

        DataTableHelper _masterHelper;
        DataTableHelper _detailsHelper;
        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            DBHelper.Instance.Init("JudoKataTournamentDb");

            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\CreateTestTables.sql", System.Environment.CurrentDirectory)))
            {
                DBHelper.Instance.ExecuteScript(reader.ReadToEnd());
            }

            _testDataSet = new TestDataSet();

            _masterHelper = new DataTableHelper(_testDataSet.MasterTable);
            _detailsHelper = new DataTableHelper(_testDataSet.DetailsTable);
            
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DropTestTables.sql", System.Environment.CurrentDirectory)))
            {
                DBHelper.Instance.ExecuteScript(reader.ReadToEnd());
            }
        }
        
        [SetUp]
        public void Setup()
        {
            //Insert Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\InsertTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DBHelper.Instance.ExecuteScript(reader.ReadToEnd());
            }
            _persistor = new DataSetPersistor(_testDataSet);
        }

        [TearDown]
        public void TearDown()
        {
            //Delete Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DeleteTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DBHelper.Instance.ExecuteScript(reader.ReadToEnd());
            }
        }

        [Test]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true);
        }
       
        [Test]
        public void SetAdapterSequenceForUpdateTest()
        {
            List<DataTableHelper> sequence = new List<DataTableHelper>();

            sequence.Add(_masterHelper);
            sequence.Add(_detailsHelper);

            _persistor.SetSequenceForUpdate(sequence);

            Assert.AreEqual(2, _persistor.SequenceForUpdate.Count);


            Assert.AreEqual(_masterHelper.CreateSelectQuery(), _persistor.SequenceForUpdate[0].Adapter.SelectCommand.CommandText);
            Assert.AreEqual(_detailsHelper.CreateSelectQuery(), _persistor.SequenceForUpdate[1].Adapter.SelectCommand.CommandText);        
        }

        [Test]
        public void SetAdapterSequenceForDeleteTest()
        {
            List<DataTableHelper> sequence = new List<DataTableHelper>();

            sequence.Add(_detailsHelper);
            sequence.Add(_masterHelper);

            _persistor.SetSequenceForDelete(sequence);

            Assert.AreEqual(2, _persistor.SequenceForDelete.Count);


            Assert.AreEqual(_detailsHelper.CreateSelectQuery(), _persistor.SequenceForDelete[0].Adapter.SelectCommand.CommandText);
            Assert.AreEqual(_masterHelper.CreateSelectQuery(), _persistor.SequenceForDelete[1].Adapter.SelectCommand.CommandText);
        }

        [Test]
        public void FillDataSetTest()
        {
            List<DataTableHelper> sequence = new List<DataTableHelper>();

            sequence.Add(_masterHelper);
            sequence.Add(_detailsHelper);

            _persistor.SetSequenceForFill(sequence);

            Assert.AreEqual(2,_persistor.SequenceForFill.Count);

            _persistor.Fill();
            
            Assert.AreEqual(4,_testDataSet.MasterTable.Rows.Count);
            Assert.AreEqual(4,_testDataSet.DetailsTable.Rows.Count);
        }
    }
}
