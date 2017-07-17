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
        private List<float> tangent;
        private List<float> binormal;
        private List<List<float>> uv;
        private List<ushort> index;
        private List<float> mdlMatrix;
        private List<List<byte>> texture;

        public int VAOhandle;
        public float[] VBO { get; }
        public int VBOhandle;
        public ushort[] Indexes { get; }
        public int IndexesHandle;
        public Matrix4 M;

        public string name;

        public Mdl(string name)
        {
            this.name = name;

            VBOhandle = GL.GenBuffer();
            IndexesHandle = GL.GenBuffer();

            uv = new List<List<float>>();
            texture = new List<List<byte>>();

            try
            {
                LoadFromFile(Application.Instance.CurrentShip.Folder + name + ".mdl");
            }
            catch
            {
                VBO = new float[] { };
                Indexes = new ushort[] { };
                return;
            }

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
            BinaryReader b;
            b = new BinaryReader(File.Open(filename, FileMode.Open));

            // Header
            b.ReadBytes(16);
            while(b.BaseStream.Position != b.BaseStream.Length)
            {
                readMdl(b);
            }
            b.Dispose();
        }

        private float[] generateVBO()
        {
            int size = vertex.Count / 3;

            float[] vbo = new float[size * 14];

            for (int i = 0; i < size; i++)
            {
                vbo[14 * i + 0] = vertex[3 * i + 0];
                vbo[14 * i + 1] = vertex[3 * i + 1];
                vbo[14 * i + 2] = vertex[3 * i + 2];
                vbo[14 * i + 3] = normal[3 * i + 0];
                vbo[14 * i + 4] = normal[3 * i + 1];
                vbo[14 * i + 5] = normal[3 * i + 2];
                vbo[14 * i + 6] = binormal[3 * i + 0];
                vbo[14 * i + 7] = binormal[3 * i + 1];
                vbo[14 * i + 8] = binormal[3 * i + 2];
                vbo[14 * i + 9] = tangent[3 * i + 0];
                vbo[14 * i + 10] = tangent[3 * i + 1];
                vbo[14 * i + 11] = tangent[3 * i + 2];
                vbo[14 * i + 12] = uv[0][2 * i + 0];
                vbo[14 * i + 13] = uv[0][2 * i + 1];
            }

            return vbo;
        }


        private void readMdl(BinaryReader b)
        {
            int type = b.ReadInt32();
            int type2 = b.ReadInt32();
            
            switch (type)
            {
                case 3 :    // Mdl Matrix
                    ReadModelMatrix(b);
                    break;
                case 5 :    // 2D Array
                    Read2DArray(b);
                    break;
                case 6 :  // Index List
                    ReadIndex(b);
                    break;
                default :
                    ReadUnknown(b);
                    break;
            }
        }

        private void ReadUnknown(BinaryReader b)
        {
            int size = b.ReadInt32();
            b.ReadBytes(size);
        }

        private void ReadModelMatrix(BinaryReader b)
        {
            int size = b.ReadInt32();

            mdlMatrix = new List<float>();
            for (int i = 0; i < size / 4; i++)
            {
                mdlMatrix.Add(b.ReadSingle());
            }
        }

        private void Read2DArray(BinaryReader b)
        {
            int size = b.ReadInt32();
            int size1 = b.ReadInt32();
            int type1 = b.ReadInt32();
            int sizeElem = b.ReadInt32();
            int size2 = b.ReadInt32();

            switch(type1)
            {
                case 1: 
                    vertex = readFloatArray(b, size1 * 3);
                    break;
                case 2:
                    normal = readFloatArray(b, size1 * 3);
                    break;
                case 3:
                    uv.Add(readFloatArray(b, size1 * 2));
                    break;
                case 4:
                    texture.Add(readByteArray(b, size1 * 4));
                    break;
                case 5:
                    tangent = readFloatArray(b, size1 * 3);
                    break;
                case 6:
                    binormal = readFloatArray(b, size1 * 3);
                    break;
            }
        }

        private void ReadIndex(BinaryReader b)
        {
            int size = b.ReadInt32();
            int size1 = b.ReadInt32();
            int type1 = b.ReadInt32();
            int type2 = b.ReadInt32();
            index = readShortArray(b, size1*3/4);
        }

        private List<float> readFloatArray(BinaryReader b, int length)
        {
            List<float> array = new List<float>();
            for (int i = 0; i < length; i++)
            {
                array.Add(b.ReadSingle());
            }
            return array;
        }

        private List<ushort> readShortArray(BinaryReader b, int length)
        {
            List<ushort> array = new List<ushort>();
            for (int i = 0; i < length; i++)
            {
                array.Add(b.ReadUInt16());
            }

            return array;
        }

        private List<byte> readByteArray(BinaryReader b, int length)
        {
            List<byte> array = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                array.Add(b.ReadByte());
            }

            return array;
        }
    }
}
