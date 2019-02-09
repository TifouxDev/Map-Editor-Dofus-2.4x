using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zlib;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class ZipHelper
    {
        public static byte[] Compress(byte[] data)
        {
            var input = new MemoryStream(data);
            var output = new MemoryStream();

            Compress(input, output);

            return output.ToArray();
        }

        public static void Compress(Stream input, Stream output)
        {
            using (var compressStream = new GZipStream(output, CompressionMode.Compress))
            {
                input.CopyTo(compressStream);
            }
        }

        public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            int size = (input.CanSeek) ? Math.Min((int)(input.Length - input.Position), 0x2000) : 0x2000;
            //byte[] buffer = new byte[size];
            byte[] buffer = new byte[size];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
            output.Flush();
        }

        public static byte[] Uncompress(byte[] datas)
        {
            using (MemoryStream outMemoryStream = new MemoryStream())
            using (ZOutputStream outZStream = new ZOutputStream(outMemoryStream))
            using (Stream inMemoryStream = new MemoryStream(datas))
            {
                CopyStream(inMemoryStream, outZStream);
                outZStream.finish();
                return outMemoryStream.ToArray();
            }
        }

        public static void Deflate(Stream input, Stream output)
        {
            var zoutput = new ZOutputStream(output);
            var inputReader = new BinaryReader(input);

            zoutput.Write(inputReader.ReadBytes((int)input.Length), 0, (int)input.Length);
            zoutput.Flush();
        }
    }
}
