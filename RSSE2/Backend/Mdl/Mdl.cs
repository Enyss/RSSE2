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
        private List<List<float>> vertex;
        private List<List<float>> normal;
        private List<List<float>> tangent;
        private List<List<float>> binormal;
        private List<List<float>> uv;
        private List<List<ushort>> index;
        private List<List<float>> mdlMatrix;
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

            vertex = new List<List<float>>();
            normal = new List<List<float>>();
            tangent = new List<List<float>>();
            binormal = new List<List<float>>();
            uv = new List<List<float>>();
            index = new List<List<ushort>>();
            mdlMatrix = new List<List<float>>();
            texture = new List<List<byte>>();

            try
            {
                LoadFromFile(Application.Instance.CurrentlyLoaded.Folder + name + ".mdl");
            }
            catch
            {
                VBO = new float[] { };
                Indexes = new ushort[] { };
                return;
            }

            VBO = generateVBO();
            
            Indexes = index[0].ToArray();

            M = new Matrix4(
                mdlMatrix[0][0], mdlMatrix[0][1], mdlMatrix[0][2], mdlMatrix[0][3],
                mdlMatrix[0][4], mdlMatrix[0][5], mdlMatrix[0][6], mdlMatrix[0][7],
                mdlMatrix[0][8], mdlMatrix[0][9], mdlMatrix[0][10], mdlMatrix[0][11],
                mdlMatrix[0][12], mdlMatrix[0][13], mdlMatrix[0][14], mdlMatrix[0][15]);
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
            int size = vertex[0].Count / 3;

            float[] vbo = new float[size * 14];

            for (int i = 0; i < size; i++)
            {
                vbo[14 * i + 0] = vertex[0][3 * i + 0];
                vbo[14 * i + 1] = vertex[0][3 * i + 1];
                vbo[14 * i + 2] = vertex[0][3 * i + 2];
                vbo[14 * i + 3] = normal[0][3 * i + 0];
                vbo[14 * i + 4] = normal[0][3 * i + 1];
                vbo[14 * i + 5] = normal[0][3 * i + 2];
                vbo[14 * i + 6] = binormal[0][3 * i + 0];
                vbo[14 * i + 7] = binormal[0][3 * i + 1];
                vbo[14 * i + 8] = binormal[0][3 * i + 2];
                vbo[14 * i + 9] = tangent[0][3 * i + 0];
                vbo[14 * i + 10] = tangent[0][3 * i + 1];
                vbo[14 * i + 11] = tangent[0][3 * i + 2];
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

            List<float> m = new List<float>();
            for (int i = 0; i < size / 4; i++)
            {
                m.Add(b.ReadSingle());
            }
            mdlMatrix.Add(m);
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
                    vertex.Add(readFloatArray(b, size1 * 3));
                    break;
                case 2:
                    normal.Add(readFloatArray(b, size1 * 3));
                    break;
                case 3:
                    uv.Add(readFloatArray(b, size1 * 2));
                    break;
                case 4:
                    texture.Add(readByteArray(b, size1 * 4));
                    break;
                case 5:
                    tangent.Add(readFloatArray(b, size1 * 3));
                    break;
                case 6:
                    binormal.Add(readFloatArray(b, size1 * 3));
                    break;
            }
        }

        private void ReadIndex(BinaryReader b)
        {
            int size = b.ReadInt32();
            int size1 = b.ReadInt32();
            int type1 = b.ReadInt32();
            int type2 = b.ReadInt32();
            index.Add(readShortArray(b, size/6-6));
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
                array.Add(b.ReadUInt16());
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
