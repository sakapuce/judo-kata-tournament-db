using System.Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DataSetPersistorTest
    {
        DataSetPersistor _persistor;
        DBHelper _dbHelper;
        TestDataSet _testDataSet;

        DbDataAdapter _masterAdapter;
        DbDataAdapter _detailsAdapter;

        DataTableHelper _masterHelper;
        DataTableHelper _detailsHelper;
        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _dbHelper = DBHelper.Instance;
            _dbHelper.Init("JudoKataTournamentDb");

            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\CreateTestTables.sql", System.Environment.CurrentDirectory)))
            {
                _dbHelper.ExecuteScript(reader.ReadToEnd());
            }

            _testDataSet = new TestDataSet();

            _masterAdapter = _dbHelper.CreateAdapter();
            _detailsAdapter = _dbHelper.CreateAdapter();

            _masterHelper = new DataTableHelper(_testDataSet.MasterTable);
            _detailsHelper = new DataTableHelper(_testDataSet.DetailsTable);

            //Data Adapters
            _masterAdapter.SelectCommand = _dbHelper.CreateCommand(_masterHelper.CreateSelectQuery());
            _masterAdapter.UpdateCommand = _dbHelper.CreateCommand(_masterHelper.CreateUpdateQuery());
            _masterAdapter.InsertCommand = _dbHelper.CreateCommand(_masterHelper.CreateInsertQuery(false));
            DbParameter idParam = _masterAdapter.InsertCommand.CreateParameter();
            idParam.DbType = DbType.Int32;
            idParam.Direction = ParameterDirection.Output;

            _detailsAdapter.SelectCommand = _dbHelper.CreateCommand(_detailsHelper.CreateSelectQuery());
            _detailsAdapter.UpdateCommand = _dbHelper.CreateCommand(_detailsHelper.CreateUpdateQuery());
            _detailsAdapter.InsertCommand = _dbHelper.CreateCommand(_detailsHelper.CreateInsertQuery(false));
            idParam = _detailsAdapter.InsertCommand.CreateParameter();
            idParam.DbType = DbType.Int32;
            idParam.Direction = ParameterDirection.Output;
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DropTestTables.sql", System.Environment.CurrentDirectory)))
            {
                _dbHelper.ExecuteScript(reader.ReadToEnd());
            }
        }
        
        [SetUp]
        public void Setup()
        {
            //Insert Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\InsertTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                _dbHelper.ExecuteScript(reader.ReadToEnd());
            }
            _persistor = new DataSetPersistor(_testDataSet);
        }

        [TearDown]
        public void TearDown()
        {
            //Delete Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DeleteTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                _dbHelper.ExecuteScript(reader.ReadToEnd());
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
            List<DbDataAdapter> adapterSequence = new List<DbDataAdapter>();

            adapterSequence.Add(_masterAdapter);
            adapterSequence.Add(_detailsAdapter);

            _persistor.SetAdapterSequenceForUpdate(adapterSequence);

            Assert.AreEqual(2, _persistor.AdapterSequenceForUpdate.Count);
            Assert.AreEqual(_masterHelper.CreateSelectQuery(), _persistor.AdapterSequenceForUpdate[0].SelectCommand.CommandText);
            Assert.AreEqual(_detailsHelper.CreateSelectQuery(), _persistor.AdapterSequenceForUpdate[1].SelectCommand.CommandText);        
        }

        [Test]
        public void SetAdapterSequenceForDeleteTest()
        {
            List<DbDataAdapter> adapterSequence = new List<DbDataAdapter>();

            adapterSequence.Add(_detailsAdapter);
            adapterSequence.Add(_masterAdapter);

            _persistor.SetAdapterSequenceForDelete(adapterSequence);

            Assert.AreEqual(2, _persistor.AdapterSequenceForDelete.Count);
            Assert.AreEqual(_detailsHelper.CreateSelectQuery(), _persistor.AdapterSequenceForDelete[0].SelectCommand.CommandText);
            Assert.AreEqual(_masterHelper.CreateSelectQuery(), _persistor.AdapterSequenceForDelete[1].SelectCommand.CommandText);
        }

        [Test]
        public void FillDataSetTest()
        {
            List<DbDataAdapter> adapterSequence = new List<DbDataAdapter>();
            adapterSequence.Add(_masterAdapter);
            adapterSequence.Add(_detailsAdapter);

            _persistor.SetAdapterSequenceForFill(adapterSequence);

            _persistor.Fill();
            
            Assert.AreEqual(4,_testDataSet.MasterTable.Rows.Count);
            Assert.AreEqual(4,_testDataSet.DetailsTable.Rows.Count);
        }
    }
}
