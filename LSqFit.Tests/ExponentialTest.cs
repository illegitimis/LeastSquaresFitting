namespace LeastSquares.Tests
{
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;    
    
    /// <summary>
    ///This is a test class for ExponentialTest and is intended
    ///to contain all ExponentialTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExponentialTest
    {
        static IEnumerable<float> myx = null;
        static IEnumerable<float> expD = null;
        static IEnumerable<float> expC = null;
        static IEnumerable<float> expB = null;
        static IEnumerable<float> expA = null;
        private TestContext testContextInstance;
        const float EXP_MINUS_06 = 0.000001f;
        const float EXP_MINUS_05 = 0.00001f;
        const float EXP_MINUS_04 = 0.0001f;

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            myx = Enumerable.Range(1, 30).Select(i => (float)i);
            //
            expD = new float[] {
                  	   0.162782f
 ,   0.196937f
 ,   0.231875f
 ,   0.28132f
 ,   0.349377f
 ,   0.432615f
 ,   0.518176f
 ,   0.643894f
 ,   0.788454f
 ,   0.966577f
 ,   1.181252f
 ,   1.428013f
 ,   1.757286f
 ,   2.138804f
 ,   2.61012f
 ,   3.188229f
 ,   3.898333f
 ,   4.76277f
 ,   5.806154f
 ,   7.09376f
 ,   8.666223f
 ,   10.578613f
 ,   12.938961f
 ,   15.806354f
 ,   19.301711f
 ,   23.566391f
 ,   28.772834f
 ,   35.165433f
 ,   42.942943f
 ,     52.453743f
 };
            //
            expC = new float[] {
                      1.109171f
                    , 1.224403f
                    , 1.344859f
                    , 1.483825f
                    , 1.644721f
                    , 1.823119f
                    , 2.004753f
                    , 2.225541f
                    , 2.461603f
                    , 2.724282f
                    , 3.012166f
                    , 3.315117f
                    , 3.676297f
                    , 4.0562f
                    , 4.480689f
                    , 4.952032f
                    , 5.476947f
                    , 6.054647f
                    , 6.680894f
                    , 7.385056f
                    ,  8.16317f
                    , 9.015013f
                    , 9.980182f
                    , 11.033176f
                    , 12.190494f
                    , 13.464738f
                    , 14.869732f
                    , 16.454647f
                    , 18.178145f
                    , 20.093537f              	
           };
            //
            expB = new float[] {
                  	0.158782f	
                   ,	0.193937f	
                   ,	0.236875f	
                   ,	0.28932f    
                   ,	0.353377f	
                   ,	0.431615f	
                   ,	0.527176f	
                   ,	0.643894f	
                   ,	0.786454f	
                   ,	0.960577f	
                   ,	1.173252f	
                   ,	1.433013f	
                   ,	1.750286f	
                   ,   2.137804f	    
                   ,	2.61112f	    
                   ,	3.189229f	
                   ,	3.895333f	
                   ,	4.75777f    
                   ,	5.811154f	
                   ,	7.09776f	    
                   ,   8.669223f	    
                   ,	10.588613f	
                   ,	12.932961f	
                   ,	15.796354f	
                   ,	19.293711f	
                   ,	23.565391f	
                   ,	28.782834f	
                   ,	35.155433f	
                   ,	42.938943f	
                   ,	52.445743f
           };
            //
            expA = new float[] {
                1.105171f
                ,1.221403f
                ,1.349859f
                ,1.491825f
                ,1.648721f
                ,1.822119f
                ,2.013753f
                ,2.225541f
                ,2.459603f
                ,2.718282f
                ,3.004166f
                ,3.320117f
                ,3.669297f
                ,4.0552f	 
                ,4.481689f
                ,4.953032f
                ,5.473947f
                ,6.049647f
                ,6.685894f
                ,7.389056f
                ,8.16617f	 
                ,9.025013f
                ,9.974182f
                ,11.023176f
                ,12.182494f
                ,13.463738f
                ,14.879732f
                ,16.444647f
                ,18.174145f
                ,20.085537f
            };
        }
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
        ///A test for 1*exp(0.1x) 
        ///</summary>
        [TestMethod()]
        public void ATest()
        {
            var expfit = new Exponential ( myx, expA);
            Assert.AreEqual(expfit.A, 1f, EXP_MINUS_06);
            Assert.AreEqual(expfit.B, 0.1f, EXP_MINUS_06);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }

        /// <summary>
        ///test for 0.13*exp(0.2x)
        ///</summary>
        [TestMethod()]
        public void BTest()
        {
          var expfit = new Exponential (myx, expB);
            Assert.AreEqual(expfit.A, 0.13f, EXP_MINUS_06);
            Assert.AreEqual(expfit.B, 0.2f, EXP_MINUS_06);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }

         /// <summary>
        ///test for  1*exp(0.1x)+rnd(-1,1) 
        ///excel rounds to 4 places
        ///</summary>
        [TestMethod()]
        public void CTest()
        {
            var expfit = new Exponential(myx, expC);
            Assert.AreEqual(expfit.A, 0.9995f, EXP_MINUS_04);
            Assert.AreEqual(expfit.B, 0.1f, EXP_MINUS_04);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_05);
        }

         /// <summary>
        ///test for  0.13*exp(0.2x)+rnd(-1,1)
        ///excel rounds to 4 places
        ///</summary>
        [TestMethod()]
        public void DTest()
        {
            var expfit = new Exponential (myx, expD);
            Assert.AreEqual(expfit.A, 0.1297f, EXP_MINUS_04);
            Assert.AreEqual(expfit.B, 0.2001f, EXP_MINUS_04);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        ///A test for 1*exp(0.1x) 
        ///</summary>
        [TestMethod()]
        public void AOTest()
        {
            var expfit = new ExponentialOptimum(myx, expA);
            Assert.AreEqual(expfit.A, 1f, EXP_MINUS_06);
            Assert.AreEqual(expfit.B, 0.1f, EXP_MINUS_06);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }

        /// <summary>
        ///test for 0.13*exp(0.2x)
        ///</summary>
        [TestMethod()]
        public void BOTest()
        {
            var expfit = new ExponentialOptimum(myx, expB);
            Assert.AreEqual(expfit.A, 0.13f, EXP_MINUS_06);
            Assert.AreEqual(expfit.B, 0.2f, EXP_MINUS_06);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }


        /// <summary>
        ///test for  1*exp(0.1x)+rnd(-1,1) 
        ///excel rounds to 4 places
        ///</summary>
        [TestMethod()]
        public void COTest()
        {
            var expfit = new ExponentialOptimum(myx, expC);
            Assert.AreEqual(expfit.A, 0.9996f, EXP_MINUS_04);
            Assert.AreEqual(expfit.B, 0.1f, EXP_MINUS_04);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_05);
        }

        /// <summary>
        ///test for  0.13*exp(0.2x)+rnd(-1,1)
        ///excel rounds to 4 places
        ///</summary>
        [TestMethod()]
        public void DOTest()
        {
            var expfit = new ExponentialOptimum(myx, expD);
            Assert.AreEqual(expfit.A, 0.13f, EXP_MINUS_04);
            Assert.AreEqual(expfit.B, 0.2f, EXP_MINUS_04);
            Assert.AreEqual(expfit.R2, 1f, EXP_MINUS_06);
        }
    }
}
