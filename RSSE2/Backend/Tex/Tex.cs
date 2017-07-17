using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.IO;

namespace RSSE2.Backend
{
    public enum TextureFormat { RGBA, DTX1=8, DTX5=6 }
    public class Tex
    {
        public TextureFormat format;
        public int baseWidth;
        public int baseHeight;
        public int mipMapLevel;

        public List<int> width;
        public List<int> height;
        public List<int> size;
        public List<byte[]> data;
        
        public Tex(string filename)
        {
            BinaryReader b = new BinaryReader(File.Open(filename, FileMode.Open));

            // Header
            b.ReadBytes(8);
            format = (TextureFormat)b.ReadInt32();
            b.ReadBytes(4);
            baseWidth = b.ReadInt32();
            baseHeight = b.ReadInt32();
            b.ReadBytes(24);
            mipMapLevel = b.ReadInt32();

            width = new List<int>(mipMapLevel);
            height = new List<int>(mipMapLevel);
            size = new List<int>(mipMapLevel);
            data = new List<byte[]>(mipMapLevel);

            // levels
            for (int lvl = 0; lvl < mipMapLevel; lvl++)
            {
                width.Add(b.ReadInt32());
                height.Add(b.ReadInt32());
                size.Add(b.ReadInt32());
                data.Add(b.ReadBytes(size[lvl]));
            }
            b.Dispose();
        }
    }
}
