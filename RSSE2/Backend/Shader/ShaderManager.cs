using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE2
{
    public class ShaderManager
    {

        public Dictionary<string, int> shader;

        public ShaderManager()
        {
            shader = new Dictionary<string, int>();
        }

        public void Load(string name)
        {
            if (shader.ContainsKey(name))
                return;

            string filename = "test.shader"; //Application.Instance.Settings.RSFolder + @"Shaders\rsGeneral\" + name + ".shader";
            List<string> file = File.ReadAllLines(filename).ToList();

            shader.Add(name, GL.CreateProgram());

            int vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            string vertexShader = GetVertexShader(file);
            GL.ShaderSource(vertexShaderHandle, vertexShader);
            GL.CompileShader(vertexShaderHandle);
            string log1 = GL.GetShaderInfoLog(vertexShaderHandle);

            int fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);
            string fragmentShader = GetFragmentShader(file);
            GL.ShaderSource(fragmentShaderHandle, fragmentShader);
            GL.CompileShader(fragmentShaderHandle);
            string log2 = GL.GetShaderInfoLog(fragmentShaderHandle);


            GL.AttachShader(shader[name], vertexShaderHandle);
            GL.AttachShader(shader[name], fragmentShaderHandle);
            GL.LinkProgram(shader[name]);
            GL.DetachShader(shader[name], vertexShaderHandle);
            GL.DetachShader(shader[name], fragmentShaderHandle);
            string log = GL.GetProgramInfoLog(shader[name]);

        }

        private string GetVertexShader( List<string> file )
        {
            string result = "";
            int i = 0;
            while (i < file.Count && !file[i].StartsWith("@OpenGL4.Vertex") )
            {
                i++;
            }
            if ( i != file.Count )
            {
                i++;
                while (i < file.Count && !file[i].StartsWith("@OpenGL"))
                {
                    result = result + file[i] + "\n";
                    i++;
                }
            }
            return result;
        }

        private string GetFragmentShader(List<string> file)
        {
            string result = "";
            int i = 0;
            while (i < file.Count && !file[i].StartsWith("@OpenGL4.Fragment"))
            {
                i++;
            }
            if (i != file.Count)
            {
                i++;
                while (i < file.Count && !file[i].StartsWith("@OpenGL"))
                {
                    result = result + file[i] + "\n";
                    i++;
                }
            }
            return result;
        }
    }
}
