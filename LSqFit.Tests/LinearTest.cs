using LeastSquares;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LeastSquares.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///This is a test class for LinearTest and is intended
    ///to contain all LinearTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LinearTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Intercept
        ///</summary>
        [TestMethod()]
        public void IdentityPts()
        {
            var llsi = new Linear(new Point[] 
        {
            new Point {x=1, y=1}, new Point {x=1, y=1.1f}, new Point {x=1, y=0.9f}
            , 
            new Point {x=2, y=2}, new Point {x=2, y=2.1f}, new Point {x=2, y=1.9f}
            , 
            new Point {x=3, y=3}, new Point {x=3, y=3.1f}, new Point {x=3, y=2.9f}
            , 
            new Point {x=10, y=10}, new Point {x=10, y=10.1f}, new Point {x=10, y=9.9f}
            ,
            new Point{x=100, y=100},new Point{x=100, y=100.1f},new Point{x=100,y=99.9f}
        });

            Assert.AreEqual(llsi.Slope, 1f);
            Assert.AreEqual(llsi.Intercept, 0f);
            Assert.AreEqual(llsi.R2, 1f);
        }

        /// <summary>
        ///A test for Slope
        ///</summary>
        [TestMethod()]
        public void IdentityDuplicatesAr()
        {
            var llsi = new Linear(
                new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                ,
                new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );

            Assert.AreEqual(llsi.Count, 18);
            Assert.AreEqual(llsi.CountUnique, 9);
            Assert.AreEqual(llsi.Slope, 1f);
            Assert.AreEqual(llsi.Intercept, 0f);
            Assert.AreEqual(llsi.R2, 1f);
        }

        [TestMethod()]
        //(1, 6), (2, 5), (3, 7), and (4, 10)
        public void WikiPts()
        {
            var llsi = new Linear(new Point[] {
                new Point {x=1, y=6}, new Point {x=2, y=5}, new Point {x=3, y=7} ,  new Point {x=4, y=10} 
            });
            Assert.AreEqual(llsi.Slope, 1.4f);
            Assert.AreEqual(llsi.Intercept, 3.5f);
            Assert.AreEqual(llsi.R2, 0.7f, 0.000001f);
        }
    }
}

