using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace RSSE2.Backend
{
    public class Mdl
    {
        private List<float> vertex;
        private List<float> normal;
        private List<float> binormal;
        private List<float> tangent;
        private List<float> uv1;
        private List<float> uv2;
        private List<ushort> index;
        private List<float> mdlMatrix;

        public int VAOhandle;
        public float[] VBO { get; }
        public int VBOhandle;
        public ushort[] Indexes { get; }
        public int IndexesHandle;
        public Matrix4 M;

        public Mdl(string filename)
        {
            LoadFromFile(filename);

            VBO = generateVBO();

            Indexes = index.ToArray();

            M = new Matrix4(
                mdlMatrix[0], mdlMatrix[1], mdlMatrix[2], mdlMatrix[3],
                mdlMatrix[4], mdlMatrix[5], mdlMatrix[6], mdlMatrix[7],
                mdlMatrix[8], mdlMatrix[9], mdlMatrix[10], mdlMatrix[11],
                mdlMatrix[12], mdlMatrix[13], mdlMatrix[14], mdlMatrix[15]);
        }

        private void LoadFromFile(string filename)
        {
            BinaryReader b = new BinaryReader(File.Open(filename, FileMode.Open));
            int size;

            // Header
            b.ReadBytes(16);

            // mdlMatrix
            b.ReadInt32(); //Type, should equal 3
            b.ReadInt32(); //Type, should equal 3
            size = b.ReadInt32();

            mdlMatrix = new List<float>(16);
            for (int i = 0; i < size / 4; i++)
            {
                mdlMatrix.Add(b.ReadSingle());
            }

            // useless info
            while (b.PeekChar() != 5)
            {
                b.ReadInt32();
                b.ReadInt32();
                size = b.ReadInt32();
                b.ReadBytes(size);
            }


            /* The order of the following reading is important ! */
            vertex = readFloatArray(b);
            normal = readFloatArray(b);
            uv1 = readFloatArray(b);
            uv2 = readFloatArray(b);
            binormal = readFloatArray(b);
            tangent = readFloatArray(b);
            index = readShortArray(b);

            b.Dispose();
        }

        private float[] generateVBO()
        {
            int size = vertex.Count/3;

            float[] vbo = new float[size*14];

            for (int i = 0; i<size; i++)
            {
                vbo[14 * i + 0] = vertex[3 * i + 0];
                vbo[14 * i + 1] = vertex[3 * i + 1];
                vbo[14 * i + 2] = vertex[3 * i + 2];
                vbo[14 * i + 3] = normal[3 * i + 0];
                vbo[14 * i + 4] = normal[3 * i + 1];
                vbo[14 * i + 5] = normal[3 * i + 2];
                vbo[14 * i + 6] = normal[3 * i + 0];
                vbo[14 * i + 7] = normal[3 * i + 1];
                vbo[14 * i + 8] = normal[3 * i + 2];
                vbo[14 * i + 9] = tangent[3 * i + 0];
                vbo[14 * i + 10] = tangent[3 * i + 1];
                vbo[14 * i + 11] = tangent[3 * i + 2];
                vbo[14 * i + 12] = uv1[2 * i + 0];
                vbo[14 * i + 13] = uv1[2 * i + 1];
            }

            return vbo;
        }

        private List<float> readFloatArray(BinaryReader b)
        {
            List<float> array = new List<float>();

            b.ReadInt32(); //Type, should equal 5
            b.ReadInt32(); //Type, should equal 0
            b.ReadInt32(); //Size in bytes of what's next 

            int size1 = b.ReadInt32(); 
            b.ReadInt32();
            b.ReadInt32();
            int size2 = b.ReadInt32(); 

            for (int i = 0; i < size1 * size2; i++)
            {
                array.Add(b.ReadSingle());
            }

            return array;
        }

        private List<ushort> readShortArray(BinaryReader b)
        {
            List<ushort> array = new List<ushort>();

            b.ReadInt32(); //Type, should equal 5
            b.ReadInt32(); //Type, should equal 0
            b.ReadInt32(); //Size in bytes of what's next 

            int size1 = b.ReadInt32();
            b.ReadInt32();
            b.ReadInt32();

            for (int i = 0; i < size1/sizeof(UInt16) * 2; i++)
            {
                array.Add(b.ReadUInt16());
            }

            return array;
        }
    }
}
