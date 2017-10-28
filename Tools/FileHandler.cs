using System.IO;
using System.IO.Compression;

namespace Tools
{
    public static class FileHandler
    {
        public static void SaveAddonData (string path, string data)
        {
            byte[] bytes;
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var ms = new MemoryStream())                
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(data);
                    sw.Flush();
                    fs.Position = 0;
                    bytes = ms.ToArray();
                }               

                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public static string LoadAddonData(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var size = (int)fs.Length;
                var data = new byte[size];
                fs.Read(data, 0, size);

                using (var ms = new MemoryStream(data))                
                using (var reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void SaveLocalData(string fileName, string data)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            byte[] bytes;
            using (var fs = new FileStream($"{directory}/{fileName}", FileMode.OpenOrCreate))
            {
                using (var ms = new MemoryStream())
                {
                    using (var compressor = new DeflateStream(ms, CompressionMode.Compress))
                    {
                        using (var sw = new StreamWriter(compressor, System.Text.Encoding.UTF8))
                        {
                            sw.Write(data);
                        }
                        bytes = ms.ToArray();
                    }
                }

                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public static string LoadLocalData(string fileName)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            using (var fs = new FileStream($"{directory}/{fileName}", FileMode.OpenOrCreate))
            {
                var size = (int)fs.Length;
                var data = new byte[size];
                fs.Read(data, 0, size);

                using(var ms = new MemoryStream(data))
                using (var decompressor = new DeflateStream(ms, CompressionMode.Decompress, leaveOpen: true))
                using (var reader = new StreamReader(decompressor))
                {                    
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
