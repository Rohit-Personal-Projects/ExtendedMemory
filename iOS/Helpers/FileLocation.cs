using System;
using System.IO;
using ExtendedMemory.Helpers;
using ExtendedMemory.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileLocation))]
namespace ExtendedMemory.iOS.Helpers
{
    public class FileLocation : IFileLocation
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
