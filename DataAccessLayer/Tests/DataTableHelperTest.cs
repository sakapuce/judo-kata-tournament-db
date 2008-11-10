using System;
using System.Data.SqlClient;
using System.IO;
using NUnit.Framework;
using System.Data;
using NUnit.Framework.SyntaxHelpers;

namespace DALHelper.Tests
{
    
    [TestFixture]
    public class DataTableHelperTest
    {
        private DataTable _dataTable;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //Create test tables
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\CreateTestTables.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
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
        public void SetUp()
        {
            _dataTable = new TestDataSet.DetailsTableDataTable();

            //Insert Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\InsertTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
        }

        [TearDown]
        public void TearDown()
        {
            //Delete Test Datas
            using (StreamReader reader = new StreamReader(string.Format(@"{0}\..\..\Tests\Scripts\DeleteTestDatas.sql", System.Environment.CurrentDirectory)))
            {
                DbHelper.ExecuteScript(reader.ReadToEnd());
            }
            
            _dataTable = null;
        }

        [Test]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true);
        }
        
        [Test]
        public void TestConstructor()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            Assert.IsTrue(tableHelper.Table.TableName=="DetailsTable");
        }

        [Test]
        public void TestGetTableSchema()
        {
            _dataTable = new TestDataSet.MasterTableDataTable();
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            DataTable schema = tableHelper.GetTableSchema();
            Assert.That(schema,Is.Not.Null);
        }

        [Test]
        public void TestAdapterType()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            Assert.That(tableHelper.Adapter, Is.TypeOf(typeof(SqlDataAdapter)));
        }
    }
}
