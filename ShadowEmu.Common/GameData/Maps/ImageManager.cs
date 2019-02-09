using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ShadowEmu.Common.GameData.Maps
{
    public class ImageManager
    {
        private static FileStream mystream { get; set; }
        private static string mDofusPath { get; set; }

        public static Dictionary<string, Dictionary<string, int[]>> DictionnaryItemGFX = new Dictionary<string, Dictionary<string, int[]>>();
        public static Dictionary<string, Dictionary<string, int[]>> DictionnaryMonsterGFX = new Dictionary<string, Dictionary<string, int[]>>();
        public static Dictionary<string, Dictionary<string, int[]>> DictionnaryWorldGFX = new Dictionary<string, Dictionary<string, int[]>>();
        public static void Init(string DofusPath)
        {
            mDofusPath = DofusPath;
            foreach (string Directorie in Directory.GetDirectories(mDofusPath))
            {
                Dictionary<string, int[]> test = new Dictionary<string, int[]>();
                foreach (string File in Directory.GetFiles(Directorie))
                {
                    if (!File.Contains("vector"))
                    {
                        mystream = new FileStream(File, FileMode.Open, FileAccess.Read);
                        byte num = Convert.ToByte(mystream.ReadByte() + mystream.ReadByte());
                        if (num == 3)
                        {
                            mystream.Position = mystream.Length - 0x18L;
                            int num2 = Convert.ToInt32(readUInt());
                            readUInt();
                            int num3 = Convert.ToInt32(readUInt());
                            int num4 = Convert.ToInt32(readUInt());
                            int num1 = Convert.ToInt32(readUInt());
                            int num10 = Convert.ToInt32(readUInt());
                            mystream.Position = num3;
                            int num5 = num4;
                            for (int i = 1; i <= num5; i++)
                            {
                                string key = readString();
                                int num7 = (int)(readUInt() + num2);
                                int num8 = (int)(readUInt());
                                test.Add(key, new int[] {
                                        num7,
                                        num8
                                    });
                            }
                        }
                        mystream.Close();
                    }
 
                        DictionnaryWorldGFX.Add(File, test);
               
                }
            }
        }

        private static short readShort()
        {
            return BitConverter.ToInt16(ImageManager._InverseArray(ImageManager.readBytes(2)), 0);
        }

        private static string readString()
        {
            int LENGTH = ImageManager.readShort();
            byte[] bytes = ImageManager.readBytes(LENGTH);
            return Encoding.UTF8.GetString(bytes);
        }

        private static byte[] readBytes(int LENGTH)
        {
            byte[] destinationArray = new byte[LENGTH];
            for (int i = 0; i <= LENGTH - 1; i++)
            {
                destinationArray[i] = (byte)mystream.ReadByte();
            }
            return destinationArray;
        }

        private static UInt32 readUInt()
        {
            return BitConverter.ToUInt32(ImageManager._InverseArray(ImageManager.readBytes(4)), 0);
        }

        private static byte[] _InverseArray(byte[] source)
        {
            byte[] buffer = new byte[source.Length];
            int i = 0;
            for (i = 0; i <= source.Length - 1; i++)
            {
                buffer[i] = source[((source.Length - 1) - i)];
            }
            return buffer;
        }

        public static Image GetItemIcon(int IconId)
        {
            foreach (KeyValuePair<string, Dictionary<string, int[]>> File in DictionnaryItemGFX)
            {
                try
                {
                    Image GFXItem = null;
                    if (File.Value.ContainsKey(IconId.ToString() + ".png"))
                    {
                        mystream = new FileStream(File.Key, FileMode.Open, FileAccess.Read);
                        int[] numArray = File.Value[IconId.ToString() + ".png"];
                        mystream.Position = numArray[0];
                        byte[] buffer = readBytes(numArray[1]);
                        MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                        mystream.Close();
                        GFXItem = Image.FromStream(stream);
                        return GFXItem;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult != -2147024809)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return null;
        }

        public static Image GetMonsterIcon(int IconId)
        {
            foreach (KeyValuePair<string, Dictionary<string, int[]>> File in DictionnaryMonsterGFX)
            {
                try
                {
                    Image GFXItem = null;
                    if (File.Value.ContainsKey(IconId.ToString() + ".png"))
                    {
                        mystream = new FileStream(File.Key, FileMode.Open, FileAccess.Read);
                        int[] numArray = File.Value[IconId.ToString() + ".png"];
                        mystream.Position = numArray[0];
                        byte[] buffer = readBytes(numArray[1]);
                        MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                        mystream.Close();
                        GFXItem = Image.FromStream(stream);
                        return GFXItem;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult != -2147024809)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return null;
        }

        public static Image GetWorldIcon(int IconId)
        {
            foreach (KeyValuePair<string, Dictionary<string, int[]>> File in DictionnaryWorldGFX)
            {
                try
                {
                    Image GFXItem = null;
                   
                    if (File.Value.Keys.Any(x=> x.Split('/').Last() ==  IconId.ToString() + ".png"))
                    {
                        var test = File.Value.Keys.First(x => x.Split('/').Last() == IconId.ToString() + ".png");
                        mystream = new FileStream(File.Key, FileMode.Open, FileAccess.Read);


                        int[] numArray = File.Value[test];
                        mystream.Position = numArray[0];
                        byte[] buffer = readBytes(numArray[1]);
                        MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                        mystream.Close();
                        GFXItem = Image.FromStream(stream);
                        return GFXItem;
                    }
                    if (File.Value.Keys.Any(x => x.Split('/').Last() == IconId.ToString() + ".jpg"))
                    {
                        var test = File.Value.Keys.First(x => x.Split('/').Last() == IconId.ToString() + ".jpg");
                        mystream = new FileStream(File.Key, FileMode.Open, FileAccess.Read);
                        int[] numArray = File.Value[test];
                        mystream.Position = numArray[0];
                        byte[] buffer = readBytes(numArray[1]);
                        MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                        mystream.Close();
                        GFXItem = Image.FromStream(stream);
                        return GFXItem;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult != -2147024809)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return null;
        }
    }
}
