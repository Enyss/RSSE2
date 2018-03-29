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
        private RSSE2.Model model;
        private int VAOhandle;
        private int shader;

        public bool selected;

        public Model( RSSE2.Model model )
        {
            scene = SceneManager.Instance;
            this.model = model;
        }

        public void Load()
        {
            scene.mdlManager.Load(model.mesh);
            scene.textureManager.Load(model.material.textures[0]);

            VAOhandle = GL.GenVertexArray();
        }

        public void LoadMdl()
        {
            Mdl mdl = scene.mdlManager.models[model.mesh];
            /* Buffer the VBO */
            GL.BindBuffer(BufferTarget.ArrayBuffer, mdl.VBOhandle);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * mdl.VBO.Length,
                mdl.VBO, BufferUsageHint.StreamDraw);

            /* Buffer the Indexes */
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mdl.IndexesHandle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(ushort) * mdl.Indexes.Length,
                mdl.Indexes, BufferUsageHint.StreamDraw);
        }

        public void Draw(Matrix4 MVP)
        {
            if (model.material.textures[0] == null)
                return;

            SceneManager scene = SceneManager.Instance;

            /* set the current shader program */
            shader = scene.shaderManager.shader[selected ? "Selected.shader" : "Base.shader"];
            GL.UseProgram(shader);            

            /* set the texture */
            int index = GL.GetUniformLocation(shader, "textureSampler");
            GL.Uniform1(index, 0);
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, scene.textureManager.loadedTexture[model.material.textures[0]]);

            /* set attrib locations */
            GL.BindVertexArray(VAOhandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, scene.mdlManager.models[model.mesh].VBOhandle);

            index = GL.GetAttribLocation(shader, "vertexPosition");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 14 * 4, 0);

            index = GL.GetAttribLocation(shader, "vertexUV");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 2, VertexAttribPointerType.Float, false, 14 * 4, 12 * 4);

            /* set the MVP matrix */
            index = GL.GetUniformLocation(shader, "MVP");
            GL.UniformMatrix4(index, false, ref MVP);

            /* bind the VAO */
            GL.BindVertexArray(VAOhandle);

            /* Get the Model */
            Mdl mdl = scene.mdlManager.models[model.mesh];

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
