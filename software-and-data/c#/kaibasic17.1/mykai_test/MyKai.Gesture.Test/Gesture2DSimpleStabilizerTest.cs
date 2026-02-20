using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyKai.Gesture;

namespace MyKai.Gesture.Test
{
    /// <summary>
    /// Summary description for Gesture2DSimpleStabilizer
    /// </summary>
    [TestClass]
    public class Gesture2DSimpleStabilizerTest
    {
        public Gesture2DSimpleStabilizerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddCoordinates()
        {
            IGesture2DIsStableChecker stabilizer = new Gesture2DIsStableChecker();

            (float xPos, float yPos)[] positions = { (0.0f, 0.0f), (0.5f, 0.0f), (1.0f, 0.0f), (1.0f, 0.5f), (1.0f, 1.0f), (0.5f, 1.0f),
                                                     (0.0f, 1.0f), (0.0f, 0.5f)};
        }
    }
}
