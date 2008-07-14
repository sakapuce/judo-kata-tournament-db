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
            //foreach (IVertex vertex in dsGraph.Vertices)
            //{
            //    Console.WriteLine(string.Format("Vertex: {0}",vertex.Label));
            //    Assert.That(vertex.Color,Is.EqualTo(VerticeColor.White));
            //}
        }

        [Test]
        public void ComputeExecutionPlanTest()
        {
            DataSetGraphTest dataset = new DataSetGraphTest();
            DataSetGraph dsGraph = new DataSetGraph(dataset);
            IList<IVertex> verticesRoute = dsGraph.ComputeExecutionPlan();
            foreach(IVertex vertex in verticesRoute)
            {
                Console.WriteLine(string.Format("Vertex: {0}", vertex.Label));
            }
        }
    }
}
