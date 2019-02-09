using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ShadowEmu.Common.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using ShadowEmu.Common.GameData.Elements.Test;

namespace ShadowEmu.Common.GameData.Maps
{
    public class MapsManager
    {
        // Methods

        public static Map GetMapFromId(double id)
        {
            string str = ((id % 10).ToString() + "/" + id.ToString() + ".dlm");
            if (MapsManager.D2pFileManager.MapExists(str))
            {
                MemoryStream stream = new MemoryStream(MapsManager.D2pFileManager.ReadFile(str)) { Position = 2 };
                DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                byte[] buffer = new byte[150000];
                MemoryStream destination = new MemoryStream(buffer);
                stream2.CopyTo(destination);
                destination.Position = 0;
                BigEndianReader reader = new BigEndianReader(destination);
                Map map2 = new Map();
                map2.Init(reader);
                return map2;
            }
            return null;
        }

        public static List<Map> ParseAllMaps()
        {
            List<Map> m_maps = new List<Map>();
            foreach (D2PFileDlm D2pFile in MapsManager.D2pFileManager.GetD2pFiles())
            {
                foreach (KeyValuePair<string, int[]> File in D2pFile.GetDictionnary())
                {
                    try
                    {
                        if (MapsManager.D2pFileManager.MapExists(File.Key))
                        {
                            MemoryStream stream = new MemoryStream(MapsManager.D2pFileManager.ReadFile(File.Key)) { Position = 2 };
                            DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                            byte[] buffer = new byte[50001];
                            MemoryStream destination = new MemoryStream(buffer);
                            stream2.CopyTo(destination);
                            destination.Position = 0;
                            BigEndianReader reader = new BigEndianReader(destination);
                            Map map2 = new Map();
                            map2.Init(reader);
                            m_maps.Add(map2);
                        }
                    }
                    catch (Exception ex)
                    {
                    //    Console.WriteLine(ex.InnerException);
                        continue;
                    }
                }
            }
            return m_maps;
        }

        public static void Initialize(string directory)
        {
            MapsManager.D2pFileManager = new D2pFileManager(directory);
            MapsManager.CheckLock = new object();
        }

        // Fields
        private static D2pFileManager D2pFileManager;
        private static object CheckLock;
    }
}
