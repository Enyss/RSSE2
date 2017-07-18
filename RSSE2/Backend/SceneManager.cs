using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace RSSE2.Backend
{
    public class SceneManager
    {
        #region Singleton pattern

        private static readonly Lazy<SceneManager> lazy = new Lazy<SceneManager>(() => new SceneManager());

        public static SceneManager Instance { get { return lazy.Value; } }

        #endregion

        private GLControl glControl;
        public GLControl Control { get { return glControl; } }

        public ShaderLoader shaderLoader;
        public TexLoader texLoader;
        public MdlLoader mdlLoader;

        public Dictionary<Part, Model> parts;

        private SceneManager()
        {
            var flags = GraphicsContextFlags.Default;
            glControl = new GLControl(new GraphicsMode(32, 24), 2, 0, flags);
            glControl.MakeCurrent();
            glControl.Paint += Paint;
            glControl.Width = 800;
            glControl.Height = 600;

            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            GL.DepthRange(0.1, 500.0);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.ClearColor(System.Drawing.Color.SkyBlue);

            shaderLoader = new ShaderLoader();
            texLoader = new TexLoader();
            mdlLoader = new MdlLoader();

            parts = new Dictionary<Part, Model>();
        }

        public void LoadPart(Part part)
        {
            if (parts.ContainsKey(part))
                return;
            if (!part.components.ContainsKey("Model"))
                return;

            parts.Add(part, new Model((RSSE2.Model)part.components["Model"]) );
            var error = GL.GetError();
            parts[part].Load();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Paint();
        }

        public void Paint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 P = Matrix4.CreateOrthographic(80, 60, 0.1f, 100); /*Matrix4.CreatePerspectiveFieldOfView(
MathHelper.PiOver2, 4f / 3, 0.1f, 100f);*/
            Matrix4 V = Matrix4.LookAt(
                new OpenTK.Vector3(15, 0, 0),
                new OpenTK.Vector3(0, 0, 0),
                new OpenTK.Vector3(0, 1, 0));

            Matrix4 VP = V*P;

            foreach ( KeyValuePair<Part,Model> pair in parts )
            {
                Matrix4 rotX = Matrix4.CreateRotationX(-(float)pair.Key.rotation.x / 180 * MathHelper.Pi);
                Matrix4 rotY = Matrix4.CreateRotationY(-(float)pair.Key.rotation.z / 180 * MathHelper.Pi);
                Matrix4 rotZ = Matrix4.CreateRotationZ((float)pair.Key.rotation.y / 180 * MathHelper.Pi);
                Matrix4 trans = Matrix4.CreateTranslation((float)pair.Key.position.x, (float)pair.Key.position.z, (float)pair.Key.position.y);
                Matrix4 T = rotZ * rotX * rotY * trans;
                pair.Value.Draw(T*VP);
            }

            glControl.SwapBuffers();
        }
    }
}
