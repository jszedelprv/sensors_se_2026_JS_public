using System;
using System.Drawing;
using Examples.Shaders;
using ObjectTK.Buffers;
using ObjectTK.Shaders;
using ObjectTK.Textures;
using ObjectTK.Tools.Shapes;
using ObjectTK.Tools.Cameras;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ShapeVisualizer
{
    public class ViewParameters
    {
        public ViewParameters()
        {
            XRotationAngle = YRotationAngle = ZRotationAngle = 0.0f;
            FieldOfView = MathHelper.PiOver4;
        }

        public float XRotationAngle
        {
            set => rotationAngles[(int)RotationAxis.X] = value;
            get => rotationAngles[(int)RotationAxis.X];
        }
        public float YRotationAngle
        {
            set => rotationAngles[(int)RotationAxis.Y] = value;
            get => rotationAngles[(int)RotationAxis.Y];
        }
        public float ZRotationAngle
        {
            set => rotationAngles[(int)RotationAxis.Z] = value;
            get => rotationAngles[(int)RotationAxis.Z];
        }

        public float FieldOfView { get; set; }
       
        private volatile float[] rotationAngles = new float[3];

        public enum RotationAxis { X = 0, Y, Z };

        public float AngleOfAxis( RotationAxis pAxis ) => rotationAngles[(int)pAxis];
    }


    public class GLControlShapeVisualizer
    {
        // The OpenTK library WinForms GLControl in which the visualization is shown
        GLControl visualizerGLControl;

        public GLControl VisualizerGLControl
        {
            set => visualizerGLControl = value;
        }

        // OpenTK objects and ObjectTK abstraction layer objects used for visualization
       Texture2D texture;

        SimpleTextureProgram textureProgram;
        TexturedCube cube;
        VertexArray cubeVao;

        Camera camera;

        Matrix4 baseView;
        Matrix4 modelView;
        Matrix4 projection;
        Matrix4 objectView;

        // GLControlShapeVisualizer own fields and properties
        readonly Vector3[] rotateVectors = new[] { Vector3.Zero, Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ, Vector3.One };
        
        ViewParameters currentViewParameters;
        public ViewParameters CurrentViewParameters
        {
            set => currentViewParameters = value;
            get => currentViewParameters;
        }

        // Public methods
        public GLControlShapeVisualizer()
        {
            camera = new Camera();
            currentViewParameters = new ViewParameters();
        }
        
        public void Initialize()
        {
            // disable vsync
            visualizerGLControl.VSync = false;

            // set up camera
            camera.DefaultState.Position.Z = 5;
            camera.ResetToDefault();

            ResetMatrices();
        }

        // Private methods
        private void ResetMatrices()
        {
            modelView = Matrix4.Identity;
            projection = Matrix4.Identity;
        }

        private void SetupPerspective()
        {
            // setup perspective projection
            projection = Matrix4.CreatePerspectiveFieldOfView(currentViewParameters.FieldOfView, GLControlAspectRatio(), 0.1f, 1000);
            modelView = Matrix4.Identity;

            // apply camera transform
            modelView = camera.GetCameraTransform();
        }
        private void UpdateRotationAxis(ViewParameters.RotationAxis pAxis)
        {
            float angle = currentViewParameters.AngleOfAxis(pAxis);

            // rotate axis
            int rotateIndex = RotateVectorIndexFromAxis(pAxis);
            objectView *= Matrix4.CreateFromAxisAngle(rotateVectors[rotateIndex], angle);
        }

        private int RotateVectorIndexFromAxis(ViewParameters.RotationAxis pAxis) => (int)pAxis + 1;

        public void UpdateView()
        {
            // determinate object view rotation vectors and apply them
            objectView = baseView;

            // update rotation
            UpdateRotationAxis(ViewParameters.RotationAxis.X);
            UpdateRotationAxis(ViewParameters.RotationAxis.Y);
            UpdateRotationAxis(ViewParameters.RotationAxis.Z);

            // update projaction
            float fovy = currentViewParameters.FieldOfView;
            fovy += (fovy <= 0.0001f ? 0.0001f : 0.0f) + (fovy >= 0.9999 ? -0.0001f : 0.0f); // prevent not allowed border values (0.0 and PI)
            projection = Matrix4.CreatePerspectiveFieldOfView(fovy, GLControlAspectRatio(), 0.1f, 1000);

            visualizerGLControl.Invalidate();
        }

        public void GLControlOnLoad()
        {
            // set search path for shader files and extension
            ProgramFactory.BasePath = "Data/Shaders/";
            ProgramFactory.Extension = "glsl";

            // load texture from file
            using (var bitmap = new Bitmap("Data/Textures/viacara_kai_logo_red.png"))
            {
                BitmapTexture.CreateCompatible(bitmap, out texture);
                texture.LoadBitmap(bitmap);
            }

            // initialize shaders
            textureProgram = ProgramFactory.Create<SimpleTextureProgram>();

            // initialize cube object and base view matrix
            objectView = baseView = Matrix4.Identity;

            // initialize demonstration geometry
            cube = new TexturedCube();
            cube.UpdateBuffers();

            // set up vertex attributes for the quad
            cubeVao = new VertexArray();
            cubeVao.Bind();
            cubeVao.BindAttribute(textureProgram.InPosition, cube.VertexBuffer);
            cubeVao.BindAttribute(textureProgram.InTexCoord, cube.TexCoordBuffer);

            // enable culling, our cube vertices are defined inside out, so we flip them
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            // set nice clear color
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        }

        public void GLControlOnPaint()
        {
            // set up viewport
            GL.Viewport(0, 0, visualizerGLControl.Width, visualizerGLControl.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // set transformation matrix
            textureProgram.Use();
            textureProgram.ModelViewProjectionMatrix.Set(objectView * modelView * projection);

            // render cube with texture
            cubeVao.Bind();
            cubeVao.DrawArrays(cube.DefaultMode, 0, cube.VertexBuffer.ElementCount);

            // swap buffers
            visualizerGLControl.SwapBuffers();
        }

        public void GLControlOnResize()
        {
            SetupPerspective();
            
            visualizerGLControl.Invalidate();
        }

        public void CleanUpObjects()
        {
            texture?.Dispose();
            textureProgram?.Dispose();
            cube?.Dispose();
            cubeVao?.Dispose();
        }

        private float GLControlAspectRatio() => (visualizerGLControl.Width / (float)visualizerGLControl.Height);
    }
}
