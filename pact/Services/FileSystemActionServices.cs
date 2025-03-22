using pact.Configs;
using pact.Models;

namespace pact.Services
{
    public class FileSystemActionServices
    {
        public async Task<bool> PerformDelete(Dictionary<string, ActionArgDef> args)
        {
            var res = new ResourceType
            {
                Path = $@"{args["-p"].Value?.ToString() ?? args["-path"].Value?.ToString()}",
                Permanent = args.ContainsKey("-pm"),
            };
            return await DeleteResource(res);
        }

        public async Task<bool> DeleteResource(ResourceType resource)
        {
            if (!(Directory.Exists(resource.Path) || File.Exists(resource.Path)))
            {
                Console.WriteLine($"No resource found: {resource.Path}");
                return false;
            }
            return await Delete(resource);
        }

        public async Task<bool> Delete(ResourceType resource)
        {
            var resourceImpl = Utils.Utils.GetResourceType(resource);
            return resourceImpl.Delete(resource);
        }
    }
}