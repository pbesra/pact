using pact.Configs;

namespace pact.Services
{
    public class FileSystemActionServices
    {
        public bool PerformDelete(Dictionary<string, string> args)
        {
            return true;
        }
        public bool DeleteResource(ResourceType resource)
        {
            if (!(Directory.Exists(resource.Path) || File.Exists(resource.Path)))
            {
                Console.WriteLine($"No resource found: {resource.Path}");
                return false;
            }
            return Delete(resource);
        }

        public bool Delete(ResourceType resource)
        {
            var resourceImpl = Utils.Utils.GetResourceType(resource);
            return resourceImpl.Delete(resource);
        }
    }
}