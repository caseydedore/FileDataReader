using System.IO;

namespace DataReader
{
    public class FileReader : IFileReader
    {
        public string Load(string path, string fileName)
        {
            var openFile = File.OpenText(Path.Combine(path, fileName));
            var data = openFile.ReadToEnd();
            openFile.Close();

            return data;
        }

        public void Save(string path, string fileName, string data)
        {
            StreamWriter writer = null;
            var fileInfo = new FileInfo(Path.Combine(path, fileName));
            if (!fileInfo.Exists)
            {
                writer = fileInfo.CreateText();
            }
            else
            {
                fileInfo.Delete();
                writer = fileInfo.CreateText();
            }
            writer.Write(data);
            writer.Close();
        }
    }
}