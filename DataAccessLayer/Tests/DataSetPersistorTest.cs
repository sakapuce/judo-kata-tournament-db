using System.Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Common;

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

            _dbHelper = DBHelper.Instance;

            _testDataSet = new TestDataSet();

            _masterAdapter = _dbHelper.CreateAdapter();
            _detailsAdapter = _dbHelper.CreateAdapter();

            _masterHelper = new DataTableHelper(_testDataSet.MasterTable);
            _detailsHelper = new DataTableHelper(_testDataSet.DetailsTable);

            //Data Adapters
            _masterAdapter.SelectCommand = _dbHelper.CreateCommand(_masterHelper.CreateSelectQuery());
            _masterAdapter.UpdateCommand = _dbHelper.CreateCommand(_masterHelper.CreateUpdateQuery());
            _masterAdapter.InsertCommand = _dbHelper.CreateCommand(_masterHelper.CreateInsertQuery(false)); 
            DbParameter IdParam = _masterAdapter.InsertCommand.CreateParameter();
            IdParam.DbType = DbType.Int32;
            IdParam.Direction = ParameterDirection.Output;

            _detailsAdapter.SelectCommand = _dbHelper.CreateCommand(_detailsHelper.CreateSelectQuery());
            _detailsAdapter.UpdateCommand = _dbHelper.CreateCommand(_detailsHelper.CreateUpdateQuery());
            _detailsAdapter.InsertCommand = _dbHelper.CreateCommand(_detailsHelper.CreateInsertQuery(false));
            IdParam = _detailsAdapter.InsertCommand.CreateParameter();
            IdParam.DbType = DbType.Int32;
            IdParam.Direction = ParameterDirection.Output;
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }
        
        [SetUp]
        public void Setup()
        {
            _persistor = new DataSetPersistor(_testDataSet);
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
        public void SetAdapterSequenceForUpdateTest()
        {
            List<DbDataAdapter> adapterSequence;
            adapterSequence = new List<DbDataAdapter>();

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
            List<DbDataAdapter> adapterSequence;
            adapterSequence = new List<DbDataAdapter>();

            adapterSequence.Add(_detailsAdapter);
            adapterSequence.Add(_masterAdapter);

            _persistor.SetAdapterSequenceForDelete(adapterSequence);

            Assert.AreEqual(2, _persistor.AdapterSequenceForDelete.Count);
            Assert.AreEqual(_detailsHelper.CreateSelectQuery(), _persistor.AdapterSequenceForDelete[0].SelectCommand.CommandText);
            Assert.AreEqual(_masterHelper.CreateSelectQuery(), _persistor.AdapterSequenceForDelete[1].SelectCommand.CommandText);
        }

        [Test]
        public void UpdateTest()
        {
            
        }
    }
}
