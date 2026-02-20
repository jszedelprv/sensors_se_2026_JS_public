
using ShapeVisualizer;


namespace MyKai.General
{
    public class BuilderOfGLControlShapeVisualizer : MyKaiBuilderBase<GLControlShapeVisualizer>
    {
        public BuilderOfGLControlShapeVisualizer WithVisualizerGLControl(OpenTK.GLControl pGLControl)
        {
            instance.VisualizerGLControl = pGLControl;
            return this;
        }

        public GLControlShapeVisualizer BuildAndInitialize()
        {
            instance.Initialize();
            return instance;
        }
    }
}
