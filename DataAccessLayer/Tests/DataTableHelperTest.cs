using System.IO;
using NUnit.Framework;
using System.Data;

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
        public void TestCreateSelectCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedSelectQuery = "SELECT Id, IdMasterTable, Details FROM DetailsTable";
            Assert.AreEqual(expectedSelectQuery, tableHelper.Adapter.SelectCommand.CommandText);
        }

        [Test]
        public void TestCreateInsertCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedInsertQuery = "INSERT INTO [DetailsTable] ([IdMasterTable], [Details]) VALUES (@IdMasterTable, @Details); SELECT Id, IdMasterTable, Details FROM DetailsTable WHERE (Id = SCOPE_IDENTITY())";
            Assert.AreEqual(expectedInsertQuery, tableHelper.Adapter.InsertCommand.CommandText);
        }

        [Test]
        public void TestCreateUpdateCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedUpdateQuery = "UPDATE [DetailsTable] SET [IdMasterTable] = @IdMasterTable, [Details] = @Details WHERE (([Id] = @Original_Id) AND ([IdMasterTable] = @Original_IdMasterTable)); SELECT Id, IdMasterTable, Details FROM DetailsTable WHERE (Id = @Id)";
            Assert.AreEqual(expectedUpdateQuery, tableHelper.Adapter.UpdateCommand.CommandText);
        }

        [Test]
        public void TestCreateDeleteCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedDeleteQuery = "DELETE FROM [DetailsTable] WHERE (([Id] = @Original_Id) AND ([IdMasterTable] = @Original_IdMasterTable))";
            Assert.AreEqual(expectedDeleteQuery, tableHelper.Adapter.DeleteCommand.CommandText);
        }
    }
}
