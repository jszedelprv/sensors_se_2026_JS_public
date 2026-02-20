using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyKai.General;

namespace MyKai.Gesture.Test
{
    /// <summary>
    /// Summary description for GestureCursorDataTest
    /// </summary>
    [TestClass]
    public partial class GestureCursorDataTest
    {

    //    public GestureCursorDataTest()
    //    {

    //    }

    //    TestContext testContextInstance;

    //    /// <summary>
    //    ///Gets or sets the test context which provides
    //    ///information about and functionality for the current test run.
    //    ///</summary>
    //    public TestContext TestContext
    //    {
    //        get
    //        {
    //            return testContextInstance;
    //        }
    //        set
    //        {
    //            testContextInstance = value;
    //        }
    //    }

    //    #region Additional test attributes
    //    //
    //    // You can use the following additional attributes as you write your tests:
    //    //
    //    // Use ClassInitialize to run code before running the first test in the class
    //    // [ClassInitialize()]
    //    // public static void MyClassInitialize(TestContext testContext) { }
    //    //
    //    // Use ClassCleanup to run code after all tests in a class have run
    //    // [ClassCleanup()]
    //    // public static void MyClassCleanup() { }
    //    //
    //    // Use TestInitialize to run code before running each test 
    //    // [TestInitialize()]
    //    // public void MyTestInitialize() { }
    //    //
    //    // Use TestCleanup to run code after each test has run
    //    // [TestCleanup()]
    //    // public void MyTestCleanup() { }
    //    //
    //    #endregion

    //    [TestMethod]
    //    public void GestureCursorCreateTest()
    //    {
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        Assert.IsNotNull(cur);
    //    }

    //    [TestMethod]
    //    public void SetPosition_ParametersAreCorrectAndAngleLimitIsPIOver4()
    //    {
    //        // Arrange - the individual part
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();
    //        (float xPos, float yPos)[] positions = { (0.0f, 0.0f), (0.5f, 0.0f), (1.0f, 0.0f), (1.0f, 0.5f), (1.0f, 1.0f), (0.5f, 1.0f),
    //                                                 (0.0f, 1.0f), (0.0f, 0.5f)};
            
    //        // Arrange/Act/Assert - the generic part
    //        Cursor2DTest_ParametersCorrect(null, cur.SetPosition, (0,0), positions);
    //    }

    //    // The structure as above is also applied in the remaining tests

    //    [TestMethod]
    //    public void SetPosition_ParametersAreOutOfRange()
    //    {
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();
    //        (float xPos, float yPos)[] positions = { (0.0f,-2.0f), (0.0f, 3.0f), (3.0f, 0.0f), (-4.0f, 0.0f), (-10.0f, -2.0f), (3.0f, 2.0f),
    //                                                 (4.2f, 2.4f), (1.1f, 2.9f)};
            
    //        Cursor2DTest_ParametersOutOfRange<ignore_T, float, Gesture2DCursorData.PositionData.InvalidGestureCursorPosition>(null, cur.SetPosition, (0, 0), positions);
    //    }

    //    [TestMethod]
    //    public void SetPosition_CheckCalculations()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (float xPos, float yPos)[] positions = { (0.0f, 0.0f), (0.5f, 0.0f), (1.0f, 0.0f), (1.0f, 0.5f), (1.0f, 1.0f),
    //                                                 (0.5f, 1.0f), (0.0f, 1.0f), (0.0f, 0.5f) };

    //        (float xAngle, float yAngle)[] angles = { (-pi4, -pi4), (0.0f, -pi4), (pi4, -pi4), (pi4, 0.0f), (pi4, pi4),
    //                                                  (0.0f, pi4), (-pi4, pi4), (-pi4, 0.0f) };

    //        Cursor2DTest_CheckCalculations(null, cur.Data.GetAngles, cur.SetPosition, (0, 0), positions, angles);
 
