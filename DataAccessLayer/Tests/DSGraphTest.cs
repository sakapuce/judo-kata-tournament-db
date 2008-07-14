using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DALHelper.Tests
{
    [TestFixture]
    public class DSGraphTest
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
        public void TestDataSetGraphConstructor()
        {
            DataSetGraphTest dataset = new DataSetGraphTest();
            DataSetGraph dsGraph = new DataSetGraph(dataset);
            Assert.That(dsGraph.Vertices.Count, Is.EqualTo(5));
        }

        [Test]
        public void ComputeExecutionPlanTest()
        {
            DataSetGraphTest dataset = new DataSetGraphTest();
            DataSetGraph dsGraph = new DataSetGraph(dataset);
            IList<IVertex> verticesRoute = dsGraph.ComputeExecutionPlan();

            Assert.That(verticesRoute[0].Label, Is.EqualTo("DataTable4"));
            Assert.That(verticesRoute[1].Label, Is.EqualTo("DataTable3"));
            Assert.That(verticesRoute[2].Label, Is.EqualTo("DataTable2"));
            Assert.That(verticesRoute[3].Label, Is.EqualTo("DataTable1"));
            Assert.That(verticesRoute[4].Label, Is.EqualTo("DataTable5"));
        }
    }
}
