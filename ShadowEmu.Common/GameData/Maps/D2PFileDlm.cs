using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.GameData.Maps
{
    public class D2PFileDlm
    {
        // Methods
        public D2PFileDlm(string D2pFilePath)
        {
            this.D2pFileStream = new FileStream(D2pFilePath, FileMode.Open, FileAccess.Read);
            this.Reader = new BigEndianReader(this.D2pFileStream);
            this.FilenameDataDictionnary = new Dictionary<string, int[]>();
            this.CheckLock = RuntimeHelpers.GetObjectValue(new object());
            byte num = Convert.ToByte((this.Reader.ReadByte() + this.Reader.ReadByte()));
            if ((num == 3))
            {
                this.D2pFileStream.Position = (this.D2pFileStream.Length - 24);
                int num2 = Convert.ToInt32(this.Reader.ReadUInt32());
                this.Reader.ReadUInt32();
                int num3 = Convert.ToInt32(this.Reader.ReadUInt32());
                int num4 = Convert.ToInt32(this.Reader.ReadUInt32());
                int num1 = Convert.ToInt32(this.Reader.ReadUInt32());
                int num9 = Convert.ToInt32(this.Reader.ReadUInt32());
                this.D2pFileStream.Position = num3;
                int num5 = num4;
                int i = 1;
                while ((i <= num5))
                {
                    string key = this.Reader.ReadString();
                    int num7 = (this.Reader.ReadInt32() + num2);
                    int num8 = this.Reader.ReadInt32();
                    this.FilenameDataDictionnary.Add(key, new int[] {
					num7,
					num8
				});
                    i += 1;
                }
            }
        }

        internal bool ExistsDlm(string DlmName)
        {
            return this.FilenameDataDictionnary.ContainsKey(DlmName);
        }

        public byte[] ReadFile(string fileName)
        {
            lock (this.CheckLock)
            {
                int[] numArray = this.FilenameDataDictionnary[fileName];
                this.D2pFileStream.Position = numArray[0];
                return this.Reader.ReadBytes(numArray[1]);
            }
        }

        public Dictionary<string, int[]> GetDictionnary()
        {
            return FilenameDataDictionnary;
        }


        // Fields
        private Dictionary<string, int[]> FilenameDataDictionnary;
        private BigEndianReader Reader;
        private FileStream D2pFileStream;
        private object CheckLock;
    }
}
