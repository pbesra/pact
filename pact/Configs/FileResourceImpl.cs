using Microsoft.VisualBasic.FileIO;

namespace pact.Configs
{
    public class FileResourceImpl : IResource
    {
        public bool Delete(ResourceType resourceType)
        {
            try
            {
                if (resourceType.Permanent)
                {
                    File.Delete(resourceType.Path);
                    Console.WriteLine("File deleted permanently.");
                    return true;
                }
                FileSystem.DeleteFile(resourceType.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                Console.WriteLine("File deleted and sent to recycle bin.");
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}