    //    }
    //    [TestMethod]
    //    public void SetPositionInPixels_ParametersAreCorrect()
    //    {
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (int xPos, int yPos)[] positions = { (0, 0), (50, 0), (100, 0), (100, 50), (100, 100), (50, 100),
    //                                             (0,100), (0, 50)};

    //        Cursor2DTest_ParametersCorrect(cur.SetViewportSize, cur.SetPositionInPixels, (100, 100), positions);
    //    }

    //    [TestMethod]
    //    public void SetPositionInPixels_ParametersAreOutOfRange()
    //    {
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (int xPos, int yPos)[] positions = { (0, -1), (0, 101), (-1, 0), (101, 0), (-1, -1), (101, 101),
    //                                             (0,-10), (0, 130), (-200, 0), (120, 0), (-100, -100), (200, 101)};

    //        Cursor2DTest_ParametersOutOfRange<int, int, Gesture2DCursorData.PositionInPixelsData.InvalidGestureCursorPositionInPixels>
    //                                           (cur.SetViewportSize, cur.SetPositionInPixels, (100, 100), positions);
    //    }

    //    [TestMethod]
    //    public void SetPositionInPixels_CheckCalculatins()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (int xPos, int yPos)[] positions = { (0, 0), (50, 0), (100, 0), (100, 50), (100, 100), (50, 100),
    //                                             (0,100), (0, 50)};

    //        (float xAngle, float yAngle)[] angles = { (-pi4, -pi4), (0.0f, -pi4), (pi4, -pi4), (pi4, 0.0f), (pi4, pi4),
    //                                                  (0.0f, pi4), (-pi4, pi4), (-pi4, 0.0f) };

    //        Cursor2DTest_CheckCalculations(cur.SetViewportSize, cur.Data.GetAngles, cur.SetPositionInPixels, (100, 100), positions, angles);
    //    }

    //    [TestMethod]
    //    public void SetAngularData_ParametersAreCorrect()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (float xAngle, float yAngle)[] angles = { (-pi4, -pi4), (0.0f, -pi4), (pi4, -pi4), (pi4, 0.0f), (pi4, pi4),
    //                                                  (0.0f, pi4), (-pi4, pi4), (-pi4, 0.0f) };
            
    //        Cursor2DTest_ParametersCorrect(cur.SetViewportSize, cur.SetPositionUsingAngularData, (100, 100), angles);
    //    }

    //    [TestMethod]
    //    public void SetAngularData_ParametersAreOutOfRange()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (float xAngle, float yAngle)[] angles = { (0, -pi4-1e10f), (0, pi4+1e10f), (-pi4-1e10f, 0), (pi4+1e10f, 0), 
    //                                                  (-pi4-1e10f, -pi4-1e10f), (pi4+1e10f, pi4+1e10f), (0, -pi4-1), 
    //                                                  (0, pi4+1), (-pi4-1, 0), (pi4+1, 0), (-pi4-1, -pi4-1), (pi4+1, pi4+1) };

    //        Cursor2DTest_ParametersOutOfRange<int, float, Gesture2DCursorData.AngularData.InvalidGestureCursorAngle>
    //                                                         (cur.SetViewportSize,cur.SetPositionUsingAngularData, (100, 100), angles);
    //    }

    //    [TestMethod]
    //    public void SetAngular_CheckCalculatins_NormalizedPosition()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (float xAngle, float yAngle)[] angles = { (-pi4, -pi4), (0.0f, -pi4), (pi4, -pi4), (pi4, 0.0f), (pi4, pi4),
    //                                                  (0.0f, pi4), (-pi4, pi4), (-pi4, 0.0f) };            
            
    //        (int xPos, int yPos)[] positions = { (0, 0), (50, 0), (100, 0), (100, 50), (100, 100), (50, 100),
    //                                             (0,100), (0, 50)};

    //        Cursor2DTest_CheckCalculations(cur.SetViewportSize, cur.Data.GetPositionInPixels, cur.SetPositionUsingAngularData, (100, 100), angles, positions);
    //    }

    //    [TestMethod]
    //    public void SetAngular_CheckCalculatins_PositionInPixels()
    //    {
    //        const float pi4 = (float)Math.PI / 4;
    //        Gesture2DCursorBase cur = new BuilderOfGesture2DCursor().Build();

    //        (float xAngle, float yAngle)[] angles = { (-pi4, -pi4), (0.0f, -pi4), (pi4, -pi4), (pi4, 0.0f), (pi4, pi4),
    //                                                  (0.0f, pi4), (-pi4, pi4), (-pi4, 0.0f) };

    //        (float xPos, float yPos)[] positions = { (0.0f, 0.0f), (0.5f, 0.0f), (1.0f, 0.0f), (1.0f, 0.5f), (1.0f, 1.0f),
    //                                                 (0.5f, 1.0f), (0.0f, 1.0f), (0.0f, 0.5f) };

    //        Cursor2DTest_CheckCalculations(cur.SetViewportSize, cur.Data.GetPosition, cur.SetPositionUsingAngularData, (100, 100), angles, positions);
    //    }
    }
}
