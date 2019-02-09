using ShadowEmu.Common.GameData.D2O;
using ShadowEmu.Common.GameData.Elements.Test;
using ShadowEmu.Common.GameData.Maps;
using ShadowEmu.Common.GameData.Maps.Elements;
using ShadowEmu.Common.IO;
using ShadowEmu.Common.Protocol.Data;
using ShardowEditor.I18n;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadow.Tile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Test> list = new List<Test>();

            MapsManager.Initialize(@"E:\Jeux\Ankama\Dofus\app\content\maps");
            I18nDataManager.Instance.AddReaders(@"E:\Jeux\Ankama\Dofus\app\data\i18n");
            ObjectDataManager.Initialize(@"E:\Jeux\Ankama\Dofus\app\data\common");
            EleReader elementManager = new EleReader(@"E:\Jeux\Ankama\Dofus\app\content\maps\elements.ele");
            var instance = elementManager.ReadElements();
            var maps = MapsManager.ParseAllMaps();

            int i = 0;
            foreach (var map in maps)
            {
                Console.Title = "triages de tiles : " + i.ToString() + @"/" + (maps.Count - 1).ToString();

                var subArea = ObjectDataManager.Get<SubArea>(map.SubAreaId);
                var name = I18nDataManager.Instance.GetText((int)subArea.nameId);

                var area = ObjectDataManager.Get<Area>(subArea.areaId);
                var namel = I18nDataManager.Instance.GetText((int)area.nameId);

                if (!list.Any(x => x.Name == name))
                    list.Add(new Test() { Name = name });

                var zone = list.First(x => x.Name == name);

                for (int j = 0; j <= 1; j++) // sols
                {
                    if (!map.Layers.Any(x => x.LayerId == j))
                        continue;

                    var layer = map.Layers.First(x => x.LayerId == j);

                    foreach (var cell in layer.Cells)
                    {
                        foreach (var element in cell.Elements)
                        {
                            if (element is GraphicalElement) //test
                            {
                                var ele = instance.GraphicalDatas.FirstOrDefault(x => x.Value.Id == (element as GraphicalElement).ElementId).Value as NormalGraphicalElementData;
                                if (ele == null)
                                    continue;
                                if (!zone.Sols.Any(x => x == ele.Gfx))
                                    zone.Sols.Add(ele.Gfx);
                            }
                        }
                    }


                }
                for (int j = 2; j <= 3; j++) // sols
                {
                    if (!map.Layers.Any(x => x.LayerId == j))
                        continue;

                    var layer = map.Layers.First(x => x.LayerId == j);

                    foreach (var cell in layer.Cells)
                    {
                        foreach (var element in cell.Elements)
                        {
                            if (element is GraphicalElement) //test
                            {
                                var ele = instance.GraphicalDatas.FirstOrDefault(x => x.Value.Id == (element as GraphicalElement).ElementId).Value as NormalGraphicalElementData;
                                if (ele == null)
                                    continue;

                                if (!zone.Objects.Any(x => x == ele.Gfx))
                                    zone.Objects.Add(ele.Gfx);
                            }
                        }
                    }


                }
                i++;
            }


            //}
            BigEndianWriter writer = new BigEndianWriter();
            foreach (var zone in list)
            {
                writer.WriteUTF(zone.Name);
                writer.WriteInt(zone.Sols.Count);
                foreach (var tile in zone.Sols)
                    writer.WriteInt(tile);

                writer.WriteInt(zone.Objects.Count);
                foreach (var tile in zone.Objects)
                    writer.WriteInt(tile);
            }


            File.WriteAllBytes("Test.data", writer.Data);


            

        }


        public class Test
        {
            public string Name;
            public List<int> Sols = new List<int>();
            public List<int> Objects = new List<int>();

        }
    }
}
