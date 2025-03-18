using pact.Configs;

namespace pact.Services
{
    public class FileSystemActionServices
    {
        public async Task<bool> PerformDelete(Dictionary<string, string> args)
        {
            var action = args["action"];
            var actionArgs = ActionConfigs.ActionUnits
                .FirstOrDefault(x => x.Code.Equals(action, StringComparison.OrdinalIgnoreCase))
                ?.ActionArgs;

            // this should be part of validation.
            var isValid = args?.Keys.Where(x => x != "action" && !actionArgs.ContainsKey(x));
            if (isValid != null)
            {
                Console.WriteLine("Wrong command entered");
            }
            var res = new ResourceType
            {
                Path = args["-p"],
                Permanent = args.ContainsKey("-pm")
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