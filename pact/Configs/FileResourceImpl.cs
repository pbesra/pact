using Microsoft.VisualBasic.FileIO;

namespace pact.Configs
{
    public class FileResourceImpl : IResource
    {
        public bool Delete(ResourceType resourceType)
        {
            if (resourceType.Permanent)
            {
                File.Delete(resourceType.Path);
            }
            FileSystem.DeleteDirectory(resourceType.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            return true;
        }
    }
}