using NUnit.Framework;
using System.Data;

namespace DALHelper.Tests
{
    
    [TestFixture]
    public class DataTableHelperTest
    {
        private DataTable _dataTable;
        
        [SetUp]
        public void SetUp()
        {
            _dataTable = new DataTable("TestTable");
            
            // Add an Id column as primary key
            DataColumn idColumn = new DataColumn("Id", System.Type.GetType("System.Int32"));
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = -1;
            idColumn.AutoIncrementStep = -1;
            _dataTable.Columns.Add(idColumn);

            _dataTable.PrimaryKey = new DataColumn[] { idColumn };

            // Add a FirstName column
            DataColumn firstNameColumn = new DataColumn("FirstName", System.Type.GetType("System.String"));
            _dataTable.Columns.Add(firstNameColumn);

            // Add a LastName column
            DataColumn lastNameColumn = new DataColumn("LastName", System.Type.GetType("System.String"));
            _dataTable.Columns.Add(lastNameColumn);
        }

        [TearDown]
        public void TearDown()
        {
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
            Assert.IsTrue(tableHelper.DataTable.TableName=="TestTable");
        }

        [Test]
        public void TestAddColumn()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            int oldNumberOfColumns = _dataTable.Columns.Count;
            tableHelper.AddColumn("TestField");

            Assert.IsTrue(tableHelper.DataTable.Columns.Count == oldNumberOfColumns+1);
        }

        [Test]
        public void TestCreateSelectCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedSelectQuery = "SELECT Id, FirstName, LastName FROM TestTable";
            Assert.AreEqual(expectedSelectQuery, tableHelper.CreateSelectQuery());
        }

        [Test]
        public void TestCreateInsertCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            string expectedSelectQuery = "INSERT INTO TestTable (Id, FirstName, LastName) VALUES (@Id, @FirstName, @LastName)";
            Assert.AreEqual(expectedSelectQuery, tableHelper.CreateInsertQuery());

            expectedSelectQuery = "INSERT INTO TestTable (FirstName, LastName) VALUES (@FirstName, @LastName)";
            Assert.AreEqual(expectedSelectQuery, tableHelper.CreateInsertQuery(false));
        }

        [Test]
        public void TestCreateUpdateCommand()
        {
            DataTableHelper tableHelper = new DataTableHelper(_dataTable);
            const string expectedSelectQuery = "UPDATE TestTable SET Id=@Id, FirstName=@FirstName, LastName=@LastName WHERE (Id=@Original_Id)";
            Assert.AreEqual(expectedSelectQuery, tableHelper.CreateUpdateQuery());
        }
    }
}
