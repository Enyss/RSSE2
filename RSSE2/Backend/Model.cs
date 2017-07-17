using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace RSSE2.Backend
{
    public class Model
    {
        private SceneManager scene;
        private Mdl mdl;
        private string shader;
        private List<string> textures;
        private int VAOhandle;


        public Model( RSSE2.Model model )
        {
            scene = SceneManager.Instance;

            mdl = new Mdl(model.mesh.filename);

            //shader = model.shader.filename;
            //scene.shaderLoader.Load(shader);
            shader = "test";
            scene.shaderLoader.Load("test");

            textures = new List<string>();
            foreach( Texture tex in model.texture )
            {
                textures.Add(tex.filename);
                scene.texLoader.Add(tex.filename);
                scene.texLoader.Load(tex.filename);
            }

            SetVAO();
        }

        private void SetVAO()
        {
            /* set the current shader program */
            GL.UseProgram( scene.shaderLoader.shader[shader] );

            /* create the VAO */
            VAOhandle = GL.GenVertexArray();
            GL.BindVertexArray(VAOhandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, mdl.VBOhandle);

            /* set attrib locations */
            int index = GL.GetAttribLocation(scene.shaderLoader.shader[shader], "vertexPosition");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 14 * 4, 0);

            index = GL.GetAttribLocation(scene.shaderLoader.shader[shader], "vertexUV");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 2, VertexAttribPointerType.Float, false, 14 * 4, 12 * 4);
        }

        public void Load()
        {
            var error = GL.GetError();
            /* Buffer the VBO */
            GL.BindBuffer(BufferTarget.ArrayBuffer, mdl.VBOhandle);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * mdl.VBO.Length,
                mdl.VBO, BufferUsageHint.StreamDraw);

            /* Buffer the Indexes */
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mdl.IndexesHandle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(ushort) * mdl.Indexes.Length,
                mdl.Indexes, BufferUsageHint.StreamDraw);
        }

        public void Draw(Matrix4 VP)
        {
            SceneManager scene = SceneManager.Instance;

            /* set the current shader program */
            GL.UseProgram(scene.shaderLoader.shader[shader]);

            /* set the texture */
            int index = GL.GetUniformLocation(scene.shaderLoader.shader[shader], "textureSampler");
            GL.Uniform1(index, 0);
            GL.ActiveTexture(TextureUnit.Texture0);
            /* temporary until mats are taken into account */
            if (textures.Count > 0)
            {
                GL.BindTexture(TextureTarget.Texture2D, scene.texLoader.loadedTexture[textures[0]]);
            }
            else
            {
                GL.BindTexture(TextureTarget.Texture2D, scene.texLoader.loadedTexture["pink"]);
            }
            
            /* set the MVP matrix */
            Matrix4 MVP = mdl.M * VP;
            index = GL.GetUniformLocation(scene.shaderLoader.shader[shader], "MVP");
            GL.UniformMatrix4(index, false, ref MVP);


            /* bind the VAO */
            GL.BindVertexArray(VAOhandle);

            /* Buffer the VBO */
            GL.BindBuffer(BufferTarget.ArrayBuffer, mdl.VBOhandle);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * mdl.VBO.Length,
                mdl.VBO, BufferUsageHint.StreamDraw);

            /* Buffer the Indexes */
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mdl.IndexesHandle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(ushort) * mdl.Indexes.Length,
                mdl.Indexes, BufferUsageHint.StreamDraw);

            /* draw the Model */
            GL.DrawElements(BeginMode.Triangles, mdl.Indexes.Length, DrawElementsType.UnsignedShort, 0);

            var error = GL.GetError();
        }
    }
}
