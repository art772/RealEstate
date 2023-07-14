using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public void WriteAllBytes(string outputFile, byte[] content)
        {
            File.WriteAllBytes(outputFile, content);
        }
    }
}