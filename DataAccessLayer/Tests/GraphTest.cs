using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DALHelper.Tests
{
    [TestFixture]
    public class GraphTest
    {
        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            
        }
        
        [SetUp]
        public void SetUp()
        {
            
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void AlwaysTrue()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public void GraphConstructor()
        {
            DataSetGraphTest dataset = new DataSetGraphTest();
            DataSetGraph dsGraph = new DataSetGraph(dataset);
            Assert.That(dsGraph.Vertices.Count, Is.EqualTo(7));
        }

        [Test]
        public void ComputeDFSItineraryTest()
        {

            IList<IVertex> verticesRoute = DFS.ComputeItinerary(new DataSetGraph(new DataSetGraphTest()));

            Assert.That(verticesRoute[0].Label, Is.EqualTo("DataTable4"));
            Assert.That(verticesRoute[1].Label, Is.EqualTo("DataTable3"));
            Assert.That(verticesRoute[2].Label, Is.EqualTo("DataTable2"));
            Assert.That(verticesRoute[3].Label, Is.EqualTo("DataTable1"));
            Assert.That(verticesRoute[4].Label, Is.EqualTo("DataTable5"));
            Assert.That(verticesRoute[5].Label, Is.EqualTo("DataTable7"));
            Assert.That(verticesRoute[6].Label, Is.EqualTo("DataTable6"));
        }
    }
}
