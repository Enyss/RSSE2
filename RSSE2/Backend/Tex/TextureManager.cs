using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE2.Backend
{
    public class TextureManager
    {
        private Dictionary<string, Tex> textures;
        public Dictionary<string, int> loadedTexture;

        public TextureManager()
        {
            textures = new Dictionary<string, Tex>();
            loadedTexture = new Dictionary<string, int>();
        }

        public void Load(string name)
        {
            if (name == null)
                return;

            if (!textures.ContainsKey(name))
            {
                textures[name] = new Tex(Application.Instance.Settings.RSFolder + name);
            }

            if (!loadedTexture.ContainsKey(name))
            {
                int handle = GL.GenTexture();
                
                loadedTexture[name] = handle;

                GL.BindTexture(TextureTarget.Texture2D, handle);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBaseLevel, 0);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, textures[name].mipMapLevel - 1);

                for (int lvl = 0; lvl < textures[name].mipMapLevel; lvl++)
                {
                    switch (textures[name].format)
                    {
                        case TextureFormat.DTX1:
                            GL.CompressedTexImage2D(TextureTarget.Texture2D, lvl, PixelInternalFormat.CompressedRgbS3tcDxt1Ext,
                                textures[name].width[lvl], textures[name].height[lvl], 0, textures[name].size[lvl], textures[name].data[lvl]);
                            break;
                        case TextureFormat.DTX5:
                            GL.CompressedTexImage2D(TextureTarget.Texture2D, lvl, PixelInternalFormat.CompressedRgbaS3tcDxt5Ext,
                                textures[name].width[lvl], textures[name].height[lvl], 0, textures[name].size[lvl], textures[name].data[lvl]);
                            break;
                        case TextureFormat.DTX5n:
                            GL.CompressedTexImage2D(TextureTarget.Texture2D, lvl, PixelInternalFormat.CompressedRgbaS3tcDxt5Ext,
                                textures[name].width[lvl], textures[name].height[lvl], 0, textures[name].size[lvl], textures[name].data[lvl]);
                            break;
                        default:
                            GL.TexImage2D(TextureTarget.Texture2D, lvl, PixelInternalFormat.Rgba,
                                 textures[name].width[lvl], textures[name].height[lvl], 0, PixelFormat.Rgba, PixelType.UnsignedInt8888, textures[name].data[lvl]);
                            break;
                    }
                }
            }
        }
    }
}
