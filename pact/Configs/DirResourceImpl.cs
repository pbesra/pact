using Microsoft.VisualBasic.FileIO;

namespace pact.Configs
{
    public class DirResourceImpl : IResource
    {
        public bool Delete(ResourceType resourceType)
        {
            if (resourceType.Permanent)
            {
                Directory.Delete(resourceType.Path, true);
            }
            FileSystem.DeleteDirectory(resourceType.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            return true;
        }
    }
}