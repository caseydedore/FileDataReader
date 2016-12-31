
namespace DataReader
{
    public interface IFileReader
    {
        string Load(string path, string fileName);
        void Save(string path, string fileName, string data);
    }
}
