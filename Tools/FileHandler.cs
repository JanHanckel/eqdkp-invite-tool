using System.IO;
using System.IO.Compression;

namespace Tools
{
    public static class FileHandler
    {
        private const string _WowAddonPath = @"\Interface\Addons\EqdkpInviteTool\Data\";

        public static void SaveAddonData (string wowPath, string fileName, string data)
        {
            string path = CheckPath(wowPath, fileName);

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

        private static string CheckPath(string wowPath, string fileName)
        {
            var path = Path.Combine($"{wowPath}{_WowAddonPath}", fileName);
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                throw new System.Exception("WoW Addon is missing or WoW-Path ist not right.");
            return path;
        }

        public static string LoadAddonData(string wowPath, string fileName)
        {
            string path = CheckPath(wowPath, fileName);

            using (var fs = new FileStream(path, FileMode.Open))
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
