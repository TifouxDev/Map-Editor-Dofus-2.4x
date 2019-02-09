using DesignEditeurMap.Elements;
using DesignEditeurMap.Extension;
using SFML.Graphics;
using ShadowEmu.Common.GameData.Elements.Test;
using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Manager
{
    public class TextureManager : DataManager<TextureManager>
    {
        private Dictionary<int, Texture> m_textures;
        private EleReader ele = null;

        public EleInstance instance = null;

        public List<Tile> m_tiles;

        public TextureManager()
        {
            m_textures = new Dictionary<int, Texture>();
            ele = new EleReader(AppDomain.CurrentDomain.BaseDirectory + @"data\maps\elements.ele");
            instance = ele.ReadElements();

            Init();
        }

        public void Init()
        {
            //E:\Map Editor Britana\DesignEditeurMap\DesignEditeurMap\bin\Debug
            BigEndianReader reader = new BigEndianReader(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + @"data\maps\Test.data"));
            List <Tile> test = new List<Tile>();
            while (reader.BytesAvailable != 0)
            {
                var zoneName = reader.ReadUTF();
              //  var subAreaId = reader.ReadInt();
                Tile tile = new Tile() { Name = zoneName };
                test.Add(tile);
                var solsCount = reader.ReadInt();
                for(int i = 0;i < solsCount;i++)
                {
                    var t = reader.ReadInt();
                    tile.Sols.Add(t);
                }
                 


                var objsCount = reader.ReadInt();
                for (int i = 0; i < objsCount; i++)
                {
                    var t = reader.ReadInt();
                    tile.Objects.Add(t);
                }
                 
            }
            m_tiles = test;
        }

        public Texture GetImageGfx(int gfx)
        {
        //    gfx = 655450;
            int step = 0;
            start:
            try
            {
                if (!m_textures.ContainsKey(gfx))
                {
                    if (File.Exists(Configuration.Configuration.Instance.TexturePath + gfx + ".png"))
                    {
                        Texture texture = new Texture(Configuration.Configuration.Instance.TexturePath + gfx + ".png");
                        m_textures.Add(gfx, texture);
                    }
                    else if (File.Exists(Configuration.Configuration.Instance.TexturePath + gfx + ".jpg"))
                    {
                        Texture texture = new Texture(  Configuration.Configuration.Instance.TexturePath + gfx + ".jpg");
                        m_textures.Add(gfx, texture);
                    }
                    else
                        return null;

                }
                else
                {
                    return m_textures[gfx];
                }
            }
            catch(Exception e)
            {

                if(step == 0)
                {
                    if (File.Exists(Configuration.Configuration.Instance.TexturePath + +gfx + ".png"))
                    {
                        var buffer = File.ReadAllBytes(Configuration.Configuration.Instance.TexturePath + gfx + ".png");
                        System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(buffer));
                        File.Delete(Configuration.Configuration.Instance.TexturePath + gfx + ".png");
                        img.Save(Configuration.Configuration.Instance.TexturePath + gfx + ".png");
                        step++;
                        goto start;
                    }
                    else if (File.Exists(Configuration.Configuration.Instance.TexturePath + gfx + ".jpg"))
                    {
                        var buffer = File.ReadAllBytes(Configuration.Configuration.Instance.TexturePath + gfx + ".jpg");
                        System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(buffer));
                        File.Delete(Configuration.Configuration.Instance.TexturePath + gfx + ".jpg");
                        img.Save(Configuration.Configuration.Instance.TexturePath + gfx + ".jpg");
                        step++;
                        goto start;
                    }
                 
                }else
                    return null;
            }

            return (Texture)m_textures[gfx];
        }

        public EleGraphicalData GetElementData(int elementID)
        {
        return    instance.GraphicalDatas.Values.FirstOrDefault(x => x.Id == elementID);
         //         var graphicElement = (NormalGraphicalElementData)instance.GraphicalDatas.Values.Where(x => x is NormalGraphicalElementData).FirstOrDefault(x => ((NormalGraphicalElementData)x).Id == elementID);
       //     return graphicElement;
        }

        public NormalGraphicalElementData GetElementDataByGfx(int gfx)
        {
            var graphicElement = (NormalGraphicalElementData)instance.GraphicalDatas.Values.Where(x => x is NormalGraphicalElementData).FirstOrDefault(x => ((NormalGraphicalElementData)x).Gfx == gfx);

            return graphicElement;
        }

        public NormalGraphicalElementData GetRotateElementDataByGfx(int gfx, bool hasSym)
        {
            var array = instance.GraphicalDatas.Values.Where(x => x is NormalGraphicalElementData && ((NormalGraphicalElementData)x).Gfx == gfx && ((NormalGraphicalElementData)x).HorizontalSymmetry == hasSym).ToArray();
            var graphicElement = (NormalGraphicalElementData)instance.GraphicalDatas.Values.Where(x => x is NormalGraphicalElementData).FirstOrDefault(x => ((NormalGraphicalElementData)x).Gfx == gfx && ((NormalGraphicalElementData)x).HorizontalSymmetry== hasSym);

            return graphicElement;
        }

        public List<string> GetAllTilesFolders()
        {
            return m_tiles.Select(x => x.Name).ToList();
        }

        public Tile GetTile(string name)
        {
            return m_tiles.First(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
