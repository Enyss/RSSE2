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


        public Model( RSSE2.Model model )
        {
            scene = SceneManager.Instance;
            this.model = model;
        }

        public void Load()
        {
            scene.mdlManager.Load(model.mesh);
            scene.shaderManager.Load(model.material.shader);
            if (model.material.textures.Count > 0)
            {
                scene.textureManager.Load(model.material.textures[0]);
            }
            SetVAO();
        }

        private void SetVAO()
        {
            /* set the current shader program */
            GL.UseProgram( scene.shaderManager.shader[model.material.shader] );

            /* create the VAO */
            VAOhandle = GL.GenVertexArray();
            GL.BindVertexArray(VAOhandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, scene.mdlManager.models[model.mesh].VBOhandle);

            /* set attrib locations */
            int index = GL.GetAttribLocation(scene.shaderManager.shader[model.material.shader], "vertexPosition");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 3, VertexAttribPointerType.Float, false, 14 * 4, 0);

            index = GL.GetAttribLocation(scene.shaderManager.shader[model.material.shader], "vertexUV");
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, 2, VertexAttribPointerType.Float, false, 14 * 4, 12 * 4);
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
            if (model.material.textures.Count == 0)
                return;

            SceneManager scene = SceneManager.Instance;

            /* set the current shader program */
            GL.UseProgram(scene.shaderManager.shader[model.material.shader]);

            /* set the texture */
            int index = GL.GetUniformLocation(scene.shaderManager.shader[model.material.shader], "textureSampler");
            GL.Uniform1(index, 0);
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, scene.textureManager.loadedTexture[model.material.textures[0]]);
            
            /* set the MVP matrix */
            index = GL.GetUniformLocation(scene.shaderManager.shader[model.material.shader], "MVP");
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
