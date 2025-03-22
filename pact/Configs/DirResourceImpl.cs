using Microsoft.VisualBasic.FileIO;

namespace pact.Configs
{
    public class DirResourceImpl : IResource
    {
        public bool Delete(ResourceType resourceType)
        {
            try
            {
                if (resourceType.Permanent)
                {
                    Directory.Delete(resourceType.Path, true);
                    Console.WriteLine("Directory deleted permanently.");
                    return true;
                }
                FileSystem.DeleteDirectory(resourceType.Path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                Console.WriteLine("Directory deleted and sent to recycle bin.");
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